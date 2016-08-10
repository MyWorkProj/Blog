/// <reference path="../jquery-1.6.4.min.js" />
(function ($,window, $) {
    var blogFunc = {
        btnSearch: function () {
            var txtSearch = document.getElementById('txtSearch').value;
            
            var json = { "strWhere": " content like '%"+ txtSearch +"%'" };
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "../AjaxService/AjaxWebService.asmx/GetListByPage",
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
        
        },
        btnCancle: function () {
            return false;
        }

    };

    //if (!window.blog.blogFunc) {
    //    window.blog.blogFunc = {}
    //}
    
    window.blogFunc = blogFunc;
})(window.JQuery,window,window.blogFunc);
