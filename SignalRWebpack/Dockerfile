FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SignalRWebpack/SignalRWebpack.csproj", "SignalRWebpack/"]
RUN dotnet restore "SignalRWebpack/SignalRWebpack.csproj"
COPY . .
WORKDIR "/src/SignalRWebpack"
RUN dotnet build "SignalRWebpack.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SignalRWebpack.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SignalRWebpack.dll"]
