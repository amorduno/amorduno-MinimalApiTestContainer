## Contenido
1. [Informacion General](#general-info)
2. [Tecnologías](#tecnologias)
3. [Configuraciones](#configuraciones)

   
### Informacion General
***
Este es un pequeño ejemplo de Minimal API. En este proyecto se implemento un simple CRUD de la entidad Persona y se crearon dos pruebas.

## Tecnologías
***
Estas son las librearías utilizadas en el proyecto:
* [Microsoft.EntityFrameworkCore.SqlServer]: Version 7.0.1
* [Testcontainers.MsSql]: Version 3.7.0
* [Testcontainers.MsSql]: Version 3.7.0
* [Microsoft.AspNetCore.Mvc.Testing]: Version 6.0.28
* [NUnit]: Version 4.1.0
* [xunit]: Version 2.4.1
* Docker
* Postman

  
## Configuraciones
***
- Es necesario crear la base de datos DemoAPIDB y posteriormente ejecutar el script "scriptDB.txt" que se encuentra en la raiz del proyecto
- Configurar el archivo APIDemo.Api/appsettings.json para apuntar a la base de datos creada.
- Es necesario tener instalado Docker desktop y abrirlo para que se puedan crear los contenedores

