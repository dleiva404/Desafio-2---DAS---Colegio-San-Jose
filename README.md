# Colegio San José - Sistema de Gestión Académica

Aplicación web desarrollada en ASP.NET Core MVC para la gestión de expedientes académicos.

## Tecnologías

- C# / ASP.NET Core MVC .NET 8
- Entity Framework Core
- SQL Server
- Chart.js
- Bootstrap / SB Admin 2

## Requisitos previos

- Visual Studio 2022
- .NET 8 SDK
- SQL Server 2019 o superior
- SQL Server Management Studio (SSMS)

## Instalación

1. Clonar el repositorio:
git clone https://github.com/dleiva404/Desafio-2---DAS---Colegio-San-Jose.git

2. Crear la base de datos en SQL Server Management Studio:
- Abrir SSMS y conectarse al servidor
- Abrir el archivo Script_Colegio_San_Jose.sql
- Ejecutar el script completo

3. Configurar la cadena de conexión en appsettings.json:
"ConnectionStrings": {
  "DefaultConnection": "Server=TU_SERVIDOR;Database=ColegioSanJoseDB;Trusted_Connection=True;"
}

4. Abrir el proyecto en Visual Studio 2022

5. Ejecutar 

## Uso

### Alumnos
- Registrar alumnos con nombre, apellido, fecha de nacimiento y grado
- Editar y eliminar registros existentes

### Materias
- Registrar materias con nombre y docente asignado
- Editar y eliminar registros existentes

### Expedientes
- Asociar alumnos con materias y registrar nota final y observaciones
- Ver listado completo con nombre del alumno y materia

### Promedios y Estadísticas
- Ver promedio general por alumno
- Gráfico de barras: promedio de notas por alumno
- Gráfico de dona: distribución de aprobados vs reprobados
- Gráfico horizontal: top 3 mejores alumnos por grado con filtro interactivo

## Base de datos
Tablas:
- Alumno: AlumnoId, Nombres, Apellidos, FechaNacimiento, Grado
- Materia: MateriaId, NombreMateria, Docente
- Expediente: ExpedienteId, AlumnoId (FK), MateriaId (FK), NotaFinal, Observaciones

Script de creación: Script_Colegio_San_Jose.sql
