# Runtime image
FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# SDK image
FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Alliance.Service/Alliance.Service.csproj Alliance.Service/
COPY Pz.Shared/Pz.Shared.csproj Pz.Shared/
RUN dotnet restore Alliance.Service/Alliance.Service.csproj
COPY . .
WORKDIR /src/Alliance.Service
RUN dotnet build Alliance.Service.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Alliance.Service.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Alliance.Service.dll"]
