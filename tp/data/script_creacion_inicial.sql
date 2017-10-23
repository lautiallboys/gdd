USE [GD2C2017]

-- ELIMINACION DE TABLAS NECESARIAS

IF OBJECT_ID('POSTRESQL.UsuarioSucursal', 'U') IS NOT NULL
DROP TABLE POSTRESQL.UsuarioSucursal

IF OBJECT_ID('POSTRESQL.UsuarioRol', 'U') IS NOT NULL
DROP TABLE POSTRESQL.UsuarioRol

IF OBJECT_ID('POSTRESQL.RubroEmpresa', 'U') IS NOT NULL
DROP TABLE POSTRESQL.RubroEmpresa

IF OBJECT_ID('POSTRESQL.FuncionalidadRol', 'U') IS NOT NULL
DROP TABLE POSTRESQL.FuncionalidadRol

IF OBJECT_ID('POSTRESQL.ItemFactura', 'U') IS NOT NULL
DROP TABLE POSTRESQL.ItemFactura

IF OBJECT_ID('POSTRESQL.Devolucion', 'U') IS NOT NULL
DROP TABLE POSTRESQL.Devolucion

IF OBJECT_ID('POSTRESQL.PagoFactura', 'U') IS NOT NULL
DROP TABLE POSTRESQL.PagoFactura

IF OBJECT_ID('POSTRESQL.Pago', 'U') IS NOT NULL
DROP TABLE POSTRESQL.Pago

IF OBJECT_ID('POSTRESQL.Factura', 'U') IS NOT NULL
DROP TABLE POSTRESQL.Factura

IF OBJECT_ID('POSTRESQL.MedioPago', 'U') IS NOT NULL
DROP TABLE POSTRESQL.MedioPago

IF OBJECT_ID('POSTRESQL.Sucursal', 'U') IS NOT NULL
DROP TABLE POSTRESQL.Sucursal

IF OBJECT_ID('POSTRESQL.Usuario', 'U') IS NOT NULL
DROP TABLE POSTRESQL.Usuario

IF OBJECT_ID('POSTRESQL.Rubro', 'U') IS NOT NULL
DROP TABLE POSTRESQL.Rubro

IF OBJECT_ID('POSTRESQL.Rol', 'U') IS NOT NULL
DROP TABLE POSTRESQL.Rol

IF OBJECT_ID('POSTRESQL.Rendicion', 'U') IS NOT NULL
DROP TABLE POSTRESQL.Rendicion

IF OBJECT_ID('POSTRESQL.Funcionalidad', 'U') IS NOT NULL
DROP TABLE POSTRESQL.Funcionalidad

IF OBJECT_ID('POSTRESQL.Empresa', 'U') IS NOT NULL
DROP TABLE POSTRESQL.Empresa

IF OBJECT_ID('POSTRESQL.Cliente', 'U') IS NOT NULL
DROP TABLE POSTRESQL.Cliente

IF EXISTS (SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = 'POSTRESQL')
    DROP SCHEMA POSTRESQL
GO

/* Creación del esquema */

CREATE SCHEMA POSTRESQL AUTHORIZATION gd;
GO




GO
/****** Object:  User [gd]    Script Date: 10/10/2017 10:42:15 ******/
--CREATE USER [gd] FOR LOGIN [gd] WITH DEFAULT_SCHEMA=[POSTRESQL]


GO
CREATE TABLE POSTRESQL.Cliente(
	clie_id INT IDENTITY(1,1) PRIMARY KEY,
	clie_dni NUMERIC(18,0) UNIQUE ,
	clie_apellido NVARCHAR(225) ,
	clie_nombre  NVARCHAR(225) ,
	clie_fecha_nac DATETIME ,
	clie_mail NVARCHAR(225) ,
	clie_direccion NVARCHAR(225) ,
	clie_codigo_postal NUMERIC(18,0) ,
	clie_habilitado BIT
)


GO
CREATE TABLE POSTRESQL.Devolucion(
	devo_id INT PRIMARY KEY,
	[devo_pago_factura] [numeric](6, 0) ,
	devo_motivo NVARCHAR(225) ,
	devo_fecha DATETIME
)



GO
CREATE TABLE [POSTRESQL].[Empresa](
	empr_id INT IDENTITY(1,1) PRIMARY KEY,
	empr_nombre NVARCHAR(50) ,
	empr_cuit NVARCHAR(50) ,
	empr_direccion NVARCHAR(225) ,
	empr_habilitado BIT
)
GO

