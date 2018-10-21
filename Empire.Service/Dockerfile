FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Empire.Service/Empire.Service.csproj Empire.Service/
COPY Pz.Shared/Pz.Shared.csproj Pz.Shared/
RUN dotnet restore Empire.Service/Empire.Service.csproj
COPY . .
WORKDIR /src/Empire.Service
RUN dotnet build Empire.Service.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Empire.Service.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Empire.Service.dll"]
