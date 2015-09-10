function getRootPath(){ 
	var strFullPath=window.document.location.href; 
	var strPath=window.document.location.pathname; 
	var pos=strFullPath.indexOf(strPath); 
	var prePath=strFullPath.substring(0,pos); 
	var postPath=strPath.substring(0,strPath.substr(1).indexOf('/')+1); 
	return(prePath+postPath); 
} 
//var webpath=getRootPath(); //webpath就是目录路径变量

dojoConfig = {
		// Don't attempt to parse the page for widgets
		parseOnLoad: true,
		packages: [
			// Any references to a "demo" resource should load modules locally, *not* from CDN
			{
				name: "model",
				location: getRootPath()+"/model"
			}
		],
		// Timeout after 10 seconds
		waitSeconds: 10,
		map: {
			// Instead of having to type "dojo/domReady!", we just want "ready!" instead
			"*": {
				ready: "dojo/domReady"
			}
		},
		// Get "fresh" resources
		cacheBust: true
	};