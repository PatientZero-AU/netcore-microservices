FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY HanSolo.Service/HanSolo.Service.csproj HanSolo.Service/
COPY Pz.Shared/Pz.Shared.csproj Pz.Shared/
RUN dotnet restore HanSolo.Service/HanSolo.Service.csproj
COPY . .
WORKDIR /src/HanSolo.Service
RUN dotnet build HanSolo.Service.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish HanSolo.Service.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "HanSolo.Service.dll"]
