FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

COPY StimulusChallenge.API/bin/Release/netcoreapp3.1/publish/ app/

ENTRYPOINT ["dotnet", "app/StimulusChallenge.API.dll"]