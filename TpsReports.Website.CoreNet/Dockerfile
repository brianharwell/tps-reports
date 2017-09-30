FROM iis-core:latest

ARG source=bin/Release/PublishOutput

WORKDIR /app

ENV ASPNETCORE_ENVIRONMENT=Development

EXPOSE 5000 80

COPY ${source} /inetpub/wwwroot