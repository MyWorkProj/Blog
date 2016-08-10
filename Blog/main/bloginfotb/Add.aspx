<%@ Page Title="" Language="C#" MasterPageFile="~/main/master.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="angularJSProj.blog.main.bloginfotb.Add"  validateRequest="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Add</title>
   
    <style type="text/css">
        div {
            width: 100%;
        }
    </style>
    <script src="../../js/jquery-1.6.4.min.js"></script>
    <script>
        $().ready(function () {
            var ue = UE.getEditor('editor');


        });
        function btnSave() {

            $('#txtContent2').val(UE.getEditor('editor').getContent());
            $('#Content_txtContent2').val(UE.getEditor('editor').getContent());
            
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div>
            <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>
                    <td class="tdbg">
                        <br />
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tr>
                                <th>Mark：</th>
                                <td>
                                    <asp:TextBox ID="txtMark" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>
                                <th>Title：</th>
                                <td>
                                    <asp:TextBox ID="txtTitle" runat="server"  CssClass="form-control"></asp:TextBox>
                                </td>
                                 <th>TypeNo：</th>
                                <td>
                                    <asp:TextBox ID="txtTypeNo" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>
                                 <th>CreateDate：</th>
                                <td>
                                    <asp:TextBox ID="txtCreateDate" runat="server" onfocus="setday(this)"></asp:TextBox>
                                </td>
                            </tr>
                            <tr><th>Content:</th></tr>
                            <tr>
                                <%--<th>Content：</th>--%>
                                <td colspan="8">
                                    <div class="details">
                                        <script id="editor" type="text/plain"></script>
                                    </div>
                                    <asp:HiddenField runat="server" ID="txtContent2"/>
                                </td>
                            </tr>
                        </table>
                         <br />
                    </td>
                </tr>
                <tr>
                    <td class="tdbg" align="center" valign="bottom">
                        <asp:button id="button1" runat="server" text="保存"  onclick="btnSave_Click" onclientclick="btnSave()" CssClass="btn  btn-success"></asp:button>
                        
                        <asp:Button ID="Button2" runat="server" Text="取消" OnClick="btnCancle_Click" CssClass="btn  btn-success"></asp:Button>

                    </td>
                </tr>
            </table>
            <br />
        </div>
    
</asp:Content>
