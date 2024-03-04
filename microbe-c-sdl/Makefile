# Compiler
CC := g++

# Compiler flags
CFLAGS := -Wall -Wextra -g `sdl2-config --cflags`

# Linker flags
LDFLAGS := -L C:\dev\w64devkit\lib -L C:\dev\w64devkit\x86_64-w64-mingw32\lib `sdl2-config --libs` -lm  -lSDL2_ttf 

# Source files
SRCS := $(wildcard *.c) $(wildcard *.cpp)

# Object files
OBJS := $(SRCS:.c=.o)
OBJS := $(OBJS:.cpp=.o)

# Target executable
TARGET := myapp

# Default target
all: $(TARGET)

# Rule to build the executable
$(TARGET): $(OBJS)
	$(CC) $(CFLAGS)  $^ $(LDFLAGS)-o $@

# Rule to compile C source files
%.o: %.c
	$(CC) $(CFLAGS) -c $< -o $@

# Rule to compile C++ source files
%.o: %.cpp
	$(CC) $(CFLAGS) -c $< -o $@



# Clean target
clean:
	rm -f $(OBJS) $(TARGET)