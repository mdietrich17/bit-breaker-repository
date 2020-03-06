/** This code creates a procedure within our db to use SQL query to retireve the binary image data. **/
CREATE PROC spGetImageById
@Id INT
as
Begin 
	SELECT ImageData FROM Images WHERE Id = @Id
End