CREATE TABLE [POSTRESQL].[Rendicion](
	[rend_id] INT PRIMARY KEY,
	[rend_fecha] DATETIME ,
	[rend_total] [decimal](12, 2) ,
	[rend_coef_comision] [float] ,
	[rend_concepto] [char](100) ,
	rend_empresa INT NOT NULL FOREIGN KEY REFERENCES POSTRESQL.Empresa(empr_id))
GO

CREATE TABLE POSTRESQL.Factura(
    fact_numero INT PRIMARY KEY,
    fact_cliente INT NOT NULL FOREIGN KEY REFERENCES POSTRESQL.Cliente(clie_id),
	fact_empresa INT NOT NULL FOREIGN KEY REFERENCES POSTRESQL.Empresa(empr_id),
    fact_fecha DATETIME,
	fact_fecha_vencimiento DATETIME,
	fact_total INT, 
	fact_cobrada BIT ,
	fact_rendicion INT FOREIGN KEY REFERENCES POSTRESQL.Rendicion(rend_id)) 

GO
CREATE TABLE [POSTRESQL].[Funcionalidad](
	[func_id] INT IDENTITY PRIMARY KEY,
	[func_descripcion] [char](100))
GO

CREATE TABLE [POSTRESQL].[Rol](
	[rol_id] INT IDENTITY PRIMARY KEY,
	[rol_nombre] [char](50) ,
	[rol_habilitado] [bit])


GO


CREATE TABLE [POSTRESQL].[FuncionalidadRol](
	[func_rol_rol] INT NOT NULL FOREIGN KEY REFERENCES POSTRESQL.ROL(rol_id),
	[func_rol_funcionalidad] INT NOT NULL FOREIGN KEY REFERENCES POSTRESQL.Funcionalidad(func_id))


GO
CREATE TABLE [POSTRESQL].[ItemFactura](
	[item_fact_monto] [decimal](12, 2) ,
	[item_fact_cantidad] [decimal](12, 2) ,
	[item_fact_factura] [numeric](6, 0) ,
	[item_fact_concepto] [char](100) ,
	[item_fact_id]  INT IDENTITY PRIMARY KEY)


GO
CREATE TABLE [POSTRESQL].[MedioPago](
	[medio_pago_id] INT IDENTITY PRIMARY KEY,
	[medio_pago_descripcion] [char](50))


GO

CREATE TABLE [POSTRESQL].[Usuario](
	[user_id] INT IDENTITY PRIMARY KEY,
	[user_nombre] [char](50) UNIQUE ,
	[user_habilitado] [bit] ,
	[user_password] [char](30))


GO

CREATE TABLE [POSTRESQL].[Pago](
	[pago_id] INT PRIMARY KEY,
	[pago_fecha] [date] ,
	[pago_medio_pago] [numeric](6, 0) ,
	[pago_sucursal] [numeric](6, 0) ,
	[pago_usuario]  INT NOT NULL FOREIGN KEY REFERENCES POSTRESQL.Usuario(user_id),
	[pago_cliente] INT NOT NULL FOREIGN KEY REFERENCES POSTRESQL.Cliente(clie_id))

GO
CREATE TABLE [POSTRESQL].[PagoFactura](
	[pago_fact_pago]  INT NOT NULL FOREIGN KEY REFERENCES POSTRESQL.Pago(pago_id),
	[pago_fact_factura] [numeric](6, 0) ,
	[pago_fact_anulado] [bit] ,
	[pago_fact_fecha] [datetime] ,
	[pago_fact_numero]INT PRIMARY KEY
)

GO

CREATE TABLE [POSTRESQL].[Rubro](
	[rubr_id] INT IDENTITY(1,1) PRIMARY KEY,
	[rubr_detalle] [char](100))

GO
CREATE TABLE [POSTRESQL].[RubroEmpresa](
	[empr_id] INT NOT NULL FOREIGN KEY REFERENCES POSTRESQL.Empresa(empr_id),
	[rubr_id]  INT NOT NULL FOREIGN KEY REFERENCES POSTRESQL.Rubro(rubr_id))

GO
CREATE TABLE [POSTRESQL].[Sucursal](
	[sucu_id] INT IDENTITY PRIMARY KEY,
	[sucu_nombre] [char](50) ,
	[sucu_direccion] [char](100) ,
	[sucu_codigo_postal] [char](20) ,
	[sucu_habilitado] [bit])


