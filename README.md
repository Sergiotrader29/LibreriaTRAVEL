Documentación del proyecto LibreriaTravel

1. Introducción
El proyecto es un software que permite la administración de un inventario de libros. La aplicación cuenta con una página principal de búsqueda, una página que muestra todos los libros y otra página para añadir libros.

2. Tecnologías utilizadas
.NET 6
ASP.NET MVC
Dapper
SQL Server
System.Data.SqlClient

3. Estructura de la aplicación
La aplicación está estructurada en capas y utiliza el patrón de diseño MVC. En la capa de modelo, se han creado cuatro modelos: Autor, Autorconlibro, Libros y Editoriales.
En la capa de servicios, se ha creado una clase que contiene todas las consultas a SQL Server utilizando Dapper. Cada consulta tiene su propia interfaz, y esa interfaz se llama desde el controlador LibreriaController.
El controlador llama a las vistas de Razor View de Home y la carpeta Libreria, donde están las vistas de buscar, añadir libro e index.
Para conectarse a la base de datos, se ha colocado la llave de conexión en DefaultConnection en appsettings.Development.json.

4.Funcionalidad CRUD y modelos
En la aplicación se utilizan cuatro modelos: Autor, Autorconlibro, Libros y Editoriales. Estos modelos son utilizados para crear, leer, actualizar y eliminar datos en la base de datos. Para crear un libro, se hace una consulta a SQL Server utilizando la sentencia INSERT y se insertan los datos ingresados en la vista Añadir Libro. Para la búsqueda de libros, se filtra por el nombre o apellido del autor y se realiza una consulta en la base de datos utilizando Dapper.

5. instalación y requisitos
Para utilizar la aplicación es necesario tener instalado NET.6, Dapper y System.Data.SqlClient. Además, es necesario importar las tablas de la base de datos en SQL Server para poder utilizar la aplicación correctamente.

6.Pasos para utilizar la aplicación
Los pasos para utilizar la aplicación son los siguientes:

7.Importar las tablas de la base de datos en SQL Server.
Instalar NET.6, Dapper y System.Data.SqlClient.
Ejecutar la aplicación en Visual Studio.
Utilizar las funcionalidades de búsqueda, creación, actualización y eliminación de libros utilizando las vistas correspondientes.
