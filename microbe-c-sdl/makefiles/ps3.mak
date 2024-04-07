# Target executable
TARGET := microbe-engine
GAME_TITLE =$(TARGET)
GAME_ID=GAME_ID
CONTENT_ID=UP0000-ABCDEFG_00-0000000000000000
APPVERSION=1.0

# Compiler
CC := ppu-g++
CXX := ppu-g++

# Compiler flags
CFLAGS := -Wall -Wextra
CFLAGS := -mcpu=cell \
	-I/usr/local/ps3dev/ppu/include \
	-I/usr/local/ps3dev/portlibs/ppu/include \
	-I/usr/local/ps3dev/portlibs/ppu/include/SDL2
CXXFLAGS := $(CFLAGS) -std=c++11

# Linker flags
LDFLAGS := -L/usr/local/ps3dev/portlibs/ppu/lib \
	-L/usr/local/ps3dev/portlibs/ppu/lib \
	-L/usr/local/ps3dev/spu/spu/lib \
	-L/usr/local/ps3dev/ppu/powerpc64-ps3-elf/lib \
	-L/usr/local/ps3dev/portlibs/ppu/lib \
	-L/usr/local/ps3dev/portlibs/ppu/lib  /usr/local/ps3dev/portlibs/ppu/lib/libSDL2_ttf.a /usr/local/ps3dev/portlibs/ppu/lib/libSDL2_mixer.a /usr/local/ps3dev/portlibs/ppu/lib/libSDL2.a -lm -lgcm_sys -lrsx -lsysutil -lio -laudio -lrt -llv2 -lio -laudio

include ./makefiles/0.mak

# Default target

# Rule to compile C source files

all: $(BIN_DIR)/$(TARGET)

# Rule to build the executable
$(BIN_DIR)/$(TARGET): $(OBJ_FILES)
	
	$(CXX) $(CFLAGS)  $^ $(LDFLAGS) -o $@

	# build the elf files.
	ppu-strip $(BIN_DIR)/$(TARGET) -o $(BIN_DIR)/$(TARGET).elf
	sprxlinker $(BIN_DIR)/$(TARGET).elf
	fself $(BIN_DIR)/$(TARGET).elf $(BIN_DIR)/$(TARGET).self
	make_self $(BIN_DIR)/$(TARGET).elf $(BIN_DIR)/$(TARGET).self
	
	# build a .pkg file
	mkdir -p pkg/USRDIR
	make_self_npdrm $(BIN_DIR)/$(TARGET).elf pkg/USRDIR/EBOOT.BIN ${CONTENT_ID}
	cp /usr/local/ps3dev/bin/sfo.xml .
	sed -i "s/01\.00/${APPVERSION}/g" sfo.xml
	sfo.py --title ${GAME_TITLE} --appid ${GAME_ID} -f /usr/local/ps3dev/bin/sfo.xml pkg/PARAM.SFO
	pkg.py --contentid ${CONTENT_ID} pkg/ $(BIN_DIR)/$(TARGET).pkg

$(OBJ_DIR)/%.o: $(SRC_DIR)/%.c
	$(CC) $(CFLAGS) -c $< -o $@

$(OBJ_DIR)/%.o: $(SRC_DIR)/%.cpp
	$(CXX) $(CXXFLAGS) -c $< -o $@


elf: $(TARGET)
	

# Clean target
clean:
	rm -rf $(OBJDIR)/*.o $(TARGET)
	rm -f *.elf *.pkg *.self *.o sfo.xml

