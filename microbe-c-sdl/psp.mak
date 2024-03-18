# Compiler
CC := psp-g++

# Compiler flags
CFLAGS := -Wall -Wextra -g $(shell /usr/local/pspdev/psp/bin/sdl2-config --cflags) -D__MIPS__

# Linker flags
LDFLAGS := -L/usr/local/pspdev/psp/sdk/lib -L/usr/local/pspdev/psp/lib \
	-ogg -lpng -lvorbis -lvorbisfile -lvorbisenc -lfreetype -lm  -lSDL2_ttf -lSDL2_mixer -ggdb \
	$(shell /usr/local/pspdev/psp/bin/sdl2-config --libs)

# Source files
SRCS := $(wildcard *.c) $(wildcard *.cpp)

OBJDIR := obj

# Object files
OBJS := $(SRCS:%.c=$(OBJDIR)/%.o)
OBJS := $(OBJS:%.cpp=$(OBJDIR)/%.o)

# Target executable
TARGET := microbe-engine
$(shell mkdir -p $(OBJDIR))

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