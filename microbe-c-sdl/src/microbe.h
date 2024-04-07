#ifndef __MICROBE__H__
#define __MICROBE__H__

/*
    This header file defines the interface for the Microbe Engine, a simple game engine built using SDL and Duktape.
    It provides functions for graphics rendering and input handling.

    Structures:
    - sprite_t: Represents a sprite with its position, tile index, visibility, and flipping properties.
    - input_state_t: Represents the state of various input buttons.

    Functions:
    - initDuktapeGraphics: Initializes the Duktape graphics module.
    - initDuktapeInput: Initializes the Duktape input module.
    - initGraphics: Initializes the SDL graphics system and returns the main window.
    - DrawToScreen: Renders the screen surface to the main window.

    Constants:
    - MAX_TILES: Maximum number of tiles supported.

    Dependencies:
    - SDL2/SDL.h: SDL library header file.
    - duktape.h: Duktape library header file.
*/

#include <SDL2/SDL.h>
#include "duktape.h"

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

typedef struct
{
    int sn;  // sine wave note
    int sv;  // sine wave volume
    int tn;  // triangle wave note
    int tv;  // triangle wave volume
    int nv;  // noise volume
    int sqn; // square wave note
    int sqv; // square wave volume
} sample_segment_t;

typedef unsigned char byte_t;

void initDuktapeGraphics(duk_context *ctx);

void initDuktapeInput(duk_context *ctx);

void initDuktapeAudio(duk_context *ctx);

void evalFile(FILE *file, bool &hasContent);

SDL_Window *initGraphics();

void DrawToScreen(SDL_Surface *screenSurface);

#endif // __MICROBE__H__
