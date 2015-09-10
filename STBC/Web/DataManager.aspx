<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataManager.aspx.cs" Inherits="Web.DataManager" %>
<%@ Register src="usercontrol/menu.ascx" tagname="menubar" tagprefix="menu" %>
<!DOCTYPE HTML>
<html>
<head runat="server">
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<title>数据库管理系统</title>
<link rel="stylesheet" href="http://js.arcgis.com/3.13/esri/css/esri.css">
<link rel="stylesheet" href="css/Default.css" type="text/css" />
<script src="Script/Register.js" type="text/javascript"></script>
<script type="text/javascript" src="Script/jquery-1.9.1.min.js"></script>
<script type="text/javascript" src="Script/Default.js"></script>
<script type="text/javascript" src="Script/jquery.form.js"></script>
<style type="text/css">
body{background: #69C url(images/cloud.png) top no-repeat;}
#banner{width:1200px;margin-left:auto;margin-right:auto;}
.COL_S2{width:1182px;}
</style>
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
                <li class="normal"><a href="javascript:void(0);" target="panel">首页</a></li>
                <li class="selected"><a  href="KnowlgManager.aspx" target="panel">知识管理</a></li>
                <li class="normal"><a href="SuitEvaluation.aspx" target="panel">适宜性评价</a></li>
            </ul>
        </div>
        <div id="hall">
           <%-- <!-- 菜单栏 -->
            <menu:menubar ID="meanubar1"  runat="server"/>--%>

            <div id="tabbed_box_1">
                <div class="window">
                    <div class="title">
                        <span class="winCtrl" title="隐藏窗口内容"></span><span class="text">数据注册</span></div>
                    <div class="slideBox">
                   
                       <form id="dataServiceRegiste"  method="post">
                        <table cellpadding="0" cellspacing="0" border="0" class="form" width="100%">
                            <tr>
                                <th class="tint">
                                    图名
                                </th>
                                <td>
                                    <input type="text" name="dataname" value="" class="inputText" />
                                </td>
                                <th class="tint">
                                    类别
                                </th>
                                <td>
                                    <select id="datacategory1" name="datacategory">
                                        <option selected="selected" value="-1">请选择数据类别</option>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <th class="tint">
                                    数据服务URL
                                </th>
                                <td colspan="3">
                                    <input type="text" class="inputText" id="serverRegiste_serverurl" name="dataserviceurl"
                                        value="" style="width: 100%;" />
                                </td>
                            </tr>
                            <tr>
                                <th class="tint">
                                    数据格式
                                </th>
                                <td>
                                    <input type="text" name="dataformat" value="" class="inputText" />
                                </td>
                                <th class="tint">
                                    数据源位置
                                </th>
                                <td>
                                    <input type="text" name="datasourcelocation" value="" class="inputText" />
                                </td>
                            </tr>
                            <tr>
                                <th class="tint">
                                    比例尺
                                </th>
                                <td>
                                    <input type="text" class="inputText" name="datascale" value="" size="11" />
                                </td>
                                <th class="tint">
                                    数据生产日期
                                </th>
                                <td>
                                    <input name="dataproducedate" type="text" class="inputText" value="" size="11" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">
                                    <input type="submit" value="提交注册" class="G_btn" />
                                </td>
                            </tr>
                        </table>
                        </form>
                    </div>
                    <div class="clear">
                    </div>
                </div>
                <div class="window">
                    <div class="title">
                        <span class="winCtrl" title="隐藏窗口内容"></span><span class="text">数据管理</span></div>
                    <div class="slideBox">
                        <table cellpadding="0" cellspacing="0" border="0" class="form" width="100%">
                            <tr>
                                <th class="tint">
                                    选择类别
                                </th>
                                <td>
                                    <select id="datacategory2" name="datacategory">
                                        <option selected="selected" value="-1">请选择数据类别</option>
                                    </select>
                                    <input id="dataServiceQuery" type="button" value="查询" class="G_btn" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="slideBox">
                        <table cellpadding="0" cellspacing="0" border="0" class="t" width="100%">
                            <tr>
                                <th align="left">
                                    查询结果
                                </th>
                            </tr>
                            <tbody id="dataServiceList">
                            </tbody>
                        </table>
                    </div>
                   <form id="ServiceInfo" method="post">
                    <div class="slideBox">
                        <div>
                            <table cellpadding="0" cellspacing="0" border="0" class="form" width="100%">
                                <tr>
                                    <th class="mass BGx" colspan="4">
                                        编辑数据
                                    </th>
                                </tr>
                                <tr>
                                    <td colspan="4" style="padding: 0;">
                                        <div id="ServceMap">
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="tint">
                                        图名
                                    </th>
                                    <td>
                                        <!-- 隐藏字段用户记录用户Id -->
                                        <input type="text" id="dataid" name="id" style="display: none;" />
                                        <input type="text" id="dataname" name="dataname" value="" class="inputText" />
                                    </td>
                                    <th class="tint">
                                        类别
                                    </th>
                                    <td>
                                        <select id="datacategory" name="datacategory" class="inputText">
                                            <option selected="selected" value="-1">请选择数据类别</option>
                                        </select>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="tint" style="height: 37px">
                                        数据服务URL
                                    </th>
                                    <td colspan="3" class="style1">
                                        <input type="text" id="dataserviceurl" name="dataserviceurl" class="inputText" value=""
                                            style="width: 100%;" />
                                    </td>
                                </tr>
                                <tr>
                                    <th class="tint">
                                        数据格式
                                    </th>
                                    <td>
                                        <input type="text" id="dataformat" name="dataformat" value="" class="inputText" />
                                    </td>
                                    <th class="tint">
                                        数据源位置
                                    </th>
                                    <td>
                                        <input type="text" id="datasourcelocation" name="datasourcelocation" value="" class="inputText" />
                                    </td>
                                </tr>
                                <tr>
                                    <th class="tint">
                                        比例尺
                                    </th>
                                    <td>
                                        <input type="text" id="datascale" name="datascale" class="inputText" value="" size="11" />
                                    </td>
                                    <th class="tint">
                                        数据生产日期
                                    </th>
                                    <td>
                                        <input name="dataproducedate" id="dataproducedate" type="text" class="inputText"
                                            value="" size="11" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="operationPanel">
                        <tr>
                            <td align="center">
                                <input type="submit" value="修改" class="G_btn" />
                                <input id="btn_del_dataServer" type="button" value="删除" class="G_btn" />
                            </td>
                        </tr>
                    </table>
                    </form>
                    <div class="clear">
                    </div>
                </div>
            </div>
           
        </div>
    </div>
    <div id="Copyright">
        Copyright &copy; 2013 Fuda Geo-Information Co., Ltd. All rights reserved.</div>
    </form>
       <script type="text/javascript">
/*栏目缩放*/
$(".winCtrl").click(function(){
	if($(this).parent().next().is(":hidden")){
		$(this).css("background-position","-582px -31px")
		$(this).attr("title","隐藏窗口内容")
	    $(".slideBox",$(this).parent().parent()).fadeIn();
    }
	else{
		$(this).css("background-position","-604px -31px")
		$(this).attr("title","显示窗口内容")
		$(".slideBox",$(this).parent().parent()).fadeOut();
		
	}
})
</script>
</body>
</html>
