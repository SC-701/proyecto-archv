#Agregar Source de paquetes
dotnet nuget add source "https://nuget.pkg.github.com/Drojascode/index.json" --name "Paquetes" --username "Drojascode" --password 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 --store-password-in-clear-text

#Crear Proyectos

dotnet new sln --name Seguridad
dotnet new classlib --name Abstracciones
dotnet new classlib --name BW
dotnet new classlib --name BC
dotnet new classlib --name DA
dotnet new webapi --use-controllers --name API 
dotnet sln add Abstracciones/Abstracciones.csproj
dotnet sln add BW/BW.csproj
dotnet sln add BC/BC.csproj
dotnet sln add DA/DA.csproj
dotnet sln add API/API.csproj


mkdir Abstracciones/Interfaces