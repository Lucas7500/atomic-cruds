FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

WORKDIR /src
COPY ["src/Atomic-Crud.Api/Atomic-Crud.Api.csproj", "src/Atomic-Crud.Api/"]
COPY ["src/Atomic-Crud.Application/Atomic-Crud.Application.csproj", "src/Atomic-Crud.Application/"]
COPY ["src/Atomic-Crud.Domain/Atomic-Crud.Domain.csproj", "src/Atomic-Crud.Domain/"]
COPY ["src/Atomic-Crud.Infrastructure/Atomic-Crud.Infrastructure.csproj", "src/Atomic-Crud.Infrastructure/"]
RUN dotnet restore "src/Atomic-Crud.Api/Atomic-Crud.Api.csproj"
COPY . .
WORKDIR "/src/src/Atomic-Crud.Api"
RUN dotnet build "Atomic-Crud.Api.csproj" --configuration Release --no-restore --nologo --output /app/build 

FROM build AS publish
RUN dotnet publish "Atomic-Crud.Api.csproj" --configuration Release --no-restore --nologo --output /app/publish

FROM publish AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Atomic-Crud.Api.dll"]