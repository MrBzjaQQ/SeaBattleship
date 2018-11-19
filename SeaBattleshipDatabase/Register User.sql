CREATE PROCEDURE RegisterUser @PlayerID INT, @Login VARCHAR(16), @EMail VARCHAR(100), 
@Password VARCHAR(100), @RegistrationDate DATE, @RegistrationTime TIME
AS
BEGIN
INSERT INTO [Player] VALUES (@PlayerID, @Login, @EMail, @Password, @RegistrationDate, @RegistrationTime);
END;