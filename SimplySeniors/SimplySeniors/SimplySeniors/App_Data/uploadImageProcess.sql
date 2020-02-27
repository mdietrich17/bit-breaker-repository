CREATE PROC spUploadImage 
@Name NVARCHAR(255), 
@Size INT, 
@ImageData VARBINARY(max), 
@NewID INT output 
as
Begin
	INSERT into Images
	values(@Name, @size, @ImageData)
	Select @NewId = SCOPE_IDENTITY()
End
