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

SDL_Color palette[256*4];  // 256 entries * 4 colors * 4 bytes for each color.

duk_ret_t setTile(duk_context *ctx){return 1;}
duk_ret_t setVram(duk_context *ctx){return 1;}
duk_ret_t setScroll(duk_context *ctx){return 1;}
duk_ret_t setSprite(duk_context *ctx){return 1;}
duk_ret_t getPalette(duk_context *ctx){return 1;}


duk_context *ctx;

void initDuktape(){

    ctx=duk_create_heap_default();

    duk_push_c_function(ctx, setTile, 2);
    duk_put_global_string(ctx, "setTile");

}

void cleanDuktape(){
    duk_destroy_heap(ctx);
}

int main( int argc, char * argv[] )
{
        SDL_Init( SDL_INIT_VIDEO | SDL_INIT_TIMER |SDL_INIT_AUDIO);

        initDuktape();

        cleanDuktape();



return 0;
}
