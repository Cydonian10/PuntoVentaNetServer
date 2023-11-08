/*
* DDL de Tablas
*/
use Pedidos;

create table Auth 
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	Nombre VARCHAR(100),
	Email VARCHAR(100),
	Password VARCHAR(100)
);

create table Users
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	Nombre VARCHAR(100),
	Email VARCHAR(100),
	Telefono VARCHAR(50),
);

create table Products
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	Nombre VARCHAR(100),
	Precio Decimal(12,2),
	Cantidad INT,
	Description TEXT,
	FechaCreacion DateTime
);



/*
*  Insertar productos
*/
create procedure InsertProduct 
	@Id UNIQUEIDENTIFIER,
	@Nombre VARCHAR(100),
	@Precio Decimal(12,2),
	@Cantidad INT,
	@Description TEXT,
	@FechaCreacion DateTime
as 
begin
	insert into Products
	values (@Id, @Nombre, @Precio, @Cantidad, @Description, @FechaCreacion)
end;

create procedure UpdateProduct
	@Id UNIQUEIDENTIFIER,
	@Nombre VARCHAR(100),
	@Precio Decimal(12,2),
	@Cantidad INT,
	@Description TEXT,
	@FechaCreacion DateTime
as begin
	update Products set Nombre=@Nombre, Precio=@Precio, Cantidad=@Cantidad, Description=@Description
		where Id=@Id
end;

create procedure DeleteProduct
	@Id UNIQUEIDENTIFIER
as begin
	delete from Products where Id=@Id
end;

create procedure GetProducts
as begin
	select * from Products;
end;

/*
* Register Auth
*/
create procedure RegisterAuth
	@Id UNIQUEIDENTIFIER,
	@Nombre VARCHAR(100),
	@Email VARCHAR(100),
	@Password VARCHAR(100)
as begin
	INSERT INTO Auth
	VALUES (@Id,@Nombre,@Email,@Password)
end;