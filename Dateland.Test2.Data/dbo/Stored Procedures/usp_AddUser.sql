CREATE PROCEDURE [dbo].[usp_AddUser]
	@firstName nvarchar(50),
	@lastName nvarchar(50),
	@emailAdress nvarchar(50),
	@profilePictureUrl nvarchar(max)
AS
INSERT INTO [dbo].[Users](FirstName, LastName, EmailAdress, ProfilePictureUrl)
VALUES
(
	@firstName, @lastName, @emailAdress, @profilePictureUrl
)
