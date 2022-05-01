# ApiCsvFileManager

Para desplegar en ambiente local la Api ejecute los siguientes comandos en la raíz de la solución.
```sh
dotnet restore
```
```sh
dotnet build
```
```sh
dotnet run
```
La aplicación creara la base de datos y ejecutara las migraciones.
Para desplegar en ambiente local la aplicación web angular, en la raíz del proyecto ejecute los siguientes comandos.
```sh
npm i
```
```sh
npm run start
```

## Características Aplicacion web
- Aplicación Web hecha en angular.
- Manejo de estado de la aplicación web personalizado.
- Se utilizo angular material.
- Todas las consultas de datos tienen filtro.
- Manejo de observables y librería Rxjs

## Características Api
- Net Core 5
- Base de datos Sql Server.
- Entity framework.
- Se implementa arquitecturas limpias, la propuesta por [Robert C. Martin (Uncle Bob)](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html).


## Plugins

Dillinger is currently extended with the following plugins.
Instructions on how to use them in your own application are linked below.

| Plugin | README |
| ------ | ------ |
| Asp NetCore | [plugins/github/README.md][PlGa] |
| EntityFramework | [plugins/github/README.md][PlGd] |
| CsvHelper | [plugins/github/README.md][PlGh] |
| FluentValidation.AspNetCore | [plugins/github/README.md][PlDb] |
| Angular | [plugins/github/README.md][PlOd] |
| Angular Material | [plugins/github/README.md][PlMe] |


   [PlGa]: <https://github.com/dotnet/aspnetcore/blob/main/README.md>
   [PlGd]: <https://github.com/rajanadar/EntityFramework/blob/dev/README.md>
   [PlGh]: <https://github.com/JoshClose/CsvHelper#readme>
   [PlDb]: <https://github.com/FluentValidation/FluentValidation#readme>
   [PlOd]: <https://github.com/angular/angular/blob/main/README.md>
   [PlMe]: <https://github.com/angular/components#readme>
   
