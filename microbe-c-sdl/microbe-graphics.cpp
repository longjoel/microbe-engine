#include "microbe.h"
#include <SDL2/SDL.h>
#include <SDL2/SDL_ttf.h>
#include "duktape.h"

#define MAX_TILES 256

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

/** begin private methods **/

/** end private methods **/

SDL_Window *initGraphics()
{

    TTF_Init();

    microbe_window = SDL_CreateWindow("microbe", SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED, 640, 480, SDL_WINDOW_RESIZABLE | SDL_WINDOW_SHOWN);
    microbe_vramCache = SDL_CreateRGBSurfaceWithFormat(0, 32 * 8, 32 * 8, 32, SDL_PIXELFORMAT_RGBA8888);
    microbe_textCache = SDL_CreateRGBSurfaceWithFormat(0, 20 * 8, 18 * 8, 32, SDL_PIXELFORMAT_RGBA8888);
    microbe_framebufferCache = SDL_CreateRGBSurfaceWithFormat(0, 160, 144, 32, SDL_PIXELFORMAT_RGBA8888);

    for (int i = 0; i < 256; i++)
    {
        microbe_sprites[i].x = 0;
        microbe_sprites[i].y = 0;
        microbe_sprites[i].background = false;
        microbe_sprites[i].tileIndex = 0;
        microbe_sprites[i].visible = false;
        microbe_sprites[i].xFlipped = false;
        microbe_sprites[i].yFlipped = false;
    }

    microbe_font = TTF_OpenFont("font.ttf", 8);

    if (microbe_font == NULL)
    {

        abort();
    }

    microbe_fontColor = {255, 255, 255, 255};

    for (int i = 0; i < MAX_TILES; i++)
    {
        microbe_tilePalette[i] = i;
        microbe_tiles_cache[i] = SDL_CreateRGBSurfaceWithFormat(0, 8, 8, 32, SDL_PIXELFORMAT_RGBA8888);

        microbe_palette[i][0].a = 255;
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

    SDL_LockSurface(microbe_tiles_cache[index]);
    uint32_t *pixels = (uint32_t *)microbe_tiles_cache[index]->pixels;
    for (int i = 0; i < 64; i++)
    {
        duk_get_prop_index(ctx, 1, i);
        microbe_tiles[index][i] = duk_get_int(ctx, -1);
        duk_pop(ctx);

        auto color = microbe_palette[microbe_tilePalette[index]][microbe_tiles[index][i]];

        pixels[i] = SDL_MapRGBA(microbe_tiles_cache[index]->format, color.r, color.g, color.b, color.a);
    }

    SDL_UnlockSurface(microbe_tiles_cache[index]);

    microbe_isDirty = true;

    return 0;
}
duk_ret_t setVram(duk_context *ctx)
{
    int x = duk_require_int(ctx, 0);
    int y = duk_require_int(ctx, 1);
    int tileIndex = duk_require_int(ctx, 2);

    microbe_vram[y][x] = ((byte_t)tileIndex);

    microbe_isDirty = true;

    return 0;
}

duk_ret_t setScroll(duk_context *ctx)
{
    microbe_scrollX = duk_require_int(ctx, 0);
    microbe_scrollY = duk_require_int(ctx, 1);

    microbe_isDirty = true;

    return 0;
}
duk_ret_t setSprite(duk_context *ctx)
{

    int index = duk_require_int(ctx, 0);
    sprite_t *sprite = &microbe_sprites[index];

    duk_get_prop_string(ctx, 1, "x");
    sprite->x = duk_get_int(ctx, -1);
    duk_pop(ctx);

    duk_get_prop_string(ctx, 1, "y");
    sprite->y = duk_get_int(ctx, -1);
    duk_pop(ctx);

    duk_get_prop_string(ctx, 1, "tileIndex");
    sprite->tileIndex = duk_get_int(ctx, -1);
    duk_pop(ctx);

    duk_get_prop_string(ctx, 1, "visible");
    sprite->visible = duk_get_boolean(ctx, -1);
    duk_pop(ctx);

    duk_get_prop_string(ctx, 1, "xFlipped");
    sprite->xFlipped = duk_get_boolean(ctx, -1);
    duk_pop(ctx);

    duk_get_prop_string(ctx, 1, "yFlipped");
    sprite->yFlipped = duk_get_boolean(ctx, -1);
    duk_pop(ctx);

    return 0;
}

duk_ret_t getSprite(duk_context *ctx)
{
    int index = duk_require_int(ctx, 0);

    sprite_t *sprite = &microbe_sprites[index];

    duk_idx_t obj_idx = duk_push_object(ctx); // Push an empty object onto the stack
    duk_push_int(ctx, sprite->x);             // Set a property named "name"
    duk_put_prop_string(ctx, obj_idx, "x");   // Assign the value

    duk_push_int(ctx, sprite->y);           // Set a property named "name"
    duk_put_prop_string(ctx, obj_idx, "y"); // Assign the value

    duk_push_boolean(ctx, sprite->background);       // Set a property named "name"
    duk_put_prop_string(ctx, obj_idx, "background"); // Assign the value

    duk_push_int(ctx, sprite->tileIndex);           // Set a property named "name"
    duk_put_prop_string(ctx, obj_idx, "tileIndex"); // Assign the value

    duk_push_boolean(ctx, sprite->visible);       // Set a property named "name"
    duk_put_prop_string(ctx, obj_idx, "visible"); // Assign the value

    duk_push_boolean(ctx, sprite->xFlipped);       // Set a property named "name"
    duk_put_prop_string(ctx, obj_idx, "xFlipped"); // Assign the value

    duk_push_boolean(ctx, sprite->yFlipped);       // Set a property named "name"
    duk_put_prop_string(ctx, obj_idx, "yFlipped"); // Assign the value

    duk_pop(ctx); // Pop the object from the stack

    return 1;
}

duk_ret_t getPalette(duk_context *ctx)
{

    int index = duk_require_int(ctx, 0);
    duk_idx_t obj_idx = duk_push_object(ctx); // Push an empty object onto the stack

    duk_idx_t c1 = duk_push_object(ctx); // Push an empty object onto the stack

    duk_push_int(ctx, microbe_palette[index][1].r);
    duk_put_prop_string(ctx, c1, "r");

    duk_push_int(ctx, microbe_palette[index][1].g);
    duk_put_prop_string(ctx, c1, "g");

    duk_push_int(ctx, microbe_palette[index][1].b);
    duk_put_prop_string(ctx, c1, "b");

    duk_put_prop_string(ctx, obj_idx, "c1");

    duk_idx_t c2 = duk_push_object(ctx);

    duk_push_int(ctx, microbe_palette[index][2].r);
    duk_put_prop_string(ctx, c2, "r");

    duk_push_int(ctx, microbe_palette[index][2].g);
    duk_put_prop_string(ctx, c2, "g");

    duk_push_int(ctx, microbe_palette[index][2].b);
    duk_put_prop_string(ctx, c2, "b");

    duk_put_prop_string(ctx, obj_idx, "c2");

    duk_idx_t c3 = duk_push_object(ctx);

    duk_push_int(ctx, microbe_palette[index][3].r);
    duk_put_prop_string(ctx, c3, "r");
    duk_push_int(ctx, microbe_palette[index][3].g);
    duk_put_prop_string(ctx, c3, "g");
    duk_push_int(ctx, microbe_palette[index][3].b);
    duk_put_prop_string(ctx, c3, "b");
    duk_put_prop_string(ctx, obj_idx, "c3");

    return 1;
}

duk_ret_t setPalette(duk_context *ctx)
{
    int index = duk_require_int(ctx, 0);

    duk_require_object(ctx, 1);
    duk_get_prop_string(ctx, -1, "c1");
    duk_get_prop_string(ctx, -1, "r");
    microbe_palette[index][1].r = duk_get_int(ctx, -1);
    duk_pop(ctx);
    duk_get_prop_string(ctx, -1, "g");
    microbe_palette[index][1].g = duk_get_int(ctx, -1);
    duk_pop(ctx);
    duk_get_prop_string(ctx, -1, "b");
    microbe_palette[index][1].b = duk_get_int(ctx, -1);
    duk_pop(ctx);
    duk_pop(ctx);

    duk_get_prop_string(ctx, -1, "c2");
    duk_get_prop_string(ctx, -1, "r");
    microbe_palette[index][2].r = duk_get_int(ctx, -1);
    duk_pop(ctx);
    duk_get_prop_string(ctx, -1, "g");
    microbe_palette[index][2].g = duk_get_int(ctx, -1);
    duk_pop(ctx);
    duk_get_prop_string(ctx, -1, "b");
    microbe_palette[index][2].b = duk_get_int(ctx, -1);
    duk_pop(ctx);
    duk_pop(ctx);

    duk_get_prop_string(ctx, -1, "c3");
    duk_get_prop_string(ctx, -1, "r");
    microbe_palette[index][3].r = duk_get_int(ctx, -1);
    duk_pop(ctx);
    duk_get_prop_string(ctx, -1, "g");
    microbe_palette[index][3].g = duk_get_int(ctx, -1);
    duk_pop(ctx);
    duk_get_prop_string(ctx, -1, "b");
    microbe_palette[index][3].b = duk_get_int(ctx, -1);
    duk_pop(ctx);
    duk_pop(ctx);

    microbe_isDirty = true;

    return 0;
}

duk_ret_t setChar(duk_context *ctx)
{
    int x = duk_require_int(ctx, 0);
    int y = duk_require_int(ctx, 1);
    const char *text = duk_require_string(ctx, 2);

    for (int i = 0; i < strlen(text); i++)
    {
        if (x + i < 20 && y < 18)
        {
            microbe_textBuffer[(y * 20) + x + i] = text[i];
        }
        else
        {
            break;
        }
    }
    return 0;
}

void initDuktapeGraphics(duk_context *ctx)
{

    duk_push_c_function(ctx, setTile, 2);
    duk_put_global_string(ctx, "setTile");

    duk_push_c_function(ctx, setVram, 3);
    duk_put_global_string(ctx, "setVram");

    duk_push_c_function(ctx, setScroll, 2);
    duk_put_global_string(ctx, "setScroll");

    duk_push_c_function(ctx, setSprite, 2);
    duk_put_global_string(ctx, "setSprite");

    duk_push_c_function(ctx, getSprite, 1);
    duk_put_global_string(ctx, "getSprite");

    duk_push_c_function(ctx, getPalette, 1);
    duk_put_global_string(ctx, "getPalette");

    duk_push_c_function(ctx, setPalette, 2);
    duk_put_global_string(ctx, "setPalette");

    duk_push_c_function(ctx, setChar, 3);
    duk_put_global_string(ctx, "setChar");

    duk_push_c_function(ctx, setChar, 3);
    duk_put_global_string(ctx, "setString");
}

void updateVramCache()
{
    SDL_FillRect(microbe_vramCache, NULL, SDL_MapRGBA(microbe_vramCache->format, 0, 0, 0, 255));

    for (int y = 0; y < 32; y++)
    {
        for (int x = 0; x < 32; x++)
        {
            int tileIndex = microbe_vram[y][x];
            SDL_Rect dest;
            dest.x = x * 8;
            dest.y = y * 8;
            dest.w = 8;
            dest.h = 8;

            SDL_BlitSurface(microbe_tiles_cache[tileIndex], NULL, microbe_vramCache, &dest);
        }
    }
}

  void centerRectangle(SDL_Rect *outer, SDL_Rect *inner, SDL_Rect *result)
        {
            int x = outer->w / 2 - inner->w / 2;
            int y = outer->h / 2 - inner->h / 2;

            result ->x = x;
            result ->y = y;
            result ->w = inner->w;
            result ->h = inner->h;

        }


        SDL_Rect bestFit(SDL_Rect *source, SDL_Rect *target, SDL_Rect *result) {
            double scale = floorf(fmin(target->w / (double)source->w, target->h / (double)source->h));

            int adjustedWidth = (int)(source->w * scale);
            int adjustedHeight = (int)(source->h * scale);

            int x = target->x + (target->w - adjustedWidth) / 2;
            int y = target->y + (target->h - adjustedHeight) / 2;

            result->x = x;
            result->y = y;
            result->w = adjustedWidth;
            result->h = adjustedHeight;

            return *result;
        }


void DrawToScreen(SDL_Surface *screenSurface)
{

    if (microbe_isDirty)
    {
        updateVramCache();
    }
    SDL_FillRect(screenSurface, NULL, SDL_MapRGBA(screenSurface->format, 0, 128, 0, 255));
    SDL_FillRect(microbe_framebufferCache, NULL, SDL_MapRGBA(microbe_framebufferCache->format, 0, 0, 128, 255));

    for (int dy = -1; dy <= 1; dy++)
    {

        for (int dx = -1; dx <= 1; dx++)
        {

            for (int i = 0; i < 256; i++)
            {
                sprite_t *sprite = &microbe_sprites[i];
                if (sprite->visible && sprite->background)
                {
                    SDL_Rect dest;
                    dest.x = sprite->x + (dx * 160);
                    dest.y = sprite->y + (dy * 144);
                    dest.w = 8;
                    dest.h = 8;

                    SDL_BlitSurface(microbe_tiles_cache[sprite->tileIndex], NULL, microbe_vramCache, &dest);
                }
            }

            SDL_Rect dest;
            dest.x = (dx * 32 * 8) + microbe_scrollX;
            dest.y = (dy * 32 * 8) + microbe_scrollY;
            dest.w = 32 * 8;
            dest.h = 32 * 8;
            SDL_BlitSurface(microbe_vramCache, NULL, microbe_framebufferCache, &dest);

            for (int i = 0; i < 256; i++)
            {
                sprite_t *sprite = &microbe_sprites[i];
                if (sprite->visible && !sprite->background)
                {
                    SDL_Rect dest;
                    dest.x = sprite->x + (dx * 160);
                    dest.y = sprite->y + (dy * 144);
                    dest.w = 8;
                    dest.h = 8;

                    SDL_BlitSurface(microbe_tiles_cache[sprite->tileIndex], NULL, microbe_vramCache, &dest);
                }
            }
        }

        for (int y = 0; y < 18; y++)
        {
            for (int x = 0; x < 20; x++)
            {
                char c = microbe_textBuffer[(y * 20) + x];
                SDL_Surface *glyph = TTF_RenderGlyph_Solid(microbe_font, c, microbe_fontColor);
                SDL_Rect dest;
                dest.x = x * 8;
                dest.y = y * 8;
                dest.w = 8;
                dest.h = 8;
                SDL_BlitSurface(glyph, NULL, microbe_textCache, &dest);
                SDL_FreeSurface(glyph);
            }
        }

        SDL_BlitScaled(microbe_textCache, NULL, microbe_framebufferCache, NULL);

        SDL_Rect inner = {0, 0, 160, 144};
        SDL_Rect outer = {0,0,screenSurface->w,screenSurface->h}; 
        SDL_Rect destRect ;

        // Get the SDL window size
      

        // Calculate the aspect ratio of the window
        bestFit( &inner, &outer, &destRect);
        
        SDL_BlitScaled(microbe_framebufferCache, &inner, screenSurface, &destRect);
        microbe_isDirty = false;
    }
}
