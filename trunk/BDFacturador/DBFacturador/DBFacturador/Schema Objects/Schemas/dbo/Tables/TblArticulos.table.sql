CREATE TABLE [TblArticulos] (
[PkArticuloId] INTEGER  NOT NULL PRIMARY KEY IDENTITY,
[FkEmisorId] INTEGER  NOT NULL,
[Descripcion] VARCHAR(1000)  NOT NULL,
[ClaveInterna] VARCHAR(10)  NULL,
[CodigoBarras] VARCHAR(40)  NULL,
[PrecioUnitario] DECIMAL(18,2) NOT NULL,
[ManejaIVA] BIT   NOT NULL,
[FkImpuesto1] INTEGER NULL,
[FkImpuesto2] INTEGER NULL,
[FkImpuesto3] INTEGER NULL,
[FkUnidaddeMedidaId] INTEGER  NOT NULL,
[FkFamiliaId] INTEGER NULL,
[ActivoSN] INTEGER DEFAULT 1 NOT NULL,

FOREIGN KEY(FkEmisorId) REFERENCES TblEmisores(PkEmisorId),
FOREIGN KEY(FkUnidaddeMedidaId) REFERENCES TblUnidadesMedida(PkUnidaddeMedidaId),
FOREIGN KEY(FkImpuesto1) REFERENCES TblImpuestos(PkImpuestoId),
FOREIGN KEY(FkImpuesto2) REFERENCES TblImpuestos(PkImpuestoId),
FOREIGN KEY(FkImpuesto3) REFERENCES TblImpuestos(PkImpuestoId)
);