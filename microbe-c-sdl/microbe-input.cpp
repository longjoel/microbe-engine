#include "microbe.h"

input_state_t inputState;
SDL_GameController *gameController;

/**
 * Retrieves input from the user.
 *
 * @param ctx The Duktape context.
 * @return The return value.
 */
duk_ret_t getInput(duk_context *ctx)
{

    const Uint8 *state = SDL_GetKeyboardState(NULL);
    SDL_GameControllerUpdate();

    inputState.up = state[SDL_SCANCODE_UP] || SDL_GameControllerGetButton(gameController, SDL_CONTROLLER_BUTTON_DPAD_UP);
    inputState.down = state[SDL_SCANCODE_DOWN] || SDL_GameControllerGetButton(gameController, SDL_CONTROLLER_BUTTON_DPAD_DOWN);
    inputState.left = state[SDL_SCANCODE_LEFT] || SDL_GameControllerGetButton(gameController, SDL_CONTROLLER_BUTTON_DPAD_LEFT);
    inputState.right = state[SDL_SCANCODE_RIGHT] || SDL_GameControllerGetButton(gameController, SDL_CONTROLLER_BUTTON_DPAD_RIGHT);
    inputState.a = state[SDL_SCANCODE_Z] || SDL_GameControllerGetButton(gameController, SDL_CONTROLLER_BUTTON_A);
    inputState.b = state[SDL_SCANCODE_X] || SDL_GameControllerGetButton(gameController, SDL_CONTROLLER_BUTTON_B);
    inputState.start = state[SDL_SCANCODE_RETURN] || SDL_GameControllerGetButton(gameController, SDL_CONTROLLER_BUTTON_START);
    inputState.select = state[SDL_SCANCODE_RSHIFT] || SDL_GameControllerGetButton(gameController, SDL_CONTROLLER_BUTTON_BACK);

    duk_idx_t obj_idx = duk_push_object(ctx); // Push an empty object onto the stack

    duk_push_object(ctx);
    duk_push_boolean(ctx, inputState.up);
    duk_put_prop_string(ctx, obj_idx, "up");
    duk_push_boolean(ctx, inputState.down);
    duk_put_prop_string(ctx, obj_idx, "down");
    duk_push_boolean(ctx, inputState.left);
    duk_put_prop_string(ctx, obj_idx, "left");
    duk_push_boolean(ctx, inputState.right);
    duk_put_prop_string(ctx, obj_idx, "right");
    duk_push_boolean(ctx, inputState.a);
    duk_put_prop_string(ctx, obj_idx, "a");
    duk_push_boolean(ctx, inputState.b);
    duk_put_prop_string(ctx, obj_idx, "b");
    duk_push_boolean(ctx, inputState.start);
    duk_put_prop_string(ctx, obj_idx, "start");
    duk_push_boolean(ctx, inputState.select);
    duk_put_prop_string(ctx, obj_idx, "select");

    duk_pop(ctx);

    return 1;
}

void initDuktapeInput(duk_context *ctx)
{
    gameController = SDL_GameControllerOpen(0);

    duk_push_c_function(ctx, getInput, 0);
    duk_put_global_string(ctx, "getGamepadState");
}

void cleanupDuktapeInput()
{
    SDL_GameControllerClose(gameController);
}