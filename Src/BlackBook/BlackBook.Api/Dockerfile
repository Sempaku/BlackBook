FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Src/BlackBook/BlackBook.Api/BlackBook.Api.csproj", "BlackBook.Api/"]
COPY ["Src/BlackBook/BookStorageService/BookStorageService.csproj", "BookStorageService/"]
COPY ["Src/BlackBook/BlackBook.Data/BlackBook.Data.csproj", "BlackBook.Data/"]
COPY ["Src/BlackBook/Mega.Client/Mega.Client.csproj", "Mega.Client/"]
COPY ["Src/BlackBook/MegaService/MegaService.csproj", "MegaService/"]
COPY ["Src/BlackBook/RatingService/RatingService.csproj", "RatingService/"]
RUN dotnet restore "BlackBook.Api/BlackBook.Api.csproj" 

WORKDIR "/src/BlackBook.Api"
COPY . .

RUN dotnet build "BlackBook.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlackBook.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false  --self-contained false --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlackBook.Api.dll"]
CMD ["dotnet", "BlackBook.Api.dll"]