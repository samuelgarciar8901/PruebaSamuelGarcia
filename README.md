# Prueba Técnica - Gestión de Tickets  
Aplicación Full Stack con **ASP.NET Core 7 + Angular**

Esta aplicación permite gestionar tickets: creación, listado y actualización de estado.
Fue construida usando una arquitectura simple y clara para facilitar mantenimiento y escalabilidad.

---

## Tecnologías Utilizadas

| Capa | Tecnología |
|-----|------------|
| Frontend | Angular + TypeScript + TailwindCSS |
| Backend | ASP.NET Core 7 (Web API) + Entity Framework Core |
| Base de Datos | SQL Server LocalDB |

---

## Requisitos Previos

Antes de ejecutar el proyecto, hay que  tener instalado:

1. **.NET SDK 7 o superior**  
   https://dotnet.microsoft.com/download

2. **Node.js 18 o superior**  
   https://nodejs.org/

3. **Angular CLI**  
   ```bash
   npm install -g @angular/cli

 4. **SQL Server** 
 LocalDB (viene incluido con Visual Studio)

5. **SQL Server Management Studio (SSMS)** 

1. Abrir SQL Server Management Studio.
2. Crear la base de datos `DbDoubleVPartners`.
3. Crear la tabla `Tickets` ejecutando el script SQL incluido.

Cadena de conexión en `backend/appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=DbDoubleVPartners;Trusted_Connection=True;TrustServerCertificate=True;"
}

4. Ejecutar Backend (API)
cd backend
dotnet restore
dotnet build
dotnet run

5. Ejecutar Frontend (Angular)

cd frontend
npm install
ng serve --o

6. Cómo se Usa la Aplicación

En la página principal se muestra una grilla con los tickets.

Se Puede:

Crear un nuevo ticket (botón "Agregar")

Editar tickets existentes 

Eliminar tickets

La grilla soporta paginación.

7. Tecnologías Utilizadas

ASP.NET Core Web API

Entity Framework Core

Angular Standalone Components

TailwindCSS

SweetAlert2

SQL Server / LocalDB

8. Autor

Samuel García
Repositorio: https://github.com/samuelgarciar8901/PruebaSamuelGarcia


