CREATE TABLE [dbo].[Reports]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Date] DATE NOT NULL, 
    [ProductId] INT NOT NULL, 
    [OutletId] INT NOT NULL, 
    [RealizationRate] FLOAT NOT NULL, 
    CONSTRAINT [FK_Reports_ToTable_Products] FOREIGN KEY ([ProductId]) REFERENCES [Products]([Id]), 
    CONSTRAINT [FK_Reports_ToTable_Outlets] FOREIGN KEY ([OutletId]) REFERENCES [Outlets]([Id])
)
