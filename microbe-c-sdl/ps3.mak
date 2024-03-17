# Target executable
TARGET := microbe-engine
GAME_TITLE =$(TARGET)
GAME_ID=GAME_ID
CONTENT_ID=UP0000-ABCDEFG_00-0000000000000000
APPVERSION=1.0

# Compiler
CC := ppu-gcc

# Compiler flags
CFLAGS := -Wall -Wextra
CFLAGS := -mcpu=cell \
	-I/usr/local/ps3dev/ppu/include \
	-I/usr/local/ps3dev/portlibs/ppu/include \
	-L/usr/local/ps3dev/portlibs/ppu/lib \
	-L/usr/local/ps3dev/spu/spu/lib \
	-L/usr/local/ps3dev/ppu/powerpc64-ps3-elf/lib \
	-I/usr/local/ps3dev/portlibs/ppu/include/SDL2 \
	-I/usr/local/ps3dev/portlibs/ppu/include

# Linker flags
LDFLAGS := -L/usr/local/ps3dev/portlibs/ppu/lib -lSDL2_image -lSDL2 -lm -lgcm_sys -lrsx -lsysutil -lrt -llv2 -lio -laudio -lSDL2_ttf -lSDL2_mixer 


# Source files
SRCS := $(wildcard *.c) $(wildcard *.cpp)

OBJDIR := obj

# Object files
OBJS := $(SRCS:%.c=$(OBJDIR)/%.o)
OBJS := $(OBJS:%.cpp=$(OBJDIR)/%.o)



$(shell mkdir -p $(OBJDIR))

# Default target
all: $(TARGET)

# Rule to build the executable
$(TARGET): $(OBJS)
	
	$(CC) $(CFLAGS)  $^ $(LDFLAGS) -o $@
	# build the elf files.
	ppu-strip $(TARGET) -o $(TARGET).elf
	sprxlinker $(TARGET).elf
	fself $(TARGET).elf $(TARGET).self
	make_self $(TARGET).elf $(TARGET).self
	# build a .pkg file
	mkdir -p pkg/USRDIR
	make_self_npdrm $(TARGET).elf pkg/USRDIR/EBOOT.BIN ${CONTENT_ID}
	cp /usr/local/ps3dev/bin/sfo.xml .
	sed -i "s/01\.00/${APPVERSION}/g" sfo.xml
	sfo.py --title ${GAME_TITLE} --appid ${GAME_ID} -f /usr/local/ps3dev/bin/sfo.xml pkg/PARAM.SFO
	pkg.py --contentid ${CONTENT_ID} pkg/ $(TARGET).pkg

# Rule to compile C source files
$(OBJDIR)/%.o: %.c
	$(CC) $(CFLAGS) -c $< -o $@

# Rule to compile C++ source files
$(OBJDIR)/%.o: %.cpp
	$(CC) $(CFLAGS) -c $< -o $@

elf: $(TARGET)
	

# Clean target
clean:
	rm -rf $(OBJDIR)/*.o $(TARGET)
	rm -f *.elf *.pkg *.self *.o sfo.xml

