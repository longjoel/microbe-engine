#ifndef __MICROBE__H__
#define __MICROBE__H__

#define     MAX_TILES   256

#include <SDL2/SDL.h>
#include "duktape.h"


/*
    Graphics Functions

*/

typedef struct {
    int x;
    int y;
    int tileIndex;
    bool visible;
    bool xFlipped;
    bool yFlipped;
    bool background;
} sprite_t;

typedef struct {
bool up;
bool down;
bool left;
bool right;
bool a;
bool b;
bool start;
bool select;
} input_state_t;

typedef unsigned char byte_t;


void initDuktapeGraphics(duk_context *ctx);

void initDuktapeInput(duk_context *ctx);

SDL_Window *initGraphics();

void DrawToScreen(SDL_Surface *screenSurface);

#endif // __MICROBE__H__
