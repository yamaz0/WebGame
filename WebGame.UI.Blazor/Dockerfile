FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY WebGame.UI.Blazor/WebGame.UI.Blazor.csproj .
RUN dotnet restore WebGame.UI.Blazor/WebGame.UI.Blazor.csproj
COPY . .
RUN dotnet build WebGame.UI.Blazor/WebGame.UI.Blazor.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish WebGame.UI.Blazor/WebGame.UI.Blazor.csproj -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf