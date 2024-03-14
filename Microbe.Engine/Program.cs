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
                up = g.Dpad_Up_down || g.LStick.Y < -0.75,
                down = g.Dpad_Down_down || g.LStick.Y > .75,
                left = g.Dpad_Left_down || g.LStick.X < -0.75,
                right = g.Dpad_Right_down || g.LStick.X > .75,
                start = g.Start_down,
                select = g.Back_down
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
        private MicrobeAudio _audio;
        private Action<double> _main;
        public DebugConsoleForm DebugConsole { get; set; }
        public DebugVramForm DebugVram { get; set; }

        public MetaTileEditorForm MetaTileEditor { get; set; }

        public SampleEditorForm SampleEditorForm { get; set; }

        public MicrobeFormMain(Jint.Engine engine, MicrobeGraphics microbeGraphics, MicrobeAudio audio)
        {
            XInput.Wrapper.X.StartPolling(XInput.Wrapper.X.Gamepad_1);

            _engine = engine;
            _graphics = microbeGraphics;
            _audio = audio;

            this.DoubleBuffered = true;

            _tickTimer = new Timer();
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
                case Keys.F12:
                   EnableDebugMenu();
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
            var cmdArgs = Environment.CommandLine.Split(' ');
            var fName = "default.js";

            // first argument is always the name of the executable.
            foreach (var arg in cmdArgs.Skip(1))
            {

                if (arg.Contains('='))
                {
                    var left = arg.Split('=')[0];
                    var right = arg.Split('=')[0];

                    if (left == "")
                    {

                    }
                }

                else if (arg.Contains("--"))
                {
                    if (arg == "--debug")
                    {
                        EnableDebugMenu();
                    }
                }

                else
                {
                    fName = arg;
                }
            }

            _engine.Evaluate(fName == "default.js" ? Properties.Resources._default : File.ReadAllText(fName));

        }

        private void EnableDebugMenu()
        {
            if (Menu == null)
            {
                Menu = new MainMenu();
                var debugMenu = new MenuItem("Debug");
                Menu.MenuItems.Add(debugMenu);
                var vramMenuItem = new MenuItem("VRAM");
                debugMenu.MenuItems.Add(vramMenuItem);
                vramMenuItem.Click += (s, a) =>
                {
                    if (DebugVram == null || DebugVram.IsDisposed)
                    {
                        DebugVram = new DebugVramForm(_graphics);

                    }

                    if (DebugVram.Visible)
                    {
                        DebugVram.Hide();
                    }
                    else
                    {
                        DebugVram.Show();
                    }
                };
                var consoleMenuItem = new MenuItem("Console");
                consoleMenuItem.Click += (s, a) =>
                {
                    if (this.DebugConsole == null || DebugConsole.IsDisposed)
                    {
                        DebugConsole = new DebugConsoleForm(_engine);

                    }

                    if (DebugConsole.Visible)
                    {
                        DebugConsole.Hide();
                    }
                    else
                    {
                        DebugConsole.Show();
                    }
                };
                debugMenu.MenuItems.Add(consoleMenuItem);

                var metaTileEditorMenuItem = new MenuItem("Tile Editor");
                metaTileEditorMenuItem.Click += (s, a) =>
                {
                    if (this.MetaTileEditor == null || MetaTileEditor.IsDisposed)
                    {
                        MetaTileEditor = new MetaTileEditorForm(_graphics);

                    }

                    if (MetaTileEditor.Visible)
                    {
                        MetaTileEditor.Hide();
                    }
                    else
                    {
                        MetaTileEditor.Show();
                    }
                };
                debugMenu.MenuItems.Add(metaTileEditorMenuItem);

                var sampleEditorMenuItem = new MenuItem("Sample Editor");
                sampleEditorMenuItem.Click += (s, a) =>
                {
                    if (this.SampleEditorForm == null || SampleEditorForm.IsDisposed)
                    {
                        SampleEditorForm = new SampleEditorForm(_audio);

                    }

                    if (SampleEditorForm.Visible)
                    {
                        SampleEditorForm.Hide();
                    }
                    else
                    {
                        SampleEditorForm.Show();
                    }
                };
                debugMenu.MenuItems.Add(sampleEditorMenuItem);
            }
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

            var microbeGraphics = new MicrobeGraphics();
            var microbeAudio = new MicrobeAudio();
            var frmMain = new MicrobeFormMain(engine, microbeGraphics, microbeAudio);

            engine.RegisterMicrobeGraphicsScriptObjects(microbeGraphics);
            engine.RegisterEventsToMainWindow(frmMain);
            engine.RegisterMicrobeAudio(microbeAudio);

            Application.Run(frmMain);
        }
    }
}