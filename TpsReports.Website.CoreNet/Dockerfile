FROM microsoft/aspnet

SHELL [ "powershell", "-Command" ]

RUN Invoke-WebRequest -Uri "https://aka.ms/dotnetcore.2.0.0-windowshosting" -OutFile "C:\DotNetCore.2.0.0-WindowsHosting.exe" ; \
    C:\DotNetCore.2.0.0-WindowsHosting.exe /install /quiet ; \
    Wait-Process -Name *dotnet* -Timeout 180 ; \
    Stop-Process -Name msiexec -Force ; \
    Remove-Item -Path "C:\DotNetCore.2.0.0-WindowsHosting.exe" -Force ;

#ARG source=bin/Release/PublishOutput
#WORKDIR /app
#ENV ASPNETCORE_ENVIRONMENT=Development
#EXPOSE 5000 80
#COPY ${source} /app
#COPY ${source:-bin/Release/PublishOutput} .
#ENTRYPOINT [ "TpsReports.Website.CoreNet.exe" ]
 