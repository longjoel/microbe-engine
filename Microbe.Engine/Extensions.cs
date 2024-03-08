using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microbe.Engine
{
    public static class Extensions
    {
        public static void RegisterMicrobeGraphicsScriptObjects(this Jint.Engine engine, MicrobeGraphics graphics)
        {
            engine.SetValue("setTile", new Action<int, double[]>((a, b) => graphics.SetTileData(a, b.Select(x => (byte)x).ToArray())));
            engine.SetValue("setVram", new Action<int, int, int>((a, b, c) => graphics.SetVramData(a, b, (byte)c)));
            engine.SetValue("setScroll", new Action<int, int>((int x, int y) => graphics.ScrollTo((byte)(x % 256), (byte)(y % 255))));
            engine.SetValue("setSprite", new Action<int, Sprite>((a, b) => graphics.SetSprite(a, b)));
            engine.SetValue("getSprite", new Func<int, Sprite>((a) => { return graphics.GetSprite(a); }));
            engine.SetValue("getPalette", new Func<int, TilePalette>((a) => graphics.GetPalette(a)));
            engine.SetValue("setPalette", new Action<int, TilePalette>((a, b) => graphics.SetPalette(a, b)));
            engine.SetValue("setChar", new Action<int, int, char>((a, b, c) => graphics.SetChar(a, b, c)));
            engine.SetValue("setTextColor", new Action<RGB>(rgb => graphics.SetTextColor(rgb)));
            engine.SetValue("setString", new Action<int, int, string>((a, b, c) => graphics.SetString(a, b, c)));
            engine.SetValue("setTilePalette", new Action<int, int>((a, b) => graphics.SetTilePalette(a, b)));
            engine.SetValue("loadGfx", new Action<string>((fileName) => {
                if (File.Exists(fileName)) {
                    graphics.Deserialize(File.ReadAllText(fileName));
                }
            }));
        }

        public static void RegisterEventsToMainWindow(this Jint.Engine engine, MicrobeFormMain mainForm)
        {
            engine.SetValue("setMain", new Action<Action<double>>((Action<double> main) =>
            {
                mainForm.RegisterMain(main);
            }));

            engine.SetValue("getGamepadState", new Func<CombinedState>(() => { return mainForm.GamepadState; }));
            //engine.SetValue("sync", mainForm.Sync);

            engine.SetValue("log", new Action<string>((s) => {
                if (mainForm.DebugConsole != null && mainForm.DebugConsole.Visible)
                {
                    mainForm.DebugConsole.Log(s);
                }
            }));
        }

        public static void RegisterMicrobeAudio(this Jint.Engine engine, MicrobeAudio audio)
        {

            engine.SetValue("setSample", new Action<int, int, SampleSegment[]>((a, b, c) => audio.SetSample(a, b, c)));
            engine.SetValue("playMusic", new Action<int>(a => audio.PlayMusic(a)));
            engine.SetValue("playEffect", new Action<int>(a => audio.PlayEffect(a)));
            engine.SetValue("stopMusic", new Action(() => audio.StopMusic()));

        }

    }
}
