# Makefile for collecting and compiling source files
TARGET = microbe-engine
# Directories
SRC_DIR := src
OBJ_DIR := obj
$(shell mkdir -p $(OBJ_DIR))
BIN_DIR := bin
$(shell mkdir -p $(BIN_DIR))


# Compiler and flags
CC := gcc
CXX := g++
CFLAGS := -Wall -Wextra -g $(shell sdl2-config --cflags)
CXXFLAGS := $(CFLAGS) -std=c++11
LDFLAGS := $(shell sdl2-config --libs) -lm -lSDL2_ttf -lSDL2_mixer -ggdb
# Source files
C_FILES := $(wildcard $(SRC_DIR)/*.c)
CPP_FILES := $(wildcard $(SRC_DIR)/*.cpp)

# Object files
OBJ_FILES := $(patsubst $(SRC_DIR)/%.c,$(OBJ_DIR)/%.o,$(C_FILES))
OBJ_FILES += $(patsubst $(SRC_DIR)/%.cpp,$(OBJ_DIR)/%.o,$(CPP_FILES))

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