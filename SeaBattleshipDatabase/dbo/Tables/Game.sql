CREATE TABLE [dbo].[Game] (
    [GameID]              INT      NOT NULL,
    [HostPlayerFieldID]   INT      NOT NULL,
    [SecondPlayerFieldID] INT      NOT NULL,
    [StartDate]           DATE     NULL,
    [StartTime]           TIME (7) NULL,
    CONSTRAINT [PK_Game] PRIMARY KEY CLUSTERED ([GameID] ASC),
    CONSTRAINT [FK_Game_PlayerOne] FOREIGN KEY ([HostPlayerFieldID]) REFERENCES [dbo].[PlayerField] ([PlayerFieldID]),
    CONSTRAINT [FK_Game_PlayerTwo] FOREIGN KEY ([SecondPlayerFieldID]) REFERENCES [dbo].[PlayerField] ([PlayerFieldID])
);

