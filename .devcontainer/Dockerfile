# https://learn.microsoft.com/en-us/dotnet/core/docker/introduction#net-images
FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine3.17 as development

ARG USERNAME=vscode
ENV USERNAME $USERNAME

# To check for updates run
# doas apk -U upgrade --no-cache --simulate 
RUN apk -U upgrade --no-cache \
    # Create the user
    && adduser "$USERNAME" -G wheel --disabled-password \
    # Run apk info pkgName to get the version number of a package
    # If any issues accure remove all version pinning, rebuild, then use the apkinfo cmd to get the latest version
    && apk add --no-cache --update \
    # Add zip to compress and decompress files
    zip=3.0-r10 \
    # Add doas support. So one can experiment in the development stage
    # https://wiki.archlinux.org/title/Doas
    doas=6.8.2-r3 \
    && echo "permit nopass :wheel as root" >> /etc/doas.d/doas.conf \
    # Install docker file linter hadolint https://github.com/hadolint/hadolint
    && wget -q -O /bin/hadolint https://github.com/hadolint/hadolint/releases/download/v2.12.0/hadolint-Linux-x86_64 \
    && chmod +x /bin/hadolint

USER $USERNAME
WORKDIR /workspace