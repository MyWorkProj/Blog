<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="angularJSProj.blog.main.bloginfotb.Modify" validateRequest="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <meta http-equiv="Content-Type" content="text/html;charset=utf-8" />
    <script src="../../js/jquery-1.6.4.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../js/ueditor/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../js/ueditor/ueditor.all.min.js"> </script>
    <!--建议手动加在语言，避免在ie下有时因为加载语言失败导致编辑器加载失败-->
    <!--这里加载的语言文件会覆盖你在配置项目里添加的语言类型，比如你在配置项目里配置的是英文，这里加载的中文，那最后就是中文-->
    <script type="text/javascript" charset="utf-8" src="../../js/ueditor/lang/zh-cn/zh-cn.js"></script>

    <style type="text/css">
        div {
            width: 100%;
        }
    </style>
    <script>
        $().ready(function () {
            var ue = UE.getEditor('editor');

            UE.getEditor('editor').addListener("ready", function () {
                UE.getEditor('editor').setContent('<% =GetContent%>');
            });

        });

        function btnSave() {
            $('#txtContent2').val(UE.getEditor('editor').getContent());
        }

    </script>
</head>
<body>
    <form id="form2" runat="server">
        <div>
            <asp:HiddenField runat="server" ID="ModelId"/>
            <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>
                    <td class="tdbg">

                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tr>
                                <td>Mark：</td>
                                <td>
                                    <asp:TextBox ID="txtMark" runat="server" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Title：</td>
                                <td>
                                    <asp:TextBox ID="txtTitle" runat="server" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Content：</td>
                                <td>
                                    <div class="details">
                                        <script id="editor" type="text/plain"></script>
                                    </div>
                                    <asp:HiddenField runat="server" ID="txtContent2"/>
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
                        <asp:button id="button1" runat="server" text="保存"  onclick="btnSave_Click" onclientclick="btnSave()"></asp:button>
                        
                        <asp:Button ID="Button2" runat="server" Text="取消" OnClick="btnCancle_Click"></asp:Button>

                    </td>
                </tr>
            </table>
            <br />
        </div>
    </form>

   
</body>
</html>
