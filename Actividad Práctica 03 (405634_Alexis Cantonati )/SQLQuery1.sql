CREATE DATABASE DB_FACTURACION
GO
USE DB_FACTURACION
GO

CREATE TABLE formas_pago(
id_form int,
descripcion varchar(70)
CONSTRAINT pk_forma_pago PRIMARY KEY(id_form)
)

GO

CREATE TABLE facturas(
nro_factura int,
fecha DATETIME,
forma_pago int,
cliente varchar(80)
CONSTRAINT pk_facturas PRIMARY KEY (nro_factura)
CONSTRAINT fk_Forma_Pago FOREIGN KEY (forma_pago)
REFERENCES formas_pago(id_form)
)

GO

CREATE TABLE articulos(
id_articulo int,
nombre varchar(70),
precio_unitario float
CONSTRAINT pk_articulos PRIMARY KEY(id_articulo)
)

GO

CREATE TABLE detalles_facturas(
id_detalle int,
id_factura int,
id_articulo int,
cantidad int
CONSTRAINT pk_detalle PRIMARY KEY(id_detalle)
CONSTRAINT fk_factura FOREIGN KEY(id_factura)
REFERENCES facturas(nro_factura),
CONSTRAINT fk_articulo FOREIGN KEY(id_articulo)
REFERENCES articulos(id_articulo)
)

GO


INSERT INTO formas_pago VALUES(1,'tarjeta'),(2,'efectivo'),(3,'debito')

GO


INSERT INTO facturas VALUES(5,'2000/12/12',2,'jorge')

GO

INSERT INTO articulos VALUES(1,'manzana',100),(2,'banana',200),(3,'uva',300),(4,'higo',400),(5,'pera',500)

GO

CREATE PROCEDURE SP_BORRAR_FACTURA
@id int
AS
BEGIN
DELETE FROM facturas
WHERE nro_factura = @id
END

GO

CREATE PROCEDURE SP_BORRAR_ARTICULO
@id int
AS
BEGIN
DELETE FROM articulos
WHERE id_articulo = @id
END

GO

CREATE PROCEDURE SP_BORRAR_DETALLE
@id int
AS
BEGIN
DELETE FROM detalles_facturas
WHERE id_detalle = @id
END

GO

CREATE PROCEDURE SP_CREAR_FACTURA
@nro_factura int,
@fecha DATETIME,
@forma_pago int,
@cliente varchar(80)
AS
BEGIN
	INSERT INTO facturas VALUES(@nro_factura,@fecha,@forma_pago,@cliente)
END


GO

CREATE PROCEDURE SP_CREAR_ARTICULO
@id int,
@nombre varchar(80),
@precio int
AS
BEGIN
	INSERT INTO articulos VALUES(@id,@nombre,@precio)
END


GO

CREATE PROCEDURE SP_CREAR_DETALLE
@id int,
@factura varchar(80),
@articulo int,
@cantidad int
AS
BEGIN
	INSERT INTO detalles_facturas VALUES(@id,@factura,@articulo,@cantidad)
END

GO

CREATE PROCEDURE SP_TRAER_FACTURAS
AS
BEGIN
SELECT f.*,d.cantidad,d.id_detalle,a.*
FROM facturas f
join detalles_facturas d on f.nro_factura = d.id_factura
join articulos a on a.id_articulo = d.id_articulo

ORDER BY f.nro_factura
END

GO

CREATE PROCEDURE SP_TRAER_FACTURA_PARAM
@fecha datetime = null,
@forma_pago int = null
AS
BEGIN
SELECT *
FROM facturas
WHERE (@fecha is null or fecha = @fecha) and
(@forma_pago is null or forma_pago = @forma_pago)
END

GO

CREATE PROCEDURE SP_TRAER_ARTICULOS
AS
BEGIN
SELECT * FROM articulos
END

GO

CREATE PROCEDURE SP_TRAER_DETALLES
AS
BEGIN
SELECT * FROM detalles_facturas
END

GO

CREATE PROCEDURE SP_TRAER_FORMAS
AS
BEGIN
SELECT * FROM formas_pago
END

exec SP_BORRAR_FACTURA @id = 1

GO

CREATE PROCEDURE SP_EDITAR_FACTURA
@id int,
@fecha datetime,
@forma_pago int,
@cliente varchar(80)
AS
BEGIN
UPDATE facturas 
SET fecha = @fecha,forma_pago = @forma_pago, cliente = @cliente
WHERE nro_factura = @id
END

GO

CREATE PROCEDURE SP_EDITAR_ARTICULO
@id int,
@nombre varchar(80),
@precio int
AS
BEGIN
UPDATE articulos
SET nombre = @nombre, precio_unitario = @precio
WHERE id_articulo = @id
END
