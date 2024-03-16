FROM ubuntu:20.04
ENV DEBIAN_FRONTEND=noninteractive

RUN apt-get update && apt-get install -y git
RUN apt-get install -y python-dev-is-python3 python-is-python3 autoconf automake bison flex gcc libelf-dev make \
    texinfo libncurses5-dev patch python3 subversion wget zlib1g-dev \
    libtool libtool-bin python3-dev bzip2 libgmp3-dev pkg-config g++ libssl-dev clang

WORKDIR /ps3dev
RUN cd /ps3dev 
ENV PS3DEV=/ps3dev
ENV PSL1GHT=$PS3DEV

ENV PATH=$PATH:$PS3DEV/bin
ENV PATH=$PATH:$PS3DEV/ppu/bin
ENV PATH=$PATH:$PS3DEV/spu/bin

ENV PLATFORM=ps3

RUN git fetch https://github.com/ps3dev/ps3toolchain.git

RUN bash ./toolchain.sh