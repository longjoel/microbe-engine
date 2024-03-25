# Compiler

CC       = psp-g++
CXX      = psp-g++
AS       = psp-g++
LD       = psp-g++
AR       = psp-gcc-ar
RANLIB   = psp-gcc-ranlib
STRIP    = psp-strip
MKSFO    = mksfoex
PACK_PBP = pack-pbp
FIXUP    = psp-fixup-imports
ENC              = PrxEncrypter

BUILD_PRX = 1 

EXTRA_TARGETS   = EBOOT.PBP
PSP_EBOOT_TITLE = microbe-engine

PSPSDK=$(shell psp-config --pspsdk-path)

INCDIR   := $(INCDIR) . $(PSPDEV)/psp/include $(PSPSDK)/include
LIBDIR   := $(LIBDIR) . $(PSPDEV)/psp/lib $(PSPSDK)/lib

CFLAGS   := $(addprefix -I,$(INCDIR)) $(CFLAGS)
CXXFLAGS := $(CFLAGS) $(CXXFLAGS)
ASFLAGS  := $(CFLAGS) $(ASFLAGS)

ifeq ($(PSP_FW_VERSION),)
PSP_FW_VERSION=600
endif

EXPAND_MEMORY = 0

# Compiler flags
CXXFLAGS :=  $(CXXFLAGS) -Wall -Wextra -g -D__MIPS__ -G0 -Wall -O2 -fno-exceptions -fno-rtti \
	$(shell psp-pkg-config --cflags SDL2_mixer) \
	$(shell psp-pkg-config --cflags SDL2_ttf) \
	$(shell psp-pkg-config --cflags sdl2)

# Linker flags
LDFLAGS := $(LDFLAGS) \
	$(shell psp-pkg-config --libs SDL2_mixer) \
	$(shell psp-pkg-config --libs SDL2_ttf) \
	$(shell psp-pkg-config --libs sdl2) \
	-ogg -lpng -lvorbis -lvorbisfile -lvorbisenc -lfreetype -lm -ggdb 

ifeq ($(shell test $(PSP_FW_VERSION) -gt 390; echo $$?),0)
EXPAND_MEMORY = 1
ifeq ($(PSP_LARGE_MEMORY),1)
$(warning "PSP_LARGE_MEMORY" flag is not necessary targeting firmware versions above 3.90)
else ifeq ($(PSP_LARGE_MEMORY),0)
EXPAND_MEMORY = 0
endif # PSP_LARGE_MEMORY
else
ifeq ($(PSP_LARGE_MEMORY),1)
EXPAND_MEMORY = 1
endif # PSP_LARGE_MEMORY
endif # PSP_FW_VERSION

SFOFLAGS := -d MEMSIZE=$(EXPAND_MEMORY) $(SFOFLAGS)

CFLAGS += -D_PSP_FW_VERSION=$(PSP_FW_VERSION)
CXXFLAGS += -D_PSP_FW_VERSION=$(PSP_FW_VERSION)

# CFW versions after M33 3.90 guard against expanding the
# user memory partition on PSP-1000, making MEMSIZE obsolete.
# It is now an opt-out policy with PSP_LARGE_MEMORY=0
ifeq ($(shell test $(PSP_FW_VERSION) -gt 390; echo $$?),0)
EXPAND_MEMORY = 1
ifeq ($(PSP_LARGE_MEMORY),1)
$(warning "PSP_LARGE_MEMORY" flag is not necessary targeting firmware versions above 3.90)
else ifeq ($(PSP_LARGE_MEMORY),0)
EXPAND_MEMORY = 0
endif # PSP_LARGE_MEMORY
else
ifeq ($(PSP_LARGE_MEMORY),1)
EXPAND_MEMORY = 1
endif # PSP_LARGE_MEMORY
endif # PSP_FW_VERSION

SFOFLAGS := -d MEMSIZE=$(EXPAND_MEMORY) $(SFOFLAGS)

CFLAGS += -D_PSP_FW_VERSION=$(PSP_FW_VERSION)
CXXFLAGS += -D_PSP_FW_VERSION=$(PSP_FW_VERSION)

ifeq ($(BUILD_PRX),1)
LDFLAGS  := $(addprefix -L,$(LIBDIR)) -specs=$(PSPSDK)/lib/prxspecs -Wl,-q,-T$(PSPSDK)/lib/linkfile.prx $(LDFLAGS)
EXTRA_CLEAN += $(TARGET).elf
# Setup default exports if needed
ifdef PRX_EXPORTS
EXPORT_OBJ=$(patsubst %.exp,%.o,$(PRX_EXPORTS))
EXTRA_CLEAN += $(EXPORT_OBJ)
else 
EXPORT_OBJ=$(PSPSDK)/lib/prxexports.o
endif
else
LDFLAGS  := $(addprefix -L,$(LIBDIR)) $(LDFLAGS)
endif

# Reduce binary size
LDFLAGS +=  -Wl,-zmax-page-size=128

ifeq ($(USE_KERNEL_LIBS),1)
LIBS := -nostdlib $(LIBS) -lpspdebug -lpspdisplay_driver -lpspctrl_driver -lpspmodinfo -lpspsdk -lpspkernel
else
LIBS := $(LIBS) -lpspdebug -lpspdisplay -lpspge -lpspctrl \
                -lpspnet -lpspnet_apctl
endif

# Define the overridable parameters for EBOOT.PBP
ifndef PSP_EBOOT_TITLE
PSP_EBOOT_TITLE = $(TARGET)
endif

ifndef PSP_EBOOT_SFO
PSP_EBOOT_SFO = PARAM.SFO
endif

