FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Paul.Service/Paul.Service.csproj", "Paul.Service/"]
RUN dotnet restore "Paul.Service/Paul.Service.csproj"
COPY . .
WORKDIR "/src/Paul.Service"
RUN dotnet build "Paul.Service.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Paul.Service.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Paul.Service.dll"]