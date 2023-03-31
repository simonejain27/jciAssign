# pulling from base image i.e., ASP .net core to run on it 
FROM mcr.microsoft.com/dotnet/sdk:6.0 as builder

#set the work directory inside the image where all application files will be copied
WORKDIR /src

#copy the project file to the image
COPY ./CategoryService.csproj .

#Restore all the references used in the project file
RUN dotnet restore 'CategoryService.csproj'

#copy all the executable references from the application to the image
COPY . . 
#source[project file] to detination[working directory] 

# inform the image that the base runtime is ready from the imported image
RUN dotnet build CategoryService.csproj -c debug -o /src/out

#point to work directory from where the application will be accessible
FROM mcr.microsoft.com/dotnet/aspnet:6.0

#copy the path from wher ethe execution will take place inside the image
WORKDIR /app
COPY --from=builder /src/out .
#expose the port
EXPOSE 80

#set the entrypoint to the application 
ENTRYPOINT ["dotnet", "CategoryService.dll"]