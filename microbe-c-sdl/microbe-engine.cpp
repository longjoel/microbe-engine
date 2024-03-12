/**
 * @file main.cpp
 * @brief Entry point of the Microbe Engine application.
 */

#include <SDL2/SDL.h>
#include "duktape.h"
#include "microbe.h"

duk_context *ctx; /**< The Duktape context used for JavaScript evaluation. */

/**
 * @brief Cleans up the Duktape context.
 */
void cleanDuktape()
{
    duk_destroy_heap(ctx);
}

/**
 * @brief The main function of the Microbe Engine application.
 * 
 * @param argc The number of command-line arguments.
 * @param argv The command-line arguments.
 * @return The exit status of the application.
 */
int main(int argc, char *argv[])
{
    SDL_Init(SDL_INIT_VIDEO | SDL_INIT_TIMER | SDL_INIT_AUDIO);

    SDL_Window *window;

    ctx = duk_create_heap_default();

    window = initGraphics();

    initDuktapeGraphics(ctx);
    initDuktapeInput(ctx);

    bool hasContent = false;

    if (argc > 1)
    {
        FILE *file = fopen(argv[1], "r");
        evalFile(file, hasContent);
    }

    if (!hasContent)
    {

        duk_eval_string_noresult(ctx, "setString(0,0,\"  *Microbe Engine*\");");
        duk_eval_string_noresult(ctx, "setString(0,1,\"No Game Loaded.\");");
        duk_eval_string_noresult(ctx, "setString(0,3,\"Drag and drop a\");");
        duk_eval_string_noresult(ctx, "setString(0,4,\"game file onto \");");
        duk_eval_string_noresult(ctx, "setString(0,5,\"the window to \");");
        duk_eval_string_noresult(ctx, "setString(0,6,\"load it.\");");
         }

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

            if(event.type == SDL_DROPFILE)
            {
                FILE *file = fopen(event.drop.file, "r");
                evalFile(file, hasContent);
                SDL_free(event.drop.file);
            }
        }

        SDL_Surface *screenSurface = SDL_GetWindowSurface(window);
        SDL_SetSurfaceBlendMode(screenSurface, SDL_BLENDMODE_BLEND);

        SDL_FillRect(screenSurface, NULL, SDL_MapRGB(screenSurface->format, 128, 0, 0));

        DrawToScreen(screenSurface);

        SDL_UpdateWindowSurface(window);

        SDL_Delay(16);
    }

    cleanDuktape();

    return 0;
}

void evalFile(FILE *file, bool &hasContent)
{
    if (file)
    {
        // Read the contents of the file
        fseek(file, 0, SEEK_END);
        long fileSize = ftell(file);
        fseek(file, 0, SEEK_SET);
        char *fileContents = new char[fileSize + 1];
        fread(fileContents, 1, fileSize, file);
        fileContents[fileSize] = '\0';

        // Evaluate the contents of the file in the Duktape context
        duk_eval_string_noresult(ctx, fileContents);

        // Clean up
        delete[] fileContents;
        fclose(file);
        hasContent = true;
    }
}
