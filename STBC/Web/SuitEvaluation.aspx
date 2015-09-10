<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuitEvaluation.aspx.cs"
    Inherits="Web.SuitEvaluation" %>

<%@ Register Src="usercontrol/menu.ascx" TagName="menubar" TagPrefix="menu" %>
<!DOCTYPE HTML>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>适宜性评价</title>
    <link rel="stylesheet" href="css/Default.css" type="text/css" />
    <script type="text/javascript" src="Script/jquery-1.9.1.min.js"></script>
  <script type="text/javascript" src="Script/Default.js"></script>
      <%--  矩阵根据上三角计算下三角的值--%>
    <script src="js/Matrix.js" type="text/javascript"></script>
    <%--  控制模糊函数的选择--%>
    <script src="js/Fuzzfuction.js" type="text/javascript"></script>
    <%--  限制条件脚本控制--%>
    <script src="js/Limcond.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
            background: #69C url(images/cloud.png) top no-repeat;
        }
        #banner
        {
            width: 1200px;
            margin-left: auto;
            margin-right: auto;
        }
        .COL_S2
        {
            width: 1182px;
        }
        

        .tableS1{table-layout:fixed;}
     
    </style>
    <%--  操作地图本地库引入--%>
    <link rel="stylesheet" type="text/css" href="http://193.100.100.26/arcgis_js_api/library/3.9/3.9/js/dojo/dijit/themes/tundra/tundra.css" />
    <link rel="stylesheet" type="text/css" href="http://193.100.100.26/arcgis_js_api/library/3.9/3.9/js/esri/css/esri.css" />
    <script type="text/javascript" src="http://193.100.100.26/arcgis_js_api/library/3.9/3.9/init.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {

        
            $("#ddlMeasure").change(function () {
                $("#div_shentailinchao").hide();
                $("#div_fenjin").hide();
                $("#div_dixiaogaizhao").hide(); 
                $("#div_zhonhe").hide();
                $("#div_jinjilinguo").hide();
            var option = $("#ddlMeasure").val();
            myMap.removeLayer(dynamicMapServiceLayer);
            switch (option) {
                case "综合评价":
                    $("#div_zhonhe").show();
                    dynamicMapServiceLayer = new esri.layers.ArcGISDynamicMapServiceLayer("http://193.100.100.26:6080/arcgis/rest/services/evaluatedata/fourmeasuresend/MapServer");
                    break;
                case "生态林草":
                    $("#div_shentailinchao").show();
                    dynamicMapServiceLayer = new esri.layers.ArcGISDynamicMapServiceLayer("http://193.100.100.26:6080/arcgis/rest/services/evaluatedata/shengtailincao/MapServer");
                    break;
                case "经济林果":
                    $("#div_jinjilinguo").show();
                    dynamicMapServiceLayer = new esri.layers.ArcGISDynamicMapServiceLayer("http://193.100.100.26:6080/arcgis/rest/services/evaluatedata/jingjilinguo/MapServer");
                    break;
                case "低效林改造":
                    $("#div_dixiaogaizhao").show();
                    dynamicMapServiceLayer = new esri.layers.ArcGISDynamicMapServiceLayer("http://193.100.100.26:6080/arcgis/rest/services/evaluatedata/dixiaolingai/MapServer");
                    break;
                case "封禁":
                    $("#div_fenjin").show();
                    dynamicMapServiceLayer = new esri.layers.ArcGISDynamicMapServiceLayer("http://193.100.100.26:6080/arcgis/rest/services/evaluatedata/fengjin/MapServer");
                    break;
                default:
                    break;

            }
           
            myMap.addLayer(dynamicMapServiceLayer);
        });

        });

        function Maplegend() { 
            var legendPar = {
                map: Map,
                arrangment: esri.dijit.Legend.ALIGN_RIGHT,
                autoUpdate: true

            };
            var legendDijit = new esri.dijit.Legend(legendPar, "legendDiv");
            legendDijit.startup();

        }

        dojo.require("esri.map");
        dojo.require("esri.dijit.Legend");
        var myMap;
        var visible = [];
        var dynamicMapServiceLayer = [];
        var dynamicMapServiceLayer2;
        function init1() {
            myMap = new esri.Map("map", {
                center: [116.3642160, 25.8392740],
                zoom: 12,
               // maxScale: 500,
                minScale: 1000000            });
            dynamicMapServiceLayer = new esri.layers.ArcGISDynamicMapServiceLayer("http://193.100.100.26:6080/arcgis/rest/services/evaluatedata/jingjilinguo/MapServer");
            //dynamicMapServiceLayer = new esri.layers.ArcGISDynamicMapServiceLayer("http://193.100.100.26:6080/arcgis/rest/services/sensitivitydata/2013zhibeiC/MapServer");
            
            
            if (navigator.onLine) {
                var basemap = new esri.layers.ArcGISTiledMapServiceLayer("http://193.100.100.26:6080/arcgis/rest/services/changting/MapServer");
               // var basemap = new esri.layers.ArcGISTiledMapServiceLayer("http://cache1.arcgisonline.cn/ArcGIS/rest/services/ChinaOnlineStreetWarm/MapServer");
                myMap.addLayer(basemap);
            }
            //添加图层载入后监听方法loadLayerList

            dojo.connect(dynamicMapServiceLayer, "onLoad", loadLayerList);
            myMap.addLayer(dynamicMapServiceLayer); 
        }
        //载入地图名称到右边的列表中
        function loadLayerList(layers) {
            var html = "";
            //获取图层信息
            var infos = layers.layerInfos;
            for (var i = 0; i < infos.length; i++) {
                var info = infos[i];
                //图层默认显示的话就把图层id添加到visible
                if (info.defaultVisibility) {
                    visible.push(info.id);
                }
                //输出图层列表的html
                html = html + "<div><input id='" + info.id + "' name='layerList' class='listCss' type='checkbox' value='checkbox' onclick='setLayerVisibility()' " + (info.defaultVisibility ? "checked" : "") + " />" + info.name + "</div>"

            }

            //设置可视图层
            dynamicMapServiceLayer.setVisibleLayers(visible);

            //在右边显示图层名列表
            dojo.byId("left-text").innerHTML = html;
        }
        //设置图层是否可视的方法
        function setLayerVisibility() {
            //用dojo.query获取css为listCss的元素数组
            var inputs = dojo.query(".listCss");
            visible = [];
            //对checkbox数组进行变量把选中的id添加到visible
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].checked) {
                    visible.push(inputs[i].id);
                }
            }
            //设置可视图层
            dynamicMapServiceLayer.setVisibleLayers(visible);
        }
        dojo.addOnLoad(init1);
  
        function CallServer() {
            //让执行按钮不可用，放置二次点击，在执行完之后再可用
            $("#execute").attr("disabled", true); 
            var ddlMeasure = document.getElementById("ddlMeasure");
            var measureName = ddlMeasure.options[ddlMeasure.selectedIndex].text; // 选中文本
            <%= ClientScript.GetCallbackEventReference(this, "measureName", "ReceiveServerData",null)%>;
        }
        //服务器执行完后返回到客户端
        function ReceiveServerData(rValue) {
           // if (rValue=="单项措施计算成功") {
                $("#execute").attr("disabled", false); 
                //alert(rValue);
                myMap.removeLayer(dynamicMapServiceLayer);
                myMap.addLayer(dynamicMapServiceLayer2);
            //}

        }
    </script>
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
             
                <li class="selected"><a href="SuitEvaluation.aspx">适宜性评价</a></li>
                <li class="normal"><a href="RiskAssessment.aspx">风险评估</a></li>
            </ul>
        </div>
        <div id="hall">
           <table border="0" cellspacing="0" cellpadding="0" width="100%" class="tableS1">
