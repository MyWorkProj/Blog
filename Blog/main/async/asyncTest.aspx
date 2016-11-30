<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="asyncTest.aspx.cs" Inherits="Blog.main.async.asyncTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div  id="showValue">
        <%=showValue%>
    </div>
        <input type="button" value="客户端控件" onserverclick="btnClick0_Click" runat="server"/>
        <asp:Button ID="btnClick" runat="server" OnClick="btnClick_Click" Text="点击调用" />
    </form>
</body>
</html>
