# Juegos-de-Mesa-Digitales
Definicion del Proyecto

Juegos de mesa digitales es una aplicación de escritorio desarrollada en C# utilizando Windows Forms, que integra dos juegos clásicos: Tic-Tac-Toe (Tres en Raya) y Damas Clásicas.

El sistema fue desarrollado aplicando los principios de Programación Orientada a Objetos (POO), así como la conexión y persistencia de datos mediante una base de datos MySQL.

La aplicación permite registrar automáticamente las partidas jugadas, almacenar los movimientos realizados por los jugadores y consultar un historial completo de partidas desde la interfaz gráfica.

Además, incorpora estadísticas en tiempo real, historial de juegos y una arquitectura organizada en capas para facilitar el mantenimiento y escalabilidad del proyecto.

 Objetivos:
- Aplicar los conceptos fundamentales de Programación Orientada a Objetos.
- Implementar operaciones CRUD mediante una base de datos MySQL.
- Desarrollar una interfaz gráfica funcional utilizando Windows Forms.
- Registrar partidas y movimientos de los jugadores.
- Mostrar estadísticas e historial de partidas.

Tecnologías Utilizadas

Lenguaje de Programación
- C#
- Framework
- .NET Framework / Windows Forms
  
Base de Datos
- MySQL
  
Herramientas de Desarrollo
- Visual Studio Community
- MySQL Workbench
- Git
- GitHub
  
Librerías Utilizadas
- MySql.Data
- System.Drawing
- System.Media
- Windows Forms

Instrucciones de Ejecución

Requisitos Previos
Antes de ejecutar la aplicación es necesario contar con:

- Visual Studio Community 2022 o superior.
- .NET Framework instalado.
- MySQL Server.
- MySQL Workbench (opcional para administración de la base de datos).
- Conector MySQL para .NET (MySql.Data).

Instalación y Ejecución

1. Clonar el repositorio desde GitHub
2. Abrir la solución del proyecto en Visual Studio.
3. Crear una base de datos MySQL para el proyecto.
4. Ejecutar los scripts SQL correspondientes para crear las tablas necesarias.
5. Configurar la cadena de conexión en el archivo (ConexionBD.cs)

Ejemplo:
private string cadenaConexion = "server=localhost;database=suite_videojuegos;user=root;password=;";
Modificar los valores según la configuración local de MySQL.

6. Restaurar los paquetes NuGet necesarios para el proyecto.
7. Compilar la solución desde Visual Studio.
8. Ejecutar la aplicación presionando F5
o seleccionando:

Depurar → Iniciar depuración

9. Al iniciar la aplicación se mostrará el menú principal, desde donde es posible:

- Jugar Tic-Tac-Toe.
- Jugar Damas Clásicas.
- Consultar el historial de partidas.
- Visualizar estadísticas de juego.
- Acceder a la configuración de conexión a la base de datos.

Funcionalidades Disponibles

- Registro automático de partidas.
- Registro automático de movimientos.
- Almacenamiento de ganadores.
- Historial de partidas.
- Dashboard de estadísticas.
- Sistema de turnos.
- Detección de ganadores y empates.
- Persistencia de datos mediante MySQL.

Estructura General del Proyecto

Suite de Videojuegos

Datos
- ConexionBD.cs
- MovimientoDAO.cs
- PartidaDAO.cs
  
Entidades
- Movimiento.cs
- Partida.cs
- Pieza.cs

Logica
- DamasLogica.cs
- TicTacToeLogica.cs

Forms
- FormMenu.cs
- FormTicTacToe.cs
- FormDamas.cs
- FormHistorial.cs

Program.cs

Notas:
- La aplicación requiere una conexión activa a MySQL para registrar y consultar información.
- Si la base de datos no está disponible, algunas funcionalidades relacionadas con el historial y estadísticas pueden no funcionar correctamente.
- Se recomienda ejecutar MySQL Server antes de iniciar la aplicación.
- El proyecto fue desarrollado utilizando Programación Orientada a Objetos (POO), Windows Forms y MySQL como sistema de persistencia de datos.

Integrantes

Nery Mariano Perez Arrue Carnet 0902-25-10109

Edgar Ismael Peláez Blanco 0902-25-14066

Mario David Ramirez Pop Carnet 0902-25-14020
