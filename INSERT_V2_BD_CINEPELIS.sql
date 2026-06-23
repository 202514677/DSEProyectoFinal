INSERT INTO Roles
(
Nombre,
Activo
)
VALUES

('ADMINISTRADOR',1),

('SUPERVISOR',1),

('CAJERO',1),

('ATENCION_CLIENTE',1),

('MARKETING',1),

('INVITADO',1);


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
Activo,
FechaRegistro,
Rol,
TokenAcceso,
FechaToken,
FechaActualizacion
)
VALUES

(
'12345678',
'Administrador',
'Sistema',
'1990-01-01',
'999999999',
'admin@cinepelis.com',
'1234',
1,
1,
GETDATE(),
'ADMINISTRADOR',
'',
GETDATE(),
GETDATE()
),

(
'85274163',
'Percy Martin',
'Aguayo',
'1990-02-04',
'961757428',
'percymartin@cinepelis.com',
'1234',
0,
1,
GETDATE(),
'SUPERVISOR',
'',
GETDATE(),
GETDATE()
),

(
'74185296',
'Carlos',
'Perez',
'1991-03-20',
'987654321',
'cperez@cinepelis.com',
'1234',
0,
1,
GETDATE(),
'CAJERO',
'',
GETDATE(),
GETDATE()
),

(
'96385274',
'Rosa',
'Torres',
'1992-05-15',
'912345678',
'rtorres@cinepelis.com',
'1234',
0,
1,
GETDATE(),
'ATENCION_CLIENTE',
'',
GETDATE(),
GETDATE()
),

(
'78945612',
'Luis',
'Ramirez',
'1989-07-18',
'923456789',
'lramirez@cinepelis.com',
'1234',
0,
1,
GETDATE(),
'MARKETING',
'',
GETDATE(),
GETDATE()
),

(
'45678912',
'Juan',
'Castro',
'1993-08-22',
'934567891',
'jcastro@cinepelis.com',
'1234',
0,
1,
GETDATE(),
'INVITADO',
'',
GETDATE(),
GETDATE()
);

INSERT INTO Clientes
(
Dni,
Nombre,
Apellido,
Celular,
Email,
Activo,
FechaRegistro,
FechaActualizacion,
Password,
TokenAcceso,
FechaToken
)
VALUES

(
'43215678',
'Jose',
'Guzman',
'987654321',
'joseguzman@emailejemplo.com',
1,
GETDATE(),
GETDATE(),
'1234',
'',
GETDATE()
),

(
'74125896',
'Pedro',
'Rojas',
'956789123',
'pedrorojas@emailejemplo.com',
1,
GETDATE(),
GETDATE(),
'1234',
'',
GETDATE()
),

(
'85236974',
'Luis',
'Torres',
'945678912',
'luistorres@emailejemplo.com',
1,
GETDATE(),
GETDATE(),
'1234',
'',
GETDATE()
),

(
'96325874',
'Ana',
'Flores',
'934567891',
'anaflores@emailejemplo.com',
1,
GETDATE(),
GETDATE(),
'1234',
'',
GETDATE()
),

(
'25874196',
'Maria',
'Lopez',
'923456789',
'marialopez@emailejemplo.com',
1,
GETDATE(),
GETDATE(),
'1234',
'',
GETDATE()
),

(
'14785236',
'Cesar',
'Mendoza',
'912345678',
'cesarmendoza@emailejemplo.com',
1,
GETDATE(),
GETDATE(),
'1234',
'',
GETDATE()
);



INSERT INTO CategoriasDulceria
(
Nombre,
Activo
)
VALUES

('CANCHITAS',1),

('BEBIDAS',1),

('COMBOS',1),

('NACHOS',1),

('HELADOS',1),

('CHOCOLATES',1);


INSERT INTO Cines
(
Nombre,
Ciudad,
Direccion,
GoogleMaps,
Imagen,
CantidadSalas2D,
CantidadSalas3D,
CantidadSalas4K,
CantidadSalasPrime,
CantidadSalasEventos,
IdUsuario,
Activo,
FechaRegistro,
FechaActualizacion
)
VALUES

