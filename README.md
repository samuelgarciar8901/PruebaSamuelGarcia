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

La base de datos se  llama DbDoubleVPartners

Abrir SQL Server Management Studio.

Conectarse a:

(localdb)\MSSQLLocalDB


Crear la base de datos manualmente.

Ejecutar el script SQL incluido en el proyecto (el archivo .sql con la creación de la tabla Tickets).
