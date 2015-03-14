
CREATE DATABASE Fruit;
GO
USE Fruit;

CREATE TABLE [dbo].[GrowsOn] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [GrowsOn] NVARCHAR (50) NOT NULL
);
GO
CREATE TABLE [dbo].[Fruit]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FruitName] NVARCHAR(50) NOT NULL, 
    [FruitColor] NVARCHAR(50) NULL, 
    [FruitGrowsOn] INT NULL, 
    [FruitIsYummy] BIT NULL
)
GO
INSERT INTO [GrowsOn] ([GrowsOn]) VALUES
	('Tree'),('Bush'),('Vine');
INSERT INTO [Fruit] ([FruitName], [FruitColor], [FruitGrowsOn],[FruitIsYummy]) VALUES
	('Apple', 'Red', 1, 1), ('Banana', 'Yellow', 1, 1)