<tr>
           <td width="50%" valign="top">
             <div id="syxLevel" class="window">
                <div class="title"><span class="winCtrl" title="隐藏窗口内容"></span><span class="text">适宜性分级规则创建</span></div>
                <div class="slideBox">
                    <table class="t" cellpadding="0" cellspacing="0" width="100%" border="0">
                        <tr>
                            <th>
                                级别名称
                            </th>
                            <th>
                                级别Code
                            </th>
                            <th>
                                适宜性指数范围
                            </th>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="levelLabel1" ReadOnly="true" Text="高度适宜" runat="server"></asp:TextBox>
                                <%-- <input name="levelLabel" style="width: 99.4%;" type="text" value="高度适宜">--%>
                            </td>
                            <td>
                                <asp:TextBox ID="levelName1" Text="Highly_Suitable" runat="server"></asp:TextBox>
                                <%-- <input name="levelName" type="text" style="width: 99.4%;" value="Highly_Suitable">--%>
                            </td>
                            <td>
                                （
                                <asp:TextBox ID="levelLeft1" Text="0.8" runat="server"></asp:TextBox>
                                <%--<input type="text" name="levelLeft" value="0.8">--%>,
                                <asp:TextBox ID="levelRight1" Text="1" runat="server"></asp:TextBox>
                                <%--<input type="text" name="levelRight" value="1">--%>]
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="levelLabel2"  ReadOnly="true" Text="比较适宜" runat="server"></asp:TextBox>
                                <%-- <input type="text" style="width: 99.4%;" name="levelLabel" value="比较适宜">--%>
                            </td>
                            <td>
                                <asp:TextBox ID="levelName2" Text="Comparatively_Suitable" runat="server"></asp:TextBox>
                                <%--<input type="text" name="levelName" style="width: 99.4%;" value="Comparatively_Suitable">--%>
                            </td>
                            <td>
                                （
                                <asp:TextBox ID="levelLeft2" Text="0.6" runat="server"></asp:TextBox>
                                <%--<input type="text" name="levelLeft" value="0.6">--%>,
                                <asp:TextBox ID="levelRight2" Text="0.8" runat="server"></asp:TextBox>
                                <%-- <input type="text" name="levelRight" value="0.8">--%>]
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="levelLabel3"  ReadOnly="true" Text="一般适宜" runat="server"></asp:TextBox>
                                <%--  <input type="text" style="width: 99.4%;" name="levelLabel" value="一般适宜">--%>
                            </td>
                            <td>
                                <asp:TextBox ID="levelName3" Text="Popularly_Suitable" runat="server"></asp:TextBox>
                                <%--  <input type="text" name="levelName" style="width: 99.4%;" value="Popularly_Suitable">--%>
                            </td>
                            <td>
                                （
                                <asp:TextBox ID="levelLeft3" Text="0.4" runat="server"></asp:TextBox>
                                <%--<input type="text" name="levelLeft" value="0.4">--%>,
                                <asp:TextBox ID="levelRight3" Text="0.6" runat="server"></asp:TextBox>
                                <%-- <input type="text" name="levelRight" value="0.6">--%>]
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="levelLabel4"  ReadOnly="true" Text="不适宜" runat="server"></asp:TextBox>
                                <%-- <input type="text" style="width: 99.4%;" name="levelLabel" value="不适宜">--%>
                            </td>
                            <td>
                                <asp:TextBox ID="levelName4" Text="No_Suitable" runat="server"></asp:TextBox>
                                <%--  <input type="text" name="levelName" style="width: 99.4%;" value="No_Suitable">--%>
                            </td>
                            <td>
                                （
                                <asp:TextBox ID="levelLeft4" Text="0.0" runat="server"></asp:TextBox>
                                <%--<input type="text" name="levelLeft" value="0.0">--%>,
                                <asp:TextBox ID="levelRight4" Text="0.4" runat="server"></asp:TextBox>
                                <%-- <input type="text" name="levelRight" value="0.4">--%>]
                            </td>
                        </tr>
                    </table>
                </div>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="operationPanel">
                    <tr>
                        <td>
                            <asp:Button ID="addLevel" runat="server" CssClass="G_btn" Text="新增单元行" />
                            <%--   <input type="button" id="addLevel" value="新增单元行" onclick="addvalue();" class="G_btn" />--%>
                            <asp:Button ID="removeLevel" runat="server" CssClass="R_btn" Text="删除最后一行" />
                            <%--<input type="button" id="removeLevel" value="删除最后一行" onclick="removevalue();" class="R_btn" />--%>
                            <asp:Button ID="btnCreateRule" runat="server" CssClass="G_btn" Text="创建规则" 
                                />
                            <asp:Button ID="reset" CssClass="G_btn" runat="server" Text="取消" />
                        </td>
                    </tr>
                </table>
                <div class="clear">
                </div>
            </div>
            <!-- 指标权重计算（ahp法）-->
            <div id="weightCompute" class="window">
                <div class="title"><span class="winCtrl" title="显示窗口内容" style="background-position:-604px -31px;"></span><span class="text">效益评价因子权重设置</span></div>
                <div class="slideBox" style="display:none;">
                    <!--效益因子判断矩阵设置-->
                    <asp:GridView ID="BenefitGrid" GridLines="None"  CssClass="t"
                        runat="server"  Width="100%">
                        <Columns>
                            <asp:BoundField DataField="Name" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:TextBox ID="first" runat="server">
                                    </asp:TextBox></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:TextBox ID="second" runat="server">
                                    </asp:TextBox></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:TextBox ID="three" runat="server">
                                    </asp:TextBox></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:TextBox ID="four" runat="server">
                                    </asp:TextBox></ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="operationPanel">
                    <tr>
                        <td>
                            <asp:Button ID="benefitFactorsComp" runat="server" Text="计算权重" 
                                CssClass="G_btn" />
                            <input type="button" id="resetbenefitFactors" value="重置" onclick="ResetBenMax()"
                                class="G_btn" />
                            <asp:Button ID="benefitFactorscreateRule" runat="server" Text="创建规则" CssClass="G_btn" />
                        </td>
                    </tr>
                </table>
                <div class="slideBox" style="display:none;">
                    <table class="t withDoubleTH" width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <th colspan="5" align="left">
                                效益因子权重计算结果
                            </th>
                        </tr>
                        <tr class="SP">
                            <th>
                                效益评价因子
                            </th>
                            <th>
                                土壤肥力增加值
                            </th>
                            <th>
                                土地产出增加值
                            </th>
                            <th>
                                减流效益
                            </th>
                            <th>
                                减沙效益
                            </th>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="benefitFactors" runat="server" ReadOnly="true" Width="99.4%" Text="0.611"></asp:TextBox>
                                <%-- <input  id="benefitFactors"  runat="server" type="text" />--%>
                            </td>
                            <td>
                                <asp:TextBox ID="delta_fertility" runat="server" ReadOnly="true" Width="99.4%" Text="0.442"></asp:TextBox>
                                <%--  <input id="delta_fertility" runat="server" type="text" />--%>
                            </td>
                            <td>
                                <asp:TextBox ID="delta_landout" runat="server" ReadOnly="true" Width="99.4%" Text="1"></asp:TextBox>
                                <%--  <input id="delta_landout" runat="server" type="text" />--%>
                            </td>
                            <td>
                                <asp:TextBox ID="delta_runoff" runat="server" ReadOnly="true" Width="99.4%" Text="0.333"></asp:TextBox>
                                <%--  <input id="delta_runoff" runat="server" type="text" />--%>
                            </td>
                            <td>
                                <asp:TextBox ID="delta_soilErosion" runat="server" ReadOnly="true" Width="99.4%" Text="0.642"></asp:TextBox>
                                <%-- <input id="delta_soilErosion" runat="server" type="text" />--%>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear"></div>
            </div>
            <div class="window">
                <div class="title"><span class="winCtrl" title="显示窗口内容" style="background-position:-604px -31px;"></span><span class="text">适宜性评价因子权重设置</span></div>
                <%--设置自然因子和社会因子的对比较矩阵--%>
                <div class="slideBox" style="display:none;">
                    <asp:GridView ID="SuitfactGrid" GridLines="None" AutoGenerateColumns="false" CssClass="t"
                        runat="server" >
                        <Columns>
                            <asp:BoundField DataField="Name" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:TextBox ID="first2" runat="server">
                                    </asp:TextBox></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:TextBox ID="second2" runat="server">
                                    </asp:TextBox></ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <%--  设置社会因子--%>
                <div class="slideBox" style="display:none;">
                    <asp:GridView ID="SuitfactGrid2" GridLines="None" AutoGenerateColumns="false" CssClass="t"
                        runat="server"  >
                        <Columns>
                            <asp:BoundField DataField="Name" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:TextBox ID="first3" runat="server">
                                    </asp:TextBox></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:TextBox ID="second3" runat="server">
                                    </asp:TextBox></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:TextBox ID="three3" runat="server">
                                    </asp:TextBox></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:TextBox ID="four3" runat="server">
                                    </asp:TextBox></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:TextBox ID="five3" runat="server">
                                    </asp:TextBox></ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="slideBox" style="display:none;">
                    <%-- 设置自然因子--%>
                    <asp:GridView ID="SuitfactGrid3" GridLines="None" AutoGenerateColumns="false" CssClass="t"
                        runat="server"  >
                        <Columns>
                            <asp:BoundField DataField="Name" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:TextBox ID="first4" runat="server">
                                    </asp:TextBox></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:TextBox ID="second4" runat="server">
                                    </asp:TextBox></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:TextBox ID="three4" runat="server">
                                    </asp:TextBox></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:TextBox ID="four4" runat="server">
                                    </asp:TextBox></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:TextBox ID="five4" runat="server">
                                    </asp:TextBox></ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="operationPanel">
                    <tr>
                        <td>
                            <asp:DropDownList ID="measureSuit" runat="server">
                                <asp:ListItem Value="FJ">封禁</asp:ListItem>
                                <asp:ListItem Value="STLC">生态林草</asp:ListItem>
                                <asp:ListItem Value="DXLGZ">低效林改造</asp:ListItem>
                                <asp:ListItem Value="JJLG" Selected="True">经济林果</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Button ID="suitabilityFactorsComp" runat="server" Text="计算权重" CssClass="G_btn"
                                />
                            <input type="button" id="resetsuitabilityFactors" value="重置" onclick="ResetSuitMax();"
                                class="G_btn" />
                            <asp:Button ID="suitabilityFactorscreateRule" CssClass="G_btn" runat="server" Text="创建规则"
                                 />
                            <%--   <input type="button" id="suitabilityFactorscreateRule" value="创建规则" class="G_btn" />--%>
                            
                            <%--  <input type="button" id="suitabilityFactorsrestW" value="返回重新计算权重" onclick="hidd();" class="R_btn" /></td>--%>
                    </tr>
                </table>
                <div class="slideBox" style="display:none;">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
                        <tr>
                            <th colspan="4" class="mass BGx">
                                适宜性评价因子权重计算结果
                            </th>
                        </tr>
                        <tr>
                            <th class="tint">
                                适宜性评价因子
                            </th>
                            <td colspan="3">
                                <asp:TextBox ID="txtsuitabilityFactors" CssClass="inputText" runat="server"></asp:TextBox>
                                <%--<input type="text" class="inputText" id="suitabilityFactors" />--%>
                            </td>
                        </tr>
                        <tr>
                            <th colspan="4" class="mass BGx">
                                社会经济因子
                            </th>
                        </tr>
                        <tr>
                            <th class="tint">社会经济因子</th>
                            <td colspan="3"><asp:TextBox ID="txtsocioeconomicFactors" CssClass="inputText" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                          
                         
                                
                                <%--  <input type="text" class="inputText" id="natureFactors" /></td>--%>
                                <th class="tint">
                                    农村劳动力密度</th>
                                <td>
                                 <asp:TextBox ID="txtrural_labor_intensity" CssClass="inputText" runat="server"></asp:TextBox>
                                   <%-- <input type="text" class="inputText" id="currentLandUse" />--%>
                                </td>
                                <th class="tint">
                                政府决策因素
                                </th>
                                <td>
                                 <asp:TextBox ID="txtgov_policy" CssClass="inputText" runat="server"></asp:TextBox>
                                  <%--  <input type="text" class="inputText" id="plantcoverage" />--%>
                                </td>
                        </tr>
                        <tr>
                            <th class="tint">
                                建设需求投资
                            </th>
                            <td>
                             <asp:TextBox ID="txtbuildInput" CssClass="inputText" runat="server"></asp:TextBox>
                            <%--    <input type="text" class="inputText" id="slope" />--%>
                            </td>
                            <th class="tint">
                                距道路距离
                            </th>
                            <td>
                             <asp:TextBox ID="txtRoad" CssClass="inputText" runat="server"></asp:TextBox>
                            <%--    <input type="text" class="inputText" id="soilErodibility" />--%>
                            </td>
                        </tr>
                        <tr>
                            <th class="tint">
                                距居民点距离
                            </th>
                            <td colspan="3">
                            <asp:TextBox ID="txtJMD" CssClass="inputText" runat="server"></asp:TextBox>
                               <%-- <input type="text" class="inputText" id="soilErosionIntensity" />--%>
                            </td>
                        </tr>
                        <tr>
                            <th colspan="4" class="mass BGx">
                                自然条件因子
                            </th>
                        </tr>
                        <tr>
                           <th class="tint">自然条件因子</th>
                            <td colspan="3"><asp:TextBox ID="txtnatureFactors" CssClass="inputText" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                        
                            <th class="tint">
                                水土流失强度</th>
                            <td>
                             <asp:TextBox ID="txtsoilErosionIntensity" CssClass="inputText" runat="server"></asp:TextBox>
                              <%--  <input type="text" class="inputText" id="JMD" />--%>
                            </td>
                            <th class="tint">
                                土壤可蚀因子
                            </th>
                            <td>
                            <asp:TextBox ID="txtsoilErodibility" CssClass="inputText" runat="server"></asp:TextBox>
                              <%--  <input type="text" class="inputText" id="Road" />--%>
                            </td>
                        </tr>
                        <tr>
                            <th class="tint">
                                坡度</th>
                            <td>
                            <asp:TextBox ID="txtslope" CssClass="inputText" runat="server"></asp:TextBox>
                               <%-- <input type="text" class="inputText" id="buildInput" />--%>
                            </td>
                            <th class="tint">
                                植被覆盖度
                            </th>
                            <td>
                              <asp:TextBox ID="txtplantcoverage" CssClass="inputText" runat="server"></asp:TextBox>
                              <%--  <input type="text" class="inputText" id="gov_policy" />--%>
                            </td>
                        </tr>
                        <tr>
                            <th class="tint">
                                土地利用现状
                            </th>
                            <td colspan="3">
                             <asp:TextBox ID="txtcurrentLandUse" CssClass="inputText" runat="server"></asp:TextBox>
                             <%--   <input type="text" class="inputText" id="rural_labor_intensity" />--%>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
            <!--模糊函数创建规则构建-->
            <div id="indicatorCompute" class="window">
                <div class="title"><span class="winCtrl"  title="显示窗口内容" style="background-position:-604px -31px;"></span><span class="text">模糊函数创建规则构建</span></div>
                <div class="slideBox"  style="display:none;">
                    <asp:GridView ID="FuzzfunctGrid" GridLines="None" AutoGenerateColumns="false" CssClass="t"
                        runat="server">
                        <Columns>
                            <asp:BoundField DataField="Name" HeaderText="评价因子" />
                            <asp:TemplateField HeaderText="单位">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtUnit1" runat="server">
                                    </asp:TextBox></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="拐点设置">
                                <ItemTemplate>
                                    <div style="display: inline">
                                        <span>a1:</span>
                                        <asp:TextBox ID="txtPa1" runat="server"></asp:TextBox>
                                        <span>b1:</span>
                                        <asp:TextBox ID="txtPb1" runat="server"></asp:TextBox>
                                        <span>b2:</span>
                                        <asp:TextBox ID="txtPb2" runat="server"></asp:TextBox>
                                        <span>a2:</span>
                                        <asp:TextBox ID="txtPa2" runat="server"></asp:TextBox>
                                    </div>
                                    <div style="display: none">
                                        <span>a:</span>
                                        <asp:TextBox ID="txtSa" runat="server"></asp:TextBox>
                                        <span>b:</span>
                                        <asp:TextBox ID="txtSb" runat="server"></asp:TextBox>
                                    </div>
                                    <div style="display: none">
                                        <span>a:</span>
                                        <asp:TextBox ID="txtJa" runat="server"></asp:TextBox>
                                        <span>b:</span>
                                        <asp:TextBox ID="txtJb" runat="server"></asp:TextBox>
                                    </div>
                                    <div style="display: none">
                                        <span>高度适宜:</span>
                                        <asp:TextBox ID="txtGsuit" runat="server"></asp:TextBox>
                                        <span>比较适宜:</span>
                                        <asp:TextBox ID="txtBJsuit" runat="server"></asp:TextBox>
                                        <span>一般适宜:</span>
                                        <asp:TextBox ID="txtYsuit" runat="server"></asp:TextBox>
                                        <span>不适宜:</span>
                                        <asp:TextBox ID="txtBsuit" runat="server"></asp:TextBox>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="模糊函数选择">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlFunctSelect" runat="server">
                                        <asp:ListItem Value="抛物线型">抛物线型</asp:ListItem>
                                        <asp:ListItem Value="升半梯形">升半梯形</asp:ListItem>
                                        <asp:ListItem Value="降半梯形">降半梯形</asp:ListItem>
                                        <asp:ListItem Value="特征函数">特征函数</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="operationPanel">
                    <tr>
                        <td>
                            <%--<select id="measure2" name="measure" size="1">
                                    <option value="FJ">封禁</option>
                                    <option value="STLC">生态林草</option>
                                    <option value="DXLGZ">低效林改造</option>
                                    <option value="JJLG" selected="selected">经济林果</option>
                                </select>--%>
                            <asp:DropDownList ID="measureFuzzfunct" runat="server">
                                <asp:ListItem Value="FJ">封禁</asp:ListItem>
                                <asp:ListItem Value="STLC">生态林草</asp:ListItem>
                                <asp:ListItem Value="DXLGZ">低效林改造</asp:ListItem>
                                <asp:ListItem Value="JJLG" Selected="True">经济林果</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Button Text="创建规则" ID="btn_modelCreated" CssClass="G_btn" runat="server"  
                                />
                            <%-- <input type="submit" id="btn_modelCreated" value="创建规则" class="G_btn" />--%>
                            <input type="reset" value="重置" class="G_btn" />
                        </td>
                    </tr>
                </table>
                <div class="clear">
                </div>
            </div>
            <!-- 限制性条件 -->
            <div class="window">
                <div class="title"><span class="winCtrl" title="显示窗口内容" style="background-position:-604px -31px;"></span><span class="text">限制性条件</span></div>
                <div class="slideBox"  style="display:none;">
                    <asp:GridView ID="LimcondGrid" GridLines="None" AutoGenerateColumns="false" CssClass="t"
                        runat="server">
                        <Columns>
                            <asp:BoundField DataField="Name" HeaderText="评价因子" />
                            <asp:TemplateField HeaderText="单位">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtUnit2" runat="server">
                                    </asp:TextBox></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="限制条件">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlContType" runat="server">
                                        <asp:ListItem Value=">">></asp:ListItem>
                                        <asp:ListItem Value="=">=</asp:ListItem>
                                        <asp:ListItem Value="<"><</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="ddlIntype" runat="server">
                                        <asp:ListItem Value="in">in</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtLimitC" runat="server">
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="因子值类型">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlFactType" runat="server">
                                        <asp:ListItem Value="数值类型">数值类型</asp:ListItem>
                                        <asp:ListItem Value="非数值类型">非数值类型</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="operationPanel">
                    <tr>
                        <td>
                            <%--<select id="measure3" name="measure" size="1">
                                    <option value="FJ">封禁</option>
                                    <option value="STLC">生态林草</option>
                                    <option value="DXLGZ">低效林改造</option>
                                    <option value="JJLG" selected="selected">经济林果</option>
                                </select>--%>
                            <asp:DropDownList ID="measureLimit" runat="server">
                                <asp:ListItem Value="FJ">封禁</asp:ListItem>
                                <asp:ListItem Value="STLC">生态林草</asp:ListItem>
                                <asp:ListItem Value="DXLGZ">低效林改造</asp:ListItem>
                                <asp:ListItem Value="JJLG" Selected="True">经济林果</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Button ID="btn_limitativeRule" CssClass="G_btn" runat="server" Text="创建规则" 
                               />
                            <%--<input type="submit" id="btn_limitativeRule" value="创建规则" class="G_btn" />--%>
                            <asp:Button ID="resetLimit" CssClass="G_btn" runat="server" Text="重置" />
                            <%-- <input type="reset" value="重置" class="G_btn" />--%>
                        </td>
                    </tr>
                </table>
                <div class="clear"></div>
            </div>
               </td>



      <td valign="top">
            <div id="tabbed_box_1" class="window">
                 <div class="title">
                    <span class="winCtrl" title="隐藏窗口内容"></span><span class="text">地图</span></div>  
                    <div id="content_1" class="slideBox">
                        <table class="t" cellpadding="0" cellspacing="0" width="100%" border="0">
                            <%--<tr>--%>
                              <%--  <th style="width: 300px;">
                                    <div  >
                                        <span>请选择评价流程</span>
                                        <select>
                                            <option selected="selected">单措施适宜性等级评定</option>
                                            <!--  onclick="alert('OL')" -->
                                            <option>措施综合适宜性布局</option>
                                            <!-- onclick="alert('op');"-->
                                        </select>
                                    </div>
                                    <div class="mapping">
                                        <input type="button" value="添加制图服务" id="addMappingServer" />
                                        <input type="button" value="↑" onclick="" />
                                        <input type="button" value="↓" onclick="" />
                                        <input type="button" value="返回" onclick="workflow();" />
                                    </div>
                                </th>--%>
                               <%-- <th  >
                                    <span>请选择待评价措施</span>
                                    <select id="ddlMeasure">
                                        <option selected="selected">经济林果</option>
                                        <option>低效林改造</option>
                                        <option>封禁</option>
                                        <option>生态林草</option>
                                    </select>
                                    <input type="button" id="execute"  onclick="CallServer()" value="执行" class="G_btn"/>
                                    <input type="button" value="制图" onclick="mapping();" class="G_btn"/>
                                    <input type="button" value="导出地图"  class="G_btn"/>--%>
                                  <%--  <input type="button" id="SwitchBJMap" value="隐藏底图" />--%>
                              <%--  </th>
                            </tr>--%>
                            <tr>
                               <%-- <td>--%>
                               <%--     <div class="workflow">
                                    </div>--%>
                                  <%--  <div id="left-text" class="mapping">
                                        <ul id="serverList">
                                            <li>
                                                <input type="checkbox" checked="checked" />
                                                <span>县界</span>
                                                <div class="colorSelector" onclick="createColorPicker();">
                                                </div>
                                                <div id="color-picker" class="cp-default">
                                                </div>
                                                <script type="text/javascript">
                                                    function createColorPicker(arrRGB) {
                                                        ColorPicker(
														document
																.getElementById('color-picker'),
														function (hex, hsv, rgb) {
														    console.log(hsv.h,
																	hsv.s,
																	hsv.v); // [0-359], [0-1], [0-1]
														    console.log(rgb.r,
																	rgb.g,
																	rgb.b); // [0-255], [0-255], [0-255]

														    arrRGB[0] = rgb.r;
														    arrRGB[1] = rgb.g;
														    arrRGB[2] = rgb.b;

														    document.body.style.backgroundColor = hex; // #HEX
														});
                                                    }
                                                </script>
                                            </li>
                                        </ul>
                                    </div>
                                </td>--%>
                                <dt>
                                   
                                        <div id="map" style="width: 100%; height: 400px;">  
                                    </div>
                                    
                                </dt>
                            </tr>
                        </table>
                    </div> 
                  <table width="100%" border="0" cellspacing="0" cellpadding="0" class="operationPanel">
                    <tr>
                        <td>
                          <span>请选择待评价措施</span>
                                    <select id="ddlMeasure" name="ddlMeasure">
                                        <option selected="selected">经济林果</option>
                                        <option>低效林改造</option>
                                        <option>封禁</option>
                                        <option>生态林草</option>
                                        <option>综合评价</option>
                                    </select>
                                    <input type="button" id="execute"  onclick="CallServer()" value="执行" class="G_btn"/>
                                    <input type="button" value="制图" onclick="mapping();" class="G_btn"/>
                                    <input type="button" value="导出地图"  class="G_btn"/>
                        </td>
                    </tr>
                </table>
                 <div class="slideBox" id="div_fenjin" style="display:none;">
                     <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t withDoubleTH">
                         <tr><th colspan="5" style="text-align:left;">
                             封禁措施适宜性评价结果分析
                             </th></tr>
                         <tr class="SP">
                             <th>
