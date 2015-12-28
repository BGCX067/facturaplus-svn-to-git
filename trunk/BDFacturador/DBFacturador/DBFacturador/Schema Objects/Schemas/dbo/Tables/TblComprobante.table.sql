﻿CREATE TABLE [TblComprobante] (
[PkComprobanteId] INTEGER   NOT NULL PRIMARY KEY IDENTITY,
[FkEmisorId] INTEGER  NOT NULL,
[FkUsuarioId] INTEGER  NOT NULL,
[FkReceptorId] INTEGER  NOT NULL,
[FkMetododePagoId] INTEGER  NOT NULL,
[FkFormadePagoId] INTEGER  NOT NULL,
[Serie] VARCHAR(10)  NOT NULL,
[Folio] INTEGER  NOT NULL,
[FechaCreacion] DATETIME NOT NULL,
[Estatus] INTEGER  NOT NULL,
[Subtotal] DECIMAL(18,2)  NOT NULL,
[IVA] DECIMAL(18,2)  NOT NULL,
[Descuento] DECIMAL(18,2)  NOT NULL,
[MotivoDescuento] VARCHAR(100)  NULL,
[Total] DECIMAL(18,2)  NOT NULL,
[CadenaOriginal] VARCHAR(4000)  NULL,
[SelloDigital] VARCHAR(1000)  NULL,
[CondicionesdePago] VARCHAR(10)  NULL,
[CantidadConLetra] VARCHAR(300)  NOT NULL,
[TipoComprobante] INTEGER  NOT NULL,
[NoCertificado] VARCHAR(30)  NULL,
[FechaEmision] VARCHAR(20)  NULL,
[FkMonedaId] INTEGER NOT  NULL,
[Moneda] VARCHAR(20)  NOT NULL,
[TipoCambio] VARCHAR(20)  NOT NULL,

FOREIGN KEY(FkEmisorId) REFERENCES TblEmisores(PkEmisorId),
FOREIGN KEY(FkUsuarioId) REFERENCES TblUsuarios(PkUsuarioId),
FOREIGN KEY(FkReceptorId) REFERENCES TblReceptores(PkReceptorId),
FOREIGN KEY(FkMetododePagoId) REFERENCES TblMetododePago(PkMetododePagoId),
FOREIGN KEY(FkFormadePagoId) REFERENCES TblFormadePago(PkFormadePagoId),
FOREIGN KEY(FkMonedaId) REFERENCES TblMonedas(PkMonedaId)
);