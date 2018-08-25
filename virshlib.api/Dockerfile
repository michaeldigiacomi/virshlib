FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["virshlib.api/virshlib.api.csproj", "virshlib.api/"]
RUN dotnet restore "virshlib.api/virshlib.api.csproj"
COPY . .
WORKDIR "/src/virshlib.api"
RUN dotnet build "virshlib.api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "virshlib.api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "virshlib.api.dll"]