</th>
                         <th style="width:80px;">
                             高度适宜区
                         </th>
                              <th style="width:80px;">
                             中度适宜区
                         </th>
                                 <th style="width:80px;">
                             一般适宜区
                         </th>
                                     <th style="width:80px;">
                             不适宜区
                         </th>
                         </tr> 
                        <tr>
                            <td>
                                面积(km2)
                            </td>
                        <td>
                       290.03
                        </td>
                               <td>
                       303.89
                        </td>
                              <td>
                       145.97
                        </td>
                              <td>
                       84.92
                        </td>
                    </tr>
                           <tr>
                            <td>
                                比例
                            </td>
                        <td  style="width:80px;">
                       35.16%
                        </td>
                               <td style="width:80px;">
                      36.84%
                        </td>
                              <td>
                     17.70%
                        </td>
                              <td>
                       10.30%
                        </td>
                    </tr>
                         <tr>
                            <td>
                                主要分布
                            </td>
                        <td>
                       零星分布在三洲镇、河田镇、策武镇和濯田镇
                        </td>
                               <td>
                     策武镇中东部、河田镇中部、三洲镇中东部-河田镇东南部、濯田镇中部及北部、涂坊镇中部、大同镇-新桥镇中部
                        </td>
                              <td>
                    河田镇东部-南山镇西部、三洲镇西北-河田镇西南部及东南部、濯田镇中北部、策武镇东部-河田镇西部、涂坊镇北部及南部、大同镇西部及东部-新桥镇西部
                        </td>
                              <td>
                       策武镇西北部及东南部、河田镇中部及西南部、三洲镇东南部、濯田镇中东部、涂坊镇南部、南山镇西北部、南山镇中南部、大同镇中部、新桥镇中部
                        </td>
                    </tr>
                         <tr>
                            <td>
                                特点
                            </td>
                        <td>
                       距村庄近，交通便利，坡度平缓，水土流失强度高
                        </td>
                               <td>
                      大多数适宜性指标得分较高，虽然存在处于中强度流失区、植被覆盖度太高或太低等劣势
                        </td>
                              <td>
                     指标适宜性得分都比较低，主要处于中轻度流失区、交通可达性低、植被覆盖度太高或太低、土地利用类型多为农用地或砂石地。
                        </td>
                              <td>
                       适宜性得分很低，或者存在限制性因素。如植被覆盖度太高或太低，处于中轻度流失区、交通可达性低、土地利用类型为农用地或砂石地
                        </td>
                    </tr>

                </table>
           
                </div>
                    <div class="slideBox" id="div_shentailinchao" style="display:none;">
                     <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t withDoubleTH">
                         <tr><th colspan="5" style="text-align:left;">
                             生态林草措施适宜性评价结果分析
                             </th></tr>
                         <tr class="SP">
                             <th>
