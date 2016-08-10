
        // currentNum:第几页    allNum：数据总数   Count4page:每页显示多少条数据
        function PageSplit(currentNum, allNum, Count4page) {

            if (currentNum > allNum) {
                return "";
            }
            
            if (currentNum <= 0) {
                return "";
            }
            var endPart = " ";
            if (currentNum == allNum) {
                endPart += "<li class='disabled'><a href='#' pageindex = '0'>&rsaquo;</a></li>";
                endPart += "<li class='disabled'><a href='#' pageindex = '0'>&raquo;</a></li>";
                // endPart += "</ul>";
            } else if (currentNum * Count4page > allNum) {
                endPart += "<li class='disabled'><a href='#' pageindex = '0'>&rsaquo;</a></li>";
                endPart += "<li class='disabled'><a href='#' pageindex = '0'>&raquo;</a></li>";
            }
            else
            {
                var lastNum = allNum / Count4page;
                lastNum = (lastNum == 0) ? lastNum : lastNum+1;
                endPart += "<li><a href='#" + (currentNum + 1) + "' pageindex = '" + (currentNum + 1) + "'>&rsaquo;</a></li>";
                endPart += "<li><a href='#" + lastNum + "' pageindex = '" + lastNum + "'>&raquo;</a></li>";
                //   endPart += "</ul>";
            }
            //首页 上一页  1,2,3,4 下一页 末页 
            var middleNum = " ";
            if (currentNum - 3 > 0) {
                middleNum += "<li><a href='#link" + (currentNum - 3) + "'  pageindex='" + (currentNum - 3) + "'> " + (currentNum - 3) + "</a></li>";
            }
            if (currentNum - 2 > 0) {
                middleNum += "<li><a href='#link" + (currentNum - 2) + "'  pageindex='" + (currentNum - 2) + "'> " + (currentNum - 2) + "</a></li>";
            }
            if (currentNum - 1 > 0) {
                middleNum += "<li><a href='#link" + (currentNum - 1) + "'  pageindex='" + (currentNum - 1) + "'> " + (currentNum - 1) + "</a></li>";
            }
            if (currentNum > 0) {
                middleNum += "<li><a href='#'  pageindex='" + (currentNum) + "'>" + currentNum + "</a></li>";
            }

            var startNum = " ";
            if (currentNum <= 1) {
                //  startNum += "<ul>";
                startNum += "<li class='disabled'><a href='#' pageindex = '0'>&laquo;</a></li>";
                startNum += "<li class='disabled'><a href='#' pageindex = '0'>&lsaquo;</a></li>";
            } else {
                //   startNum += "<ul>";
                startNum += "<li><a href='#" + 1 + "' pageindex = '" + 1 + "'>&laquo;</a></li>";
                startNum += "<li><a href='#" + (currentNum - 1) + "' pageindex = '" + (currentNum - 1) + "'>&lsaquo;</a></li>";
            }
            return startNum + middleNum + endPart;

        }