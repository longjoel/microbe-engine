using Esprima.Ast;
using Jint;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Microbe.Engine
{



    public class CombinedState
    {
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
        CombinedState GetStateFromXInput()
        {

            var g = XInput.Wrapper.X.Gamepad_1;

            return new CombinedState
            {
                a = g.A_down,
                b = g.B_down,
                //start = g.Buttons.Start == XInputDotNetPure.ButtonState.Pressed,
                //select = g.Buttons.Back == XInputDotNetPure.ButtonState.Pressed,
                //down = g.DPad.Down == XInputDotNetPure.ButtonState.Pressed || g.ThumbSticks.Left.Y > 0.25,
                //up = g.DPad.Up == XInputDotNetPure.ButtonState.Pressed || g.ThumbSticks.Left.Y < -0.25,
                //left = g.DPad.Left == XInputDotNetPure.ButtonState.Pressed || g.ThumbSticks.Left.X < -0.25,
                //right = g.DPad.Right == XInputDotNetPure.ButtonState.Pressed || g.ThumbSticks.Left.X > .25,
            };
        }

        public CombinedState KeyboardState { get; protected set; }

        public CombinedState GamepadState
        {
            get
            {
                var gpState = GetStateFromXInput();
                return new CombinedState()
                {
                    a = KeyboardState.a || gpState.a,
                    b = KeyboardState.b || gpState.b,
                    up = KeyboardState.up || gpState.up,
                    down = KeyboardState.down || gpState.down,
                    left = KeyboardState.left || gpState.left,
                    right = KeyboardState.right || gpState.right,
                    start = KeyboardState.start || gpState.start,
                    select = KeyboardState.select || gpState.select,

                };
            }
        }

        private System.Windows.Forms.Timer _tickTimer;
        private Jint.Engine _engine;
        private MicrobeGraphics _graphics;
        private Action<double> _main;


        public MicrobeFormMain(Jint.Engine engine, MicrobeGraphics microbeGraphics)
        {
            XInput.Wrapper.X.StartPolling(XInput.Wrapper.X.Gamepad_1);

            _engine = engine;
            _graphics = microbeGraphics;

            this.DoubleBuffered = true;

            _tickTimer = new System.Windows.Forms.Timer();
            _tickTimer.Interval = (1000 / 60);
            _tickTimer.Tick += _onTick;

            _main = null;
            KeyboardState = new CombinedState();



        }

        protected override void OnClosed(EventArgs e)
        {
            XInput.Wrapper.X.StopPolling();
            base.OnClosed(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    KeyboardState.up = true;
                    break;
                case Keys.Down:
                    KeyboardState.down = true;
                    break;
                case Keys.Left:
                    KeyboardState.left = true;
                    break;
                case Keys.Right:
                    KeyboardState.right = true;
                    break;
                case Keys.Z:
                    KeyboardState.a = true;
                    break;
                case Keys.X:
                    KeyboardState.b = true;
                    break;
                case Keys.Tab:
                    KeyboardState.start = true;
                    break;
                case Keys.Escape:
                    KeyboardState.select = true;
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
                    KeyboardState.up = false;
                    break;
                case Keys.Down:
                    KeyboardState.down = false;
                    break;
                case Keys.Left:
                    KeyboardState.left = false;
                    break;
                case Keys.Right:
                    KeyboardState.right = false;
                    break;
                case Keys.Z:
                    KeyboardState.a = false;
                    break;
                case Keys.X:
                    KeyboardState.b = false;
                    break;
                case Keys.Tab:
                    KeyboardState.start = false;
                    break;
                case Keys.Escape:
                    KeyboardState.select = false;
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

            if (cmdArgs.Length > 1)
            {
                fName = cmdArgs[1];
            }

            _engine.Evaluate(fName == "default.js" ? Properties.Resources._default : File.ReadAllText(fName));

        }

        private void _onTick(object sender, EventArgs e)
        {



            this?._main?.Invoke(1 / 60);

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

        public void Sync()
        {
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