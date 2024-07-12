INSTALACIONES/DEPENDENCIAS:
1.1 Instalar SQLServerMS, Visual Studio Code, Visual Studio Community.
1.2 Abrir la siguiente url e instalar el SDK de .NET 8: "https://dotnet.microsoft.com/es-es/download/dotnet/8.0".

BASE DE DATOS:
2.1. Abrir SQLServerMS. Conectarse a algun servidor o crear uno propio.
2.2. Abrir el archivo "Verifarma_Script_DB" dentro de la carpeta "Verifarma_BD".
En SQLServerMS ejecutar el script con el boton "Ejecutar" (tiene un icono de "play") o apretar F5. Esto generara la
Base de Datos necesaria para usar el sistema.

BACKEND:
3.1. Abrir la carpeta "Verifarma_Backend" y abrir la solucion "Verifarma_Backend.sln"
con Visual Studio.
3.2. Abra el archivo "appsettings.json" dentro del proyecto y cambie en Data Source= y agregue el nombre de su servidor.
El nombre del servidor es el que abriste o creaste en SQLServerMS (aparece al momento de abrir SQLServerMS).
3.3 Ejecutar el sistema con el boton que tiene un icono de "play".
3.4 Ver la consola de comandos si las devoluciones de log estan OK.

4. Estructura del proyecto:

*** Proyecto ***
/Verifarma_Challenge_Elias_Vallejos
│
├── Verifarma_Backend/
│   │
│   ├── Verifarma_Backend/
│   │   ├── Controllers/
│   │   ├── Data/
│   │   ├── DTOs/
│   │   ├── Models/
│   │   ├── Services/
│   │   ├── appsettings.json
│   │   └── Program.cs
│   │
│   └── Verifarma_TestProject_XUnit/
│       └── TestProject_XUnit.cs/
│
└── Verifarma_BD/
    └── Verifarma_Script_DB.sql

*** BD ***
• Farmacia:
	• id (PRIMARY KEY)
	• nombre
	• direccion
	• latitud
	• longitud

5. Documentacion de la API:
	* Abra la carpeta "Verifarma_Documentacion_API" con VSCode para visualizar los archivos drawio. Para visualizarlos
	  debera instalar el plugin. Dentro de VSCode dirijase a Extensiones y busque "Draw.io Integration". Ya instalada
	  podra visualizar los .drawio.
	* "Verifarma_API_Documentacion_Esquema_Arquitectura_Backend.drawio" es un esquema de como esta pensado el Backend
	  bajo la logica del patro de diseño Repository.
	* En la carpeta "API" encontrara el archivo "Verifarma_API_Documentacion_Esquema_Arquitectura_API.drawio" que muestra
	  como es el esquema de la API y los endpoints que la componen.
	* Se asigna una imagen ilustrativa de Swagger para mayor visibilidad.
	* Por ultimo tendremos el esquema completo de la API en formato JSON y Yaml.

6. Uso de Linter (SonarLint).