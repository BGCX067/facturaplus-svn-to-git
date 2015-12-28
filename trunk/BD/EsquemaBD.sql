CREATE TABLE [TblCompanias] (
[PKCompaniaId] INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL,
[RazonSocial] VARCHAR(200)  NOT NULL,
[Rfc] VARCHAR(13)  NOT NULL,
[Calle] VARCHAR(200)  NOT NULL,
[NoExterior] VARCHAR(10)  NULL,
[NoInterior] VARCHAR(10)  NULL,
[Colonia] VARCHAR(200)  NULL,
[Localidad] VARCHAR(200)  NULL,
[Municipio] VARCHAR(200)  NULL,
[Estado] INTEGER  NULL,
[CP] VARCHAR(10)  NULL,
[Certificado] VARCHAR(3000)  NULL,
[NoCertificado] VARCHAR(100)  NULL,
[FechaInicial] DATE  NULL,
[FechaFinal] dATE  NULL,
[Logo] TEXT  NULL,
[PasswordCertificado] VARCHAR(30)  NULL,
[Regimen] VARCHAR(50)  NULL,
[RegimenFiscal] VARCHAR(100)  NULL,
[RutaCertificado] VARCHAR(100)  NULL,
[ImagenRFC] teXT  NULL
);

CREATE TABLE [TblClientes] (
[PkClienteId] INTEGER  NOT NULL PRIMARY KEY AUTOINCREMENT,
[FKCompaniaId] INTEGER  NOT NULL,
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
[Estado] INTEGER  NULL,
[CorreoElectronico] VARCHAR(50)  NULL,
[CP] vARCHAR(10)  NULL,
FOREIGN KEY(FKCompaniaId) REFERENCES TblCompanias(PKCompaniaId)
);

CREATE TABLE [TblUsuarios] (
[PKUsuarioId] INTEGER   PRIMARY KEY AUTOINCREMENT NOT NULL,
[FKCompaniaId] INTEGER  NOT NULL,
[Nombre] VARCHAR(100)  NOT NULL,
[Apellidos] VARCHAR(100)  NOT NULL,
[Puesto] VARCHAR(50)  NULL,
[Rol] INTEGER  NULL,
[Password] VARCHAR(100)  NULL,
[Bloqueado] INTEGER  NULL,
FOREIGN KEY(FKCompaniaId) REFERENCES TblCompanias(PKCompaniaId)
);

CREATE TABLE [TblEstados] (
[PKestadoId] INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL,
[Estado] VARCHAR(30)  NOT NULL
);

CREATE TABLE [TblMetodoPago] (
[PkMetodoPagoId] INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL,
[MetododePago] VARCHAR(50)  NOT NULL
);

CREATE TABLE [TblUnidadesMedida] (
[PKUnidadMedidaId] INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL,
[UnidaddeMedida] VARCHAR(20)  NOT NULL
);

CREATE TABLE [TblFormadePago] (
[PkFormaPagoId] INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL,
[FormadePago] VARCHAR(50)  NOT NULL
);

CREATE TABLE [TblImpuestos] (
[PKImpuestoId] INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL,
[Impuesto] VARCHAR(5)  NOT NULL,
[Tasa] INTEGER DEFAULT '''0''' NOT NULL
);

CREATE TABLE [TblMonedas] (
[PKMonedaId] INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL,
[Moneda] VARCHAR(20)  NOT NULL,
[TipoCambio] REAL DEFAULT '1' NOT NULL,
[Prefijo] VARCHAR(3)  NULL,
[Simbolo] VARCHAR(3) DEFAULT '$' NULL
);


CREATE TABLE [TblArticulos] (
[PKArticuloId] INTEGER  NOT NULL PRIMARY KEY AUTOINCREMENT,
[FKCompaniaId] INTEGER  NOT NULL,
[Descripcion] VARCHAR(1000)  NOT NULL,
[ClaveInterna] VARCHAR(10)  NULL,
[CodigoBarras] VARCHAR(40)  NULL,
[PrecioUnitario] VARCHAR(20) NOT NULL,
[ManejaIVA] INTEGER   NOT NULL,
[FKImpuesto1] INTEGER NULL,
[FKImpuesto2] INTEGER NULL,
[FKImpuesto3] INTEGER NULL,
[FKUnidaddeMedidaId] INTEGER  NOT NULL,
[FKFamiliaId] INTEGER NULL,
[ActivoSN] INTEGER DEFAULT '1' NOT NULL,
FOREIGN KEY(FKCompaniaId) REFERENCES TblCompanias(PKCompaniaId),
FOREIGN KEY(FKUnidaddeMedidaId) REFERENCES TblUnidadesMedida(PKUnidaddeMedidaId),
FOREIGN KEY(FKImpuesto1) REFERENCES TblImpuestos(PKImpuestoId),
FOREIGN KEY(FKImpuesto2) REFERENCES TblImpuestos(PKImpuestoId),
FOREIGN KEY(FKImpuesto3) REFERENCES TblImpuestos(PKImpuestoId)
);

