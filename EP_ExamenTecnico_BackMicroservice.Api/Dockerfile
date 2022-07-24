#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["EP_Planning_BackMicroservice.Api/EP_Planning_BackMicroservice.Api.csproj", "EP_Planning_BackMicroservice.Api/"]
COPY ["Util/Util.csproj", "Util/"]
COPY ["EP_Planning_BackMicroservice.Infraestructure/EP_Planning_BackMicroservice.Infraestructure.csproj", "EP_Planning_BackMicroservice.Infraestructure/"]
COPY ["EP_Planning_BackMicroservice.Entities/EP_Planning_BackMicroservice.Entities.csproj", "EP_Planning_BackMicroservice.Entities/"]
COPY ["EP_Planning_BackMicroservice.Repository/EP_Planning_BackMicroservice.Repository.csproj", "EP_Planning_BackMicroservice.Repository/"]
COPY ["EP_Planning_BackMicroservice.Service/EP_Planning_BackMicroservice.Service.csproj", "EP_Planning_BackMicroservice.Service/"]
COPY ["EP_Planning_BackMicroservice.Domain/EP_Planning_BackMicroservice.Domain.csproj", "EP_Planning_BackMicroservice.Domain/"]
COPY ["EP_Planning_BackMicroservice.Exceptions/EP_Planning_BackMicroservice.Exceptions.csproj", "EP_Planning_BackMicroservice.Exceptions/"]
RUN dotnet restore "EP_Planning_BackMicroservice.Api/EP_Planning_BackMicroservice.Api.csproj"
COPY . .
WORKDIR "/src/EP_Planning_BackMicroservice.Api"
RUN dotnet build "EP_Planning_BackMicroservice.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EP_Planning_BackMicroservice.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EP_Planning_BackMicroservice.Api.dll"]