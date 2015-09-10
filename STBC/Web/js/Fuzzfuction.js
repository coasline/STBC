var selects;
$(function () {
    //获取所有的下拉框
    selects = $("#FuzzfunctGrid select");

    for (var i = 0; i < selects.length; i++) {
        var select = selects[i];
        select.onchange = ddlonChange;
    }
});
function ddlonChange() {
    for (var i = 0; i < selects.length; i++) {
        if (selects[i] == this) {
            var select = selects[i];
            var index = select.selectedIndex; // 选中索引
            var text = select.options[index].text; // 选中文本
            var value = select.options[index].value; // 选中值  
            var tr1 = select.parentNode.parentNode;
            var div = tr1.getElementsByTagName("div");
            if (value == "抛物线型") {
                div[0].style.display = "inline";
                div[1].style.display = "none";
                div[2].style.display = "none";
                div[3].style.display = "none";
            }
            else if (value == "升半梯形") {
                div[0].style.display = "none";
                div[1].style.display = "inline";
                div[2].style.display = "none";
                div[3].style.display = "none";
            }
            else if (value == "降半梯形") {
                div[0].style.display = "none";
                div[1].style.display = "none";
                div[2].style.display = "inline";
                div[3].style.display = "none";
            }
            else {
                div[0].style.display = "none";
                div[1].style.display = "none";
                div[2].style.display = "none";
                div[3].style.display = "inline";
            }
        }
    }
}