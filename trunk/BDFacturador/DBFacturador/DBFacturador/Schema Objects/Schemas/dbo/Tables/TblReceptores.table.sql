CREATE TABLE [dbo].[TblReceptores]
(
	[PkReceptorId] INTEGER  NOT NULL PRIMARY KEY identity,
	[FkEmisorId] INTEGER  NOT NULL,
	[RazonSocial] VARCHAR(200)  NOT NULL,
	[Rfc] VARCHAR(13)  NOT NULL,
	[TipoEmisor] INTEGER  NULL,
	[Calle] VARCHAR(100)  NOT NULL,
	[NoExterior] VARCHAR(10)  NULL,
	[NoInterior] VARCHAR(10)  NULL,
	[Colonia] VARCHAR(50)  NULL,
	[Localidad] VARCHAR(100)  NULL,
	[Referencia] VARCHAR(50)  NULL,
	[Municipio] VARCHAR(100)  NULL,
	[Estado] varchar(100)  NULL,
	[CorreoElectronico] VARCHAR(50)  NULL,
	[CP] VARCHAR(10)  NULL,
	FOREIGN KEY(FkEmisorId) REFERENCES TblEmisores(PkEmisorId)
);