ifndef PSP_EBOOT_ICON
PSP_EBOOT_ICON = NULL
endif

ifndef PSP_EBOOT_ICON1
PSP_EBOOT_ICON1 = NULL
endif

ifndef PSP_EBOOT_UNKPNG
PSP_EBOOT_UNKPNG = NULL
endif

ifndef PSP_EBOOT_PIC1
PSP_EBOOT_PIC1 = NULL
endif

ifndef PSP_EBOOT_SND0
PSP_EBOOT_SND0 = NULL
endif

ifndef PSP_EBOOT_PSAR
PSP_EBOOT_PSAR = NULL
endif

ifndef PSP_EBOOT
PSP_EBOOT = EBOOT.PBP
endif

ifeq ($(BUILD_PRX),1)
ifneq ($(TARGET_LIB),)
$(error TARGET_LIB should not be defined when building a prx)
else
FINAL_TARGET = $(TARGET).prx
endif
else
ifneq ($(TARGET_LIB),)
FINAL_TARGET = $(TARGET_LIB)
else
FINAL_TARGET = $(TARGET).elf
endif
endif





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
all: $(EXTRA_TARGETS) $(FINAL_TARGET)


kxploit: $(TARGET).elf $(PSP_EBOOT_SFO)
	mkdir -p "$(TARGET)"
	$(STRIP) $(TARGET).elf -o $(TARGET)/$(PSP_EBOOT)
	mkdir -p "$(TARGET)%"
	$(PACK_PBP) "$(TARGET)%/$(PSP_EBOOT)" $(PSP_EBOOT_SFO) $(PSP_EBOOT_ICON)  \
                $(PSP_EBOOT_ICON1) $(PSP_EBOOT_UNKPNG) $(PSP_EBOOT_PIC1)  \
                $(PSP_EBOOT_SND0) NULL $(PSP_EBOOT_PSAR)



SCEkxploit: $(TARGET).elf $(PSP_EBOOT_SFO)
	mkdir -p "__SCE__$(TARGET)"
	$(STRIP) $(TARGET).elf -o __SCE__$(TARGET)/$(PSP_EBOOT)
	mkdir -p "%__SCE__$(TARGET)"
	$(PACK_PBP) "%__SCE__$(TARGET)/$(PSP_EBOOT)" $(PSP_EBOOT_SFO) $(PSP_EBOOT_ICON)  \
			$(PSP_EBOOT_ICON1) $(PSP_EBOOT_UNKPNG) $(PSP_EBOOT_PIC1)  \
			$(PSP_EBOOT_SND0) NULL $(PSP_EBOOT_PSAR)





ifeq ($(NO_FIXUP_IMPORTS), 1)
$(TARGET).elf: $(OBJS) $(EXPORT_OBJ)
	$(CXXFLAGS) $(LINK.c) $^ $(LDFLAGS) -o $@
else
$(TARGET).elf: $(OBJS) $(EXPORT_OBJ)
	$(LINK.c) $^ $(LDFLAGS) -o $@
	$(FIXUP) $@
endif

$(TARGET_LIB): $(OBJS)
	$(AR) cru $@ $(OBJS)
	$(RANLIB) $@


# Rule to build the executable
$(TARGET): $(OBJS)
	$(CXX) $(CXXFLAGS)  $^ $(LDFLAGS) -o $@
	
# Rule to compile C source files
$(OBJDIR)/%.o: %.c
	$(CXX) $(CXXFLAGS) -c $< -o $@

# Rule to compile C++ source files
$(OBJDIR)/%.o: %.cpp
	$(CXX) $(CXXFLAGS) -c $< -o $@



$(PSP_EBOOT_SFO): 
	$(MKSFO) $(SFOFLAGS) '$(PSP_EBOOT_TITLE)' $@

ifeq ($(BUILD_PRX),1)
$(PSP_EBOOT): $(TARGET).prx $(PSP_EBOOT_SFO)
ifeq ($(ENCRYPT), 1)
	- $(ENC) $(TARGET).prx $(TARGET).prx
endif
	$(PACK_PBP) $(PSP_EBOOT) $(PSP_EBOOT_SFO) $(PSP_EBOOT_ICON)  \
			$(PSP_EBOOT_ICON1) $(PSP_EBOOT_UNKPNG) $(PSP_EBOOT_PIC1)  \
			$(PSP_EBOOT_SND0)  $(TARGET).prx $(PSP_EBOOT_PSAR)
else
$(PSP_EBOOT): $(TARGET).elf $(PSP_EBOOT_SFO)
	$(STRIP) $(TARGET).elf -o $(TARGET)_strip.elf
	$(PACK_PBP) $(PSP_EBOOT) $(PSP_EBOOT_SFO) $(PSP_EBOOT_ICON)  \
			$(PSP_EBOOT_ICON1) $(PSP_EBOOT_UNKPNG) $(PSP_EBOOT_PIC1)  \
			$(PSP_EBOOT_SND0)  $(TARGET)_strip.elf $(PSP_EBOOT_PSAR)
	-rm -f $(TARGET)_strip.elf
endif

%.prx: %.elf
	psp-prxgen $< $@

%.c: %.exp
	psp-build-exports -b $< > $@


# Clean target
clean:
	rm -rf $(OBJDIR)/*.o $(TARGET)
	# Fix missing separator error on line 259
	rm -f $(FINAL_TARGET) $(EXTRA_CLEAN) $(OBJS) $(PSP_EBOOT_SFO) $(PSP_EBOOT) $(EXTRA_TARGETS)

##########################################################################



# Add PSPSDK includes and libraries.



rebuild: clean all