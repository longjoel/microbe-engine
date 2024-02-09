using Esprima.Ast;
using Jint;
using System.Diagnostics;
using XInputium;
using XInputium.XInput;

namespace Microbe.Engine
{
    
    public static class Extensions
    {
        public static void RegisterMicrobeGraphicsScriptObjects(this Jint.Engine engine, MicrobeGraphics graphics)
        {
            engine.SetValue("setTile", graphics.SetTileData);
            engine.SetValue("setVram", graphics.SetVramData);
            engine.SetValue("setScroll", (int x, int y)=>graphics.ScrollTo((byte)(x%256), (byte)(y%255)));
            engine.SetValue("setSprite", graphics.SetSprite);
            engine.SetValue("getSprite", graphics.GetSprite);
            engine.SetValue("getPalette", graphics.GetPalette);
            engine.SetValue("setPalette", graphics.SetPalette);
            engine.SetValue("setChar", graphics.SetChar);
            engine.SetValue("setTextColor", graphics.SetTextColor);
            engine.SetValue("setString", graphics.SetString);
            engine.SetValue("setTilePalette", graphics.SetTilePalette);
        }

        public static void RegisterEventsToMainWindow(this Jint.Engine engine, MicrobeFormMain mainForm)
        {
            engine.SetValue("setMain", (Action<double> main) =>
            {
                mainForm.RegisterMain(main);
            });

            engine.SetValue("getGamepadState", () => { return mainForm.GamepadState; });
            engine.SetValue("sync", mainForm.Sync);
        }

        public static void RegisterMicrobeAudio(this Jint.Engine engine, MicrobeAudio audio) {

            engine.SetValue("setSample", audio.SetSample);
            engine.SetValue("playMusic", audio.PlayMusic);
            engine.SetValue("playEffect", audio.PlayEffect);
            engine.SetValue("stopMusic", audio.StopMusic);

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
        private Action<double>? _main;

        XGamepad? _gamePad;

        public MicrobeFormMain(Jint.Engine engine, MicrobeGraphics microbeGraphics)
        {

            _engine = engine;
            _graphics = microbeGraphics;
            _gamePad = new XGamepad();

            this.DoubleBuffered = true;

            _tickTimer = new System.Windows.Forms.Timer();
            _tickTimer.Interval = (1000 / 60);
            _tickTimer.Tick += _onTick;

            _main = null;
            GamepadState = new GamePadState();

            if (_gamePad != null)
            {

                _gamePad.ButtonPressed += (s, e) =>
                {
                    switch (e.Button.Button)
                    {
                        case XButtons.DPadUp:
                            GamepadState.up = true;
                            break;
                        case XButtons.DPadDown:
                            GamepadState.down = true;
                            break;
                        case XButtons.DPadLeft:
                            GamepadState.left = true;
                            break;
                        case XButtons.DPadRight:
                            GamepadState.right = true;
                            break;
                        case XButtons.A:
                            GamepadState.a = true;
                            break;
                        case XButtons.B:
                            GamepadState.b = true;
                            break;
                        case XButtons.Start:
                            GamepadState.start = true;
                            break;
                        case XButtons.Back:
                            GamepadState.select = true;
                            break;

                        default:
                            break;
                    }
                };

                _gamePad.ButtonReleased += (s, e) =>
                {
                    switch (e.Button.Button)
                    {
                        case XButtons.DPadUp:
                            GamepadState.up = false;
                            break;
                        case XButtons.DPadDown:
                            GamepadState.down = false;
                            break;
                        case XButtons.DPadLeft:
                            GamepadState.left = false;
                            break;
                        case XButtons.DPadRight:
                            GamepadState.right = false;
                            break;
                        case XButtons.A:
                            GamepadState.a = false;
                            break;
                        case XButtons.B:
                            GamepadState.b = false;
                            break;
                        case XButtons.Start:
                            GamepadState.start = false;
                            break;
                        case XButtons.Back:
                            GamepadState.select = false;
                            break;

                        default:
                            break;
                    }
                };
            }

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

        private void _onTick(object? sender, EventArgs e)
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
            ApplicationConfiguration.Initialize();

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