# Makefile for collecting and compiling source files
TARGET = microbe-engine
# Directories
SRC_DIR := src
OBJ_DIR := obj
$(shell mkdir -p $(OBJ_DIR))
BIN_DIR := bin
$(shell mkdir -p $(BIN_DIR))

C_FILES := $(wildcard $(SRC_DIR)/*.c)
CPP_FILES := $(wildcard $(SRC_DIR)/*.cpp)

# Object files
OBJ_FILES := $(patsubst $(SRC_DIR)/%.c,$(OBJ_DIR)/%.o,$(C_FILES))
OBJ_FILES += $(patsubst $(SRC_DIR)/%.cpp,$(OBJ_DIR)/%.o,$(CPP_FILES))