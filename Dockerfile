#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WebGame.Api/WebGame.Api.csproj", "WebGame.Api/"]
COPY ["TimeAction/WebGame.TimeAction.csproj", "TimeAction/"]
COPY ["WebGame.Application/WebGame.Application.csproj", "WebGame.Application/"]
COPY ["WebGame.Application.Secure/WebGame.Application.Security.csproj", "WebGame.Application.Secure/"]
COPY ["WebGame.Domain/WebGame.Domain.csproj", "WebGame.Domain/"]
COPY ["WebGame.Persistence.EF/WebGame.Persistence.EF.csproj", "WebGame.Persistence.EF/"]
COPY ["WebGame.Duel/WebGame.Duel.csproj", "WebGame.Duel/"]
COPY ["WebGame.Security/WebGame.Security.csproj", "WebGame.Security/"]
RUN dotnet restore "WebGame.Api/WebGame.Api.csproj"
COPY . .
WORKDIR "/src/WebGame.Api"
RUN dotnet build "WebGame.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebGame.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebGame.Api.dll"]