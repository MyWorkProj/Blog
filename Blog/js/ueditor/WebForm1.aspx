<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication4.ueditor.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <meta http-equiv="Content-Type" content="text/html;charset=utf-8"/>
    <script type="text/javascript" charset="utf-8" src="ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="ueditor.all.min.js"> </script>
    <!--建议手动加在语言，避免在ie下有时因为加载语言失败导致编辑器加载失败-->
    <!--这里加载的语言文件会覆盖你在配置项目里添加的语言类型，比如你在配置项目里配置的是英文，这里加载的中文，那最后就是中文-->
    <script type="text/javascript" charset="utf-8" src="lang/zh-cn/zh-cn.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>完整demo</h1>
     <textarea id="myEditor" name="myEditor" runat="server" onblur="setUeditor()" style="width: 700px;
                                                                    height: 100%;"></textarea>
    </div>
    </form>
    <div>

</div>



<script type="text/javascript">


    var editor = new baidu.editor.ui.Editor();

    editor.render("<%=myEditor.ClientID%>");
    function setUeditor() {
        var myEditor = document.getElementById("myEditor");
        myEditor.value = editor.getContent(); //把得到的值给textarea
    }
    //实例化编辑器
    //建议使用工厂方法getEditor创建和引用编辑器实例，如果在某个闭包下引用该编辑器，直接调用UE.getEditor('editor')就能拿到相关的实例
   
</script>
</body>
</html>
