/**利用servlet将menu页面读取过来，写入当前页面。
 */
	$.ajax({
		url:"http://localhost:8080/stbc/createMenu",
		async:false,
		success:function(data, textStatus){
			document.write(data);
		},
		error:function(XMLHttpRequest, textStatus, errorThrown){
			alert("菜单栏加载失败");
		}
	});
