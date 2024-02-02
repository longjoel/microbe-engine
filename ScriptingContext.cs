using Jint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microbe_engine
{
    internal class ScriptingContext
    {
        private Engine _engine;
        private MainForm _form;

        public Queue<Action> CommandQueue { get; set; }

        public ScriptingContext(Engine engine, MainForm form)
        {
            _engine = engine;
            _form = form;
            CommandQueue = new Queue<Action>();
        }

        public void Run()
        {

            _engine.SetValue("set_tile", (int index, byte[] data) =>
            {

                CommandQueue.Enqueue(() =>
                {

                    _form.VRam.TileRam.SetTile((byte)index, data);
                    _form.VRam.CopyToBakedVram();
                });
            });

            _engine.SetValue("set_vram", (int x, int y, int tileId) => {
                _form.VRam.SetVramValue(x, y, (byte)tileId);
            });

            _engine.SetValue("set_scroll", (int x, int y) =>
            {
                _form.ScrollX = (byte)(x % 256);
                _form.ScrollY = (byte)(y % 256);
            });
        }


    }
}
