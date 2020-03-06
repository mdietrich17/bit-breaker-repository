CREATE PROC spUploadImage 
@Name NVARCHAR(255), 
@Size INT, 
@ProfileId INT, 
@ImageData VARBINARY(max), 
@NewID INT output 
as
Begin
	INSERT into Images
	values(@Name, @Size, @ImageData,@ProfileId)
	Select @NewId = SCOPE_IDENTITY()    /** Returns the index of the location of the stored image within the Images table **/
End
