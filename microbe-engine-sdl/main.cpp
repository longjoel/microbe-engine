#include <SDL.h>

int main(int nArgs, char** args) {

	SDL_Init(SDL_INIT_VIDEO);

	SDL_Window *window;
	SDL_Renderer *renderer;
	SDL_Event event;

	SDL_CreateWindowAndRenderer(640, 480, SDL_WINDOW_SHOWN, &window, &renderer);

	while (true) {
	
		SDL_PollEvent(&event);
		if (event.type == SDL_QUIT) {
			break;
		}

		SDL_RendererFlip();
	}


	return 0;
}