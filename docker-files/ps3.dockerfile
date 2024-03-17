FROM hldtux/ps3dev

ENV PLATFORM=PS3
# RUN cd ${PS3DEV} \
#     && git clone https://github.com/humbertodias/ps3libraries /ps3libraries \
#     && cd /ps3libraries \
#     && ./libraries.sh \
#     && rm -rf /ps3libraries

WORKDIR /app
RUN cd /app