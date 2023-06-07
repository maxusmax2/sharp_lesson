CREATE FUNCTION [dbo].[SessionsUser]
(
	@UserId int,
	@PageNum int,
	@RowOnPage int
)
RETURNS TABLE
RETURN
(
	SELECT * FROM 
	LOGINS WHERE UserId = @UserId 
	ORDER BY Date 
	OFFSET @PageNum ROWS
	FETCH NEXT @RowOnPage ROWS ONLY
)