(
'CinePelis Primavera',
'LIMA',
'Av. Primavera 123',
'https://maps.google.com',
'',
4,
2,
1,
2,
1,
1,
1,
GETDATE(),
GETDATE()
),

(
'CinePelis San Miguel',
'LIMA',
'Av. La Marina 2500',
'https://maps.google.com',
'',
4,
2,
1,
2,
1,
1,
1,
GETDATE(),
GETDATE()
),

(
'CinePelis Arequipa Centro',
'AREQUIPA',
'Av. Ejercito 1500',
'https://maps.google.com',
'',
3,
2,
1,
1,
1,
1,
1,
GETDATE(),
GETDATE()
),

(
'CinePelis Cayma',
'AREQUIPA',
'Av. Cayma 300',
'https://maps.google.com',
'',
3,
1,
1,
1,
1,
1,
1,
GETDATE(),
GETDATE()
),

(
'CinePelis Cusco Plaza',
'CUZCO',
'Av. El Sol 500',
'https://maps.google.com',
'',
3,
1,
1,
1,
1,
1,
1,
GETDATE(),
GETDATE()
),

(
'CinePelis Wanchaq',
'CUZCO',
'Av. La Cultura 1000',
'https://maps.google.com',
'',
2,
1,
1,
1,
1,
1,
1,
GETDATE(),
GETDATE()
);


INSERT INTO Peliculas
(
Titulo,
Genero,
Duracion,
Clasificacion,
Sinopsis,
Estreno,
Activo,
FechaIngreso,
FechaSalida,
Idioma,
FechaRegistro,
FechaActualizacion,
Imagen
)
VALUES

(
'En la Zona Gris',
'Thriller',
108,
'+14',
'Gira en torno a dos especialistas en extracción que tienen que designar una ruta de escape para una negociadora de alto rango.',
0,
1,
'2026-05-01',
'2026-07-31',
'SUBTITULADA,DOBLADA',
GETDATE(),
GETDATE(),
'C:\DSEProyectoFinal\Imagenes\Peliculas\ZonaGris.jpg'
),

(
'Toy Story 5',
'Animación',
102,
'APT',
'Los juguetes están de regreso y esta vez, Buzz Lightyear, Woody y Jessie ven amenazado el propósito de jugar cuando aparece una nueva tableta llamada Lilypad.',
1,
1,
'2026-05-01',
'2026-07-31',
'SUBTITULADA,DOBLADA',
GETDATE(),
GETDATE(),
'C:\DSEProyectoFinal\Imagenes\Peliculas\ToyStory5.jpg'
),

(
'El Dia de la Revelacion',
'Ciencia Ficción',
146,
'+14',
'Si descubrieras que no estamos solos. En 2026 la verdad pertenece a siete mil millones de personas.',
0,
1,
'2026-05-01',
'2026-07-31',
'SUBTITULADA,DOBLADA',
GETDATE(),
GETDATE(),
'C:\DSEProyectoFinal\Imagenes\Peliculas\Revelacion.jpg'
),

(
'Amos del Universo',
'Acción',
141,
'+14',
'He-Man, el hombre más poderoso del universo, enfrenta a Skeletor para salvar Eternia.',
0,
1,
'2026-05-01',
'2026-07-31',
'SUBTITULADA,DOBLADA',
GETDATE(),
GETDATE(),
'C:\DSEProyectoFinal\Imagenes\Peliculas\AmosdelUniverso.jpg'
),

(
'Paucartambo',
'Documental',
71,
'APT',
'Documental desarrollado en la Fiesta de la Virgen del Carmen de Paucartambo mostrando la cosmovisión andina.',
0,
1,
'2026-05-01',
'2026-07-31',
'DOBLADA',
GETDATE(),
GETDATE(),
'C:\DSEProyectoFinal\Imagenes\Peliculas\Paucartambo.jpg'
),

