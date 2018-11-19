CREATE TABLE [dbo].[PlayerField] (
    [PlayerFieldID] INT         NOT NULL,
    [PlayerID]      INT         NOT NULL,
    [GameField]     NCHAR (100) NOT NULL,
    CONSTRAINT [PK_PlayerField] PRIMARY KEY CLUSTERED ([PlayerFieldID] ASC),
    CONSTRAINT [FK_PlayerField_Player] FOREIGN KEY ([PlayerID]) REFERENCES [dbo].[Player] ([PlayerID])
);

