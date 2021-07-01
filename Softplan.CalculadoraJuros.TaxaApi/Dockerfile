#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Softplan.CalculadoraJuros.TaxaApi/Softplan.CalculadoraJuros.TaxaApi.csproj", "Softplan.CalculadoraJuros.TaxaApi/"]
RUN dotnet restore "Softplan.CalculadoraJuros.TaxaApi/Softplan.CalculadoraJuros.TaxaApi.csproj"
COPY . .
WORKDIR "/src/Softplan.CalculadoraJuros.TaxaApi"
RUN dotnet build "Softplan.CalculadoraJuros.TaxaApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Softplan.CalculadoraJuros.TaxaApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Softplan.CalculadoraJuros.TaxaApi.dll"]