(
'Scary Movie Terrorificamente Incorrecta',
'Comedia',
96,
'+18',
'Los hermanos Wayans regresan para destruir todos los clichés del cine de terror.',
0,
1,
'2026-05-01',
'2026-07-31',
'SUBTITULADA,DOBLADA',
GETDATE(),
GETDATE(),
'C:\DSEProyectoFinal\Imagenes\Peliculas\ScaryMovie.jpg'
),

(
'Amando a Amanda',
'Comedia',
90,
'+14',
'Fernando descubre que olvidar a Amanda es más difícil de lo que parece.',
0,
1,
'2026-05-01',
'2026-07-31',
'DOBLADA',
GETDATE(),
GETDATE(),
'C:\DSEProyectoFinal\Imagenes\Peliculas\AmandoAmanda.jpg'
),

(
'Backrooms',
'Terror',
110,
'+14',
'Una extraña puerta aparece en el sótano de una sala de exposición de muebles.',
0,
1,
'2026-05-01',
'2026-07-31',
'SUBTITULADA,DOBLADA',
GETDATE(),
GETDATE(),
'C:\DSEProyectoFinal\Imagenes\Peliculas\Backrooms.jpg'
),

(
'The Mandalorian and Grogu',
'Acción',
133,
'APT',
'Din Djarin y Grogu vuelven para proteger la galaxia y apoyar a la Nueva República.',
1,
1,
'2026-05-01',
'2026-07-31',
'SUBTITULADA,DOBLADA',
GETDATE(),
GETDATE(),
'C:\DSEProyectoFinal\Imagenes\Peliculas\TheMandalorian.jpg'
),

(
'Obsesion',
'Terror',
108,
'+14',
'Un deseo aparentemente inocente termina convirtiéndose en una oscura pesadilla.',
0,
1,
'2026-05-01',
'2026-07-31',
'SUBTITULADA,DOBLADA',
GETDATE(),
GETDATE(),
'C:\DSEProyectoFinal\Imagenes\Peliculas\Obsesion.jpg'
),

(
'Las Ovejas Detectives',
'Comedia',
110,
'APT',
'Un grupo de ovejas intenta resolver el asesinato de su pastor.',
0,
1,
'2026-05-01',
'2026-07-31',
'DOBLADA',
GETDATE(),
GETDATE(),
'C:\DSEProyectoFinal\Imagenes\Peliculas\LasOvejasDetectives.jpg'
),

(
'El Diablo Viste a la Moda 2',
'Drama',
120,
'+14',
'Miranda Priestly se enfrenta a una nueva rival en medio de la decadencia de los medios impresos.',
0,
1,
'2026-05-01',
'2026-07-31',
'SUBTITULADA,DOBLADA',
GETDATE(),
GETDATE(),
'C:\DSEProyectoFinal\Imagenes\Peliculas\DVModa2.jpg'
),

(
'Michael',
'Drama',
127,
'+14',
'La historia de Michael Jackson desde los Jackson Five hasta convertirse en un icono mundial.',
1,
1,
'2026-05-01',
'2026-07-31',
'SUBTITULADA,DOBLADA',
GETDATE(),
GETDATE(),
'C:\DSEProyectoFinal\Imagenes\Peliculas\Michael.jpg'
);

INSERT INTO Cartelera
(
IdPelicula,
IdCine,
FechaInicio,
FechaFinalizacion,
FechaRegistro,
FechaActualizacion,
Activo,
EsPromocion,
DescripcionPromocion,
PorcentajeDescuento
)
VALUES

-- LIMA
(2,1,'2026-06-22','2026-07-31',GETDATE(),GETDATE(),1,1,'3 entradas por el precio de 2',33.33),

(1,1,'2026-06-22','2026-07-20',GETDATE(),GETDATE(),1,0,'',0),

(8,1,'2026-06-23','2026-07-15',GETDATE(),GETDATE(),1,0,'',0),

(4,2,'2026-06-23','2026-07-31',GETDATE(),GETDATE(),1,0,'',0),

(9,2,'2026-06-24','2026-07-31',GETDATE(),GETDATE(),1,0,'',0),

