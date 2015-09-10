/**
 * Created by Administrator on 14-8-26.
 */
function browser_version(){
    var Sys = {};
    var ua = navigator.userAgent.toLowerCase();
    if (window.ActiveXObject){
        Sys.ie = ua.match(/msie ([\d.]+)/)[1];
    }else if (document.getBoxObjectFor){
        Sys.firefox = ua.match(/firefox\/([\d.]+)/)[1];
    }else if (window.MessageEvent && !document.getBoxObjectFor){
        var s=ua.match(/chrome\/([\d.]+)/);
        Sys.chrome = ua.match(/chrome\/([\d.]+)/)[1];
    }else if (window.opera){
        Sys.opera = ua.match(/opera.([\d.]+)/)[1];
    }else if (window.openDatabase){
        Sys.safari = ua.match(/version\/([\d.]+)/)[1];
    }
    return Sys;
}