/**
 * Created by Administrator on 14-8-16.
 */
define(function(){
    if(typeof LayerCategory=="undefined")
    {
        var LayerCategory={
            DynamicMapService: "esri.layers.ArcGISDynamicMapServiceLayer",
            ImageService:"esri.layers.ArcGISImageServiceLayer",
            TiedMapService:"esri.layers.ArcGISTiledMapServiceLayer"
        };
    }
    return LayerCategory;
});