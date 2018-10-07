use master
create database BDUSUARIOS;

USE [BDUSUARIOS]
GO

CREATE TABLE [dbo].[Usuarios] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Nome]      NVARCHAR (100) NOT NULL,
    [Sobrenome] NVARCHAR (50)  NOT NULL,
    [Email]     NVARCHAR (200) NOT NULL
);
go


ALTER TABLE [dbo].[Usuarios]
    ADD CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED ([Id] ASC);

GO

CREATE TABLE [dbo].[DetalheUsuarios] (
    [UsuarioId] INT            NOT NULL,
    [Telefone]  NVARCHAR (50)  NOT NULL,
    [Endereco]  NVARCHAR (200) NOT NULL
);

GO

ALTER TABLE [dbo].[DetalheUsuarios]
    ADD CONSTRAINT [PK_DetalheUsuarios] PRIMARY KEY CLUSTERED ([UsuarioId] ASC);


GO

ALTER TABLE [dbo].[DetalheUsuarios]
    ADD CONSTRAINT [FK_DetalheUsuarios_Usuarios_Id] FOREIGN KEY ([UsuarioId]) REFERENCES [dbo].[Usuarios] ([Id]);

go

--USUARIOS DE TESTE
INSERT INTO DBO.USUARIOS VALUES('REGINALDO','CAUMO','RLCAUMO@GMAIL.COM')
INSERT INTO DBO.USUARIOS VALUES('MARIA DA SILVA','CASTRO','MCASTRO@GMAIL.COM')
INSERT INTO DBO.DetalheUsuarios VALUES(2,'11-99837-7632','RUA PARACATU, 3004')

SELECT * FROM DBO.USUARIOS
SELECT * FROM DBO.DetalheUsuarios




