using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Microbe.Engine
{
    public class Sprite
    {
        public int x;
        public int y;
        public byte tileIndex;
        public bool visible;
        public bool xFlipped;
        public bool yFlipped;
        public bool background;

    }

    public class RGB
    {
        public byte r;
        public byte g;
        public byte b;

        public Color ToColor() { return Color.FromArgb(255, r, g, b); }
    }
    public class TilePalette
    {
        public RGB c1;
        public RGB c2;
        public RGB c3;

        public TilePalette()
        {
            c1 = new RGB { r = 0, b = 0, g = 0 };
            c2 = new RGB { r = 128, b = 128, g = 128 };
            c3 = new RGB { r = 255, b = 255, g = 255 };
        }
    }

    public class MicrobeGraphics
    {
        private char[] _textBuffer;
        private Bitmap _textBufferCache;
        private Color _textColor;

        private TilePalette[] _tileColors;

        private Bitmap[] _tileDataCache;
        private Bitmap _vramCache;

        private Bitmap _framebufferCache;

        private List<byte[]> _tileData;
        private byte[] _vram;

        private Sprite[] _sprites;

        byte _scrollX;
        byte _scrollY;



        static Rectangle BestFit(Rectangle source, Rectangle target)
        {
            double scale = Math.Min(target.Width / (double)source.Width, target.Height / (double)source.Height);

            int adjustedWidth = (int)(source.Width * scale);
            int adjustedHeight = (int)(source.Height * scale);

            int x = target.X + (target.Width - adjustedWidth) / 2;
            int y = target.Y + (target.Height - adjustedHeight) / 2;

            return new Rectangle(x, y, adjustedWidth, adjustedHeight);
        }


        private void CopyTileToCache(int i)
        {

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    _tileDataCache[i].SetPixel(x, y, _tileData[i][y * 8 + x] switch
                    {
                        0 => Color.Transparent,
                        1 => _tileColors[i].c1.ToColor(),
                        2 => _tileColors[i].c2.ToColor(),
                        3 => _tileColors[i].c3.ToColor(),
                        _ => Color.Red
                    });
                }
            }
        }



        private void CopyVramToCache()
        {

            using (var g = Graphics.FromImage(_vramCache))
            {
                g.Clear(Color.Transparent);
                for (int y = 0; y < 32; y++)
                {
                    for (int x = 0; x < 32; x++)
                    {
                        g.DrawImage(_tileDataCache[_vram[y * 32 + x]], x * 8, y * 8);
                    }
                }
            }

        }

        private void CopyFrameBufferToCache()
        {
            using var backSprites = new Bitmap(160, 144);
            using var foreSprites = new Bitmap(160, 144);

            using (var g = Graphics.FromImage(_framebufferCache))
            {
                g.Clear(Color.Transparent);
                FixSpriteAlignment();



                for (int y = -1; y <= 1; y++)
                {
                    for (int x = -1; x <= 1; x++)
                    {
                        foreach (var sprite in _sprites.Where(sprite => sprite.background && sprite.visible))
                        {
                            g.DrawImage(_tileDataCache[sprite.tileIndex], new Rectangle(sprite.x + (x * 160), sprite.y + (y * 144), 8, 8));
                        }


                        g.DrawImage(_vramCache,
                            x * _vramCache.Width + _scrollX,
                            y * _vramCache.Height + _scrollY);

                        foreach (var sprite in _sprites.Where(sprite => !sprite.background && sprite.visible))
                        {
                            g.DrawImage(_tileDataCache[sprite.tileIndex], new Rectangle( sprite.x + (x * 160), sprite.y + (y * 144),8,8));
                        }

                    }
                }



                g.DrawImage(_textBufferCache, 0, 0);
            }
        }

        private void FixSpriteAlignment()
        {
            foreach (var sprite in _sprites)
            {
                if (sprite.x < 0)
                {
                    sprite.x += 160;
                }

                if (sprite.x >= 160)
                {
                    sprite.x -= 160;
                }

                if (sprite.y < 0)
                {
                    sprite.y += 144;
                }

                if (sprite.y >= 144)
                {
                    sprite.y -= 144;
                }
            }
        }

        private void AddFont(PrivateFontCollection pfc, byte[] fontBytes)
        {
            var handle = GCHandle.Alloc(fontBytes, GCHandleType.Pinned);
            IntPtr pointer = handle.AddrOfPinnedObject();
            try
            {
                pfc.AddMemoryFont(pointer, fontBytes.Length);
            }
            finally
            {
                handle.Free();
            }
        }

        private void CopyTextBufferToCache()
        {

            using (var gfx = Graphics.FromImage(_textBufferCache))
            {
                using (var myBrush = new SolidBrush(Color.FromArgb(255, _textColor.R, _textColor.G, _textColor.B)))
                {
                    using (var pfc = new PrivateFontCollection())
                    {
                        
                        AddFont(pfc, Properties.Resources.font);
                        
                        var fam = pfc.Families[0];

                        using (var textFont = new Font(fam, 8, GraphicsUnit.Pixel))
                        {

                            gfx.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;
                            for (int y = 0; y < 18; y++)
                            {

                                for (int x = 0; x < 20; x++)
                                {

                                    gfx.DrawString(_textBuffer[y * 20 + x].ToString(), textFont, myBrush, new Point(x * 8, y * 8));
                                }
                            }
                        };
                    }

                }
            }
        }

        public void SetTextColor(RGB rgb)
        {
            _textColor = Color.FromArgb(255, rgb.r, rgb.g, rgb.b);
            CopyTextBufferToCache();
            CopyFrameBufferToCache();

        }

        public MicrobeGraphics()
        {
            _tileDataCache = new Bitmap[256];
            _tileData = new List<byte[]>();
            _tileColors = new TilePalette[256];

            _textBuffer = new char[20 * 18];
            _textBufferCache = new Bitmap(160, 144);
            _textColor = Color.White;

            _vram = new byte[32 * 32];
            _vramCache = new Bitmap(32 * 8, 32 * 8);

            _framebufferCache = new Bitmap(160, 144);

            _sprites = new Sprite[256];
            for (int i = 0; i < 256; i++)
            {
                _sprites[i] = new Sprite();
            }


            for (int i = 0; i < 256; i++)
            {
                _tileData.Add(new byte[64]);
                _tileDataCache[i] = new Bitmap(8, 8);
                _tileColors[i] = new TilePalette();
                CopyTileToCache(i);
            }

            CopyVramToCache();
            CopyTextBufferToCache();
            CopyFrameBufferToCache();

        }

        public void SetPalette(int index, TilePalette p)
        {
            _tileColors[index] = p;
            CopyTileToCache(index);
            CopyVramToCache();
            CopyFrameBufferToCache();
        }

        public void SetChar(int x, int y, char c)
        {
            _textBuffer[y * 20 + x] = c;
            CopyTextBufferToCache();
            CopyFrameBufferToCache();

        }

        public void SetString(int x, int y, string txt)
        {

            for (int tx = 0; tx < txt.Length; tx++)
            {

                var ftx = tx + x;
                if (ftx < 20)
                {
                    SetChar(tx, y, txt.ToCharArray()[tx]);
                }

            }
        }



        public TilePalette GetPalette(int index) { return _tileColors[index]; }

        public void SetTileData(int tileIndex, byte[] data)
        {
            _tileData[tileIndex] = data;
            CopyTileToCache(tileIndex);

            CopyVramToCache();
            CopyFrameBufferToCache();
        }
        public void SetVramData(int x, int y, byte tileIndex)
        {
            _vram[y * 32 + x] = tileIndex;
            CopyVramToCache();
            CopyFrameBufferToCache();
        }

        public void ScrollTo(byte x, byte y)
        {
            _scrollX = x;
            _scrollY = y;
            CopyFrameBufferToCache();
        }

        public void SetSprite(int spriteId, Sprite sprite)
        {
            _sprites[spriteId] = sprite;
            FixSpriteAlignment();
            CopyFrameBufferToCache();
        }

        public Sprite GetSprite(int spriteId)
        {
            return _sprites[spriteId];
        }

        public void PaintToWindow(PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Black);


            e.Graphics.DrawImage(_framebufferCache,
                BestFit(new Rectangle(0, 0, _framebufferCache.Width, _framebufferCache.Height), e.ClipRectangle),
                new Rectangle(0, 0, 160, 144), GraphicsUnit.Pixel);

        }

    }

}
