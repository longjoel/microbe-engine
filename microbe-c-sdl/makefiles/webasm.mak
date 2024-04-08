include ./makefiles/0.mak

TARGET := microbe.html

# Compiler and flags
CC := emcc
CXX := emcc
CFLAGS := -sALLOW_MEMORY_GROWTH=1 -sUSE_SDL_MIXER=2 -sUSE_SDL_TTF=2 -sUSE_SDL=2 -Wall -Wextra -g $(shell sdl2-config --cflags)
CXXFLAGS := $(CFLAGS) -std=c++11
LDFLAGS := $(CXXFLAGS) $(shell sdl2-config --libs) -lm -lSDL2_ttf -lSDL2_mixer -ggdb
# Source files

# Targets
all: $(BIN_DIR)/$(TARGET)

$(BIN_DIR)/$(TARGET): $(OBJ_FILES)
	$(CXX) $^  $(LDFLAGS)  -o $@

$(OBJ_DIR)/%.o: $(SRC_DIR)/%.c
	$(CC) $(CFLAGS) -c $< -o $@

$(OBJ_DIR)/%.o: $(SRC_DIR)/%.cpp
	$(CXX) $(CXXFLAGS) -c $< -o $@

clean:
	rm -rf $(OBJ_DIR)/*.o $(BIN_DIR)/*

.PHONY: all clean