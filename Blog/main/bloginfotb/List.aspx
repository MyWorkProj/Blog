<%@ Page Title="" Language="C#" MasterPageFile="~/main/master.Master" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="angularJSProj.blog.main.bloginfotb.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>list.aspx</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div>
            <%--<table class="table" style="visibility:hidden">
                <tr>
                    <td style="width: 80px" align="right" class="tdbg">
                        <b>关键字：</b>
                    </td>
                    <td class="tdbg">
                        <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" ></asp:Button>

                    </td>
                    <td class="tdbg"></td>
                </tr>
            </table--%>
            <!--Search end-->
            <%--<asp:GridView ID="gridView" runat="server" AllowPaging="True" Width="100%" CellPadding="3" OnPageIndexChanging="gridView_PageIndexChanging"
                BorderWidth="1px" DataKeyNames="Id" OnRowDataBound="gridView_RowDataBound"
                AutoGenerateColumns="false" PageSize="10" RowStyle-HorizontalAlign="Center" OnRowCreated="gridView_OnRowCreated">
                <Columns>
                    <asp:TemplateField ControlStyle-Width="30" HeaderText="选择">
                        <ItemTemplate>
                            <asp:CheckBox ID="DeleteThis" onclick="javascript:CCA(this);" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="Mark" HeaderText="Mark" SortExpression="Mark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Content" HeaderText="Content" SortExpression="Content" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="TypeNo" HeaderText="TypeNo" SortExpression="TypeNo" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="CreateDate" HeaderText="CreateDate" SortExpression="CreateDate" ItemStyle-HorizontalAlign="Center" />

                    <asp:HyperLinkField HeaderText="详细" ControlStyle-Width="50" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="Show.aspx?id={0}"
                        Text="详细" />
                    <asp:HyperLinkField HeaderText="编辑" ControlStyle-Width="50" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="Modify.aspx?id={0}"
                        Text="编辑" />
                    <asp:TemplateField ControlStyle-Width="50" HeaderText="删除" Visible="false">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                Text="删除"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <table border="0" cellpadding="0" cellspacing="1" style="width: 100%;">
                <tr>
                    <td style="width: 1px;"></td>
                    <td align="left">
                        <asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click" />
                    </td>
                </tr>
            </table>--%>
            <div class="list-results list-results-underlined" id="divSearchContent" style="overflow-y: auto"></div>
            <ul class="pagination" id="div_page"></ul>

        </div>
        <button id="btnClick" onclick="btnClick()" style="visibility:hidden">查看   </button>

    
</asp:Content>
