#include "microbe.h"
#include <SDL2/SDL.h>
#include "duktape.h"

SDL_Surface *microbe_tiles_cache[MAX_TILES];
SDL_Surface *microbe_framebuffer_cache;
SDL_Surface *microbe_backBuffer_cache;

SDL_Window *microbe_window;

byte_t microbe_tiles[MAX_TILES][64];
byte_t microbe_vram[32][32];

byte_t microbe_tilePalette[256];

SDL_Color microbe_palette[MAX_TILES][4]; // 256 entries * 4 colors * 4 bytes for each color.

bool microbe_isDirty = false;
int microbe_scrollX = 0;
int microbe_scrollY = 0;

/** begin private methods **/

/** end private methods **/

SDL_Window *initGraphics()
{

    microbe_window = SDL_CreateWindow("microbe", SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED, 640, 480, SDL_WINDOW_RESIZABLE | SDL_WINDOW_SHOWN);

    for (int i = 0; i < MAX_TILES; i++)
    {
        microbe_tilePalette[i] = i;
        microbe_tiles_cache[i] = SDL_CreateRGBSurfaceWithFormat(0, 8, 8, 32, SDL_PIXELFORMAT_RGBA8888);

        microbe_palette[i][0].a = 0;
        microbe_palette[i][0].r = 0;
        microbe_palette[i][0].g = 0;
        microbe_palette[i][0].b = 0;

        microbe_palette[i][1].a = 255;
        microbe_palette[i][1].r = 0;
        microbe_palette[i][1].g = 0;
        microbe_palette[i][1].b = 0;

        microbe_palette[i][2].a = 255;
        microbe_palette[i][2].r = 64;
        microbe_palette[i][2].g = 64;
        microbe_palette[i][2].b = 64;

        microbe_palette[i][3].a = 255;
        microbe_palette[i][3].r = 128;
        microbe_palette[i][3].g = 128;
        microbe_palette[i][3].b = 128;
    }

    microbe_isDirty = true;

    return microbe_window;
}

duk_ret_t setTile(duk_context *ctx)
{

    int index = duk_require_int(ctx, 0);

    if (!duk_is_array(ctx, 1))
    {
        return DUK_RET_TYPE_ERROR;
    }

    if (duk_get_length(ctx, 1) != 64)
    {
        return DUK_ERR_ERROR;
    }

    for (int i = 0; i < 64; i++)
    {
        duk_get_prop_index(ctx, 1, i);
        microbe_tiles[index][i] = duk_get_int(ctx, -1);
        SDL_Color *pixels = ((SDL_Color *)microbe_tiles_cache[index]->pixels);
        memccpy(pixels, &microbe_palette[microbe_tilePalette[i]], 1, sizeof(SDL_Color));
    }

    microbe_isDirty = true;

    return 1;
}
duk_ret_t setVram(duk_context *ctx)
{
    int x = duk_require_int(ctx,0);
    int y = duk_require_int(ctx,1);
    int tileIndex = duk_require_int(ctx,2);

    microbe_vram[y][x] = ((byte_t)tileIndex);

    microbe_isDirty = true;

    return 1;
}

duk_ret_t setScroll(duk_context *ctx)
{
    microbe_scrollX = duk_require_int(ctx,0);
    microbe_scrollY= duk_require_int(ctx,1);

    microbe_isDirty = false;

    return 1;
}
duk_ret_t setSprite(duk_context *ctx)
{
    return 1;
}
duk_ret_t getPalette(duk_context *ctx)
{
    return 1;
}

void initDuktapeGraphics(duk_context *ctx)
{

    duk_push_c_function(ctx, setTile, 2);
    duk_put_global_string(ctx, "setTile");

    duk_push_c_function(ctx, setVram, 3);
    duk_put_global_string(ctx, "setVram");

    duk_push_c_function(ctx, setScroll, 2);
    duk_put_global_string(ctx, "setScroll");

    duk_push_c_function(ctx, setScroll, 2);
    duk_put_global_string(ctx, "setScroll");
}
