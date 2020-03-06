<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhotoUploadWebForm2.aspx.cs" Inherits="SimplySeniors.PhotoUploadWebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Photo upload Form</title>
    <style type="text/css">
        #uploadPhotoBox {
            width: 320px;
        }
    </style>
</head>
<body>
    <div class="container" id="uploadPhotoBox" style="border: solid; border-radius: 1em; margin: 50px; background:antiquewhite">
    <h1 style="margin-left: 25px">Upload photos here</h1>

    <div class="card-header">
    <form id="form1" runat="server">
        <asp:FileUpload ID="FileUpload1" runat="server" Height="39px" Width="222px" style="color: lightblue; margin-left: 4em; " />
        <br/>
        <br/>
        <div style="margin-left: 40px; justify-content: center; border: black" >
            <asp:Button Class="btn-outline-primary" ID="btnUpload" runat="server" Text="Upload Now" OnClick="btnUpload_Click" Label="Upload" Height="37px" Width="100px" style="text-align: center; margin-left: 5em; color: black; "/>
        </div>
        <br/>
        <br/>
        <asp:Label ID="lblMessage" BorderStyle="Groove" BorderWidth="1px" style="text-align: center; padding: 1.5em; " runat="server">Upload</asp:Label>
        <br/>
        <br/>
        <asp:HyperLink ID="hyperlink" style="text-align: center; margin-left: 2.5em; margin-bottom: 2em; padding: 1em;" runat="server">See your Photo by clicking here</asp:HyperLink>
        

    </form> 
        
        

    </div>
    </div>
</body>
</html>
