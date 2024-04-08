/**
 * @file main.cpp
 * @brief Entry point of the Microbe Engine application.
 */
#ifdef __EMSCRIPTEN__
#include <emscripten.h>
#endif
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

duk_ret_t setMain(duk_context *ctx)
{

    duk_require_function(ctx, 0);

    duk_dup(ctx, 0);
    duk_put_global_string(ctx, "__MAIN__");

    return 0;
}

bool hasContent = false;
bool isDone = false;

void mainLoop(SDL_Window *window)
{

    SDL_Event event;
    while (SDL_PollEvent(&event))
    {
        if (event.type == SDL_QUIT || event.type == SDL_WINDOWEVENT_CLOSE)
        {
#ifdef __EMSCRIPTEN__
            emscripten_cancel_main_loop(); /* this should "kill" the app. */
#else
            isDone = true;
            break;
#endif
        }

        if (event.type == SDL_DROPFILE)
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

    duk_get_global_string(ctx, "__MAIN__");

    if (duk_is_function(ctx, -1))
    {
        // Call the function with no arguments, and catch any errors
        if (duk_pcall(ctx, 0) != DUK_EXEC_SUCCESS)
        {
            printf("Error: %s\n", duk_safe_to_string(ctx, -1));
        }
    }

    duk_pop(ctx);

    SDL_Delay(16);
}

/**The main of the Microbe Engine application *
 * @param argc The number of command-line arguments.
 * @param  * @brief The main function of the Microbe Engine application.  * t * @param argc T */
int main(int argc, char *argv[])
{
    SDL_Init(SDL_INIT_VIDEO | SDL_INIT_TIMER | SDL_INIT_AUDIO);

    SDL_Window *window;

    ctx = duk_create_heap_default();

    window = initGraphics();

    duk_push_c_function(ctx, setMain, 1); // 1 argument
    duk_put_global_string(ctx, "setMain");

    initDuktapeGraphics(ctx);
    initDuktapeInput(ctx);
    initDuktapeAudio(ctx);

    if (argc > 1)
    {
        FILE *file = fopen("sample.js", "r");
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

    while (!isDone)
    {
        mainLoop(window);
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
