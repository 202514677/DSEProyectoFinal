IF DB_ID('BD_CINEPELIS') IS NOT NULL
BEGIN
    DROP DATABASE BD_CinePelis;
END
GO

CREATE DATABASE BD_CINEPELIS;
GO

USE BD_CINEPELIS;
GO

CREATE TABLE Usuarios
(
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,

    DNI VARCHAR(8) NOT NULL UNIQUE,

    Nombres VARCHAR(100) NOT NULL,

    Apellidos VARCHAR(100) NOT NULL,

    FechaNacimiento DATE NOT NULL,

    Celular VARCHAR(9) NOT NULL UNIQUE,

    Correo VARCHAR(150) NOT NULL UNIQUE,

    Password VARCHAR(100) NOT NULL,

    EsAdministrador BIT DEFAULT 0,

    Activo BIT DEFAULT 1,

    FechaRegistro DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE Cines
(
    IdCine INT IDENTITY(1,1) PRIMARY KEY,

    Nombre VARCHAR(100) NOT NULL,

    Ciudad VARCHAR(50) NOT NULL,

    Direccion VARCHAR(200) NOT NULL,

    Activo BIT DEFAULT 1
);
GO

CREATE TABLE Peliculas
(
    IdPelicula INT IDENTITY(1,1) PRIMARY KEY,

    Titulo VARCHAR(150) NOT NULL,

    Genero VARCHAR(50) NOT NULL,

    Duracion INT NOT NULL,

    Clasificacion VARCHAR(10) NOT NULL,

    Sinopsis VARCHAR(MAX),

    Estreno BIT DEFAULT 0,

    Activo BIT DEFAULT 1
);
GO

CREATE TABLE Horarios
(
    IdHorario INT IDENTITY(1,1) PRIMARY KEY,

    IdCine INT NOT NULL,

    IdPelicula INT NOT NULL,

    Fecha DATE NOT NULL,

    Hora TIME NOT NULL,

    TotalAsientos INT NOT NULL,

    CantidadVentaPublico INT NOT NULL,

    CantidadCorporativa INT DEFAULT 0,

    CantidadMarketing INT DEFAULT 0,

    Activo BIT DEFAULT 1,

    CONSTRAINT FK_Horario_Cine
        FOREIGN KEY(IdCine)
        REFERENCES Cines(IdCine),

    CONSTRAINT FK_Horario_Pelicula
        FOREIGN KEY(IdPelicula)
        REFERENCES Peliculas(IdPelicula)
);
GO

CREATE TABLE Promociones
(
    IdPromocion INT IDENTITY(1,1) PRIMARY KEY,

    Nombre VARCHAR(100) NOT NULL,

    Descripcion VARCHAR(300),

    Descuento DECIMAL(5,2),

    Activo BIT DEFAULT 1
);
GO

CREATE TABLE CategoriasDulceria
(
    IdCategoria INT IDENTITY(1,1) PRIMARY KEY,

    Nombre VARCHAR(100) NOT NULL,

    Activo BIT DEFAULT 1
);
GO

CREATE TABLE ProductosDulceria
(
    IdProducto INT IDENTITY(1,1) PRIMARY KEY,

    IdCategoria INT NOT NULL,

    Nombre VARCHAR(100) NOT NULL,

    Precio DECIMAL(10,2) NOT NULL,

    Stock INT NOT NULL,

    Activo BIT DEFAULT 1,

    CONSTRAINT FK_Producto_Categoria
        FOREIGN KEY(IdCategoria)
        REFERENCES CategoriasDulceria(IdCategoria)
);
GO

INSERT INTO Cines
(
Nombre,
Ciudad,
Direccion,
Activo
)
VALUES

('CinePelis Primavera','Lima','Av. Primavera 123',1),

('CinePelis Arequipa','Arequipa','Av. Ejército 456',1),

('CinePelis Cusco','Cusco','Av. La Cultura 789',1);
GO

INSERT INTO CategoriasDulceria
(
Nombre,
Activo
)
VALUES

('Combos',1),

('Canchita',1),

('Bebidas',1),

('Snacks',1),

('Helados',1);
GO

INSERT INTO Promociones
(
Nombre,
Descripcion,
Descuento,
Activo
)
VALUES

(
'Socios',
'Descuento para socios registrados',
15,
1
),

(
'2x1',
'Promoción dos entradas por una',
50,
1
),

(
'Estudiantes',
'Descuento con carnet estudiantil',
20,
1
);
GO

INSERT INTO Usuarios
(
DNI,
Nombres,
Apellidos,
FechaNacimiento,
Celular,
Correo,
Password,
EsAdministrador,
Activo
)
VALUES
(
'12345678',
'Administrador',
'Sistema',
'2026-06-01',
'999999999',
'admin@CinePelis.com',
'admin123',
1,
1
);
GO