</th>
                         <th>
                             高度适宜区
                         </th>
                              <th>
                             中度适宜区
                         </th>
                                 <th>
                             一般适宜区
                         </th>
                                     <th>
                             不适宜区
                         </th>
                         </tr> 
                        <tr>
                            <td>
                                面积(km2)
                            </td>
                        <td>
                       19.03
                        </td>
                               <td>
                       233.98
                        </td>
                              <td>
                       195.32
                        </td>
                              <td>
                       376.48
                        </td>
                    </tr>
                           <tr>
                            <td>
                                比例
                            </td>
                        <td>
                       2.31%
                        </td>
                               <td>
                      28.37%
                        </td>
                              <td>
                   23.68%
                        </td>
                              <td>
                       45.64%
                        </td>
                    </tr>
                         <tr>
                            <td>
                                主要分布
                            </td>
                        <td>
                       三洲镇东北部-河田东南部
                        </td>
                               <td>
                    策武镇中东部、河田镇中南部、三洲镇中东部、濯田镇中北部
                        </td>
                              <td>
                    涂坊镇中部、南山镇西北部、河田镇西南部-三洲镇西部、濯田镇东北部、新桥镇中部
                        </td>
                              <td>
                       南山镇中南部、濯田镇中南部、宣成乡、大同镇中北部、河田镇西南部
                        </td>
                    </tr>
                         <tr>
                            <td>
                                特点
                            </td>
                        <td>
                       水土流失强度高、可供建设投资高、交通便利、土地利用类型适宜、坡度适中
                        </td>
                               <td>
                      大多数适宜性指标得分较高，虽然存在水土流失强度或植被覆盖度较高等劣势
                        </td>
                              <td>
                     指标适宜性得分都比较低，如交通可达性低、可供建设投资低、处于中轻度流失区、植被覆盖度度较高。
                        </td>
                              <td>
                       适宜性得分很低，或者存在限制性因素。如植被覆盖度高、可供建设投资低，农村劳动力密度小，土地利用类型多为农用地或高植被覆盖区等
                        </td>
                    </tr>

                </table>
           
                </div>
                  <div class="slideBox" id="div_dixiaogaizhao" style="display:none;">
                     <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t withDoubleTH">
                         <tr><th colspan="5" style="text-align:left;">
                             低效林改造措施适宜性评价结果分析表
                             </th></tr>
                         <tr class="SP">
                             <th>
