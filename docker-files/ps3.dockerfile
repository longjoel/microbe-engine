FROM ubuntu:20.04
ENV DEBIAN_FRONTEND=noninteractive

RUN apt-get update 
RUN apt-get install -y python-dev-is-python3 python-is-python3 autoconf automake bison flex gcc libelf-dev make \
    texinfo libncurses5-dev patch python3 subversion wget zlib1g-dev \
    libtool libtool-bin python3-dev bzip2 libgmp3-dev pkg-config g++ libssl-dev clang git

ENV PS3DEV=/usr/local/ps3dev
ENV PSL1GHT=$PS3DEV

ENV PATH=$PATH:$PS3DEV/bin
ENV PATH=$PATH:$PS3DEV/ppu/bin
ENV PATH=$PATH:$PS3DEV/spu/bin

ENV PLATFORM=ps3

WORKDIR /ps3dev

RUN cd /ps3dev && git clone https://github.com/ps3dev/ps3toolchain.git && cd ps3toolchain && bash -c `./toolchain.sh`
RUN cd /ps3dev && git clone https://github.com/ps3dev/PSL1GHT.git && cd PSL1GHT && make install-ctrl && make && make install
RUN cd /ps3dev && git clone https://github.com/ps3dev/ps3libraries.git && cd ps3libraries && ./libraries.sh