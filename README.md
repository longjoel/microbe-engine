# microbe-engine

## Links

* [Download](https://github.com/longjoel/microbe-engine/releases/download/v1.0.0-beta/release.zip) -- Download the most recent version of the engine.

* [Reddit](https://www.reddit.com/r/microbe_engine/) -- Post here for support.

* [Github page](https://longjoel.github.io/microbe-engine/) -- API Documentation.

* [Contributing](Contributing.md) -- If you want to lend a hand, read this.

* [Code of Conduct](CodeOfConduct.md) -- Don't be a jerk.

## About

Microbe is a small, compact game engine for making 8-bit styled games in Javascript/Typescript.

## License

Microbe is licensed under GPLv3, please see [LICENSE](LICENSE).

## Details

Microbe is a tile and sprite based engine.

* Microbe supports 256 8x8 tiles, where each tile can be assigned to a palette entry.

* A palette entry supports 4 colors. The first color is always transparent, the other 3 can be user defined as combinations of red, green, and blue values.

* 160x144 internal resolution.

* 32 x 32 tiles of video ram.

* 256 sprites. These sprites can be foreground, or background. At a point they will be able to be flipped along the x axis and y axis.

* Up to 256 samples that can either be played as music or sound effects.

* Supports up, down, left, right, start, select, a and b buttons.

## Debug features in the .net version

* Integrated tile editor allowing editing of tiles while the game is running.

* Importing and exporting tile data in a format that can be loaded by the engine at runtime.

* Integrated video memory viewer. Shows the entire vram and tile map in near real time.

* Sample tracker, supports importing and exporting music files.

## Sample Project

* The distribution package contains a sample typescript project you can use to get started. It has a simple hello world program.

# Future Project Goals

## C++ Port

* Currently in progress and seeking contributors.

* A port from c#/Winforms to C++/SDL2 and DukTape

* The goal for this C++ port is to have a small, portable runtime to allow for easy development on homebrew consoles such as the PS2, PS3, Nintendo Wii, Nintendo Switch, Wii U, Sony PSP, the browser, and more.

## Web port

I have a rough idea to port Microbe to the browser to leverage the debugging capabilities and platform independence. The idea would be to port the development environment to a react based component system with more robust development tools.