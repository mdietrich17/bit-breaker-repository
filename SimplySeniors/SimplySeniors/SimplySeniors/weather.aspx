<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="weather.aspx.cs" Inherits="SimplySeniors.Models.WeatherAPI" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        table
        {
            border: 1px solid #ccc;
            border-collapse: collapse;
        }
        table th
        {
            background-color: #F7F7F7;
            color: #333;
            font-weight: bold;
        }
        table th, table td
        {
            padding: 5px;
            border: 1px solid #ccc;
        }
        table, table table td
        {
            border: 0px solid #ccc;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:TextBox Visible="False" ID="txtCity" runat="server" Text="Monmouth, Oregon" /> <%-- Here is where you go to input the location for the mapping function. We can import their location into this cell once set up. --%>
    <asp:Button Visible="False" Text="Get Weather Information" runat="server" OnLoad="GetWeatherInfo" />
    <br/>
    <table id="tblWeather" runat="server" border="0" cellpadding="0" cellspacing="0"
        visible="True">
        <tr>
            <th colspan="2">
                Weather Information
            </th>
        </tr>
        <tr>
            <td rowspan="3">
                <asp:Image ID="imgWeatherIcon" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCity_Country" runat="server" />
                <asp:Image ID="imgCountryFlag" runat="server" />
                <asp:Label ID="lblDescription" runat="server" />
                Humidity:
                <asp:Label ID="lblHumidity" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Temperature: (Min:
                <asp:Label ID="lblTempMin" runat="server" />
                Max:
                <asp:Label ID="lblTempMax" runat="server" />
                Day:
                <asp:Label ID="lblTempCurrent" runat="server" />)
         
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
