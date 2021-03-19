ARG VARIANT=5.0
FROM mcr.microsoft.com/vscode/devcontainers/dotnet:${VARIANT}

ARG NODE_VERSION=15
ENV NODE_VERSION=${NODE_VERSION}

RUN curl -sL "https://deb.nodesource.com/setup_${NODE_VERSION}.x" | bash \
    && curl -sS https://dl.yarnpkg.com/debian/pubkey.gpg | apt-key add - \
    && echo "deb https://dl.yarnpkg.com/debian/ stable main" | tee /etc/apt/sources.list.d/yarn.list

RUN apt-get update && apt-get install -y nodejs p7zip-full yarn git procps

# Install fake, paket, retire
RUN dotnet tool install fake-cli -g \
    && dotnet tool install paket -g \
    && dotnet tool install dotnet-retire -g

# Install retire.js
RUN npm install -g retire
