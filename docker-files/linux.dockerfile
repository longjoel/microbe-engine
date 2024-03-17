# Use a base image with the desired operating system and dependencies
FROM ubuntu:20.04
ENV DEBIAN_FRONTEND=noninteractive
ENV PLATFORM=Linux


# Set the working directory inside the container
WORKDIR /app

# Copy the project files into the container

# Install any necessary dependencies
RUN apt-get update && \
    apt-get install -y build-essential libsdl2-*


# Set the entrypoint command to run the built project
CMD ["bash"]