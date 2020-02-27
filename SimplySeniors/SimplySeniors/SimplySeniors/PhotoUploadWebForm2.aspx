<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhotoUploadWebForm2.aspx.cs" Inherits="SimplySeniors.PhotoUploadWebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Upload Your Photo Here!</title>
</head>
<body>
    <form id="form1" runat="server">
   <asp:FileUpload ID="FileUpload1" runat="server" />
        <br/>
        <br/>
        <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click"/>
        <br/>
        <br/>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
        <br/>
        <br/>
        <asp:HyperLink ID="hyperlink"  runat="server">See your Photo </asp:HyperLink>
    </form>
</body>
</html>
