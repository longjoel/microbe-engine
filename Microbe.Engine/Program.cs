using Esprima.Ast;
using Jint;
using System.Diagnostics;

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
        }

        public static void RegisterEventsToMainWindow(this Jint.Engine engine, MicrobeFormMain mainForm)
        {
            engine.SetValue("setMain", (Action<double> main) =>
            {
                mainForm.RegisterMain(main);
            });

            engine.SetValue("getGamepadState", () => { return mainForm.GamepadState; });
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

        public MicrobeFormMain(Jint.Engine engine, MicrobeGraphics microbeGraphics)
        {

            _engine = engine;
            _graphics = microbeGraphics;

            this.DoubleBuffered = true;

            _tickTimer = new System.Windows.Forms.Timer();
            _tickTimer.Interval = (1000 / 60);
            _tickTimer.Tick += _onTick;

            _main = null;
            GamepadState = new GamePadState();


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
            _tickTimer.Start();
            _engine.Evaluate(File.ReadAllText("default.js"));
        }

        private void _onTick(object? sender, EventArgs e)
        {
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
            var frmMain = new MicrobeFormMain(engine, graphics);

            engine.RegisterMicrobeGraphicsScriptObjects(graphics);
            engine.RegisterEventsToMainWindow(frmMain);

            Application.Run(frmMain);
        }
    }
}