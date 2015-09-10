<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModelManager.aspx.cs" Inherits="Web.ModelManager" %>

<%@ Register Src="usercontrol/menu.ascx" TagName="menubar" TagPrefix="menu" %>
<!DOCTYPE HTML>
<html>
<head runat="server">
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<title>模型库管理系统</title>
<link rel="stylesheet" href="css/Default.css" type="text/css" />
<script type="text/javascript" src="${pageContext.request.contextPath}/Script/Register.js"></script>
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
                <li class="selected"><a href="javascript:void(0);" target="panel">栏目一</a></li>
                <li class="normal"><a href="javascript:void(0);" target="panel">栏目二</a></li>
                <li class="normal"><a href="javascript:void(0);" target="panel">栏目三</a></li>
            </ul>
        </div>
        <div id="hall">
            <!-- 菜单栏 -->
            <menu:menubar ID="meanubar1" runat="server" />
            <div id="tabbed_box_1">
                <%-- <ul class="tabs">
            <li><a href="#" title="content_1" class="tab active">模型注册</a></li>
            <li><a href="#" title="content_2" class="tab">模型管理</a></li>         
        </ul>--%>
                <div class="window">
                    <div class="title">
                        <span class="winCtrl" title="隐藏窗口内容"></span><span class="text">模型注册</span></div>
                    <div id="content_1" class="slideBox">
                        <table cellpadding="0" cellspacing="0" border="0" class="form" width="100%">
                            <tr>
                                <th class="tint">
                                    模型名称
                                </th>
                                <td>
                                    <input type="text" name="modelname" value="层次分析模型" class="inputText" />
                                </td>
                                <th class="tint">
                                    模型版本号
                                </th>
                                <td>
                                    <input name="modelversion" type="text" class="inputText" value="1.0" size="4" />
                                </td>
                            </tr>
                            <tr>
                                <th class="tint">
                                    模型服务链接地址
                                </th>
                                <td colspan="3">
                                    <input type="text" id="serverRegiste_serverurl" name="modelserviceurl" value="http://localhost:8080/axis2/services/AhpImp"
                                        style="width: 100%;" class="inputText" />
                                </td>
                            </tr>
                            <tr>
                                <th class="tint">
                                    模型类别
                                </th>
                                <td>
                                    <select id="modelcategory1" name="modelcategory">
                                        <option selected="selected" value="-1">请选择模型类型</option>
                                    </select>
                                </td>
                                <th class="tint">
                                    模型应用领域
                                </th>
                                <td>
                                    <input type="text" name="modelappfield" value="多目标、多准则、多要素、多层次的非结构化的复杂问题，特别是战略决策问题"
                                        style="width: 100%;" class="inputText" />
                                </td>
                            </tr>
                            <tr>
                                <th class="tint">
                                    模型功能与概述
                                </th>
                                <td colspan="3">
                                    <textarea rows="5" style="width: 100%;" class="inputText" name="modeldescription"
                                        value="sdfsdf"></textarea>
                                </td>
                            </tr>
                            <tr>
                                <th class="tint">
                                    模型输入数据描述
                                </th>
                                <td>
                                    <input type="text" name="inputdatadescription" value="按层次树结构由上到下，由左到右依次排列所有判断矩阵"
                                        style="width: 100%;" class="inputText" />
                                </td>
                                <th class="tint">
                                    模型输入数据格式
                                </th>
                                <td>
                                    <input type="file" name="inputdataformat" />
                                </td>
                            </tr>
                            <tr>
                                <th class="tint">
                                    模型输出数据描述
                                </th>
                                <td>
                                    <input type="text" name="outputdatadescription" value="各指标的权重" style="width: 100%;"
                                        class="inputText" />
                                </td>
                                <th class="tint">
                                    模型输出数据格式
                                </th>
                                <td>
                                    <input type="file" name="outputdataformat" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">
                                    <input type="submit" value="提交注册" class="G_btn" />
                                </td>
                            </tr>
                        </table>
    </div>
    <div class="clear">
    </div>
    </div>
    <div class="window">
        <div class="title">
            <span class="winCtrl" title="隐藏窗口内容"></span><span class="text">模型管理</span></div>
        <div class="slideBox">
            <table cellpadding="0" cellspacing="0" border="0" class="form" width="100%">
                <tr>
                    <th class="tint">
                        输入服务名称
                    </th>
                    <td>
                        <input type="text" name="dataname" value="适宜性综合决策模型" class="inputText" />
                    </td>
                    <th class="tint">
                        选择类别
                    </th>
                    <td>
                        <select id="modelcategory2" name="modelcategory">
                            <option selected="selected" value="-1">查询所有类别</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        <input type="button" id="modelServiceQuery" value="查询" class="G_btn" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="slideBox">
            <table cellpadding="0" cellspacing="0" border="0" class="t" width="100%">
                <tr>
                    <th>&nbsp;
                        
                    </th>
                    <th>
                        服务名称
                    </th>
                    <th>
                        模型输出数据名称
                    </th>
                    <th>
                        模型输入参数
                    </th>
                    <th>
                        添加模型输入参数
                    </th>
                </tr>
                <tr>
                    <td align="center" id="radiogroup">
                    </td>
                    <td>
                        <ul id="modelServiceList">
                        </ul>
                    </td>
                    <td align="center">
                        <input type="text" class="inputText" style="width: 80%;" />
                    </td>
                    <td>
                        <ul id="inputParamGroup">
                        </ul>
                    </td>
                    <td align="center">
                        <input name="" type="image" src="images/add.png">
                    </td>
                </tr>
            </table>
        </div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="operationPanel">
            <tr>
                <td align="center">
                    <input type="button" id="execute" value="执行" class="G_btn" />
                </td>
            </tr>
        </table>
        <div class="clear">
        </div>
    </div>
    <!-- 隐藏字段用户记录用户Id -->
    <input type="text" id="serverid" name="id" style="display: none;" />
    <table cellpadding="0" cellspacing="0" border="0" class="form" width="100%">
        <tr>
            <th class="tint">
                模型名称
            </th>
            <td>
                <input type="text" id="modelname" name="modelname" class="inputText" />
            </td>
            <th class="tint">
                模型版本号
            </th>
            <td>
                <input id="modelversion" name="modelversion" type="text" class="inputText" size="4" />
            </td>
        </tr>
        <tr>
            <th class="tint">
                模型服务链接地址
            </th>
            <td colspan="3">
                <input type="text" id="modelserviceurl" name="modelserviceurl" style="width: 100%;"
                    class="inputText" />
            </td>
        </tr>
        <tr>
            <th class="tint">
                模型类别
            </th>
            <td>
                <select id="modelcategory" name="modelcategory">
                    <option selected="selected" value="-1">请选择模型类型</option>
                </select>
            </td>
            <th class="tint">
                模型应用领域
            </th>
            <td>
                <input type="text" name="modelappfield" value="多目标、多准则、多要素、多层次的非结构化的复杂问题，特别是战略决策问题"
                    style="width: 100%;" class="inputText" />
            </td>
        </tr>
        <tr>
            <th class="tint">
                模型功能与概述
            </th>
            <td colspan="3">
                <textarea id="modeldescription" rows="5" style="width: 100%;" class="inputText" name="modeldescription"
                    value="sdfsdf"></textarea>
            </td>
        </tr>
        <tr>
            <th class="tint">
                模型输入数据描述
            </th>
            <td>
                <input type="text" id="inputdatadescription" name="inputdatadescription" value="按层次树结构由上到下，由左到右依次排列所有判断矩阵"
                    style="width: 100%;" class="inputText" />
            </td>
            <th class="tint">
                模型输入数据格式
            </th>
            <td>
                <a id="inputdataformat"></a>
                <input type="file" name="inputdataformat" />
            </td>
        </tr>
        <tr>
            <th class="tint">
                模型输出数据描述
            </th>
            <td>
                <input type="text" id="outputdatadescription" name="outputdatadescription" style="width: 100%;"
                    class="inputText" />
            </td>
            <th class="tint">
                模型输出数据格式
            </th>
            <td>
                <a id="outputdataformat"></a>
                <input type="file" name="outputdataformat" />
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <input type="submit" value="修改" class="G_btn" />
                <input id="btn_del_modelServer" type="button" value="删除" class="G_btn" />
            </td>
        </tr>
    </table>
    </div> </div> </div>
    <div id="Copyright">
        Copyright &copy; 2013 Fuda Geo-Information Co., Ltd. All rights reserved.
       </div>
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
