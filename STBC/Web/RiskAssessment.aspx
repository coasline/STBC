<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RiskAssessment.aspx.cs" Inherits="Web.RiskAssessment" %>

<!DOCTYPE html>

<html>
<head runat="server">
 <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>风险评估</title>
    <link rel="stylesheet" href="css/Default.css" type="text/css" />
    <script type="text/javascript" src="Script/jquery-1.9.1.min.js"></script>
  <script type="text/javascript" src="Script/Default.js"></script>
    <style type="text/css">
        body{background: #69C url(images/cloud.png) top no-repeat;}
        #banner{width: 1200px;margin-left: auto;margin-right: auto;}
        .COL_S2{width: 1182px;} 
    </style>
     <%--  操作地图本地库引入--%>
      <script src="http://js.arcgis.com/3.10compact"></script>
          <link rel="stylesheet" href="http://js.arcgis.com/3.10/js/esri/css/esri.css"> 
          <link rel="shortcut icon" href="http://esri.github.io/quickstart-map-js/images/favicon.ico">
  <link rel="stylesheet" href="http://netdna.bootstrapcdn.com/bootstrap/3.1.1/css/bootstrap.min.css"  >
  <link rel="stylesheet" href="http://esri.github.io/bootstrap-map-js/src/css/bootstrapmap.css">

    <%--<link rel="stylesheet" type="text/css" href="http://193.100.100.26/arcgis_js_api/library/3.9/3.9/js/dojo/dijit/themes/tundra/tundra.css" />
    <link rel="stylesheet" type="text/css" href="http://193.100.100.26/arcgis_js_api/library/3.9/3.9/js/esri/css/esri.css" />
    <script type="text/javascript" src="http://193.100.100.26/arcgis_js_api/library/3.9/3.9/init.js"></script>--%>
</head>
<body>
    <form id="form1" runat="server">
        <dl id="banner">
        <dd>
            <div id="sysTitle">
                水土保持决策支持系统</div>
        </dd>
    </dl>
        <div class="COL_S2">
            <div id="tabs">
            <ul>
                <li class="normal"><a href="Index.aspx">首页</a></li>
             
                <li class="normal"><a href="SuitEvaluation.aspx">适宜性评价</a></li>
                 <li class="selected"><a href="RiskAssessment.aspx">风险评估与敏感性评价</a></li>
            </ul>

        </div>
               <div id="hall">
                   <div class="fieldsetPanel">
    <div class="pr BG"></div>

    <div class="p7 BG"></div>
    <div class="pt BGx"></div>
    <div class="box">
      <div>
      <table border="0" cellpadding="0" cellspacing="0">
        <tr>
       
          <td>
                
                         
                                    <select id="ddlMeasure" name="ddlMeasure">
                                
                                            <option>选择待评价措施</option>
                                        <option>敏感性评价</option>
                                        <option >风险评估</option>
                                        <option >降雨侵蚀力因子（R）</option>
                                        <option>土壤可蚀性因子（K）</option>
                                        <option>坡度坡长因子（LS）</option>
                                        <option>植被覆盖因子（C）</option>
                                        <option>水保措施因子（P）</option>
                                     
                                    </select>
                                    <input type="button" id="execute"   value="执行" class="G_btn"/>
                                    <input type="button" value="制图" onclick="mapping();" class="G_btn"/>
                                    <input type="button" value="导出地图"  class="G_btn"/>
          
              <select>
               
                 <option>选择图层类型</option>
                  <option>降雨</option>
                  <option>土壤</option>
                  <option>DEM</option>
                  <option>植被</option>
                  <option>水保</option>
                
              </select>
              <select>
                
                  <option>选择图层</option>
                 
              </select>
             <input type="file"   />
              <input type="button" value="上传图层" class="G_btn" />
          </td>
        </tr>
    
      
      </table>
      </div>
    </div>
  </div>
                   <div id="map" style="margin-right:9px;margin-left:9px;height: 400px;border:1px solid #c1dad7;margin-top:9px;">  
                                    </div>
                   <div id="legendDiv"  style="margin-right:9px;margin-left:9px;height: 50px;border:1px solid #c1dad7;margin-top:9px;"></div>
                   <div class="window" id="div_table">
                <div class="title"><span class="text">风险与敏感性等级面积统计</span></div>
                <div class="slideBox" id="div_ct">
                    <table class="t withDoubleTH" cellpadding="0" cellspacing="0" width="100%" border="0">
                        <tr>
                            <th colspan="5" style="text-align:left;">2013长汀县年水土流失风险等级面积统计</th>
                        </tr>
                        <tr class="SP">
                            <th>
                               风险等级
                            </th>
                            <th>
                                侵蚀模数
                            </th>
                            <th>
                                面积
                            </th>
                            <th>
                                比例
                            </th>
                            <th>
                                主要分布
                            </th>
                        </tr>
                        <tr>
                            <td>很低
                               
                            </td>
                            <td>
                               0-5 
                            </td>
                            <td>
                               2873 
                            </td>
                            <td>
                                92.68
                            </td>
                            <td>
                               其他乡镇人口相对稀少、植被覆盖良好、土地开发利用最低，故水土流失风险分布主要以很低、低为主。 
                            </td>
                        </tr>
                        <tr>
                            <td>低
                               
                            </td>
                            <td>
                                5-10
                            </td>
                            <td>
                                110.1
                            </td>
                            <td>
                                3.55
                            </td>
                            <td>
                                主要分布在古城、宣成、馆前、童坊等乡镇，同时这几个乡镇水土流失也以轻度为主，中度次之，少数强烈及以上
                            </td>
                        </tr>
                        <tr>
                            <td>中
                               
                            </td>
                            <td>
                               10-25 
                            </td>
                            <td>
                                76.2
                            </td>
                            <td>
                               2.46 
                            </td>
                            <td>
                               主要分布在濯田、涂坊、南山、新桥、大同等乡镇，同时这几个乡镇也是水土流失多发的区域。 
                            </td>
                        </tr>
                        <tr>
                            <td>高
                               
                            </td>
                            <td>
                               >25 
                            </td>
                            <td>
                                40.6
                            </td>
                            <td>
                               1.31 
                            </td>
                            <td>
                               主要分布在河田、三洲、策武三个乡镇，同时这三个也是也是水土流失最严重的区域，存在大面积强烈及以上的水土流失区。 
                            </td>
                        </tr>
                       
                    </table>
                </div>
                           <div class="slideBox"  id="div_gx" >
                    <table class="t withDoubleTH" cellpadding="0" cellspacing="0" width="100%" border="0">
                        <tr>
                            <th colspan="5" style="text-align:left;">各乡镇综合敏感性各等级所占面积统计表</th>
                        </tr>
                        <tr class="SP">
                            <th>
                               敏感等级
                            </th>
                        
                            <th>
                                面积
                            </th>
                            <th>
                                比例
                            </th>
                            <th>
                                主要分布
                            </th>
                        </tr>
                        <tr>
                            <td>不敏感
                               
                            </td>
                         
                            <td>
                               31.7416
                            </td>
                            <td>
                               1.03
                            </td>
                            <td>
                               主要分布在濯田镇的西北部及南部，且不敏感区土壤类型主要为硅质红壤
                            </td>
                        </tr>
                        <tr>
                            <td>轻度敏感
                               
                            </td>
                         
                            <td>
                               1829.6364
                            </td>
                            <td>
                                59.25
                            </td>
                            <td>
                                主要分布在古城、策武、濯田、四都、红山、羊牯等西部和西南部乡镇以及东北部的童坊镇
                            </td>
                        </tr>
                        <tr>
                            <td>中度敏感
                               
                            </td>
                         
                            <td>
                                1196.7711
                            </td>
                            <td>
                               38.75
                            </td>
                            <td>
                               主要集中在长汀县的北部及东南部，占有较大比例的乡镇有铁长、庵杰、新桥、大同、策武、河田、三州、涂坊及南山
                            </td>
                        </tr>
                        <tr>
                            <td>高度敏感
                               
                            </td>
                           
                            <td>
                              29.8293
                            </td>
                            <td>
                               0.97
                            </td>
                            <td>
                              主要散布在长汀县的北部及东南部 
                            </td>
                        </tr>
                        <tr>
                            <td>极敏感
                               
                            </td>
                           
                            <td>
                           0.0710
                            </td>
                            <td>
                              0.00
                            </td>
                            <td>
                               极度敏感区的面积几乎为零，可以忽略 
                            </td>
                        </tr>
                       
                    </table>
                </div>
                
                <div class="clear">
                </div>
            </div>
                   </div>
        </div>
     <div id="Copyright">
        Copyright &copy; 2013 Fuda Geo-Information Co., Ltd. All rights reserved.</div>
        
         <script type="text/javascript">
             //// Load map and app
             //require(["esri/map", "app", "dojo/domReady!"],
             //  function (Map, app, utils) {
             //      "use-strict"
             //      var map = new Map("mapDiv", {
             //          basemap: "gray",
             //          center: [-100, 50],
             //          zoom: 3
             //      });
             //      app.init(map);
             //  });

             //$(document).ready(function () {

             //    $("#div_gx").hide();
             //    $("#div_ct").hide();
             //    $("#div_table").hide();
             //    $("#ddlMeasure").change(function () { 
             //        $("#div_gx").hide();
             //        $("#div_ct").hide();
             //        $("#div_table").hide();
             //        var option = $("#ddlMeasure").val();

             //        switch (option) {
             //            case "风险评估":
             //                $("#div_ct").show();
             //                $("#div_table").show();
                             
             //                break;
             //            case "敏感性评价":
             //                $("#div_gx").show();
             //                $("#div_table").show();
             //                break;
             //            default:
             //                break;
             //        } 
             //    });

             //});
             ////var map;
             var layerInfo = { layer: layer.layer, title: layer.layer.name };
             require(["esri/map", "esri/layers/ArcGISTiledMapServiceLayer", "esri/layers/ArcGISDynamicMapServiceLayer", "esri/dijit/Legend", "dojo/domReady!"],
               function (Map, Tiled,Dynamic, Legend) {
                   map = new Map("map");
                   var tiled = new Tiled("http://193.100.100.26:6080/arcgis/rest/services/changting/MapServer");
                   var dynamic = new Dynamic("http://193.100.100.26:6080/arcgis/rest/services/evaluatedata/jingjilinguo/MapServer");
                   map.addLayer(tiled);
                   map.addLayer(dynamic);
                   var legend = new Legend({
                       map: map,
                       autoUpdate: true,
                       arrangement: esri.dijit.Legend.ALIGN_RIGHT,
                       layerInfos: layerInfo

                   }, "legendDiv");
                   legend.startup();
               }
             );
             //function Maplegend() {
             ////    var legendPar = {
             ////        map: Map,
             ////        arrangment: esri.dijit.Legend.ALIGN_RIGHT,
             ////        autoUpdate: true

             ////    };
             //    var legendDijit = new esri.dijit.Legend(legendPar, "legendDiv");
             //    legendDijit.startup();
             //}

             //dojo.require("esri.map");
             ////var myMap;
             ////var visible = [];
             ////var dynamicMapServiceLayer = [];
             ////var dynamicMapServiceLayer2;
             ////function init1() {
             ////    myMap = new esri.Map("map", {
             ////        center: [116.3642160, 25.8392740],
             ////        zoom: 12,
             ////        // maxScale: 500,
             ////        minScale: 1000000
             ////    });
                

             ////    if (navigator.onLine) {
             ////        var basemap = new esri.layers.ArcGISTiledMapServiceLayer("http://193.100.100.26:6080/arcgis/rest/services/evaluatedata/jingjilinguo/MapServer");
             ////        // var basemap = new esri.layers.ArcGISTiledMapServiceLayer("http://cache1.arcgisonline.cn/ArcGIS/rest/services/ChinaOnlineStreetWarm/MapServer");
             ////        myMap.addLayer(basemap);
             ////    } 
             ////}
              
             //var myMap;
             //var mapoption = { sliderStyle: "large" }; //JSON对象 
            
            
             //function Maplegend() {
             //    mapoption.center = [116.3642160, 25.8392740]; //这个点处于地图的中间 
             //    myMap = new esri.Map("map", mapoption);
             //    var layer = new esri.layers.ArcGISTiledMapServiceLayer("http://193.100.100.26:6080/arcgis/rest/services/evaluatedata/jingjilinguo/MapServer");
             //    myMap.addLayer(layer);
             //    var legendPar = { map: Map, arrangment: esri.dijit.Legend.ALIGN_RIGHT, autoUpdate: true };
             //    var legendDijit = new esri.dijit.Legend(legendPar, "legendDiv"); legendDijit.startup();
             //}
             //dojo.addOnLoad(Maplegend);
    </script>
    </form>
</body>
</html>
