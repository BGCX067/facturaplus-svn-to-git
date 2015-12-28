CREATE TABLE [TblImpuestos] (
[PkImpuestoId] INTEGER  PRIMARY KEY IDENTITY NOT NULL,
[Impuesto] VARCHAR(5)  NOT NULL,
[FkTipoImpuestoId] INTEGER NOT NULL,
[Tasa] DECIMAL(4,2) NOT NULL,

FOREIGN KEY(FkTipoImpuestoId) REFERENCES TblTipoImpuesto(PkTipoImpuestoId)

);