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

    window = initGraphics();

    initDuktapeGraphics(ctx);
    initDuktapeInput(ctx);

       duk_eval_string_noresult(ctx,"setTile(0, [2,2,2,2,2,2,2,2, 2,2,2,2,2,2,2,2, 2,2,2,2,2,2,2,2, 2,2,2,2,2,2,2,2, 2,2,2,2,2,2,2,2, 2,2,2,2,2,2,2,2, 2,2,2,2,2,2,2,2, 2,2,2,2,2,2,2,2]);");

    bool isDone = false;
    while (!isDone)
    {
        SDL_Event event;
        while (SDL_PollEvent(&event))
        {
            if (event.type == SDL_QUIT || event.type == SDL_WINDOWEVENT_CLOSE)
            {
                isDone = true;
                break;
            }
        }

        screenSurface = SDL_GetWindowSurface(window);
        SDL_FillRect(screenSurface, NULL, SDL_MapRGB(screenSurface->format, 128, 128, 255));

        DrawToScreen(screenSurface);

        SDL_UpdateWindowSurface(window);
    }

    cleanDuktape();
    

    return 0;
}