</th>
                         <th>
                             高度适宜区
                         </th>
                              <th>
                             中度适宜区
                         </th>
                                 <th>
                             一般适宜区
                         </th>
                                     <th>
                             不适宜区
                         </th>
                         </tr> 
                        <tr>
                            <td>
                                面积(km2)
                            </td>
                        <td>
                       9.62
                        </td>
                               <td>
                      211.29
                        </td>
                              <td>
                       235.81
                        </td>
                              <td>
                      368.09
                        </td>
                    </tr>
                           <tr>
                            <td>
                                比例
                            </td>
                        <td>
                      1.17%
                        </td>
                               <td>
                      25.62%
                        </td>
                              <td>
                   28.59%
                        </td>
                              <td>
                      44.63%
                        </td>
                    </tr>
                         <tr>
                            <td>
                                主要分布
                            </td>
                        <td>
                      零星分布在三洲镇、河田镇、策武镇和濯田镇
                        </td>
                               <td>
                    策武镇中东部、河田镇中部、三洲镇中东部-河田镇东南部、濯田镇中部及北部、涂坊镇中部、大同镇-新桥镇中部
                        </td>
                              <td>
                    河田镇东部-南山镇西部、三洲镇西北-河田镇西南部及东南部、濯田镇中北部、策武镇东部-河田镇西部、涂坊镇北部及南部、大同镇西部及东部-新桥镇西部
                        </td>
                              <td>
                       策武镇西北部及东南部、河田镇中部及西南部、三洲镇东南部、濯田镇中东部、涂坊镇南部、南山镇西北部、南山镇中南部、大同镇中部、新桥镇中部
                        </td>
                    </tr>
                         <tr>
                            <td>
                                特点
                            </td>
                        <td>
                       距村庄近，交通便利，坡度平缓，水土流失强度高
                        </td>
                               <td>
                      大多数适宜性指标得分较高，虽然存在处于中强度流失区、植被覆盖度太高或太低等劣势
                        </td>
                              <td>
                     指标适宜性得分都比较低，主要处于中轻度流失区、交通可达性低、植被覆盖度太高或太低、土地利用类型多为农用地或砂石地。
                        </td>
                              <td>
                       适宜性得分很低，或者存在限制性因素。如植被覆盖度太高或太低，处于中轻度流失区、交通可达性低、土地利用类型为农用地或砂石地
                        </td>
                    </tr>

                </table>
           
                </div>
                     <div class="slideBox" id="div_jinjilinguo" >
                     <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t withDoubleTH">
                         <tr><th colspan="5" style="text-align:left;">
                             经济林果措施适宜性评价结果分析
                             </th></tr>
                         <tr class="SP">
                             <th>
