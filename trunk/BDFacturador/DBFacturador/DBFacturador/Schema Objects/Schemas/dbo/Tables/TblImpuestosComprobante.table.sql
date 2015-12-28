CREATE TABLE [TblImpuestosComprobante] (
[PkImpuestosComprobanteId] INTEGER NOT NULL PRIMARY KEY IDENTITY,
[FkEmisorId] INTEGER  NOT NULL,
[FkComprobanteId] INTEGER  NOT NULL,
[FkImpuestoId] INTEGER  NOT NULL,
[DescripcionImpuesto] VARCHAR(10)  NOT NULL,
[MontoImpuesto] DECIMAL(18,2)  NOT NULL,
[TasaImpuesto] VARCHAR(20)  NULL,
[Subtotal] DECIMAL(18,2)  NOT NULL,
FOREIGN KEY(FkEmisorId) REFERENCES TblEmisores(PkEmisorId),
FOREIGN KEY(FkComprobanteId) REFERENCES TblComprobante(PkComprobanteId),
FOREIGN KEY(FkImpuestoId) REFERENCES TblImpuestos(PkImpuestoId)
);