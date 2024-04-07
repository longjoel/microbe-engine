include ./makefiles/0.mak


# Compiler flags
CFLAGS := -Wall -Wextra -g $(shell sdl2-config --cflags)
CXXFLAGS := $(CFLAGS) -std=c++11

# Linker flags
LDFLAGS := -L C:\dev\w64devkit\lib -L C:\dev\w64devkit\x86_64-w64-mingw32\lib $(shell sdl2-config --libs) -lm  -lSDL2_ttf -lSDL2_mixer -ggdb

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