</th>
                         <th>
                             高度适宜区
                         </th>
                              <th>
                             中度适宜区
                         </th>
                                 <th>
                             一般适宜区
                         </th>
                                     <th>
                             不适宜区
                         </th>
                         </tr> 
                        <tr>
                            <td>
                                面积(km2)
                            </td>
                        <td>
                       43.94
                        </td>
                               <td>
                      114.88
                        </td>
                              <td>
                       31.55
                        </td>
                              <td>
                      634.44
                        </td>
                    </tr>
                           <tr>
                            <td>
                                比例
                            </td>
                        <td>
                      5.33%
                        </td>
                               <td>
                      13.93%
                        </td>
                              <td>
                  3.83%
                        </td>
                              <td>
                     76.92%
                        </td>
                    </tr>
                         <tr>
                            <td>
                                主要分布
                            </td>
                        <td>
                      策武镇的东北部、河田镇的中南部、三洲镇的中部。在濯田镇的中部和涂坊镇的南部也有零星的分布
                        </td>
                               <td>
                    河田镇的中南部、三洲镇的中部、策武镇的中部、濯田中北部、大同镇-新桥镇、南山镇-涂坊镇
                        </td>
                              <td>
                    三洲镇的西北部、大同镇的中部、策武镇的中部、河田镇中南部
                        </td>
                              <td>
                       河田镇西南部-三洲镇西北部、三洲镇南部-濯田镇中北部、大同镇-新桥镇
                        </td>
                    </tr>
                         <tr>
                            <td>
                                特点
                            </td>
                        <td>
                       距村庄近，交通便利，坡度平缓，多为中轻度水土流失区
                        </td>
                               <td>
                      大多数适宜性指标得分较高，虽存在可供建设投资较低，或者土地利用类型为高植被覆盖区等劣势
                        </td>
                              <td>
                     指标适宜性得分都比较低，如交通可达性低、距居民地远、可供建设投资低等
                        </td>
                              <td>
                       适宜性得分很低，或者存在限制性因素。如坡度太陡、可供建设投资低，距居民地远、土地利用类型不匹配。
                        </td>
                    </tr>

                </table>
           
                </div>
                <div class="slideBox" id="div_zhonhe" style="display:none;">
                     <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t withDoubleTH">
                         <tr><th colspan="5" style="text-align:left;">
                             长汀县水土保持措施适宜性综合决策结果分析
                             </th></tr>
                         <tr class="SP">
                             <th>
