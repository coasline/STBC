function setH(){
   var h0=$("body").innerHeight()
   var h1=$("#dropNav").outerHeight(true)+39
   var h2=$("body").innerHeight()-$("#tip").outerHeight(true)-$("#tabs").outerHeight(true)-2
   var h3=$("#banner").innerHeight()+$("#Copyright").innerHeight()
   $("#sysMenu").height(h0-h3-34)
   $("#frameBox_S1 iframe").height(h0-h3-18)
   $("#slideBox").height(h2)
   $("#sider").height(h2)
   $("#panel").height(h2)
   $("#frameBox_S2 iframe").height(h0-h1)
}
function setW(){
	$(".window").width($("#slideBox").innerWidth()-58);
}
function openNewWin(url){
	if($.browser.msie&$.browser.version=="6.0"){
		var winW=window.screen.availWidth-20
	    var winH=window.screen.availHeight-42
	    window.open(url,"height="+winH+",width="+winW+",top=0,left=0,toolbar=no,menubar=no,scrollbars=no,resizable=no,location=no");
    }
	else{
		window.open(url)
	}
}
$(document).ready(function(){
	$("#dropNav a:odd").addClass("odd")
	$("a:odd",".portalPanel div").addClass("odd")
	$(".t tr:even").addClass("alt")
	$(".t tr").find("td:last").css("border-right","1px solid #FFF")
	$(".form").find("tr:last td").css("border-bottom","none")
	$(".form").find("tr:last th").css("border-bottom","none")
	$("#hall dl:last").css("border-bottom","none")
	$("#postDetail dl:last").css("border-bottom","none");
});
$(window).resize(function(){

    setH();

});