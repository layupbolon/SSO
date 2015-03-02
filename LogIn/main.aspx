<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="LogIn.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">SiteA</asp:LinkButton>   
        </div>
        <div>
        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">SiteB</asp:LinkButton>
    </div>
    </form>
</body>
</html>
