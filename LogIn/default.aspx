<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="LogIn._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="用户名："></asp:Label><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </div>
        <div>
        <asp:Label ID="Label2" runat="server" Text="密码："></asp:Label><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    </div>
        <div>
            <asp:Button ID="Button1" runat="server" Text="登录" OnClick="Button1_Click" /><asp:Button ID="Button2" runat="server" Text="重置" OnClick="Button2_Click" />
            <asp:Button ID="Button3" runat="server" Text="showCookie" OnClick="Button3_Click" />
    </div>
    </form>
</body>
</html>