(13,2,'2026-06-24','2026-07-31',GETDATE(),GETDATE(),1,0,'',0),

-- AREQUIPA
(10,3,'2026-06-25','2026-07-31',GETDATE(),GETDATE(),1,1,'20% descuento Arequipa',20),

(7,3,'2026-06-25','2026-07-25',GETDATE(),GETDATE(),1,1,'20% descuento Arequipa',20),

(6,4,'2026-06-26','2026-07-31',GETDATE(),GETDATE(),1,1,'20% descuento Arequipa',20),

(3,4,'2026-07-01','2026-07-31',GETDATE(),GETDATE(),1,1,'20% descuento Arequipa',20),

-- CUZCO
(5,5,'2026-06-27','2026-07-31',GETDATE(),GETDATE(),1,1,'20% descuento Cuzco',20),

(11,5,'2026-07-02','2026-07-31',GETDATE(),GETDATE(),1,1,'20% descuento Cuzco',20),

(12,6,'2026-07-05','2026-07-31',GETDATE(),GETDATE(),1,1,'20% descuento Cuzco',20);


INSERT INTO Horarios
(
IdCine,
IdCartelera,
NumSala,
TipoSala,
FechaInicio,
FechaFinalizacion,
PrecioVentaPublico,
TotalAsientos,
CantidadVentaPublico,
CantidadCorporativo,
CantidadMarketing,
EntradasVendidas,
Activo,
FechaRegistro,
FechaActualizacion
)
VALUES

(1,1,1,'2D','2026-06-22 11:00','2026-06-22 13:00',22.90,120,0,0,0,0,1,GETDATE(),GETDATE()),

(1,1,1,'2D','2026-06-22 16:00','2026-06-22 18:00',22.90,120,0,0,0,0,1,GETDATE(),GETDATE()),

(1,1,2,'3D','2026-06-22 19:00','2026-06-22 21:00',28.90,150,0,0,0,0,1,GETDATE(),GETDATE()),

(1,2,1,'2D','2026-06-22 13:30','2026-06-22 15:30',20.90,120,0,0,0,0,1,GETDATE(),GETDATE()),

(1,3,2,'PRIME','2026-06-23 18:30','2026-06-23 20:30',32.90,100,0,0,0,0,1,GETDATE(),GETDATE()),

(2,4,1,'2D','2026-06-23 11:00','2026-06-23 13:30',21.90,120,0,0,0,0,1,GETDATE(),GETDATE()),

(2,5,2,'PRIME','2026-06-24 19:00','2026-06-24 21:30',34.90,100,0,0,0,0,1,GETDATE(),GETDATE()),

(2,6,3,'XTREME','2026-06-24 21:00','2026-06-24 23:30',39.90,180,0,0,0,0,1,GETDATE(),GETDATE()),

(3,7,1,'2D','2026-06-25 16:00','2026-06-25 18:00',19.90,120,0,0,0,0,1,GETDATE(),GETDATE()),

(3,8,2,'PRIME','2026-06-25 19:00','2026-06-25 21:00',29.90,100,0,0,0,0,1,GETDATE(),GETDATE()),

(4,9,1,'2D','2026-06-26 20:00','2026-06-26 22:00',21.90,120,0,0,0,0,1,GETDATE(),GETDATE()),

(4,10,2,'PRIME','2026-07-01 19:00','2026-07-01 21:30',31.90,100,0,0,0,0,1,GETDATE(),GETDATE()),

(5,11,1,'2D','2026-06-27 18:00','2026-06-27 20:00',18.90,120,0,0,0,0,1,GETDATE(),GETDATE()),

(5,12,2,'2D','2026-07-02 17:00','2026-07-02 19:00',18.90,120,0,0,0,0,1,GETDATE(),GETDATE()),

(6,13,1,'2D','2026-07-05 19:00','2026-07-05 21:00',22.90,120,0,0,0,0,1,GETDATE(),GETDATE());

