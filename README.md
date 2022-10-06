Mi proyecto final para www.coderhouse.com, donde son pedian hacer un CRUD con ADO .NET Core Web API para un local comercial.

DataBaseScript es la base de datos creada y dada a los alumnos por CoderHouse como modelo del trabajo final.


Dentro de la carpeta principal llamada "ProyectoFinalApi" encontraran las siguientes carpetas:

Carpeta "Models", contiene las tablas Usuario, Producto, Producto Vendido y Ventas de la base de datos.

		-------

Carpeta "Properties", contiene el "launchSettings.json"

		-------

Carpeta "ADO .NET", contiene 3 carpetas adentro:

Carpeta 1 "Error": contiene dos carpetas, "HandlreErrors" y "ValidatorErrors". Su funcionalidad es poder atajar las excepciones de las carpetas "Handler" y "ModelsValidator"

Carpeta 2 "Handler": contiene las peticiones de Creat, Read, Update, Delete a la base de datos.

Carpeta 3 "ModelsValidator": contiene las validaciones para cada clase de la base de datos.

		-------

Carpeta "Controllers", contiene los controller de cada clase y tambien contiene 2 capetas dentro:

Carpeta 1 "DTOS": contiene los PUT y POST.

Carpeta 2 "ExceptionFilter": contiene un filtro para atajar cada excepcion por separado.
