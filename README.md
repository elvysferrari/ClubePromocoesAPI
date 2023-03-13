# ClubePromocoesAPI
 
API .NET CORE 7 com Autenticação JWT, CQRS, DDD e SQL Server.
 
Features:
1 - Usuário com token jwt
2 - CQRS Usando mediatr
3 - SQL SERVER
4 - Padrão DDD

-Scripts SQL SERVER

--Criar o banco
CREATE DATABASE [ClubePromocoes]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ClubePromocoes', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ClubePromocoes.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ClubePromocoes_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ClubePromocoes_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT

--TABELAS
--USUARIO
CREATE TABLE [dbo].[usuario](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[nome] [nvarchar](200) NOT NULL,
	[email] [varchar](200) NOT NULL,
	[password] [varbinary](max) NULL,
	[criado_em] [datetime] NOT NULL,
	[b_liberada] [bit] NOT NULL,
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
--CATEGORIA
CREATE TABLE [dbo].[categoria](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[nome] [nvarchar](150) NOT NULL,
	[fl_ativo] [bit] NOT NULL,
 CONSTRAINT [PK_categoria] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
--LOJA
CREATE TABLE [dbo].[loja](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[id_categoria] [bigint] NOT NULL,
	[nome] [nvarchar](150) NOT NULL,
	[descricao] [nvarchar](250) NOT NULL,
	[criada_em] [smalldatetime] NOT NULL,
	[imagem] [nvarchar](150) NOT NULL,
	[abre_as] [smalldatetime] NULL,
	[fecha_as] [smalldatetime] NULL,
	[endereco] [nvarchar](100) NOT NULL,
	[numero] [nvarchar](5) NOT NULL,
	[bairro] [nvarchar](100) NOT NULL,
	[cidade] [nvarchar](100) NOT NULL,
	[uf] [nvarchar](2) NOT NULL,
	[fl_ativo] [bit] NOT NULL,
 CONSTRAINT [PK_loja] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[loja]  WITH CHECK ADD  CONSTRAINT [FK_loja_categoria] FOREIGN KEY([id_categoria])
REFERENCES [dbo].[categoria] ([id])
GO

ALTER TABLE [dbo].[loja] CHECK CONSTRAINT [FK_loja_categoria]
GO
--PROMOCAO
CREATE TABLE [dbo].[promocao](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[id_loja] [bigint] NOT NULL,
	[id_usuario] [bigint] NOT NULL,
	[criada_em] [smalldatetime] NOT NULL,
	[data_inicio] [smalldatetime] NOT NULL,
	[data_fim] [smalldatetime] NOT NULL,
	[titulo] [nvarchar](150) NOT NULL,
	[descricao] [nvarchar](250) NULL,
	[observacao] [nvarchar](250) NULL,
	[imagem_destacada] [nvarchar](150) NOT NULL,
	[valor_de] [decimal](18, 2) NULL,
	[valor_por] [decimal](18, 2) NULL,
	[fl_ativo] [bit] NOT NULL,
 CONSTRAINT [PK_promocoes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[promocao]  WITH CHECK ADD  CONSTRAINT [FK_promocao_loja] FOREIGN KEY([id_loja])
REFERENCES [dbo].[loja] ([id])
GO

ALTER TABLE [dbo].[promocao] CHECK CONSTRAINT [FK_promocao_loja]
GO

ALTER TABLE [dbo].[promocao]  WITH CHECK ADD  CONSTRAINT [FK_promocao_usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuario] ([id])
GO

ALTER TABLE [dbo].[promocao] CHECK CONSTRAINT [FK_promocao_usuario]
GO
