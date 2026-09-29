FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Сначала только csproj — чтобы слой с restore кэшировался.
# ВАЖНО: имена папок должны совпадать с путями ProjectReference в csproj.
COPY ["Src/BlackBook.Api/BlackBook.Api.csproj", "BlackBook.Api/"]
COPY ["Src/BlackBook.Data/BlackBook.Data.csproj", "BlackBook.Data/"]
COPY ["Src/BookStorageService/BookStorageService.csproj", "BookStorageService/"]
COPY ["Src/Mega.Client/Mega.Client.csproj", "Mega.Client/"]
COPY ["Src/MegaService/MegaService.csproj", "MegaService/"]
COPY ["Src/RatingService/RatingService.csproj", "RatingService/"]
COPY ["Src/UserBookProgress.Service/UserBookProgressService.csproj", "UserBookProgress.Service/"]
RUN dotnet restore "BlackBook.Api/BlackBook.Api.csproj"

# Исходники
COPY ["Src/BlackBook.Api/", "BlackBook.Api/"]
COPY ["Src/BlackBook.Data/", "BlackBook.Data/"]
COPY ["Src/BookStorageService/", "BookStorageService/"]
COPY ["Src/Mega.Client/", "Mega.Client/"]
COPY ["Src/MegaService/", "MegaService/"]
COPY ["Src/RatingService/", "RatingService/"]
COPY ["Src/UserBookProgress.Service/", "UserBookProgress.Service/"]
RUN dotnet publish "BlackBook.Api/BlackBook.Api.csproj" -c Release -o /app/publish --no-restore /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "BlackBook.Api.dll"]
