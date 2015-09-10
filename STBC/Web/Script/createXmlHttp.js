function createXmlHttp() {//创建xhr对象
            var xhobj = false;
            try {
                xhobj = new ActiveXObject("Msxml2.XMLHTTP"); // ie msxml3.0+
            } catch (e) {
                try {
                    xhobj = new ActiveXObject("Microsoft.XMLHTTP"); //ie msxml2.6
                } catch (e2) {
                    xhobj = false;
                }
            }
            if (!xhobj && typeof XMLHttpRequest != 'undefined') {// Firefox, Opera 8.0+, Safari
                xhobj = new XMLHttpRequest();
            }
            return xhobj;
        }