  # MVC-CRUD-Users

Este repositorio contiene un proyecto CRUD basado en un Modelo Vista-Controlador, con implementación 
de Registro e Inicio de Sesión. La aplicación web permite registrar usuarios e iniciar sesión con los mismos, 
además de acceder a las operaciones básicas de CRUD.

Para este proyecto se utilizaron las tecnologías de ASP.NET & EntityFramework, siendo esta última una gran 
ayuda para poder gestionar bases de datos desde la consola del Administrador de Paquetes NuGet. 

Algunos desafíos encontrados fueron las validaciones, las cuales, si bien algunas están implementadas, 
faltan otras relacionadas con el Registro e Inicio de Sesión. Esto lo implementaré a futuro.

## Requisitos Previos

- Tener instalado Visual Studio 2022
- Tener instalado Microsoft SQL Server Management Studio 20.

## Instrucciones de Uso

1. **Clona el Repositorio:** Clona este repositorio utilizando Git:

    ```bash
    git clone https://github.com/Matex2395/MVC-CRUD-Users.git
    ```

2. **Abre el Proyecto en Visual Studio 2022:** Abre Visual Studio 2022 y ejecuta el archivo que contiene la solución del proyecto, con esto podrás acceder a los archivos del proyecto.

3. **Crea la Base de Datos**

    - Modifica la cadena de conexión en ```appsettings.json``` para que esta responda a tu base de datos en SQL Server.
    - Añade las migraciones y actualiza la Base de Datos por medio de la consola del Administrador de Paquetes NuGet.

4. **Ejecuta el proyecto**

   - Pon a correr al proyecto y prueba las funcionalidades de este.
   - Puedes comprobar la seguridad de las URLs al intentar iniciar sesión.

## Créditos

Este proyecto salió de los siguientes tutoriales, los cuales fueron adaptados por mí para que encajen en el proyecto:
- CRUD: https://www.youtube.com/watch?v=dhguXv3vRIk
- Login: https://www.youtube.com/watch?v=pJb9O7foT-8

## Contribuciones

¡Siéntete libre de contribuir al proyecto abriendo issues o enviando pull requests!
