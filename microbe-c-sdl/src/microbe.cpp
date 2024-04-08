#include <SDL2/SDL.h>
#include <string>
#include "duk_config.h"
#include "duktape.h"

#include "microbe.h"
#include <memory>

#define TRY_SDL(expr)              \
    if (expr < 0)                  \
    {                              \
        this->AbortReason = #expr; \
        this->isRunning = false;   \
        return;                    \
    }

DuktapeContext::DuktapeContext()
{
    this->ctx = duk_create_heap_default();
    if (this->ctx == NULL)
    {
        printf("Failed to create Duktape heap.\n");
    }
    else
    {
        this->bindFunctions();
    }
}

DuktapeContext::~DuktapeContext()
{
    duk_destroy_heap(this->ctx);
}

void DuktapeContext::bindFunctions()
{
   
}


Microbe::Microbe(std::shared_ptr<DuktapeContext> duktapeContext)
{
    TRY_SDL(SDL_Init(SDL_INIT_VIDEO));
    window = SDL_CreateWindow("Microbe", SDL_WINDOWPOS_UNDEFINED, SDL_WINDOWPOS_UNDEFINED, 640, 480, SDL_WINDOW_SHOWN);
    if (window == NULL)
    {
        this->AbortReason = "Failed to create window.";
        this->isRunning = false;
        return;
    }

    this->duktapeContext = duktapeContext;

    isRunning = true;
}

Microbe::~Microbe()
{

    SDL_DestroyWindow(window);
    SDL_Quit();
}

void Microbe::innerLoop()
{
    SDL_Event event;
    while (SDL_PollEvent(&event))
    {
        if (event.type == SDL_QUIT)
        {
            this->isRunning = false;
        }
    }
    SDL_Surface *screenSurface = SDL_GetWindowSurface(this->window);
    if (screenSurface == NULL)
    {
        this->AbortReason = "Failed to get window surface.";
        this->isRunning = false;
        return;
    }
    TRY_SDL(SDL_SetSurfaceBlendMode(screenSurface, SDL_BLENDMODE_BLEND));
    TRY_SDL(SDL_FillRect(screenSurface, NULL, SDL_MapRGB(screenSurface->format, 128, 0, 0)));
    TRY_SDL(SDL_UpdateWindowSurface(this->window));
}

void Microbe::run()
{

    while (this->isRunning)
    {
        innerLoop();
    }
}

int main(int nArgs, char **args)
{

    std::shared_ptr<DuktapeContext> duktapeContext(new DuktapeContext());
    if(duktapeContext->getContext() == NULL)
    {
        printf("Failed to create Duktape context.\n");
        return 1;
    }

    std::unique_ptr<Microbe> microbe(new Microbe(duktapeContext));
    microbe->run();

    if (microbe->AbortReason != "")
    {
        printf("Error: %s\n", microbe->AbortReason.c_str());
        return 1;
    }

    return 0;
}