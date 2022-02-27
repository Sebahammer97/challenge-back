# Challenge de Desarrollo

> Programador Backend

**Objetivo de la entrega:**

- Desarrollar una Web API en .NET Core o .NET 5 o superior, con acceso a datos a través de Entity Framework, utilizando la metodología Db First. 

**Casos de uso**

Se pide CRUD de profesores, CRUD de alumnos y poder asociar un profesor a un alumno.

Para la entrega del mismo se debe seguir los siguientes pasos:
1. Hacer un Fork del repo challenge-back.
2. Subir el código fuente a un repo personal público.
3. Proveer por mail el acceso a dicho repo para su revisión.

Se deberá entregar tanto el código fuente como el proyecto o script de base de datos. Un archivo Markdown con los comandos para poder instalar las librerías que requieran instalación por npm y los links de las librerías externas no mencionadas sugeridas a conveniencia del Autor.

**Deseable**

- Validaciones.
- Implementar el Backend en CQRS con Mediatr.
- Se valoran el uso de librerías como Automapper, Dependency Inyection o las que vea conveniente para un código limpio y escalable.
- Test Unitarios.
- Colección de endpoints de Postman.

> Tiempo de entrega: 1 semana.

> Colocar debajo de este espacio lo necesario para que la aplicacion compile y se ejecute correctamente.

Pre-requisitos:
Tener MariaDb o MySQL instalado en la máquina.

Pasos de instalación:
1. Clonar el repositorio localmente.
2. Instalar o verificar que se tenga instalado las siguientes librerías en el nuget package:
  ![imagen](https://user-images.githubusercontent.com/55815143/155888328-d79d744d-2c67-4cc6-b293-4875819022f7.png)
3. Cambiar el connection string ubicado en el archivo appsettings.json por lo que corresponda con su configuración local.
4. Ir a la carpeta Utils, abrir el archivo DB-University.sql y ejecutar el script en una base de datos MariaDb o MySQL.
5. Al ejecutar el proyecto, automáticamente se abrirá una página en el navegador indicando los endpoints disponibles (Swagger).
  a. Ejemplo:
  ![imagen](https://user-images.githubusercontent.com/55815143/155888718-61eceaff-361b-416e-b327-e4d8f55b4676.png)
  b. Opcionalmente en la carpeta Utils se encuentra el archivo UniversityAPI.postman_collection.json en el que se lo puede importar al programa Postman para realizar las llamadas a la API.
