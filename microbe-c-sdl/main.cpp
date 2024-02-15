#include <SDL2/SDL.h>
#include "duktape.h"
#include "microbe.h"

duk_context *ctx;

void cleanDuktape()
{
    duk_destroy_heap(ctx);
}

int main(int argc, char *argv[])
{
    SDL_Init(SDL_INIT_VIDEO | SDL_INIT_TIMER | SDL_INIT_AUDIO);

    SDL_Window *window;
    SDL_Surface *screenSurface;

    ctx = duk_create_heap_default();

    initDuktapeGraphics(ctx);

    window = initGraphics();

    SDL_Event event;

    screenSurface = SDL_GetWindowSurface(window);

    while (true)
    {
        SDL_PollEvent(&event);

        if (event.type == SDL_QUIT)
        {
            break;
        }

        SDL_FillRect(screenSurface, NULL, SDL_MapRGB(screenSurface->format, 255, 128, 255));

        SDL_UpdateWindowSurface(window);
    }

    cleanDuktape();

    return 0;
}