--INSERT INTO Usuarios
--(
--DNI,
--Nombres,
--Apellidos,
--FechaNacimiento,
--Celular,
--Correo,
--Password,
--EsAdministrador,
--Activo,
--FechaRegistro,
--Rol,
--TokenAcceso,
--FechaToken,
--FechaActualizacion
--)
--VALUES

--(
--'12345678',
--'Administrador',
--'Sistema',
--'1990-01-01',
--'999999999',
--'admin@cinepelis.com',
--'1234',
--1,
--1,
--GETDATE(),
--'ADMINISTRADOR',
--'',
--GETDATE(),
--GETDATE()
--),

--(
--'85274163',
--'Percy Martin',
--'Aguayo',
--'1990-02-04',
--'961757428',
--'percymartin@cinepelis.com',
--'1234',
--0,
--1,
--GETDATE(),
--'SUPERVISOR',
--'',
--GETDATE(),
--GETDATE()
--),

--(
--'74185296',
--'Carlos',
--'Perez',
--'1991-03-20',
--'987654321',
--'cperez@cinepelis.com',
--'1234',
--0,
--1,
--GETDATE(),
--'CAJERO',
--'',
--GETDATE(),
--GETDATE()
--),

--(
--'96385274',
--'Rosa',
--'Torres',
--'1992-05-15',
--'912345678',
--'rtorres@cinepelis.com',
--'1234',
--0,
--1,
--GETDATE(),
--'ATENCION_CLIENTE',
--'',
--GETDATE(),
--GETDATE()
--),

--(
--'78945612',
--'Luis',
--'Ramirez',
--'1989-07-18',
--'923456789',
--'lramirez@cinepelis.com',
--'1234',
--0,
--1,
--GETDATE(),
--'MARKETING',
--'',
--GETDATE(),
--GETDATE()
--),

--(
--'45678912',
--'Juan',
--'Castro',
--'1993-08-22',
--'934567891',
--'jcastro@cinepelis.com',
--'1234',
--0,
--1,
--GETDATE(),
--'INVITADO',
--'',
--GETDATE(),
--GETDATE()
--);


INSERT INTO ProductosDulceria
(
Nombre,
Descripcion,
Categoria,
Precio,
Stock,
Imagen,
Activo,
FechaRegistro,
FechaActualizacion,
EsPromocion,
DescripcionPromocion
)
VALUES

-- CANCHITAS

(
'Canchita Grande',
'Canchita tamaño grande',
'CANCHITAS',
18.90,
100,
'C:\DSEProyectoFinal\Imagenes\Dulceria\Canchita_Grande_250x250.png',
1,
GETDATE(),
GETDATE(),
0,
''
),

(
'Canchita Mediana',
'Canchita tamaño mediano',
'CANCHITAS',
14.90,
120,
'C:\DSEProyectoFinal\Imagenes\Dulceria\Canchita_Mediana_250x250.png',
1,
GETDATE(),
GETDATE(),
0,
''
),

(
'Canchita Personal',
'Canchita tamaño personal',
'CANCHITAS',
10.90,
150,
'C:\DSEProyectoFinal\Imagenes\Dulceria\Canchita_Personal_250x250.png',
1,
GETDATE(),
GETDATE(),
0,
''
),

-- BEBIDAS

(
'Bebida Vaso',
'Bebida en vaso',
'BEBIDAS',
9.90,
100,
'C:\DSEProyectoFinal\Imagenes\Dulceria\Bebida_Vaso_250x250.png',
1,
GETDATE(),
GETDATE(),
0,
''
),

(
'Bebida Botella',
'Bebida embotellada',
'BEBIDAS',
8.90,
100,
'C:\DSEProyectoFinal\Imagenes\Dulceria\Bebidas_Botellas_250x250.png',
1,
GETDATE(),
GETDATE(),
0,
''
),

(
'Gaseosa Grande',
'Gaseosa tamaño grande',
'BEBIDAS',
12.90,
100,
'C:\DSEProyectoFinal\Imagenes\Dulceria\Bebida_Gaseosa_250x250.png',
1,
GETDATE(),
GETDATE(),
1,
'Gratis por compras mayores a S/60'
),

-- COMBOS

