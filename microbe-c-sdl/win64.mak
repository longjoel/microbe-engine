# Compiler
CC := g++

# Compiler flags
CFLAGS := -Wall -Wextra -g $(shell sdl2-config --cflags)

# Linker flags
LDFLAGS := -L C:\dev\w64devkit\lib -L C:\dev\w64devkit\x86_64-w64-mingw32\lib $(shell sdl2-config --libs) -lm  -lSDL2_ttf -ggdb

# Source files
SRCS := $(wildcard *.c) $(wildcard *.cpp)

OBJDIR := obj

# Object files
OBJS := $(SRCS:%.c=$(OBJDIR)/%.o)
OBJS := $(OBJS:%.cpp=$(OBJDIR)/%.o)

# Target executable
TARGET := microbe-engine

# Default target
all: $(TARGET)

# Rule to build the executable
$(TARGET): $(OBJS)
	$(CC) $(CFLAGS)  $^ $(LDFLAGS) -o $@
	
# Rule to compile C source files
$(OBJDIR)/%.o: %.c
	$(CC) $(CFLAGS) -c $< -o $@

# Rule to compile C++ source files
$(OBJDIR)/%.o: %.cpp
	$(CC) $(CFLAGS) -c $< -o $@

# Clean target
clean:
	rm -rf $(OBJDIR)/*.o $(TARGET)