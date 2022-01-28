# Sistema de para lançamento de vendas.

# 🚨 Requisitos
- O cliente necessita de um sistema onde possa catalogar as vendas de seus clientes que são empresas:

- Para isto será necessário desenvolver as seguintes funcionalidades básicas:
	- Tela de Cadastro/Visualização de Empresa;
	- Tela de Cadastro/Visualização do Segmento da empresa;
	- Tela de Cadastro/Visualização das Vendas;
	- Tela de Cadastro/Visualização Usuários;

# Esquema do Banco
<img src="https://github.com/ricmazz/SistemaVendas/blob/master/SistemaVendas/Banco.png?raw=true" />

# Script para Criação do Banco
- Rodar scripts abaixo para realizar a criação da base de dados.
<code>
	CREATE DATABASE SistemaVendasDatabase;
	
	-- Seleciona base de dados "SistemaVendasDatabase"
	use SistemaVendasDatabase;

	-- Cria uma nova tabela chamada '[Tb_Usuario]'
	-- Deleta a tabela se já houver.
	IF OBJECT_ID('[dbo].[Tb_Usuario]', 'U') IS NOT NULL
	DROP TABLE [dbo].[Tb_Usuario]
	GO
	
	-- Create the table in the specified schema
	CREATE TABLE [dbo].[Tb_Usuario]
	(
	[IdUsuario] BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	[Nome] NVARCHAR(50) NOT NULL,
	[Cpf] NVARCHAR(14) NOT NULL,
	[Telefone] NVARCHAR(15) NOT NULL,
	[DesLogin] NVARCHAR(20) NOT NULL,
	[Senha] NVARCHAR(max) NOT NULL
	);
	
	GO
	
	IF OBJECT_ID('[dbo].[Tb_Empresa]', 'U') IS NOT NULL
	DROP TABLE [dbo].[Tb_Empresa]
	GO
	
	CREATE TABLE [dbo].[Tb_Empresa]
	(
	    [IdEmpresa] BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	    [IdUsuarioCadastro] BIGINT NOT NULL,
	    [RazaoSocial] NVARCHAR(50) NOT NULL,
	    [Cnpj] NVARCHAR(18) NOT NULL,
	    [Endereco] NVARCHAR(200) NOT NULL,
	    [Telefone] NVARCHAR(20) NULL,
	);
	GO
	    ALTER TABLE [dbo].[Tb_Empresa]
	    ADD CONSTRAINT FK_Tb_Empresa_Tb_Usuario FOREIGN KEY (IdUsuarioCadastro) REFERENCES Tb_Usuario (IdUsuario)
	GO
	
	IF OBJECT_ID('[dbo].[Tb_SegmentoEmpresa]', 'U') IS NOT NULL
	DROP TABLE [dbo].[Tb_SegmentoEmpresa]
	GO
	
	CREATE TABLE [dbo].[Tb_SegmentoEmpresa]
	(
	    [IdSegmentoEmpresa] BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	    [IdEmpresa] BIGINT NOT NULL,
	    [DesSegmento] NVARCHAR(50) NOT NULL,
	    [Ativo] bit NOT NULL default(0)
	);
	GO
	    ALTER TABLE [dbo].[Tb_SegmentoEmpresa]
	    ADD CONSTRAINT FK_Tb_SegmentoEmpresa_Tb_Empresa FOREIGN KEY (IdEmpresa) REFERENCES Tb_Empresa (IdEmpresa)
	GO
	IF OBJECT_ID('[dbo].[Tb_Vendas]', 'U') IS NOT NULL
	DROP TABLE [dbo].[Tb_Vendas]
	GO
	
	CREATE TABLE [dbo].[Tb_Vendas]
	(
	    [IdVenda] BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	    [IdEmpresa] BIGINT NOT NULL,
	    [IdUsuarioCadastro] BIGINT NOT NULL,
	    [ValorVenda] NUMERIC(11,2) NOT NULL,
	    [DataVenda] DATETIME NOT NULL,
	    [EmitidoNF] bit NOT NULL default(0)
	);
	GO
	ALTER TABLE [dbo].[Tb_Vendas]
	ADD CONSTRAINT FK_Tb_Vendas_Tb_Empresa FOREIGN KEY (IdEmpresa) REFERENCES Tb_Empresa (IdEmpresa)
	GO
	    
	ALTER TABLE [dbo].[Tb_Vendas]
	ADD CONSTRAINT FK_Tb_Vendas_Tb_Usuario FOREIGN KEY (IdUsuarioCadastro) REFERENCES Tb_Usuario (IdUsuario)
	GO
</code>
