FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SpecificationPatternExample/SpecificationPatternExample.csproj", "SpecificationPatternExample/"]
RUN dotnet restore "SpecificationPatternExample/SpecificationPatternExample.csproj"
COPY . .
WORKDIR "/src/SpecificationPatternExample"
RUN dotnet build "SpecificationPatternExample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpecificationPatternExample.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpecificationPatternExample.dll"]
