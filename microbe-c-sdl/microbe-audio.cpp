#include "microbe.h"
#include "SDL2/SDL_mixer.h"
#include "duktape.h"

Mix_Chunk *samples[256];

// Declare the missing function
duk_ret_t playEffect(duk_context *ctx);
duk_ret_t playMusic(duk_context *ctx);
duk_ret_t stopMusic(duk_context *ctx);
duk_ret_t setSample(duk_context *ctx);

void initDuktapeAudio(duk_context *ctx)
{

    // Initialize the audio system
    if (Mix_OpenAudio(44100, MIX_DEFAULT_FORMAT, 1, 2048) < 0)
    {
        printf("SDL_mixer could not initialize! SDL_mixer Error: %s\n", Mix_GetError());
    }

    // Register the audio functions

    duk_push_c_function(ctx, playEffect, 1);
    duk_put_global_string(ctx, "playEffect");
    duk_push_c_function(ctx, playMusic, 1);
    duk_put_global_string(ctx, "playMusic");
    duk_push_c_function(ctx, stopMusic, 0);
    duk_put_global_string(ctx, "stopMusic");
    duk_push_c_function(ctx, setSample, 3);
    duk_put_global_string(ctx, "setSample");
}

duk_ret_t playEffect(duk_context *ctx)
{
    int index = duk_require_int(ctx, 0);
    Mix_PlayChannel(-1, samples[index], 1);
    return 0;
}

duk_ret_t playMusic(duk_context *ctx)
{
    int index = duk_require_int(ctx, 0);
    Mix_PlayChannel(-1, samples[index], -1);
    return 0;
}

duk_ret_t stopMusic(duk_context *ctx)
{
    Mix_HaltChannel(-1);
    return 0;
}

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

Mix_Chunk *createSample(sample_segment_t *segments, int numSegments, int segmentDurrationMs)
{
    for (int i = 0; i < numSegments; i++)
    {
        int segmentSize = segmentDurrationMs * 44.1;
        Uint8 *segment = (Uint8 *)malloc(segmentSize);
        for (int j = 0; j < segmentSize; j++)
        {
            int sampleValue = 0;
            if (segments[i].sn != -1)
            {
                sampleValue += (int)(sin(2 * M_PI * j * segments[i].sn / 44100) * segments[i].sv);
            }
            if (segments[i].tn != -1)
            {
                sampleValue += (int)(sin(2 * M_PI * j * segments[i].tn / 44100) * segments[i].tv);
            }
            if (segments[i].nv != -1)
            {
                sampleValue += (int)(rand() % segments[i].nv);
            }
            if (segments[i].sqn != -1)
            {
                sampleValue += (int)(sin(2 * M_PI * j * segments[i].sqn / 44100) * segments[i].sqv);
            }
            segment[j] = (Uint8)(sampleValue / 4);
        }
        return Mix_QuickLoad_RAW(segment, segmentSize);
        free(segment);
    }}
void duk_require_array(duk_context *ctx, duk_idx_t index) {
    if (!duk_is_array(ctx, index)) {
        duk_type_error(ctx, "expected array");
    }
}
    duk_ret_t setSample(duk_context * ctx){
        int index = duk_require_int(ctx, 0);
        int numSegments = duk_require_int(ctx, 1);
       
        sample_segment_t *segments = (sample_segment_t *)malloc(numSegments * sizeof(sample_segment_t));

        duk_require_array(ctx, 2);

        for (int i = 0; i < numSegments; i++)
        {
            duk_get_prop_index(ctx, 2, i);

            duk_get_prop_string(ctx, -1, "sn");
            segments[i].sn = duk_require_int(ctx, -1);
            duk_pop(ctx);

            duk_get_prop_string(ctx, -1, "sv");
            segments[i].sv = duk_require_int(ctx, -1);
            duk_pop(ctx);

            duk_get_prop_string(ctx, -1, "sqn");
            segments[i].sqn = duk_require_int(ctx, -1);
            duk_pop(ctx);

            duk_get_prop_string(ctx, -1, "sqv");
            segments[i].sqv = duk_require_int(ctx, -1);
            duk_pop(ctx);

            duk_get_prop_string(ctx, -1, "tn");
            segments[i].tn = duk_require_int(ctx, -1);
            duk_pop(ctx);

            duk_get_prop_string(ctx, -1, "tv");
            segments[i].tv = duk_require_int(ctx, -1);
            duk_pop(ctx);

            duk_get_prop_string(ctx, -1, "nv");
            segments[i].nv = duk_require_int(ctx, -1);
            duk_pop(ctx);

            duk_pop(ctx);

            Mix_Chunk *chunk = createSample(&segments[i], 1, 1000);
            samples[index] = chunk;
        }

        free(segments);
        return 0;
    }