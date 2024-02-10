using Esprima.Ast;
using Jint;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Microbe.Engine
{
    
    public static class Extensions
    {
        public static void RegisterMicrobeGraphicsScriptObjects(this Jint.Engine engine, MicrobeGraphics graphics)
        {
            engine.SetValue("setTile", new Action<int,double[]>((a,b)=> graphics.SetTileData(a,b.Select(x=>(byte)x).ToArray())));
            engine.SetValue("setVram", new Action<int,int,int>((a,b,c)=>graphics.SetVramData(a,b,(byte)c)));
            engine.SetValue("setScroll",new Action<int,int>( (int x, int y)=>graphics.ScrollTo((byte)(x%256), (byte)(y%255))));
            engine.SetValue("setSprite", new Action<int,Sprite>((a,b)=>graphics.SetSprite(a,b)));
            engine.SetValue("getSprite", new Func<int,Sprite>((a)=> { return graphics.GetSprite(a); }));
            engine.SetValue("getPalette", new Func<int, TilePalette>((a)=> graphics.GetPalette(a)));
            engine.SetValue("setPalette", new Action<int, TilePalette>((a,b)=>graphics.SetPalette(a,b)));
            engine.SetValue("setChar", new Action<int,int,char>((a,b,c)=>graphics.SetChar(a,b,c)));
            engine.SetValue("setTextColor", new Action<RGB>(rgb=>graphics.SetTextColor(rgb)));
            engine.SetValue("setString", new Action<int,int,string>((a,b,c)=>graphics.SetString(a,b,c)));
            engine.SetValue("setTilePalette", new Action<int, int>((a,b)=>graphics.SetTilePalette(a,b)));
        }

        public static void RegisterEventsToMainWindow(this Jint.Engine engine, MicrobeFormMain mainForm)
        {
            engine.SetValue("setMain", new Action<Action<double>>((Action<double> main) =>
            {
                mainForm.RegisterMain(main);
            }));

            engine.SetValue("getGamepadState", new Func<GamePadState>( () => { return mainForm.GamepadState; }));
            //engine.SetValue("sync", mainForm.Sync);
        }

        public static void RegisterMicrobeAudio(this Jint.Engine engine, MicrobeAudio audio) {

            engine.SetValue("setSample", new Action<int,int,SampleSegment[]> ((a,b,c)=>audio.SetSample(a,b,c)));
            engine.SetValue("playMusic", new Action<int>(a=> audio.PlayMusic(a)));
            engine.SetValue("playEffect", new Action<int>(a=>audio.PlayEffect(a)));
            engine.SetValue("stopMusic", new Action(()=>audio.StopMusic()));

        }

    }

    public class GamePadState {
        public bool up;
        public bool down;
        public bool left;
        public bool right;
        public bool a;
        public bool b;
        public bool start;
        public bool select;
    }

    public class MicrobeFormMain : Form
    {
        public GamePadState GamepadState { get; protected set; }

        private System.Windows.Forms.Timer _tickTimer;
        private Jint.Engine _engine;
        private MicrobeGraphics _graphics;
        private Action<double> _main;

        XInput.Wrapper.X.Gamepad _gamePad;

        public MicrobeFormMain(Jint.Engine engine, MicrobeGraphics microbeGraphics)
        {

            _engine = engine;
            _graphics = microbeGraphics;
            _gamePad = XInput.Wrapper.X.Gamepad_1;

            this.DoubleBuffered = true;

            _tickTimer = new System.Windows.Forms.Timer();
            _tickTimer.Interval = (1000 / 60);
            _tickTimer.Tick += _onTick;

            _main = null;
            GamepadState = new GamePadState();

            /*if (_gamePad != null)
            {

                _gamePad.KeyDown += (s, e) =>
                {
                    if (_gamePad.Dpad_Up_down) {
                        GamepadState.up = true;
                    }
                    if (_gamePad.Dpad_Down_down)
                    {
                        GamepadState.down = true;
                    }
                    if (_gamePad.Dpad_Left_down)
                    {
                        GamepadState.left = true;
                    }
                    if (_gamePad.Dpad_Right_down)
                    {
                        GamepadState.right = true;
                    }
                    if (_gamePad.A_down)
                    {
                        GamepadState.a = true;
                    }
                    if (_gamePad.B_down)
                    {
                        GamepadState.b = true;
                    }
                    if (_gamePad.Start_down)
                    {
                        GamepadState.start = true;
                    }
                    if (_gamePad.Back_down)
                    {
                        GamepadState.select = true;
                    }

                    
                };

               
            }*/

        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode) {
                case Keys.Up:
                    GamepadState.up = true;
                    break;
                case Keys.Down:
                    GamepadState.down = true;
                    break;
                case Keys.Left:
                    GamepadState.left = true;
                    break;
                case Keys.Right:
                    GamepadState.right = true;
                    break;
                case Keys.Z:
                    GamepadState.a = true;
                    break;
                case Keys.X:
                    GamepadState.b = true;
                    break;
                case Keys.Tab:
                    GamepadState.start = true;
                    break;
                case Keys.Escape:
                    GamepadState.select = true;
                    break;

                default:
                    break;
            }
            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Up:
                    GamepadState.up = false;
                    break;
                case Keys.Down:
                    GamepadState.down = false;
                    break;
                case Keys.Left:
                    GamepadState.left = false;
                    break;
                case Keys.Right:
                    GamepadState.right = false;
                    break;
                case Keys.Z:
                    GamepadState.a = false;
                    break;
                case Keys.X:
                    GamepadState.b = false;
                    break;
                case Keys.Tab:
                    GamepadState.start = false;
                    break;
                case Keys.Escape:
                    GamepadState.select = false;
                    break;

                default:
                    break;
            }
            base.OnKeyUp(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            Width = 640;
            Height = 480;
            _tickTimer.Start();
            var cmdArgs = Environment.GetCommandLineArgs();
            var fName = "default.js";

            if (cmdArgs.Length > 1) {
                fName = cmdArgs[1];
            }

            _engine.Evaluate(fName=="default.js" ? Properties.Resources._default : File.ReadAllText( fName));

        }

        private void _onTick(object sender, EventArgs e)
        {
            _gamePad?.Update();

            this?._main?.Invoke(1/60);

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            _graphics.PaintToWindow(e);
            base.OnPaint(e);
        }

        public void RegisterMain(Action<double> main)
        {
            _main = main;
            
        }

        public void Sync() {
            Application.DoEvents();
            Invalidate();
        }
    }

    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();

            var engine = new Jint.Engine();

            var graphics = new MicrobeGraphics();
            var microbeAudio = new MicrobeAudio();
            var frmMain = new MicrobeFormMain(engine, graphics);

            engine.RegisterMicrobeGraphicsScriptObjects(graphics);
            engine.RegisterEventsToMainWindow(frmMain);
            engine.RegisterMicrobeAudio(microbeAudio);

            Application.Run(frmMain);
        }
    }
}