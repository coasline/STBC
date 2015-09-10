/**
 * Created by Administrator on 14-8-16.
 */
define([
    "dojo/_base/declare",
    "esri/map","esri/layers/Layer",
    "esri/dijit/Scalebar",
    "dojo/domReady!"
],function(declare,Map,Layer,ScaleBar){
    return declare(null,{
        mapDiv:null,
        constructor:function(mapdiv){
            this.mapDiv=new Map(mapdiv);
            var scalebar=new ScaleBar({
                map:this.mapDiv,
                scalebarUnit:"metric",
                attachTo:"bottom-left"
            });
        },
        AddLayer:function(layerCategory,url){
            var newStr='new '+layerCategory+'("'+url+'");';
            //var newStr='new esri.layers.ArcGISDynamicMapServiceLayer("http://193.100.100.136:6080/arcgis/rest/services/bjMap/MapServer");';
           // var layer=eval(newStr);
            //var dynamicMap=new esri.layers.ArcGISDynamicMapServiceLayer('http://193.100.100.136:6080/arcgis/rest/services/bjMap/MapServer');
            this.mapDiv.addLayer(dy);
        }
    });
});