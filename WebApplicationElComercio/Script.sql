USE [master]
GO

CREATE DATABASE [metricaandina] 
GO
USE [metricaandina]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[banco](
	[idbanco] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[direccion] [varchar](100) NULL,
	[fecharegistro] [datetime] NULL,
 CONSTRAINT [PK_banco] PRIMARY KEY CLUSTERED 
(
	[idbanco] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sucursal](
	[idsucursal] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[direccion] [varchar](150) NULL,
	[fecharegistro] [datetime] NULL,
	[idbanco] [int] NOT NULL,
 CONSTRAINT [PK_sucursal] PRIMARY KEY CLUSTERED 
(
	[idsucursal] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ordenpago](
	[idordenpago] [int] IDENTITY(1,1) NOT NULL,
	[monto] [money] NULL,
	[moneda] [varchar](50) NULL,
	[estado] [varchar](50) NULL,
	[fechapago] [date] NULL,
	[idsucursal] [int] NOT NULL,
 CONSTRAINT [PK_ordenpago] PRIMARY KEY CLUSTERED 
(
	[idordenpago] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[sucursal]  WITH CHECK ADD  CONSTRAINT [FK_sucursal_banco] FOREIGN KEY([idbanco])
REFERENCES [dbo].[banco] ([idbanco])
GO
ALTER TABLE [dbo].[sucursal] CHECK CONSTRAINT [FK_sucursal_banco]
GO

ALTER TABLE [dbo].[ordenpago]  WITH CHECK ADD  CONSTRAINT [FK_ordenpago_sucursal] FOREIGN KEY([idsucursal])
REFERENCES [dbo].[sucursal] ([idsucursal])
GO
ALTER TABLE [dbo].[ordenpago] CHECK CONSTRAINT [FK_ordenpago_sucursal]
GO