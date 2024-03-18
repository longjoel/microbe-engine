FROM ghcr.io/pspdev/pspsdk:latest
ENV PLATFORM=PSP

RUN psp-pacman  -Sy
RUN psp-pacman  -Suy
RUN yes | psp-pacman -S $(psp-pacman -Slq)

WORKDIR /app
RUN cd /app