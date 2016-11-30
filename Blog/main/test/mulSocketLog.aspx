<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mulSocketLog.aspx.cs" Inherits="Blog.main.test.mulSocketLog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input type="button" value="坛内框" id="btnClose"/>
    </div>
    </form>

    <script>
        document.ready = function () {
            console.log("=====ready=====");

            document.getElementById("btnClose").onclick = function () {
                //window.open('page.html', 'newwindow', 'height=100, width=400, top=0, left=0, toolbar=no, menubar=no, scrollbars=no, resizable=no, location=no, status=no')   //该句写成一行代码
                //参数解释：
                //window.open 弹出新窗口的命令； 
                //'page.html' 弹出窗口的文件名； 
                //'newwindow' 弹出窗口的名字（不是文件名），非必须，可用空''代替； 
                    //_blank - URL加载到一个新的窗口。这是默认
                    //_parent - URL加载到父框架
                    //_self - URL替换当前页面
                    //_top - URL替换任何可加载的框架集
                    //name - 窗口名称

                //height=100 窗口高度； 
                //width=400 窗口宽度； 
                //top=0 窗口距离屏幕上方的象素值； 
                //left=0 窗口距离屏幕左侧的象素值； 
                //toolbar=no 是否显示工具栏，yes为显示； 
                //menubar，scrollbars 表示菜单栏和滚动栏。 
                //resizable=no 是否允许改变窗口大小，yes为允许； 
                //location=no 是否显示地址栏，yes为允许； 
                //status=no 是否显示状态栏内的信息（通常是文件已经打开），yes为允许；
                window.open("t2.html", '_self', "modal=yes,top=150,left=150,width=500,height=500,resizable=no,scrollbars=no");
            }
        }
    </script>
</body>
</html>
