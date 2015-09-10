var arr1;
var len;
$(function () {
    var inputs = $("#BenefitGrid input");
    arr1 = new Array();
    len = Math.sqrt(inputs.length);
    for (var i = 0; i < len; i++) {
        arr1[i] = new Array();
        for (var j = 0; j < len; j++) {
            arr1[i][j] = inputs[i * len + j];
            if (i == j) {
                arr1[i][j].value = "1.0";
            }
            if (i >= j) {
                arr1[i][j].readOnly = true;
            }
            else {
                arr1[i][j].onchange = InputBoxChanged;
            }
        }
    }
});
//当效益的相比较矩阵右上角改变的时候，自动补全矩阵下三角
function InputBoxChanged() {
    for (var i = 0; i < len; i++) {
        for (var j = 0; j < len; j++) {
            if (arr1[i][j] == this) {
                arr1[j][i].value = 1 / parseFloat(this.value);

            }
        }
    }
}
//重置效益举证
function ResetBenMax() {
    for (var i = 0; i < len; i++) {
        for (var j = 0; j < len; j++) {
            if (i == j) {
                arr1[i][j].value = "1.0";
            }
            else {
                arr1[i][j].value = "";
            }
        }
    }
}

var arr2;
var len2;
$(function () {
    var inputs = $("#SuitfactGrid input");

    arr2 = new Array();
    len2 = Math.sqrt(inputs.length);
    for (var i = 0; i < len2; i++) {
        arr2[i] = new Array();
        for (var j = 0; j < len2; j++) {
            arr2[i][j] = inputs[i * len2 + j];
            if (i == j) {
                arr2[i][j].value = "1.0";
            }
            if (i >= j) {
                arr2[i][j].readOnly = true;
            }
            else {
                arr2[i][j].onchange = InputBoxChanged2;
            }
        }
    }
});
//当适宜性的相比较矩阵右上角改变的时候，自动补全矩阵下三角
function InputBoxChanged2() {
    for (var i = 0; i < len2; i++) {
        for (var j = 0; j < len2; j++) {
            if (arr2[i][j] == this) {
                arr2[j][i].value = 1 / parseFloat(this.value);

            }
        }
    }
}
//重置适宜性矩阵
function ResetSuitMax1() {
    for (var i = 0; i < len2; i++) {
        for (var j = 0; j < len2; j++) {
            if (i == j) {
                arr2[i][j].value = "1.0";
            }
            else {
                arr2[i][j].value = "";
            }
        }
    }
}

var arr3;
var len3;
$(function () {
    var inputs = $("#SuitfactGrid2 input");
    arr3 = new Array();
    len3 = Math.sqrt(inputs.length);
    for (var i = 0; i < len3; i++) {
        arr3[i] = new Array();
        for (var j = 0; j < len3; j++) {
            arr3[i][j] = inputs[i * len3 + j];
            if (i == j) {
                arr3[i][j].value = "1.0";
            }
            if (i >= j) {
                arr3[i][j].readOnly = true;
            }
            else {
                arr3[i][j].onchange = InputBoxChanged3;
            }
        }
    }
});
//当适宜性矩阵右上角改变的时候，自动补全矩阵下三角
function InputBoxChanged3() {
    for (var i = 0; i < len3; i++) {
        for (var j = 0; j < len3; j++) {
            if (arr3[i][j] == this) {
                arr3[j][i].value = 1 / parseFloat(this.value);

            }
        }
    }
}
//重置适宜性矩阵
function ResetSuitMax2() {
    for (var i = 0; i < len3; i++) {
        for (var j = 0; j < len3; j++) {
            if (i == j) {
                arr3[i][j].value = "1.0";
            }
            else {
                arr3[i][j].value = "";
            }
        }
    }
}

var arr4;
var len4;
$(function () {
    var inputs = $("#SuitfactGrid3 input");
    arr4 = new Array();
    len4 = Math.sqrt(inputs.length);
    for (var i = 0; i < len4; i++) {
        arr4[i] = new Array();
        for (var j = 0; j < len4; j++) {
            arr4[i][j] = inputs[i * len4 + j];
            if (i == j) {
                arr4[i][j].value = "1.0";
            }
            if (i >= j) {
                arr4[i][j].readOnly = true;
            }
            else {
                arr4[i][j].onchange = InputBoxChanged4;
            }
        }
    }
});
//当适宜性的相比较矩阵右上角改变的时候，自动补全矩阵下三角
function InputBoxChanged4() {
    for (var i = 0; i < len4; i++) {
        for (var j = 0; j < len4; j++) {
            if (arr4[i][j] == this) {
                arr4[j][i].value = 1 / parseFloat(this.value);

            }
        }
    }
}
//重置适宜性矩阵
function ResetSuitMax3() {
    for (var i = 0; i < len4; i++) {
        for (var j = 0; j < len4; j++) {
            if (i == j) {
                arr4[i][j].value = "1.0";
            }
            else {
                arr4[i][j].value = "";
            }
        }
    }
}
//重置适宜性所有矩阵
function ResetSuitMax() {
    ResetSuitMax1();
    ResetSuitMax2();
    ResetSuitMax3();
}