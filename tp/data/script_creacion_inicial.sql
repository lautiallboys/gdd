USE [GD2C2017]

-- CREACION DE SCHEMA

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'POSTRESQL')
BEGIN
	EXEC ('CREATE SCHEMA POSTRESQL')
END

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




GO
/****** Object:  User [gd]    Script Date: 10/10/2017 10:42:15 ******/
--CREATE USER [gd] FOR LOGIN [gd] WITH DEFAULT_SCHEMA=[POSTRESQL]


GO
CREATE TABLE [POSTRESQL].[Cliente](
	[clie_id] [numeric] (6, 0) NOT NULL,
	[clie_dni] [numeric](8, 0) NOT NULL,
	[clie_apellido] [char](50) NULL,
	[clie_nombre] [char](50) NULL,
	[clie_fecha_nac] [date] NULL,
	[clie_mail] [char](50) NOT NULL,
	[clie_direccion] [char](100) NULL,
	[clie_codigo_postal] [char](20) NULL,
	[clie_habilitado] [bit] NULL,
 CONSTRAINT [PK__Cliente__EDD86EE012B2A493] PRIMARY KEY CLUSTERED 
(
	[clie_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


GO
CREATE TABLE [POSTRESQL].[Devolucion](
	[devo_id] [numeric](6, 0) NOT NULL,
	[devo_pago_factura] [numeric](6, 0) NOT NULL,
	[devo_motivo] [char](100) NULL,
	[devo_fecha] [date] NOT NULL,
 CONSTRAINT [PK_Devolucion] PRIMARY KEY CLUSTERED 
(
	[devo_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



GO
CREATE TABLE [POSTRESQL].[Empresa](
	[empr_id] [numeric](6, 0) NOT NULL,
	[empr_nombre] [char](50) NULL,
	[empr_cuit] [numeric](11, 0) NULL,
	[empr_direccion] [char](100) NULL,
	[empr_habilitado] [bit] NULL,
 CONSTRAINT [PK_Empresa] PRIMARY KEY CLUSTERED 
(
	[empr_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



GO
CREATE TABLE [POSTRESQL].[Factura](
	[fact_numero] [numeric](6, 0) NOT NULL,
	[fact_fecha] [date] NOT NULL,
	[fact_fecha_vencimiento] [date] NOT NULL,
	[fact_cliente] [numeric](6, 0) NOT NULL,
	[fact_empresa] [numeric](6, 0) NOT NULL,
	[fact_cobrada] [bit] NULL,
	[fact_rendicion] [numeric](6, 0) NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[fact_numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



GO
CREATE TABLE [POSTRESQL].[Funcionalidad](
	[fund_id] [numeric](6, 0) NOT NULL,
	[fund_descripcion] [char](100) NULL,
 CONSTRAINT [PK_Funcionalidad] PRIMARY KEY CLUSTERED 
(
	[fund_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



GO
CREATE TABLE [POSTRESQL].[FuncionalidadRol](
	[func_rol_rol] [numeric](6, 0) NOT NULL,
	[func_rol_funcionalidad] [numeric](6, 0) NOT NULL,
 CONSTRAINT [PK_FuncionalidadRol] PRIMARY KEY CLUSTERED 
(
	[func_rol_rol] ASC,
	[func_rol_funcionalidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


GO
CREATE TABLE [POSTRESQL].[ItemFactura](
	[item_fact_monto] [decimal](12, 2) NULL,
	[item_fact_cantidad] [decimal](12, 2) NULL,
	[item_fact_factura] [numeric](6, 0) NULL,
	[item_fact_Concepto] [char](100) NULL,
	[item_fact_id] [numeric](6, 0) NOT NULL,
 CONSTRAINT [PK_ItemFactura] PRIMARY KEY CLUSTERED 
(
	[item_fact_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


GO
CREATE TABLE [POSTRESQL].[MedioPago](
	[medio_pago_id] [numeric](6, 0) NOT NULL,
	[medio_pago_descripcion] [char](50) NOT NULL,
 CONSTRAINT [PK_MedioPago] PRIMARY KEY CLUSTERED 
(
	[medio_pago_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


GO
CREATE TABLE [POSTRESQL].[Pago](
	[pago_numero] [numeric](6, 0) NOT NULL,
	[pago_fecha] [date] NOT NULL,
	[pago_medio_pago] [numeric](6, 0) NOT NULL,
	[pago_sucursal] [numeric](6, 0) NOT NULL,
	[pago_usuario] [numeric](6, 0) NOT NULL,
	[pago_cliente] [numeric](6, 0) NOT NULL,
 CONSTRAINT [PK_Pago] PRIMARY KEY CLUSTERED 
(
	[pago_numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


GO
CREATE TABLE [POSTRESQL].[PagoFactura](
	[pago_fact_pago] [numeric](6, 0) NOT NULL,
	[pago_fact_factura] [numeric](6, 0) NOT NULL,
	[pago_fact_anulado] [bit] NULL,
	[pago_fact_fecha] [datetime] NOT NULL,
	[pago_fact_numero] [numeric](6, 0) NOT NULL,
 CONSTRAINT [PK_PagoFactura] PRIMARY KEY CLUSTERED 
(
	[pago_fact_numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


GO
CREATE TABLE [POSTRESQL].[Rendicion](
	[rend_numero] [numeric](6, 0) NOT NULL,
	[rend_fecha] [date] NOT NULL,
	[rend_total] [decimal](12, 2) NOT NULL,
	[rend_coef_comision] [float] NOT NULL,
	[rend_concepto] [char](100) NOT NULL,
	[rend_empresa] [numeric](6, 0) NOT NULL,
 CONSTRAINT [PK_Rendicion] PRIMARY KEY CLUSTERED 
(
	[rend_numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


GO
CREATE TABLE [POSTRESQL].[Rol](
	[rol_id] [numeric](6, 0) NOT NULL,
	[rol_nombre] [char](50) NULL,
	[rol_habilitado] [bit] NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[rol_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


GO
CREATE TABLE [POSTRESQL].[Rubro](
	[rubr_id] [numeric](6, 0) NOT NULL,
	[rubr_detalle] [char](100) NULL,
 CONSTRAINT [PK_Rubro] PRIMARY KEY CLUSTERED 
(
	[rubr_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


GO
CREATE TABLE [POSTRESQL].[RubroEmpresa](
	[empr_id] [numeric](6, 0) NOT NULL,
	[rubr_id] [numeric](6, 0) NOT NULL,
 CONSTRAINT [PK_Rubro.Empresa] PRIMARY KEY CLUSTERED 
(
	[empr_id] ASC,
	[rubr_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


GO
CREATE TABLE [POSTRESQL].[Sucursal](
	[sucu_id] [numeric](6, 0) NOT NULL,
	[sucu_nombre] [char](50) NULL,
	[sucu_direccion] [char](100) NULL,
	[sucu_codigo_postal] [char](20) NULL,
	[sucu_habilitado] [bit] NULL,
 CONSTRAINT [PK_Sucursal] PRIMARY KEY CLUSTERED 
(
	[sucu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


GO
CREATE TABLE [POSTRESQL].[Usuario](
	[user_id] [numeric](6, 0) NOT NULL,
	[user_nombre] [char](50) NULL,
	[user_habilitado] [bit] NULL,
	[user_password] [char](30) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


GO
CREATE TABLE [POSTRESQL].[UsuarioRol](
	[user_rol_usuario] [numeric](6, 0) NOT NULL,
	[user_rol_rol] [numeric](6, 0) NOT NULL,
 CONSTRAINT [PK_UsuarioRol] PRIMARY KEY CLUSTERED 
(
	[user_rol_usuario] ASC,
	[user_rol_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


GO
CREATE TABLE [POSTRESQL].[UsuarioSucursal](
	[user_suc_usuario] [numeric](6, 0) NOT NULL,
	[user_suc_sucursal] [numeric](6, 0) NOT NULL,
 CONSTRAINT [PK_UsuarioSucursal] PRIMARY KEY CLUSTERED 
(
	[user_suc_usuario] ASC,
	[user_suc_sucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [POSTRESQL].[Devolucion]  WITH CHECK ADD  CONSTRAINT [FK_DevoPagoFact] FOREIGN KEY([devo_pago_factura])
REFERENCES [POSTRESQL].[PagoFactura] ([pago_fact_numero])
GO
ALTER TABLE [POSTRESQL].[Devolucion] CHECK CONSTRAINT [FK_DevoPagoFact]
GO
ALTER TABLE [POSTRESQL].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_FactClien] FOREIGN KEY([fact_cliente])
REFERENCES [POSTRESQL].[Cliente] ([clie_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [POSTRESQL].[Factura] CHECK CONSTRAINT [FK_FactClien]
GO
ALTER TABLE [POSTRESQL].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_FactEmpr] FOREIGN KEY([fact_empresa])
REFERENCES [POSTRESQL].[Empresa] ([empr_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [POSTRESQL].[Factura] CHECK CONSTRAINT [FK_FactEmpr]
GO
ALTER TABLE [POSTRESQL].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_FactRend] FOREIGN KEY([fact_numero])
REFERENCES [POSTRESQL].[Rendicion] ([rend_numero])
GO
ALTER TABLE [POSTRESQL].[Factura] CHECK CONSTRAINT [FK_FactRend]
GO
ALTER TABLE [POSTRESQL].[FuncionalidadRol]  WITH CHECK ADD  CONSTRAINT [FK_FuncRolFunc] FOREIGN KEY([func_rol_funcionalidad])
REFERENCES [POSTRESQL].[Funcionalidad] ([fund_id])
GO
ALTER TABLE [POSTRESQL].[FuncionalidadRol] CHECK CONSTRAINT [FK_FuncRolFunc]
GO
ALTER TABLE [POSTRESQL].[FuncionalidadRol]  WITH CHECK ADD  CONSTRAINT [FK_FuncRolRol] FOREIGN KEY([func_rol_rol])
REFERENCES [POSTRESQL].[Rol] ([rol_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [POSTRESQL].[FuncionalidadRol] CHECK CONSTRAINT [FK_FuncRolRol]
GO
ALTER TABLE [POSTRESQL].[ItemFactura]  WITH CHECK ADD  CONSTRAINT [FK_ItemFactFact] FOREIGN KEY([item_fact_factura])
REFERENCES [POSTRESQL].[Factura] ([fact_numero])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [POSTRESQL].[ItemFactura] CHECK CONSTRAINT [FK_ItemFactFact]
GO
ALTER TABLE [POSTRESQL].[Pago]  WITH CHECK ADD  CONSTRAINT [FK_PagoMedio] FOREIGN KEY([pago_medio_pago])
REFERENCES [POSTRESQL].[MedioPago] ([medio_pago_id])
GO
ALTER TABLE [POSTRESQL].[Pago] CHECK CONSTRAINT [FK_PagoMedio]
GO
ALTER TABLE [POSTRESQL].[Pago]  WITH CHECK ADD  CONSTRAINT [FK_PagoSucu] FOREIGN KEY([pago_sucursal])
REFERENCES [POSTRESQL].[Sucursal] ([sucu_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [POSTRESQL].[Pago] CHECK CONSTRAINT [FK_PagoSucu]
GO
ALTER TABLE [POSTRESQL].[Pago]  WITH CHECK ADD  CONSTRAINT [FK_PagoUser] FOREIGN KEY([pago_usuario])
REFERENCES [POSTRESQL].[Usuario] ([user_id])
GO
ALTER TABLE [POSTRESQL].[Pago] CHECK CONSTRAINT [FK_PagoUser]
GO
ALTER TABLE [POSTRESQL].[Pago]  WITH CHECK ADD  CONSTRAINT [FK_PagoClie] FOREIGN KEY([pago_cliente])
REFERENCES [POSTRESQL].[Cliente] ([clie_id])
GO
ALTER TABLE [POSTRESQL].[Pago] CHECK CONSTRAINT [FK_PagoClie]
GO
ALTER TABLE [POSTRESQL].[PagoFactura]  WITH CHECK ADD  CONSTRAINT [FK_PagoFactFact] FOREIGN KEY([pago_fact_factura])
REFERENCES [POSTRESQL].[Factura] ([fact_numero])
GO
ALTER TABLE [POSTRESQL].[PagoFactura] CHECK CONSTRAINT [FK_PagoFactFact]
GO
ALTER TABLE [POSTRESQL].[PagoFactura]  WITH CHECK ADD  CONSTRAINT [FK_PagoFactPago] FOREIGN KEY([pago_fact_pago])
REFERENCES [POSTRESQL].[Pago] ([pago_numero])
GO
ALTER TABLE [POSTRESQL].[PagoFactura] CHECK CONSTRAINT [FK_PagoFactPago]
GO
ALTER TABLE [POSTRESQL].[Rendicion]  WITH CHECK ADD  CONSTRAINT [FK_RendEmpr] FOREIGN KEY([rend_empresa])
REFERENCES [POSTRESQL].[Empresa] ([empr_id])
GO
ALTER TABLE [POSTRESQL].[Rendicion] CHECK CONSTRAINT [FK_RendEmpr]
GO
ALTER TABLE [POSTRESQL].[RubroEmpresa]  WITH CHECK ADD  CONSTRAINT [FK_RubrEmprEmpr] FOREIGN KEY([empr_id])
REFERENCES [POSTRESQL].[Empresa] ([empr_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [POSTRESQL].[RubroEmpresa] CHECK CONSTRAINT [FK_RubrEmprEmpr]
GO
ALTER TABLE [POSTRESQL].[RubroEmpresa]  WITH CHECK ADD  CONSTRAINT [FK_RubrEmprRubr] FOREIGN KEY([rubr_id])
REFERENCES [POSTRESQL].[Rubro] ([rubr_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [POSTRESQL].[RubroEmpresa] CHECK CONSTRAINT [FK_RubrEmprRubr]
GO
ALTER TABLE [POSTRESQL].[UsuarioRol]  WITH CHECK ADD  CONSTRAINT [FK_UserRolRol] FOREIGN KEY([user_rol_rol])
REFERENCES [POSTRESQL].[Rol] ([rol_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [POSTRESQL].[UsuarioRol] CHECK CONSTRAINT [FK_UserRolRol]
GO
ALTER TABLE [POSTRESQL].[UsuarioRol]  WITH CHECK ADD  CONSTRAINT [FK_UserRolUser] FOREIGN KEY([user_rol_usuario])
REFERENCES [POSTRESQL].[Usuario] ([user_id])
GO
ALTER TABLE [POSTRESQL].[UsuarioRol] CHECK CONSTRAINT [FK_UserRolUser]
GO
ALTER TABLE [POSTRESQL].[UsuarioSucursal]  WITH CHECK ADD  CONSTRAINT [FK_UserSucSuc] FOREIGN KEY([user_suc_sucursal])
REFERENCES [POSTRESQL].[Sucursal] ([sucu_id])
GO
ALTER TABLE [POSTRESQL].[UsuarioSucursal] CHECK CONSTRAINT [FK_UserSucSuc]
GO
ALTER TABLE [POSTRESQL].[UsuarioSucursal]  WITH CHECK ADD  CONSTRAINT [FK_UserSucUser] FOREIGN KEY([user_suc_usuario])
REFERENCES [POSTRESQL].[Usuario] ([user_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [POSTRESQL].[UsuarioSucursal] CHECK CONSTRAINT [FK_UserSucUser]
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


--MIGRACION EMPRESAS

INSERT INTO POSTRESQL.Empresa(
	empr_nombre, empr_cuit, empr_direccion)
SELECT DISTINCT
	[Empresa_Nombre], [Empresa_Cuit], [Empresa_Direccion]
FROM gd_esquema.Maestra
WHERE [Empresa_Nombre] IS NOT NULL


--MIGRACION SUCURSALES

INSERT INTO POSTRESQL.Sucursal(
	sucu_nombre, sucu_direccion, sucu_codigo_postal)
SELECT DISTINCT
	[Sucursal_Nombre], [Sucursal_Dirección], [Sucursal_Codigo_Postal]
FROM gd_esquema.Maestra
WHERE [Sucursal_Nombre] IS NOT NULL





--MIGRACION FACTURAS

INSERT INTO POSTRESQL.Factura(
	fact_numero, fact_fecha, fact_fecha_vencimiento)
SELECT DISTINCT
	[Nro_Factura], [Factura_Fecha], [Factura_Fecha_Vencimiento]
FROM gd_esquema.Maestra
WHERE [Nro_Factura] IS NOT NULL




--FIN MIGRACIONES















