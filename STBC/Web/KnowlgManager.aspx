<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KnowlgManager.aspx.cs"
    Inherits="Web.KnowlgManager" %>

<%@ Register Src="usercontrol/menu.ascx" TagName="menubar" TagPrefix="menu" %>
<!DOCTYPE HTML>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>知识库规则创建</title>
    <link rel="stylesheet" href="css/Default.css" type="text/css" />
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
    </style>
   <%-- <script type="text/javascript" src="Script/Register.js"></script>--%>
    <script type="text/javascript" src="Script/jquery-1.9.1.min.js"></script>
  <%--  <script type="text/javascript" src="Script/Default.js"></script>
    <script type="text/javascript" src="Script/ruleCreate.js"></script>
    <script type="text/javascript" src="Script/dhtmlxtree.js"></script>--%>
    <%--  矩阵根据上三角计算下三角的值--%>
    <script src="js/Matrix.js" type="text/javascript"></script>
    <%--  控制模糊函数的选择--%>
    <script src="js/Fuzzfuction.js" type="text/javascript"></script>
    <%--  限制条件脚本控制--%>
    <script src="js/Limcond.js" type="text/javascript"></script>
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
                <li class="normal"><a href="Index.aspx" target="_self">首页</a></li>
                <li class="selected"><a  href="KnowlgManager.aspx" target="_self">知识管理</a></li>
                <li class="normal"><a href="SuitEvaluation.aspx" target="_self">适宜性评价</a></li>
            </ul>
        </div>
        <div id="hall">
           
            <!-- 创建适宜性级别 -->
            <div id="syxLevel" class="window">
                <div class="title">
                    <span class="winCtrl" title="隐藏窗口内容"></span><span class="text">适宜性分级规则创建</span></div>
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
                                onclick="btnCreateRule_Click" />
                            <asp:Button ID="reset" CssClass="G_btn" runat="server" Text="取消" />
                        </td>
                    </tr>
                </table>
                <div class="clear">
                </div>
            </div>
            <!-- 指标权重计算（ahp法）-->
            <div id="weightCompute" class="window">
                <div class="title">
                    <span class="winCtrl" title="隐藏窗口内容"></span><span class="text">效益评价因子权重设置</span></div>
                <div class="slideBox">
                    <!--效益因子判断矩阵设置-->
                    <asp:GridView ID="BenefitGrid" GridLines="None" AutoGenerateColumns="false" CssClass="t"
                        runat="server" OnRowCreated="BenefitGrid_RowCreated" Width="100%">
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
                            <asp:Button ID="benefitFactorsComp" runat="server" Text="计算权重" OnClick="benefitFactorsComp_Click"
                                CssClass="G_btn" />
                            <input type="button" id="resetbenefitFactors" value="重置" onclick="ResetBenMax()"
                                class="G_btn" />
                            <asp:Button ID="benefitFactorscreateRule" runat="server" Text="创建规则" CssClass="G_btn"
                                OnClick="benefitFactorscreateRule_Click" />
                        </td>
                    </tr>
                </table>
                <div class="slideBox">
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
                                <asp:TextBox ID="benefitFactors" runat="server" ReadOnly="true" Width="99.4%"></asp:TextBox>
                                <%-- <input  id="benefitFactors"  runat="server" type="text" />--%>
                            </td>
                            <td>
                                <asp:TextBox ID="delta_fertility" runat="server" ReadOnly="true" Width="99.4%"></asp:TextBox>
                                <%--  <input id="delta_fertility" runat="server" type="text" />--%>
                            </td>
                            <td>
                                <asp:TextBox ID="delta_landout" runat="server" ReadOnly="true" Width="99.4%"></asp:TextBox>
                                <%--  <input id="delta_landout" runat="server" type="text" />--%>
                            </td>
                            <td>
                                <asp:TextBox ID="delta_runoff" runat="server" ReadOnly="true" Width="99.4%"></asp:TextBox>
                                <%--  <input id="delta_runoff" runat="server" type="text" />--%>
                            </td>
                            <td>
                                <asp:TextBox ID="delta_soilErosion" runat="server" ReadOnly="true" Width="99.4%"></asp:TextBox>
                                <%-- <input id="delta_soilErosion" runat="server" type="text" />--%>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
            <div class="window">
                <div class="title">
                    <span class="winCtrl" title="隐藏窗口内容"></span><span class="text">适宜性评价因子权重设置</span></div>
                <%--设置自然因子和社会因子的对比较矩阵--%>
                <div class="slideBox">
                    <asp:GridView ID="SuitfactGrid" GridLines="None" AutoGenerateColumns="false" CssClass="t"
                        runat="server" OnRowCreated="SuitfactGrid_RowCreated">
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
                <div class="slideBox">
                    <asp:GridView ID="SuitfactGrid2" GridLines="None" AutoGenerateColumns="false" CssClass="t"
                        runat="server" OnRowCreated="SuitfactGrid2_RowCreated">
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
                <div class="slideBox">
                    <%-- 设置自然因子--%>
                    <asp:GridView ID="SuitfactGrid3" GridLines="None" AutoGenerateColumns="false" CssClass="t"
                        runat="server" OnRowCreated="SuitfactGrid3_RowCreated">
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
                                OnClick="suitabilityFactorsComp_Click" />
                            <input type="button" id="resetsuitabilityFactors" value="重置" onclick="ResetSuitMax();"
                                class="G_btn" />
                            <asp:Button ID="suitabilityFactorscreateRule" CssClass="G_btn" runat="server" Text="创建规则"
                                OnClick="suitabilityFactorscreateRule_Click" />
                            <%--   <input type="button" id="suitabilityFactorscreateRule" value="创建规则" class="G_btn" />--%>
                            
                            <%--  <input type="button" id="suitabilityFactorsrestW" value="返回重新计算权重" onclick="hidd();" class="R_btn" /></td>--%>
                    </tr>
                </table>
                <div class="slideBox">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
                        <tr>
                            <th colspan="7" class="mass BGx">
                                适宜性评价因子权重计算结果
                            </th>
                        </tr>
                        <tr class="SP">
                            <th class="tint">
                                适宜性评价因子
                            </th>
                            <td colspan="5">
                                <asp:TextBox ID="txtsuitabilityFactors" CssClass="inputText" runat="server"></asp:TextBox>
                                <%--<input type="text" class="inputText" id="suitabilityFactors" />--%>
                            </td>
                        </tr>
                        <tr>
                            <th rowspan="3" class="tint">
                                社会经济因子
                            </th>
                            <td rowspan="3">
                                <asp:TextBox ID="txtsocioeconomicFactors" CssClass="inputText" runat="server"></asp:TextBox>
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
                            <th rowspan="3" class="tint">
                                自然条件因子
                            </th>
                            <td rowspan="3">
                                <asp:TextBox ID="txtnatureFactors" CssClass="inputText" runat="server"></asp:TextBox>
                                <%--  <input type="text" class="inputText" id="socioeconomicFactors" />--%>
                            </td>
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
                <div class="title">
                    <span class="winCtrl" title="隐藏窗口内容"></span><span class="text">模糊函数创建规则构建</span></div>
                <div class="slideBox">
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
                            <asp:Button Text="创建规则" ID="btn_modelCreated" CssClass="G_btn" runat="server" onclick="btn_modelCreated_Click" 
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
                <div class="title">
                    <span class="winCtrl" title="隐藏窗口内容"></span><span class="text">限制性条件</span></div>
                <div class="slideBox">
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
                                onclick="btn_limitativeRule_Click" />
                            <%--<input type="submit" id="btn_limitativeRule" value="创建规则" class="G_btn" />--%>
                            <asp:Button ID="resetLimit" CssClass="G_btn" runat="server" Text="重置" />
                            <%-- <input type="reset" value="重置" class="G_btn" />--%>
                        </td>
                    </tr>
                </table>
                <div class="clear">
                </div>
            </div>
        </div>
    </div>
    <div id="Copyright">
        Copyright &copy; 2013 Fuda Geo-Information Co., Ltd. All rights reserved.</div>
    </form> 
</body>
</html>
