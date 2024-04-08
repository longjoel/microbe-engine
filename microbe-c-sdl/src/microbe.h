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
#include <string>
#include <memory>
#include <SDL2/SDL_ttf.h>

#define MAX_TILES 256

typedef unsigned char byte_t;

typedef struct
{
    byte_t r;
    byte_t g;
    byte_t b;
} rgb_t;

typedef struct
{
    int x;
    int y;
    int tileIndex;
    bool visible;
    bool xFlipped;
    bool yFlipped;
    bool background;
} sprite_t;

typedef struct
{
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

class DuktapeContext
{
public:
    DuktapeContext();
    ~DuktapeContext();

    duk_context *getContext() { return ctx; }

private:
    void bindFunctions();
    duk_context *ctx;
};

class MicrobeRenderer
{
public:
    MicrobeRenderer(SDL_Window *window);
    ~MicrobeRenderer();

    void setTile(int index, byte_t *data);
    void setVram(int x, int y, byte_t tileIndex);
    void setScroll(int x, int y);
    void setSprite(int index, sprite_t *sprite);
    sprite_t *getSprite(int index);
    void setPalette(int index, rgb_t *colors);
    rgb_t *getPalette(int index);
    void setChar(int x, int y, char c);
    void setString(int x, int y, const char *str);

    void UpdateVramCache();
    void UpdateTextCache();

private:
    SDL_Surface *microbe_tiles_cache[MAX_TILES];

    TTF_Font *microbe_font;
    SDL_Color microbe_fontColor = {255, 255, 255, 255};
    char microbe_textBuffer[20 * 18];
    SDL_Surface *microbe_textCache;
    SDL_Surface *microbe_framebufferCache;

    SDL_Window *microbe_window;

    byte_t microbe_tiles[MAX_TILES][64];
    byte_t microbe_vram[32][32];
    SDL_Surface *microbe_vramCache;

    byte_t microbe_tilePalette[256];

    SDL_Color microbe_palette[MAX_TILES][4]; // 256 entries * 4 colors * 4 bytes for each color.

    sprite_t microbe_sprites[256];

    bool microbe_isDirty = true;
    int microbe_scrollX = 0;
    int microbe_scrollY = 0;
};

class Microbe
{
public:
    Microbe(std::shared_ptr<DuktapeContext> duktapeContext);
    ~Microbe();
    void run();
    std::string AbortReason;

private:
    std::shared_ptr<DuktapeContext> duktapeContext;
    SDL_Window *window;
    bool isRunning;
    void innerLoop();
};

void initDuktapeGraphics(duk_context *ctx);

void initDuktapeInput(duk_context *ctx);

void initDuktapeAudio(duk_context *ctx);

void evalFile(FILE *file, bool &hasContent);

SDL_Window *initGraphics();

void DrawToScreen(SDL_Surface *screenSurface);

#endif // __MICROBE__H__
