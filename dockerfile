# .NET Core Build
FROM microsoft/dotnet:latest AS dotnetcore-build
WORKDIR /source

# Copy Projects Files
COPY source/App/Application/Solution.App.Application.csproj ./App/Application/
COPY source/App/CrossCutting/Solution.App.CrossCutting.csproj ./App/CrossCutting/
COPY source/App/Database/Solution.App.Database.csproj ./App/Database/
COPY source/App/Domain/Solution.App.Domain.csproj ./App/Domain/
COPY source/App/IoC/Solution.App.IoC.csproj ./App/IoC/
COPY source/App/Model/Solution.App.Model.csproj ./App/Model/
COPY source/App/Web/Solution.App.Web.csproj ./App/Web/
COPY source/Core/AspNetCore/Solution.Core.AspNetCore.csproj ./Core/AspNetCore/
COPY source/Core/Databases/Solution.Core.Databases.csproj ./Core/Databases/
COPY source/Core/EntityFrameworkCore/Solution.Core.EntityFrameworkCore.csproj ./Core/EntityFrameworkCore/
COPY source/Core/Extensions/Solution.Core.Extensions.csproj ./Core/Extensions/
COPY source/Core/Logging/Solution.Core.Logging.csproj ./Core/Logging/
COPY source/Core/Mapping/Solution.Core.Mapping.csproj ./Core/Mapping/
COPY source/Core/MongoDB/Solution.Core.MongoDB.csproj ./Core/MongoDB/
COPY source/Core/Objects/Solution.Core.Objects.csproj ./Core/Objects/
COPY source/Core/Security/Solution.Core.Security.csproj ./Core/Security/
COPY source/Core/Validation/Solution.Core.Validation.csproj ./Core/Validation/

# ASP.NET Core Restore
RUN dotnet restore ./App/Web/Solution.App.Web.csproj

# Copy All Files
COPY source .

# ASP.NET Core Build
RUN dotnet build ./App/Web/Solution.App.Web.csproj -c Release -o /app

# ASP.NET Core Publish
FROM dotnetcore-build AS dotnetcore-publish
RUN dotnet publish ./App/Web/Solution.App.Web.csproj -c Release -o /app

# Angular
FROM node:alpine AS angular-build
ARG ANGULAR_ENVIRONMENT
WORKDIR /frontend
ENV PATH /frontend/node_modules/.bin:$PATH
COPY source/App/Web/Frontend/package.json .
RUN npm run restore
COPY source/App/Web/Frontend .
RUN npm run $ANGULAR_ENVIRONMENT

# ASP.NET Core Runtime
FROM microsoft/dotnet:2.1.5-aspnetcore-runtime AS aspnetcore-runtime
WORKDIR /app
EXPOSE 80

# ASP.NET Core and Angular
FROM aspnetcore-runtime AS aspnetcore-angular
ARG ASPNETCORE_ENVIRONMENT
ENV ASPNETCORE_ENVIRONMENT=$ASPNETCORE_ENVIRONMENT
WORKDIR /app
COPY --from=dotnetcore-publish /app .
COPY --from=angular-build /frontend/dist ./Frontend/dist
ENTRYPOINT ["dotnet", "Solution.App.Web.dll"]
