<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="show.aspx.cs" Inherits="angularJSProj.blog.main.bloginfotb.show" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <meta http-equiv="Content-Type" content="text/html;charset=utf-8" />
    <script src="../../js/jquery-1.6.4.min.js"></script>
    <script>
        <%--$().ready(function () {

        });

        function btnSave() {
            $('#txtContent2').val(UE.getEditor('editor').getContent());
        }--%>

    </script>
</head>
<body>
    <form id="form2" runat="server">
        <div>
            <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>
                    <td class="tdbg">

                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tr>
                                <td>Mark：</td>
                                <td>
                                    <asp:TextBox ID="txtMark" runat="server" Width="200px"></asp:TextBox>
                                </td>
                            <%--</tr>--%>
                            <tr>
                                <td>Title：</td>
                                <td>
                                    <asp:TextBox ID="txtTitle" runat="server" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Content：</td>
                                <td>
                                    <div id="divContent"><%=GetContent %></div>
                                    <%--<div class="details">
                                        <script id="editor" type="text/plain"></script>
                                    </div>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>TypeNo：</td>
                                <td>
                                    <asp:TextBox ID="txtTypeNo" runat="server" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>CreateDate：</td>
                                <td>
                                    <asp:TextBox ID="txtCreateDate" runat="server" Width="70px" onfocus="setday(this)"></asp:TextBox>
                                </td>
                            </tr>
                        </table>

                    </td>
                </tr>
                <tr>
                    <td class="tdbg" align="center" valign="bottom">
                       <%-- <asp:button id="button1" runat="server" text="保存"  onclick="btnSave_Click" onclientclick="btnSave()"></asp:button>--%>
                        
                        <asp:Button ID="Button2" runat="server" Text="取消" OnClick="btnCancle_Click"></asp:Button>

                    </td>
                </tr>
            </table>
            <br />
        </div>
    </form>

   
</body>
</html>
