FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Brendan.Service/Brendan.Service.csproj", "Brendan.Service/"]
RUN dotnet restore "Brendan.Service/Brendan.Service.csproj"
COPY . .
WORKDIR "/src/Brendan.Service"
RUN dotnet build "Brendan.Service.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Brendan.Service.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Brendan.Service.dll"]