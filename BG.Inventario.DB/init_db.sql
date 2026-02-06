use [master];
go
CREATE LOGIN [API_INVEN] 
WITH PASSWORD = N'BG2@261NV', 
CHECK_POLICY = ON; 
GO
create database BG_Inventario;
go
use BG_Inventario
go
CREATE USER [API_INVEN] FOR LOGIN [API_INVEN];
go
ALTER ROLE [db_owner] ADD MEMBER [API_INVEN];
go
create table [User](
	UserId int primary key identity,
	FirstName varchar(50) not null,
	LastName varchar(50) not null,
	UserName varchar(20) not null,
	Password varchar(20) not null
);
go
create table [Supplier] (
	SupplierId int primary key identity,
	Name varchar(50) not null,
	Email varchar(50) not null
);
go
create table [Product](
	ProductId int primary key identity,
	Name varchar(50) not null,
	Description varchar(50) not null,
	Status varchar(50) not null,
	Stock int not null,
	SalePrice  decimal(18,2) not null
);
go
create table [Product_Supplier](
	ProductId int not null, 
	SupplierId int not null, 
	PurcharsePrice decimal (18, 2) not null,
	MinimumOrderQuantity int not null
	
	primary key (ProductId, SupplierId),
	foreign key (ProductId) references Product(ProductId),
	foreign key (SupplierId) references Supplier(SupplierId)
)
go
create view vw_ProductSupplierSumary
as
select 
	p.ProductId,
	s.SupplierId, 
	p.Name AS ProductName,
    s.Name AS SupplierName,
    ps.PurcharsePrice,
    ps.MinimumOrderQuantity
from Product_Supplier  ps
inner join supplier s on s.SupplierId = ps.SupplierId
inner join product p on p.ProductId = ps.ProductId
go
insert into [User] 
 (FirstName, LastName, UserName, Password) 
values
('Saul', 'Consuegra', 'sconsuegra', 'conmor@26');
go

-- Suppliers
insert into [Supplier] (Name, Email) values
('TecnoSuministros SA', 'ventas@tecnosuministros.com'),
('Electrónica Global', 'compras@electronicaglobal.com'),
('Insumos Industriales Ltda', 'pedidos@insumosindustriales.com'),
('Distribuidora Nacional', 'contacto@distnacional.com');
go

-- Products
insert into [Product] (Name, Description, Status, Stock, SalePrice) values
('Laptop HP 15', 'Portátil 15 pulgadas, 8GB RAM', 'Activo', 25, 899.99),
('Monitor Dell 24"', 'Monitor Full HD 24 pulgadas', 'Activo', 40, 249.50),
('Teclado Mecánico', 'Teclado RGB switches Cherry MX', 'Activo', 60, 89.99),
('Mouse Inalámbrico', 'Mouse ergonómico 1600 DPI', 'Activo', 100, 35.00),
('Webcam HD 1080p', 'Cámara web con micrófono integrado', 'Activo', 30, 79.99);
go

-- Product_Supplier (relación Producto-Proveedor)
insert into [Product_Supplier] (ProductId, SupplierId, PurcharsePrice, MinimumOrderQuantity) values
(1, 1, 650.00, 5),   -- Laptop HP 15 - TecnoSuministros
(1, 4, 670.00, 10),  -- Laptop HP 15 - Distribuidora Nacional
(2, 1, 180.00, 10),  -- Monitor Dell - TecnoSuministros
(2, 2, 185.00, 5),   -- Monitor Dell - Electrónica Global
(3, 2, 55.00, 20),   -- Teclado Mecánico - Electrónica Global
(3, 3, 52.00, 15),   -- Teclado Mecánico - Insumos Industriales
(4, 3, 22.00, 50),   -- Mouse Inalámbrico - Insumos Industriales
(4, 4, 24.00, 30),   -- Mouse Inalámbrico - Distribuidora Nacional
(5, 1, 45.00, 10),   -- Webcam HD - TecnoSuministros
(5, 2, 48.00, 5);    -- Webcam HD - Electrónica Global
go
