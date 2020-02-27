<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhotoUploadWebForm2.aspx.cs" Inherits="SimplySeniors.PhotoUploadWebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Photo upload form</title>
</head>
<body>
    <form id="form1" runat="server">
   <asp:FileUpload ID="FileUpload1" runat="server" Height="39px" Width="282px" />
        <br/>
        <br/>
        <asp:Button CssClass="btn-outline-primary" Value="Upload" ID="btnUpload" runat="server" OnClick="btnUpload_Click" Height="33px" Width="128px"/>
        <br/>
        <br/>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
        <br/>
        <br/>
        <asp:HyperLink ID="hyperlink"  runat="server">See your Photo </asp:HyperLink>
    </form>
</body>
</html>
