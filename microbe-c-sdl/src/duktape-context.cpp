#include "microbe.h"

DuktapeContext::DuktapeContext(std::shared_ptr<MicrobeRenderer> renderer)
{
    DuktapeContext::renderer = renderer;
    DuktapeContext::ctx = duk_create_heap_default();
    if (DuktapeContext::ctx == NULL)
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
    duk_destroy_heap(DuktapeContext::ctx);
}


duk_ret_t DuktapeContext::duk_setTile(duk_context *ctx)
{
    int index = duk_require_int(ctx, 0);
    byte_t *data = (byte_t *)duk_require_buffer(ctx, 1, NULL);
    DuktapeContext::renderer->setTile(index, data);
    return 0;
}

duk_ret_t DuktapeContext::duk_setVram(duk_context *ctx)
{
    int x = duk_require_int(ctx, 0);
    int y = duk_require_int(ctx, 1);
    byte_t tileIndex = duk_require_int(ctx, 2);
    DuktapeContext::renderer->setVram(x, y, tileIndex);
    return 0;
}

duk_ret_t DuktapeContext::duk_setScroll(duk_context *ctx)
{
    int x = duk_require_int(ctx, 0);
    int y = duk_require_int(ctx, 1);
    DuktapeContext::renderer->setScroll(x, y);
    return 0;
}

duk_ret_t DuktapeContext::duk_setSprite(duk_context *ctx)
{
    int index = duk_require_int(ctx, 0);
int index = duk_require_int(ctx, 0);
    sprite_t *sprite = renderer->getSprite(index);

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

    DuktapeContext::renderer->setSprite(index, sprite);
    return 0;
}

duk_ret_t DuktapeContext::duk_getSprite(duk_context *ctx)
{
    int index = duk_require_int(ctx, 0);
    sprite_t *sprite = DuktapeContext::renderer->getSprite(index);
    duk_push_object(ctx);
    duk_push_int(ctx, sprite->x);
    duk_put_prop_string(ctx, -2, "x");
    duk_push_int(ctx, sprite->y);
    duk_put_prop_string(ctx, -2, "y");
    duk_push_int(ctx, sprite->tileIndex);
    duk_put_prop_string(ctx, -2, "tileIndex");
    duk_push_boolean(ctx, sprite->visible);
    duk_put_prop_string(ctx, -2, "visible");
    duk_push_boolean(ctx, sprite->xFlipped);
    duk_put_prop_string(ctx, -2, "xFlipped");
    duk_push_boolean(ctx, sprite->yFlipped);
    duk_put_prop_string(ctx, -2, "yFlipped");
    return 1;
}

duk_ret_t DuktapeContext::duk_setPalette(duk_context *ctx)
{

    int index = duk_require_int(ctx, 0);
    duk_idx_t obj_idx = duk_push_object(ctx); // Push an empty object onto the stack

    duk_idx_t c1 = duk_push_object(ctx); // Push an empty object onto the stack

SDL_Color *microbe_palette = DuktapeContext::renderer->getPalette(index);

    duk_push_int(ctx, microbe_palette[1].r);
    duk_put_prop_string(ctx, c1, "r");

    duk_push_int(ctx, microbe_palette[1].g);
    duk_put_prop_string(ctx, c1, "g");

    duk_push_int(ctx, microbe_palette[1].b);
    duk_put_prop_string(ctx, c1, "b");

    duk_put_prop_string(ctx, obj_idx, "c1");

    duk_idx_t c2 = duk_push_object(ctx);

    duk_push_int(ctx, microbe_palette[2].r);
    duk_put_prop_string(ctx, c2, "r");

    duk_push_int(ctx, microbe_palette[2].g);
    duk_put_prop_string(ctx, c2, "g");

    duk_push_int(ctx, microbe_palette[2].b);
    duk_put_prop_string(ctx, c2, "b");

    duk_put_prop_string(ctx, obj_idx, "c2");

    duk_idx_t c3 = duk_push_object(ctx);

    duk_push_int(ctx, microbe_palette[3].r);
    duk_put_prop_string(ctx, c3, "r");
    duk_push_int(ctx, microbe_palette[3].g);
    duk_put_prop_string(ctx, c3, "g");
    duk_push_int(ctx, microbe_palette[3].b);
    duk_put_prop_string(ctx, c3, "b");
    duk_put_prop_string(ctx, obj_idx, "c3");

    return 1;
}

duk_ret_t DuktapeContext::duk_getPalette(duk_context *ctx)
{
    int index = duk_require_int(ctx, 0);
    SDL_Color *microbe_palette = DuktapeContext::renderer->getPalette(index);

    duk_push_object(ctx);
    duk_push_object(ctx);
    duk_push_int(ctx, microbe_palette[1].r);
    duk_put_prop_string(ctx, -2, "r");
    duk_push_int(ctx, microbe_palette[1].g);
    duk_put_prop_string(ctx, -2, "g");
    duk_push_int(ctx, microbe_palette[1].b);
    duk_put_prop_string(ctx, -2, "b");
    duk_put_prop_string(ctx, -2, "c1");

    duk_push_object(ctx);
    duk_push_int(ctx, microbe_palette[2].r);
    duk_put_prop_string(ctx, -2, "r");
    duk_push_int(ctx, microbe_palette[2].g);
    duk_put_prop_string(ctx, -2, "g");
    duk_push_int(ctx, microbe_palette[2].b);
    duk_put_prop_string(ctx, -2, "b");
    duk_put_prop_string(ctx, -2, "c2");

    duk_push_object(ctx);
    duk_push_int(ctx, microbe_palette[3].r);
    duk_put_prop_string(ctx, -2, "r");
    duk_push_int(ctx, microbe_palette[3].g);
    duk_put_prop_string(ctx, -2, "g");
    duk_push_int(ctx, microbe_palette[3].b);
    duk_put_prop_string(ctx, -2, "b");
    duk_put_prop_string(ctx, -2, "c3");

    return 1;
}

duk_ret_t DuktapeContext::duk_setChar(duk_context *ctx)
{
    
    int x = duk_require_int(ctx, 0);
    int y = duk_require_int(ctx, 1);
    const char *text = duk_require_string(ctx, 2);
                DuktapeContext::renderer->setChar(x,y,text[0]);
    return 0;
}

duk_ret_t DuktapeContext::duk_setString(duk_context *ctx)
{
    int x = duk_require_int(ctx, 0);
    int y = duk_require_int(ctx, 1);
    const char *text = duk_require_string(ctx, 2);
    DuktapeContext::renderer->setString(x, y, text);
    return 0;
}

void DuktapeContext::bindFunctions()
{

    
}