(
'Combo Personal',
'Combo personal de cine',
'COMBOS',
19.90,
80,
'C:\DSEProyectoFinal\Imagenes\Dulceria\Combo_Personal_250x250.png',
1,
GETDATE(),
GETDATE(),
0,
''
),

(
'Combo Mediano',
'Combo mediano de cine',
'COMBOS',
29.90,
80,
'C:\DSEProyectoFinal\Imagenes\Dulceria\Combo_Mediano_250x250.png',
1,
GETDATE(),
GETDATE(),
1,
'Producto en promoción'
),

(
'Combo Grande',
'Combo grande de cine',
'COMBOS',
39.90,
80,
'C:\DSEProyectoFinal\Imagenes\Dulceria\Combo_Grande_250x250.png',
1,
GETDATE(),
GETDATE(),
1,
'Producto en promoción'
),

-- NACHOS

(
'Nachos Grandes',
'Nachos tamaño grande',
'NACHOS',
18.90,
80,
'C:\DSEProyectoFinal\Imagenes\Dulceria\Nachos_Grandes_250x250.png',
1,
GETDATE(),
GETDATE(),
0,
''
),

(
'Nachos Medianos',
'Nachos tamaño mediano',
'NACHOS',
15.90,
80,
'C:\DSEProyectoFinal\Imagenes\Dulceria\Nachos_Medianos_250x250.png',
1,
GETDATE(),
GETDATE(),
0,
''
),

(
'Nachos con Queso',
'Nachos con salsa de queso',
'NACHOS',
21.90,
80,
'C:\DSEProyectoFinal\Imagenes\Dulceria\Nachos_Queso_250x250.png',
1,
GETDATE(),
GETDATE(),
0,
''
),

-- HELADOS

(
'Helado 1 Bola',
'Helado de una bola',
'HELADOS',
8.90,
80,
'C:\DSEProyectoFinal\Imagenes\Dulceria\Helado_1_Bola_250x250.png',
1,
GETDATE(),
GETDATE(),
0,
''
),

(
'Helado 2 Bolas',
'Helado de dos bolas',
'HELADOS',
12.90,
80,
'C:\DSEProyectoFinal\Imagenes\Dulceria\Helado_2_Bolas_250x250.png',
1,
GETDATE(),
GETDATE(),
0,
''
),

(
'Helado Copa',
'Helado en copa especial',
'HELADOS',
16.90,
80,
'C:\DSEProyectoFinal\Imagenes\Dulceria\Helado_Copa_250x250.png',
1,
GETDATE(),
GETDATE(),
0,
''
),

-- CHOCOLATES

(
'Chocolate 50g',
'Chocolate de 50 gramos',
'CHOCOLATES',
7.90,
100,
'C:\DSEProyectoFinal\Imagenes\Dulceria\Chocolate_50g_250x250.png',
1,
GETDATE(),
GETDATE(),
0,
''
),

(
'Chocolate 100g',
'Chocolate de 100 gramos',
'CHOCOLATES',
10.90,
100,
'C:\DSEProyectoFinal\Imagenes\Dulceria\Chocolate_100g_250x250.png',
1,
GETDATE(),
GETDATE(),
0,
''
),

(
'Chocolate Variados',
'Caja surtida de chocolates',
'CHOCOLATES',
15.90,
100,
'C:\DSEProyectoFinal\Imagenes\Dulceria\Chocolate_Variados_250x250.png',
1,
GETDATE(),
GETDATE(),
0,
''
);


INSERT INTO Ventas
(
IdCliente,
IdHorario,
FechaVenta,
CantidadEntradas,
SubTotal,
IGV,
Total,
MetodoPago,
NumeroAutorizacion,
Ultimos4Tarjeta,
Estado,
CodigoTicket,
UsuarioRegistro,
QRTexto
)
VALUES

(
1,
1,
GETDATE(),
2,
38.81,
6.99,
45.80,
'YAPE',
'YAPE001',
'',
'PAGADO',
'TK-202606220001',
1,
'TICKET TK-202606220001'
),

