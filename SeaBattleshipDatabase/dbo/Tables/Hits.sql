CREATE TABLE [dbo].[Hits] (
    [HitID]     INT      NOT NULL,
    [GameID]    INT      NOT NULL,
    [PlayerID]  INT      NOT NULL,
    [X_Hit]     INT      NOT NULL,
    [Y_Hit]     INT      NOT NULL,
    [isSuccess] BIT      NOT NULL,
    [HItDate]   DATE     NULL,
    [HitTime]   TIME (7) NULL,
    CONSTRAINT [PK_Hits] PRIMARY KEY CLUSTERED ([HitID] ASC, [GameID] ASC),
    CONSTRAINT [FK_Hits_Game] FOREIGN KEY ([GameID]) REFERENCES [dbo].[Game] ([GameID]),
    CONSTRAINT [FK_Hits_Player] FOREIGN KEY ([PlayerID]) REFERENCES [dbo].[Player] ([PlayerID])
);

