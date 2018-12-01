<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Math.aspx.cs" Inherits="WcfService1.Math" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Number 1:"></asp:Label>
            <asp:TextBox ID="Number1" runat="server"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="Number 2:"></asp:Label>
            <asp:TextBox ID="Number2" runat="server"></asp:TextBox>
            <asp:Button ID="BtnSum" runat="server" OnClick="BtnSum_Click" Text="=" />
            <asp:Label ID="LblSum" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