(
2,
4,
GETDATE(),
3,
58.22,
10.48,
68.70,
'TARJETA',
'',
'4587',
'PAGADO',
'TK-202606220002',
1,
'TICKET TK-202606220002'
),

(
3,
5,
GETDATE(),
1,
16.86,
3.04,
19.90,
'PLIN',
'PLIN001',
'',
'PAGADO',
'TK-202606220003',
1,
'TICKET TK-202606220003'
),

(
4,
7,
GETDATE(),
2,
49.15,
8.85,
58.00,
'YAPE',
'YAPE002',
'',
'PAGADO',
'TK-202606220004',
2,
'TICKET TK-202606220004'
),

(
5,
8,
GETDATE(),
4,
91.19,
16.41,
107.60,
'TARJETA',
'',
'9825',
'PAGADO',
'TK-202606220005',
2,
'TICKET TK-202606220005'
),

(
6,
10,
GETDATE(),
2,
42.20,
7.60,
49.80,
'PLIN',
'PLIN002',
'',
'PAGADO',
'TK-202606220006',
3,
'TICKET TK-202606220006'
);

INSERT INTO DetalleVenta
(
IdVenta,
Asiento,
Precio
)
VALUES

(1,'A1',22.90),
(1,'A2',22.90),

(2,'B1',22.90),
(2,'B2',22.90),
(2,'B3',22.90),

(3,'C5',19.90),

(4,'D1',29.00),
(4,'D2',29.00),

(5,'E1',26.90),
(5,'E2',26.90),
(5,'E3',26.90),
(5,'E4',26.90),

(6,'F1',24.90),
(6,'F2',24.90);

INSERT INTO VentasDulceria
(
IdCliente,
FechaVenta,
SubTotal,
IGV,
Total,
MetodoPago,
NumeroAutorizacion,
Ultimos4Tarjeta,
Estado,
CodigoTicket,
UsuarioRegistro,
QRTexto
)
VALUES

(
1,
GETDATE(),
39.75,
7.15,
46.90,
'YAPE',
'YAPE001',
'',
'PAGADO',
'VD-202606220001',
1,
'TICKET VD-202606220001'
),

(
2,
GETDATE(),
57.54,
10.36,
67.90,
'TARJETA',
'',
'4587',
'PAGADO',
'VD-202606220002',
1,
'TICKET VD-202606220002'
),

(
3,
GETDATE(),
24.49,
4.41,
28.90,
'PLIN',
'PLIN001',
'',
'PAGADO',
'VD-202606220003',
2,
'TICKET VD-202606220003'
),

(
4,
GETDATE(),
33.81,
6.09,
39.90,
'YAPE',
'YAPE002',
'',
'PAGADO',
'VD-202606220004',
2,
'TICKET VD-202606220004'
),

(
5,
GETDATE(),
74.49,
13.41,
87.90,
'TARJETA',
'',
'9825',
'PAGADO',
'VD-202606220005',
3,
'TICKET VD-202606220005'
),

(
6,
GETDATE(),
49.07,
8.83,
57.90,
'PLIN',
'PLIN002',
'',
'PAGADO',
'VD-202606220006',
3,
'TICKET VD-202606220006'
);

INSERT INTO DetalleVentaDulceria
(
IdVentaDulceria,
IdProducto,
Cantidad,
Precio,
SubTotal
)
VALUES

-- Venta 1
(1,1,1,18.90,18.90),
(1,6,1,12.90,12.90),
(1,16,2,7.90,15.80),

-- Venta 2
(2,9,1,39.90,39.90),
(2,12,1,21.90,21.90),
(2,13,1,8.90,8.90),

-- Venta 3
(3,8,1,29.90,29.90),

-- Venta 4
(4,7,1,19.90,19.90),
(4,10,1,18.90,18.90),

-- Venta 5
(5,9,2,39.90,79.80),
(5,15,1,16.90,16.90),

-- Venta 6
(6,1,1,18.90,18.90),
(6,11,1,15.90,15.90),
(6,17,2,10.90,21.80);