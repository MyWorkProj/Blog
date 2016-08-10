<%@ Page Title="" Language="C#" MasterPageFile="~/main/master.Master" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="Blog.main.bloginfotb.test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Add</title>

    



    <link href="../../js/common/JiaThisCss.css" rel="stylesheet" />
    <script type="text/javascript" charset="utf-8" src="../../js/ueditor/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../js/ueditor/ueditor.all.min.js"> </script>
    <script type="text/javascript" charset="utf-8" src="../../js/ueditor/lang/zh-cn/zh-cn.js"></script>
    <style type="text/css">
        div {
            width: 100%;
        }
    </style>
    
    <script>
        $().ready(function () {
            var ue = UE.getEditor('editor');


        });
        function btnSave() {

            ueditor.ready(function () {
                //ueditor.setContent('UEditor报错TypeError: me.body is undefined');

                $('#txtContent2').val(UE.getEditor('editor').getContent());
            });

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <br /><br /><br />
    <p class="navbar-text">
        阿斯顿撒健健康康
    </p>

    <div class="jumbotron">
  <h1>Hello, world!</h1>
  <p>...</p>
  <p><a class="btn btn-primary btn-lg" href="#" role="button">Learn more</a></p>
</div>
    <br /><br /><br /><br />


    <!-- JiaThis Button BEGIN -->
<script type="text/javascript" src="http://v3.jiathis.com/code/jiathis_r.js?btn=r2.gif" charset="utf-8"></script>
<!-- JiaThis Button END -->
<!-- UJian Button BEGIN -->
	<script type="text/javascript" src="http://v1.ujian.cc/code/ujian.js?type=slide"></script>
<!-- UJian Button END -->


    
    <br />
    <!-- Small modal -->
<button type="button" class="btn btn-primary" data-toggle="modal" data-target=".bs-example-modal-sm">Small modal</button>

<div class="modal fade bs-example-modal-sm" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel">
  <div class="modal-dialog modal-sm">
    <div class="modal-content">
      ...
    </div>
  </div>
</div>
     <br />
    <!-- Button trigger modal -->
<button type="button" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#myModal">
  Launch demo modal
</button>

<!-- Modal -->
<div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Modal title</h4>
      </div>
      <div class="modal-body">
        ...
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Save changes</button>
      </div>
    </div>
  </div>
</div>

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



    <div class="progress">
  <div class="progress-bar" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="min-width: 2em;">
    0%
  </div>
</div>
<div class="progress">
  <div class="progress-bar" role="progressbar" aria-valuenow="2" aria-valuemin="0" aria-valuemax="100" style="min-width: 2em; width: 2%;">
    2%
  </div>
</div>
    <br />
    <noscript>
  <!-- anchor linking to external file -->
  <a href="http://www.mozilla.com/">your webbrowser  does not support javascript!</a>
</noscript>
<p>Rocks!</p>

    <hr />
    <br />
    <!-- 16:9 aspect ratio -->
<div class="embed-responsive embed-responsive-16by9">
 <%-- <iframe class="embed-responsive-item" src="../../images/张杰%20-%20我想%20[mqms].mp4" style="width:800px;height:600px"></iframe>--%>
</div>
    <video src="../../images/张杰%20-%20我想%20[mqms].mp4" controls="controls" />
<!-- 4:3 aspect ratio -->
<div class="embed-responsive embed-responsive-4by3" style="width:800px;height:600px">
  <iframe class="embed-responsive-item" src="../../images/yoga.jpg"></iframe>
</div>
   

    <hr/>
    <div class="well">..ssssssadasdasd.</div>
    <hr />
    <ul class="list-group">
  <li class="list-group-item" style="width:200px">
    <span class="badge">14</span>
    Cras justo odio
  </li>
</ul>
    ===============================================================================================
    <div class="progress">
  <div class="progress-bar progress-bar-striped active" role="progressbar" aria-valuenow="45" aria-valuemin="0" aria-valuemax="100" style="width: 45%">
    <span class="sr-only">45% Complete</span>
  </div>
</div>
    ===============================================================================================
    <div class="progress">
  <div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" style="width: 40%">
    <span class="sr-only">40% Complete (success)</span>
  </div>
</div>
<div class="progress">
  <div class="progress-bar progress-bar-info" role="progressbar" aria-valuenow="20" aria-valuemin="0" aria-valuemax="100" style="width: 20%">
    <span class="sr-only">20% Complete</span>
  </div>
</div>
<div class="progress">
  <div class="progress-bar progress-bar-warning" role="progressbar" aria-valuenow="60" aria-valuemin="0" aria-valuemax="100" style="width: 60%">
    <span class="sr-only">60% Complete (warning)</span>
  </div>
</div>
<div class="progress">
  <div class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="80" aria-valuemin="0" aria-valuemax="100" style="width: 80%">
    <span class="sr-only">80% Complete (danger)</span>
  </div>
</div>
</asp:Content>
