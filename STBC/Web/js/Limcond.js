var selects2;
$(function () {
    //获取所有的下拉框
    selects2 = $("#LimcondGrid select");
    for (var i = 1; i < selects2.length; i = i + 3) {
        var select = selects2[i];
        select.style.display = "none";
    }
    for (var i = 2; i < selects2.length; i = i + 3) {
        var select = selects2[i];
        select.onchange = ddlonChange2;
    }
});
function ddlonChange2() {
    for (var i = 0; i < selects2.length; i++) {
        if (selects2[i] == this) {
            var select = selects2[i];
            var tr1 = select.parentNode.parentNode;
            var selectcollect = tr1.getElementsByTagName("select");
            if (select.value == "数值类型") {
                selectcollect[0].style.display = "";
                selectcollect[1].style.display = "none";
            }
            else {
                selectcollect[0].style.display = "none";
                selectcollect[1].style.display = "";
            }
        }
    }
}