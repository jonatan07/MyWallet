# MyWallet

## Descripcion
Es un API tipo **REST** construido para manejar las operaciones basicas (CRUD) de una billetera.
Ademas permila generacion de operaciones (Debito / Credito) y ver el historial de las mismas.

## Tecnologias
La tecnologia que usan en el API son las siguientes:
- ASP.NET 8
- C# 8
- Entity Framework
- Serilog
- MediatR
- Swagger (Open API)
## Base de datos
- Sql server
## Buenas practicas implementadas:
- Solid
- Dry
- DTO
- Clear Architect

## Datos importantes:
  Se uso una implementacion de DataBase First para la creacion de este proyecto
## Diagrama de base de datos:

![MyWallet](https://github.com/user-attachments/assets/d02aba2b-b6a1-402c-b66b-0009b46b58b6).
<br>

## Script de base de datos
```SQL
CREATE TABLE [wallet] (
  [id] int identity PRIMARY KEY,
  [documentId] varchar(25),
  [documentType] varchar(10),
  [name] varchar(50),
  [balance] decimal(16,2),
  [createdAt] datetime,
  [updatedAt] datetime
)
GO

CREATE TABLE [operations] (
  [id] int identity PRIMARY KEY,
  [walletId] int NOT NULL,
  [type] varchar(8),
  [amount] decimal(16,2),
  [createdAt] datetime,
  [updatedAt] datetime
)
GO

ALTER TABLE [operations] ADD FOREIGN KEY ([walletId]) REFERENCES [wallet] ([id])
GO

ALTER TABLE [wallet] ADD FOREIGN KEY ([userId]) REFERENCES [user] ([id])
GO