</th>
                         <th>
                             高度适宜区
                         </th>
                              <th>
                             中度适宜区
                         </th>
                                 <th>
                             一般适宜区
                         </th>
                                     <th>
                             不适宜区
                         </th>
                         </tr> 
                        <tr>
                            <td>
                                面积(km2)
                            </td>
                        <td>
                      587.19
                        </td>
                               <td>
                      54.41
                        </td>
                              <td>
                       102.55
                        </td>
                              <td>
                      80.66
                        </td>
                    </tr>
                           <tr>
                            <td>
                                比例
                            </td>
                        <td>
                     71.19%
                        </td>
                               <td>
                      6.60%
                        </td>
                              <td>
                  12.43%
                        </td>
                              <td>
                     9.78%
                        </td>
                    </tr>
                         <tr>
                            <td>
                                主要分布
                            </td>
                        <td>
                      策武镇东北部-河田镇北部、河田镇西南部-三洲镇西部-濯田镇中北部、河田镇东部-三洲镇东部-濯田镇东部、南山镇西部-涂坊镇中北部
                        </td>
                               <td>
                    大同镇中部、河田镇西南部、濯田镇中北部、涂坊镇中北部、在新桥镇中部和三洲镇南部有零星分布。
                        </td>
                              <td>
                    新桥镇南部、策武镇中部-河田镇中南部、三洲镇中部。在濯田镇中部有零星分布。
                        </td>
                              <td>
                       新桥西南部、策武中部、河田中南部-三洲中部、涂坊南部。在濯田镇东部和北部有零星分布。
                        </td>
                    </tr>
                         <tr>
                            <td>
                                特点
                            </td>
                        <td>
                       远离村庄，处于轻度流失区；植被覆盖度高。
                        </td>
                               <td>
                      距村庄近，交通便利，水土流失强度高
                        </td>
                              <td>
                     水土流失强度高、可供建设投资高、植被覆盖度低
                        </td>
                              <td>
                       距村庄近，交通便利，坡度平缓，处于中轻度流失区、劳动力密度高、可供建设投资高
                        </td>
                    </tr>

                </table>
           
                </div>
            </div>

      </td>
    </tr>
               </table>

        <%--    <div id="div_AddModel" class="window">
                 <div class="title">
                    <span class="winCtrl" title="隐藏窗口内容"></span><span class="text">添加模型参数</span></div>  
            <!-- 添加模型参数时出现 -->
            <table cellpadding="0" cellspacing="0" border="0" class="t" width="100%">
                <tr>
                    <td>
                        <div>&nbsp;</div>
                    </td>
                </tr>
              <%--  <tr>
                    <th class="tint">
                        选择类别
                    </th>
                    <td>
                        <select id="datacategory" name="datacategory">
                            <option selected="selected" value="-1">请选择数据类别</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <input id="dataServiceQuery" type="button" value="查询" class="G_btn" />
                    </td>
                </tr>--%>
          <%--  </table>

                 <table width="100%" border="0" cellspacing="0" cellpadding="0" class="operationPanel">
                    <tr>
                        <td>
                            <select id="datacategory" name="datacategory">
                            <option selected="selected" value="-1">请选择数据类别</option>
                        </select>
                         <input id="dataServiceQuery" type="button" value="查询" class="G_btn" />
                        </td>
                    </tr>
                </table>
                <div class="clear">
                </div>
                </div>--%>
      <%--    </td>
     </tr>          
