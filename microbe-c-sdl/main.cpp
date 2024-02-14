#include <exception>
#include <string>
#include <iostream>
#include <SDL2/SDL.h>
#include "duktape.h"

typedef unsigned char byte_t;

SDL_Surface *microbe_tiles_cache[256];
SDL_Surface *microbe_framebuffer_cache;
SDL_Surface *microbe_backBuffer_cache;


byte_t microbe_tiles[256][64];
byte_t microbe_vram[32][32];

SDL_Color palette[256][4];  // 256 entries * 4 colors * 4 bytes for each color.

bool isDirty = false;

duk_ret_t setTile(duk_context *ctx){

    int index = duk_require_int(ctx,0);

    if(!duk_is_array(ctx,1)){
        return DUK_RET_TYPE_ERROR;
    }

    if(duk_get_length(ctx, 1) != 64){
        return DUK_ERR_ERROR;
    }

    for(int i = 0; i < 64;i++){
            duk_get_prop_index(ctx, 1,i);
        microbe_tiles[index][i]=duk_get_int(ctx,-1);
    }

    isDirty = true;

    return 1;
}
duk_ret_t setVram(duk_context *ctx){return 1;}
duk_ret_t setScroll(duk_context *ctx){return 1;}
duk_ret_t setSprite(duk_context *ctx){return 1;}
duk_ret_t getPalette(duk_context *ctx){return 1;}


duk_context *ctx;

void initDuktape(){

    ctx=duk_create_heap_default();

    duk_push_c_function(ctx, setTile, 2);
    duk_put_global_string(ctx, "setTile");

    duk_push_c_function(ctx, setVram, 3);
    duk_put_global_string(ctx, "setVram");

    duk_push_c_function(ctx, setScroll, 2);
    duk_put_global_string(ctx, "setScroll");

    duk_push_c_function(ctx, setScroll, 2);
    duk_put_global_string(ctx, "setScroll");

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
