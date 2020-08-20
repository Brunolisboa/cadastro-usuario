USE [Loja]
GO

/****** Object:  Table [dbo].[tb_usuarios]    Script Date: 19/08/2020 22:11:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tb_usuarios](
	[cod_usuario] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](100) NOT NULL,
	[login] [varchar](50) NOT NULL,
	[email] [varchar](150) NULL,
	[senha] [varchar](100) NOT NULL,
	[cadastro] [date] NOT NULL,
	[situacao] [varchar](1) NOT NULL,
	[perfil] [int] NOT NULL,
 CONSTRAINT [PK_tb_usuarios] PRIMARY KEY CLUSTERED 
(
	[cod_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

