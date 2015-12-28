CREATE TABLE [TblUsuarios] (
[PkUsuarioId] INTEGER   PRIMARY KEY IDENTITY NOT NULL,
[FkEmisorId] INTEGER  NOT NULL,
[Nombre] VARCHAR(100)  NOT NULL,
[Apellidos] VARCHAR(100)  NOT NULL,
[Puesto] VARCHAR(50)  NULL,
[Rol] INTEGER  NULL,
[Password] VARCHAR(100)  NULL,
[Bloqueado] INTEGER  NULL,
FOREIGN KEY(FkEmisorId) REFERENCES TblEmisores(PkCompaniaId)
);