</table>--%>

          <%--  <!-- 显示查询到的数据 -->
            <table cellpadding="0" cellspacing="0" border="0" class="form" width="100%">
                <tr>
                    <td id="inputdata">
                    </td>
                    <td>
                        <ul id="dataServiceList">
                        </ul>
                    </td>
                </tr>
                <tr>
                    <th class="tint">
                        分页使用
                    </th>
                    <td>
                        <img src="images/eye.png" alt="详细">
                    </td>
                </tr>
            </table>
            <div style="text-align:center"><input type="button" id="adddata" value="确认添加" class="G_btn"/></div>--%>
        </div>
    </div>
         <div id="Copyright">
        Copyright &copy; 2013 Fuda Geo-Information Co., Ltd. All rights reserved.</div>
    </form>
 
        <script type="text/javascript">
$(".winCtrl").click(function(){
    if($(this).parent().next().is(":hidden")){
        $(this).css("background-position","-582px -31px");
        $(this).attr("title","隐藏窗口内容");
        $(".slideBox",$(this).parent().parent()).fadeIn();
    }
    else{
        $(this).css("background-position","-604px -31px");
        $(this).attr("title","显示窗口内容");
        $(".slideBox",$(this).parent().parent()).fadeOut();
    }
});
</script>

</body>
</html>
