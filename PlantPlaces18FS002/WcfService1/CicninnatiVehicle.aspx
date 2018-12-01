<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CicninnatiVehicle.aspx.cs" Inherits="WcfService1.CicninnatiVehicle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Odometer:"></asp:Label>
            <asp:TextBox ID="TxtOdometer" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            <asp:Label ID="LblCount" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
