#include <exception>
#include <string>
#include <iostream>
#include <SDL2/SDL.h>
#include "duktape.h"

typedef unsigned char byte_t;

SDL_Surface *microbe_tiles_cache[256];
SDL_Surface *microbe_framebuffer_cache;
SDL_Surface *microbe_backBuffer_cache;


byte_t microbe_tiles[256*8];
byte_t microbe_vram[32*32];

byte_t palette[256*4*4];  // 256 entries * 4 colors * 4 bytes for each color.



int main( int argc, char * argv[] )
{
        SDL_Init( SDL_INIT_VIDEO | SDL_INIT_TIMER |SDL_INIT_AUDIO);



return 0;
}
