CREATE FUNCTION [dbo].[GetLoginForIP]
(
	@IpADDRESS nvarchar(15),
	@PageNum int,
	@RowOnPage int
)
RETURNS TABLE AS RETURN
(
	SELECT Id,Date,IpAddress,DeviceSettings,UserId FROM LOGINS
	WHERE IpAddress LIKE '@IpADDRESS.%'
	ORDER BY Id
	OFFSET @PageNum ROWS
	FETCH NEXT @RowOnPage ROWS ONLY
)
