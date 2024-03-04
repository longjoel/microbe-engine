# Compiler
include $(PSPSDK)/lib/build.mak


CC := psp-g++

PSPSDK=$(shell psp-config --pspsdk-path)
PSPDIR=$(shell psp-config --psp-prefix)



# Compiler flags
CFLAGS := `/usr/local/pspdev/psp/bin/sdl-config --cflags`
# Linker flags
LDFLAGS := `/usr/local/pspdev/psp/bin/sdl-config --libs`  -lSDL2_ttf 

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
	$(CC) $(CFLAGS)  $^ $(LDFLAGS) -o $@

# Rule to compile C source files
%.o: %.c
	$(CC) $(CFLAGS) -c $< -o $@

# Rule to compile C++ source files
%.o: %.cpp
	$(CC) $(CFLAGS) -c $< -o $@



# Clean target
clean:
	rm -f $(OBJS) $(TARGET)