#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CustomerSupport.API/CustomerSupport.API.csproj", "CustomerSupport.API/"]
COPY ["CustomerSupport.Infra/CustomerSupport.Infra.csproj", "CustomerSupport.Infra/"]
COPY ["CustomerSupport.Domain/CustomerSupport.Domain.csproj", "CustomerSupport.Domain/"]
COPY ["CustomerSupport.Infra.IoC/CustomerSupport.Infra.IoC.csproj", "CustomerSupport.Infra.IoC/"]
COPY ["CustomerSupport.Application/CustomerSupport.Application.csproj", "CustomerSupport.Application/"]
COPY ["CustomerSupport.Resource/CustomerSupport.Resource.csproj", "CustomerSupport.Resource/"]
RUN dotnet restore "CustomerSupport.API/CustomerSupport.API.csproj"
COPY . .
WORKDIR "/src/CustomerSupport.API"
RUN dotnet build "CustomerSupport.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CustomerSupport.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CustomerSupport.API.dll"]