
`Domain Project` Es el encargado de crear las clases de dominio, o las clases de tipo entidad que a futuro se convertirán en tablas de la base de datos.
`Persistence Project`  Es el va a llevar la acción el proceso de mapeo de las clases de dominio a tablas de la base de datos.

`Por ello necesitamos añadir como dependencia el proyecto de dominio en el proyecto de persistencia.`

Trabajaremos con el Patrón CQRS, por lo que necesitamos separar las acciones de lectura de las acciones de escritura, las cuales
se llevarán a cabo dentro del proyecto `Application`, por lo que necesitamos indicarle al proyecto las referencias
de los proyectos `Domain` y `Persistence`.

Por ultimo tenemos el proyecto `API`, el cual es el encargado de recibir las peticiones del cliente y enviar las respuestas,
por lo que necesitamos indicarle al proyecto las referencias de los proyectos `Application` ya que en este proyecto se encuentran 
las reglas de negocio y las acciones que se van a ejecutar.


-- En persistencia se crea la carpeta Data, donde se crean las clases de contexto de la base de datos, y las clases de migración, ademas de que es en esta 
   donde se deben de instalar los paquetes de EntityFrameworkCore y EntityFrameworkCore.SqlServer.



## Manera alternativa de generar migraciones

```bash
dotnet ef migrations add InitialCreate --project Project.Persistence -o Data/Migrations
```

Notas:
Si la migracion se hace desde el Package Manager console, en el proyecto start(API) se debe de instalar el paquete de EntityFrameworkCore.Design

```bash
dotnet add package Microsoft.EntityFrameworkCore.Design
```

Si al hacer la migracion se nos muestra el siguiente error:

```bash
Unable to create an object of type 'ApplicationDbContext'. For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728
```

Debemos de agregar un constructor a la clase ApplicationDbContext en blanco
 