GO
CREATE TABLE [POSTRESQL].[UsuarioRol](
	[user_rol_usuario]  INT NOT NULL FOREIGN KEY REFERENCES POSTRESQL.Usuario(user_id),
	[user_rol_rol] INT NOT NULL FOREIGN KEY REFERENCES POSTRESQL.Rol(rol_id))

GO
CREATE TABLE [POSTRESQL].[UsuarioSucursal](
	[user_suc_usuario]  INT NOT NULL FOREIGN KEY REFERENCES POSTRESQL.Usuario(user_id),
	[user_suc_sucursal]  INT NOT NULL FOREIGN KEY REFERENCES POSTRESQL.Sucursal(sucu_id))
GO


--INICIO MIGRACIONES

-- MIGRACION CLIENTES

INSERT INTO POSTRESQL.Cliente(
	clie_dni, clie_apellido, clie_nombre, clie_fecha_nac, clie_mail,
	clie_direccion, clie_codigo_postal)
SELECT DISTINCT
	[Cliente-Dni], [Cliente-Apellido], [Cliente-Nombre], [Cliente-Fecha_Nac], [Cliente_Mail],
	[Cliente_Direccion], [Cliente_Codigo_Postal]
FROM gd_esquema.Maestra
WHERE [Cliente-Dni] IS NOT NULL

GO

--MIGRACION EMPRESAS

INSERT INTO POSTRESQL.Empresa(
	empr_nombre, empr_cuit, empr_direccion)
SELECT DISTINCT
	[Empresa_Nombre], [Empresa_Cuit], [Empresa_Direccion]
FROM gd_esquema.Maestra
WHERE [Empresa_Nombre] IS NOT NULL

GO
--MIGRACION SUCURSALES

INSERT INTO POSTRESQL.Sucursal(
	sucu_nombre, sucu_direccion, sucu_codigo_postal)
SELECT DISTINCT
	[Sucursal_Nombre], [Sucursal_Dirección], [Sucursal_Codigo_Postal]
FROM gd_esquema.Maestra
WHERE [Sucursal_Nombre] IS NOT NULL

GO

--MIGRACION ITEM_FACTURA

INSERT INTO POSTRESQL.ItemFactura(
	item_fact_monto, item_fact_cantidad)
SELECT DISTINCT
	[ItemFactura_Monto], [ItemFactura_Cantidad]
FROM gd_esquema.Maestra
WHERE [Sucursal_Nombre] IS NOT NULL

GO

--MIGRACION RUBRO
INSERT INTO POSTRESQL.Rubro(
	rubr_detalle)
SELECT DISTINCT
	[Rubro_Descripcion]
FROM gd_esquema.Maestra
WHERE [Rubro_Descripcion] IS NOT NULL

GO

-- MIGRACION PAGO


GO

-- MIGRACION MEDIO_PAGO
INSERT INTO POSTRESQL.MedioPago(
	medio_pago_descripcion)
SELECT DISTINCT
	[FormaPagoDescripcion]
FROM gd_esquema.Maestra
WHERE [FormaPagoDescripcion] IS NOT NULL

GO

--MIGRACION FACTURAS

INSERT INTO POSTRESQL.Factura(
	fact_numero, fact_fecha, fact_fecha_vencimiento, fact_total, fact_cliente, fact_empresa)
SELECT DISTINCT
	[Nro_Factura], [Factura_Fecha], [Factura_Fecha_Vencimiento], [Factura_Total], 
(SELECT clie_id from POSTRESQL.Cliente WHERE clie_dni = [Cliente-Dni]),
(SELECT empr_id from POSTRESQL.Empresa WHERE empr_cuit = Empresa_Cuit)
FROM gd_esquema.Maestra
WHERE [Nro_Factura] IS NOT NULL

GO

--MIGRACION USUARIO (Admin)
INSERT INTO POSTRESQL.Usuario(user_nombre, user_password, user_habilitado)
VALUES ('admin', 'w23e', 1)

GO

GO

--MIGRACION ROLES

INSERT INTO POSTRESQL.Rol (rol_nombre)
	VALUES ('Administrador'), ('Cobrador')


GO

--MIGRACION FUNCIONALIDADES
  
INSERT INTO POSTRESQL.Funcionalidad(func_descripcion)
	VALUES	('ABM Rol'),
			('Login y Seguridad'),
			('Registro de Usuarios'),
			('ABM Clientes'),
			('ABM Empresas'),
			('ABM Sucursal'),
			('ABM Facturas'),
			('Registro de pago de facturas'),
			('Rendicion de facturas cobradas'),
			('Devoluciones'),
			('Listado Estadistico')

GO
--FIN MIGRACIONES