CREATE TABLE [TblFactura] (
[PKFacturaId] INTEGER   NOT NULL PRIMARY KEY AUTOINCREMENT,
[FKCompaniaId] INTEGER  NOT NULL,
[FKUsuarioId] INTEGER  NOT NULL,
[FKClienteId] INTEGER  NOT NULL,
[FKMetodoPagoId] INTEGER  NOT NULL,
[FKFormaPagoId] INTEGER  NOT NULL,
[Serie] VARCHAR(10)  NOT NULL,
[Folio] NUMERIC  NOT NULL,
[FechaCreacion] DATE DEFAULT CURRENT_DATE NOT NULL,
[HoraCreacion] tIME DEFAULT CURRENT_TIME NOT NULL,
[Estatus] INTEGER  NOT NULL,
[Subtotal] VARCHAR(20)  NOT NULL,
[IVA] VARCHAR(20)  NOT NULL,
[Descuento] VARCHAR(20)  NOT NULL,
[MotivoDescuento] VARCHAR(100)  NULL,
[Total] VARCHAR(20)  NOT NULL,
[CadenaOriginal] VARCHAR(4000)  NULL,
[SelloDigital] VARCHAR(1000)  NULL,
[CondicionesPago] VARCHAR(10)  NULL,
[CantidadConLetra] VARCHAR(300)  NOT NULL,
[TipoFactura] INTEGER  NOT NULL,
[NoCertificado] VARCHAR(30)  NULL,
[FechaEmision] VARCHAR(20)  NULL,
[FKMonedaId] INTEGER NOT  NULL,
[Moneda] VARCHAR(20)  NOT NULL,
[TipoCambio] VARCHAR(20)  NOT NULL,
FOREIGN KEY(FKCompaniaId) REFERENCES TblCompanias(PKCompaniaId),
FOREIGN KEY(FKUsuarioId) REFERENCES TblUsuarios(PKUsuarioId),
FOREIGN KEY(FKClienteId) REFERENCES TblClientes(PKClienteId),
FOREIGN KEY(FKMetodoPagoId) REFERENCES TblMetodoPago(PKMetodoPagoId),
FOREIGN KEY(FKFormaPagoId) REFERENCES TblFormadePago(PKFormaPagoId),
FOREIGN KEY(FKMonedaId) REFERENCES TblMonedas(PKMonedaId)
);

CREATE TABLE [TblArticulosFac] (
[FKCompaniaId] INTEGER  NOT NULL,
[FKFacturaId] INTEGER  NOT NULL,
[PKArticulosFacId] INTEGER  NOT NULL,
[FKArticuloId] INTEGER  NOT NULL,
[ArticuloDescripcion] VARCHAR(4000)  NOT NULL,
[Cantidad] REAL  NOT NULL,
[PrecioVenta] REAL  NOT NULL,
[UnidadMedida] INTEGER  NOT NULL,
[DescUnidadMedida] VARCHAR(40)  NOT NULL,
PRIMARY KEY(FKCompaniaId,FkFacturaId,PKArticulosFacId ),
FOREIGN KEY(FKCompaniaId) REFERENCES TblCompanias(PKCompaniaId),
FOREIGN KEY(FkFacturaId) REFERENCES TblFacturas(PKFacturaId),
FOREIGN KEY(FKArticuloId) REFERENCES TblArticulos(PKArticuloId)

);

CREATE TABLE [TblImpuestosFac] (
[FKCompaniaId] INTEGER  NOT NULL,
[FKFacturaId] INTEGER  NOT NULL,
[PKImpuestosFacId] INTEGER  NOT NULL,
[FKImpuestoId] INTEGER  NOT NULL,
[DescripcionImpuesto] VARCHAR(10)  NOT NULL,
[MontoImpuesto] REAL  NOT NULL,
[TasaImpuesto] REAL  NULL,
[Subtotal] REAL  NOT NULL,
PRIMARY KEY(FKCompaniaId,FKFacturaId,PKImpuestosFacId ),
FOREIGN KEY(FKCompaniaId) REFERENCES TblCompanias(PKCompaniaId),
FOREIGN KEY(FKFacturaId) REFERENCES TblFacturas(PKFacturaId),
FOREIGN KEY(FKImpuestoId) REFERENCES TblImpuestos(PKImpuestoId)

);
