CREATE TABLE [TblArticulosComprobante] (
[PkArticulosComprobanteId] INTEGER NOT NULL PRIMARY KEY IDENTITY,
[FkEmisorId] INTEGER  NOT NULL,
[FkComprobanteId] INTEGER  NOT NULL,
[FkArticuloId] INTEGER  NOT NULL,
[ArticuloDescripcion] VARCHAR(1000)  NOT NULL,
[Cantidad] DECIMAL(18,5)  NOT NULL,
[PrecioVenta] DECIMAL(18,2)  NOT NULL,
[UnidadMedida] INTEGER  NOT NULL,
[DescUnidadMedida] VARCHAR(40)  NOT NULL,
FOREIGN KEY(FkEmisorId) REFERENCES TblEmisores(PkEmisorId),
FOREIGN KEY(FkComprobanteId) REFERENCES TblComprobante(PkComprobanteId),
FOREIGN KEY(FkArticuloId) REFERENCES TblArticulos(PkArticuloId)
);