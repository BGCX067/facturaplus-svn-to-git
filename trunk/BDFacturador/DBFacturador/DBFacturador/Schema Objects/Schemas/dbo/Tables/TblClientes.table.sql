USE [Facturador]
GO

/****** Object:  Table [dbo].[tblClientes]    Script Date: 10/04/2012 20:55:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tblClientes](
	[pkClienteid] [int] IDENTITY(1,1) NOT NULL,
	[CorreoElectronico] [varchar](80) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Telefono] [varchar](10) NOT NULL,
 CONSTRAINT [PK_tblClienteid] PRIMARY KEY CLUSTERED 
(
	[pkClienteid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

