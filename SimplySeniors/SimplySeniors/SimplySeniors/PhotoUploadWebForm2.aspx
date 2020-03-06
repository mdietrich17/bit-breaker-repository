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
    <div class="container" id="uploadPhotoBox">
    <h1>Upload photos here</h1>
    <div class="card-header">
    <form id="form1" runat="server">
        <asp:FileUpload ID="FileUpload1" runat="server" Height="39px" Width="292px" style="color: #003300; background-color: #FFFFFF" />
        <br/>
        <br/>
        <div style="margin-left: 40px">
            <asp:Button Class="btn-outline-primary" ID="btnUpload" runat="server" Text="Upload Now" OnClick="btnUpload_Click" Label="Upload" Height="37px" Width="113px" style="text-align: left; color: #FFFFFF; margin-top: 0px; background-color: #0000CC"/>
        </div>
        <br/>
        <br/>
        <asp:Label ID="lblMessage" runat="server">Upload</asp:Label>
        <br/>
        <br/>
        <asp:HyperLink ID="hyperlink"  runat="server">See your Photo by clicking here</asp:HyperLink>
    </form>
    </div>
    </div>
</body>
</html>
