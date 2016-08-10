
        function btnClick() {
            console.log("===1===");

            alert("===11==");
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "List.aspx/GetAllCount",
                data: json,
                dataType: "json",
                success: function (result) {
                    var rtnValue = result.d
                    console.log("===true====" + rtnValue);
                },
                error: function (result, status) {
                    if (status == 'error') {
                        console.log("===false====");
                    }
                }
            });
        }
function btnOptionSearch() {
    var searchValue = $("#searchInput").val();

    pageChange(1, getObj(0));
}

function getObj(mysqlIndex) {
    var searchValue = $("#searchInput").val();
    var obj = new Object();
    if (searchValue == undefined) {
        obj.strWhere = "";
    }
    else {
        obj.strWhere = " title like '%" + searchValue + "%' or Content like '%" + searchValue + "%'";
    }


    obj.orderby = "";

    // mysql  limit 第一个参数，从第几个数开始取
    obj.startIndex = mysqlIndex;
    // mysql  limit 第二个参数，要取数据的个数
    obj.length = 10;

    var parm = JSON2.stringify(obj);
    return parm;
}

$().ready(function () {
    // 获取数据总数
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "List.aspx/GetAllCount",
        data: {},
        dataType: 'json',
        success: function (result) {
            try {
                var allCount = result.d;

                pageChange(1, getObj(0));
            }
            catch (e) {
                //window.link.utility.showSuccessMessage(e);
                return;
            }
        },
        error: function (result, status) {
            if (status == 'error') {
                //window.link.utility.showSuccessMessage(status);
            }
        }
    });
});


// pageIndex : 第几页， parm  查询参数
function pageChange(pageIndex, parm) {
    $.ajax({
        type: "POST",
        contentType: "application/json",
        //url: "../../AjaxService/AjaxWebService.asmx/GetListByPage",
        url: "List.aspx/GetListByPage",
        data: parm,
        dataType: 'json',
        success: function (result) {
            showValue(result, pageIndex, parm);

            //try {

            //    showValue(result, pageIndex, parm);
            //}
            //catch (e) {
            //    window.link.utility.showSuccessMessage(e);
            //    return;
            //}
        },
        error: function (result, status) { //如果没有上面的捕获出错会执行这里的回调函数
            if (status == 'error') {
                window.link.utility.showSuccessMessage(status);
            }
        }
    });
}
function getMinContent(content) {
    if (content.length > 100) {
        content = content.substr(0, 100) + "......";
    }
    return content;
}
function showValue(result, pageIndex, parm) {
    var DataSet = result.d;
    var str = "<table class='table table-bordered table-hover'>";
    //	Mark	Title	Content	TypeNo	CreateDate	详细	编辑
    str += "<tr><th>Mark</th><th>Title</th><th>Content</th><th>TypeNo</th><th>CreateDate</th><th>详细</th><th>编辑</th></tr>";

    $.each(DataSet, function (i, item) {
        var minContent = getMinContent(item.Content);
        //str += "<div class='col-xs-12' onclick='showDetailDiv(this," + item.ID + ")'><p><a class='text-medium text-lg text-primary' href='#'>" + item.Title + "</a><br><div class='contain-xs pull-left'>" + minContent + "</div></div>";
        //<td><span style='display:inline-block;width:30px;'><input id='Content_gridView_DeleteThis_0' type='checkbox' name='ctl00$Content$gridView$ctl02$DeleteThis' onclick='javascript:CCA(this);'></span></td>
        str += "<tr align='center'><td align='center'>" + item.Mark + "</td><td align='center'>" + item.Title + "</td><td align='center'><a href='Show.aspx?id=" + item.Id + "' style='display:inline-block;'>" + minContent + "</a></td><td align='center'>" + item.TypeNo + "</td><td align='center'>" + item.CDate + "</td><td><a href='Show.aspx?id=" + item.Id + "' style='display:inline-block;width:50px;'>详细</a></td><td><a href='Modify.aspx?id=" + item.Id + "' style='display:inline-block;width:50px;'>编辑</a></td></tr>";
    })

    str += "</table>";
    $("#divSearchContent").html('');
    $("#divSearchContent").append(str);


    $("#div_page").children().remove();

    // 获取数据总数
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "List.aspx/GetAllCount",
        data: {},
        dataType: 'json',
        success: function (result) {
            try {
                var allCount = result.d;
                var pagegroup = PageSplit(pageIndex, allCount, 6);

                $("#div_page").html(pagegroup);
                $("#div_page").find("a").click(function () {
                    var pageindex = parseInt($(this).attr("pageindex"));
                    var str2 = JSON.parse(parm);
                    str2.startIndex = (pageindex - 1) * 10;
                    parm = JSON.stringify(str2);

                    if (pageindex != 0) {
                        pageChange(pageindex, parm);
                    }
                });
            }
            catch (e) {
                window.link.utility.showSuccessMessage(e);
                return;
            }
        },
        error: function (result, status) {
            if (status == 'error') {
                window.link.utility.showSuccessMessage(status);
            }
        }
    });
}

function showDetailDiv(obj, id) {
    var value1 = "{id:'" + id + "'}";
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "../AjaxService/AjaxWebService.asmx/GetFaqListByID",
        data: value1,
        dataType: 'json', //返回的类型为XML ，和前面的Json，不一样了
        success: function (result) {
            //演示一下捕获
            try {
                var jsonDatas = window.link.utility.strToJson($(result).get(0).d);
                LoadContrlData(jsonDatas, obj);
            }
            catch (e) {
                window.link.utility.showSuccessMessage(e);
                return;
            }
        },
        error: function (result, status) { //如果没有上面的捕获出错会执行这里的回调函数
            if (status == 'error') {
                window.link.utility.showSuccessMessage(status);
            }
        }
    });
}
function LoadContrlData(jsonDatas, obj) {
    if (jsonDatas.ID != null) {
        var txtTitle = jsonDatas.FaqTitle;
        var busstreecode = jsonDatas.BussTreeCode;
        //var busstreetext = GetCodeName(jsonDatas.BussTreeCode);
        var drpFlowType = jsonDatas.IDFlow;
        var Content = jsonDatas.Content;
        var strType = busstreecode == 10000 ? "知识库类别" : "";
        var tbValue = "<tr class='wd-searchBox-Layout'><th>标题：</th><td>" + txtTitle + "</td></tr><tr class='wd-searchBox-Layout'><th>知识库分类：</th><td>" + strType + "</td></tr><tr class='wd-searchBox-Layout'><th>内容：</th><td>" + Content + "</td></tr>";
        $("#contentID").html('');
        $("#contentID").append(tbValue);

        showMask();
        showMenu(obj);
    }
}