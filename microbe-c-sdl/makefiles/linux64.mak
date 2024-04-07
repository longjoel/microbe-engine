include ./makefiles/0.mak

# Compiler and flags
CC := gcc
CXX := g++
CFLAGS := -Wall -Wextra -g $(shell sdl2-config --cflags)
CXXFLAGS := $(CFLAGS) -std=c++11
LDFLAGS := $(shell sdl2-config --libs) -lm -lSDL2_ttf -lSDL2_mixer -ggdb
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