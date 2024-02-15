#ifndef __MICROBE__H__
#define __MICROBE__H__

#define     MAX_TILES   256

#include <SDL2/SDL.h>
#include "duktape.h"


/*
    Graphics Functions

*/


typedef unsigned char byte_t;


void initDuktapeGraphics(duk_context *ctx);
SDL_Window *initGraphics();


duk_ret_t setTile(duk_context *ctx);
duk_ret_t setVram(duk_context *ctx);
duk_ret_t setScroll(duk_context *ctx);
duk_ret_t setSprite(duk_context *ctx);
duk_ret_t getPalette(duk_context *ctx);


#endif // __MICROBE__H__
