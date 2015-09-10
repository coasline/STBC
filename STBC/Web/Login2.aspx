<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login2.aspx.cs" Inherits="Web.Login2" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/LoginMain.css" rel="stylesheet" type="text/css" />
    <script src="Script/jquery-1.9.1.min.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
            background: #69C url(Images/cloud.png) top no-repeat;
        }
        .userName
        {
            width: 97px !important;
        }
        .ghost, .password
        {
            width: 116px !important;
        }
        #signIn
        {
            margin-right: 7px;
        }
        img
        {
            _behavior: url("Script/iepngfix.htc");
        }
        #wall img
        {
            margin-left: 128px;
            margin-top: 103px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="login">
        <div class="banner">
            系统名称</div>
        <div class="main BG">
            <div id="loginPanel">
                <div class="inputBox">
                    <ul>
                        <li class="C BG"></li>
                        <li class="I BGx"><span class="icon"></span>
                            <input type="text" id="userName" class="userName" value="用户名" />
                            <span class="icon pw"></span>
                            <input type="text" class="ghost" value="密码" />
                            <input type="password" id="password" class="password" value="" />
                        </li>
                        <li class="D BG"></li>
                    </ul>
                    <ul>
                        <li class="C BG"></li>
                        <li class="I BGx"><span class="icon ic"></span>
                            <input type="text" id="identifyingCode" class="identifyingCode" value="验证码" />
                        </li>
                        <li class="D BG"></li>
                    </ul>
                    <div class="icImageBox">
                        <img src="Rnd.aspx" alt="" /></div>
                    <ul>
                        <li class="C BG"></li>
                        <li class="I BGx"><span class="icon pn"></span>
                            <input type="text" id="mobilePhone" class="mobilePhone" value="已绑定手机用户，请在此输入手机号！" />
                        </li>
                        <li class="D BG"></li>
                    </ul>
                    <div class="BTNs">
                        <asp:Button ID="btnLogin" runat="server" CssClass="BG" Text=""></asp:Button>
                        <asp:Button ID="btnCancel" CssClass="BG" runat="server" Text="" />
                        <%--  <input name="" type="submit" class="BG" id="signIn" value="" onclick="window.open('Default.html')" />
                        <input name="" type="button" class="BG" id="signUp" value="" />--%>
                    </div>
                </div>
                <div id="loginTips">
                    <a href="">忘记密码？</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="http://1drv.ms/1dHzf7I">用户使用手册</a><br />
                    <a href="">下载“两违”情况摸底表</a></div>
            </div>
            <div id="wall">
            </div>
        </div>
        <div id="Copyright">
            Copyright &copy; 2014 Fuda Geo-Information Co., Ltd. All rights reserved. | 业务咨询：0591-87805995
            | 技术咨询：0591-87881267 | QQ群：111858281</div>
    </div>
    <script type="text/javascript">
        /*分辨率验证*/
        if (screen.width < "1080") {
            if (confirm("当前显示器分辨率过低，是否调整至最佳状态？")) {
                window.close();
            }
        }
        /*IE升级*/
        if ($.browser.msie & $.browser.version == "6.0") {
            if (confirm("有可用的Internet Explorer更新，是否升级？")) {
                window.location.href = "http://windows.microsoft.com/zh-cn/internet-explorer/products/ie/home";
            }
        }
        /*输入框切换*/
        $("input").focus(function () {
            if (this.type != "submit") {
                if (this.id != "") {
                    this.value = ""
                }
                else {
                    this.style.display = "none"
                    $(".password").focus()
                }
            }
        });
        $("input").blur(function () {
            if (this.value == "" && this.type != "submit") {
                if (this.className == "userName") {
                    this.value = "用户名"
                }
                if (this.className == "password") {
                    $(".ghost").show()
                }
                if (this.className == "identifyingCode") {
                    this.value = "验证码"
                }
                if (this.className == "mobilePhone") {
                    this.value = "已绑定手机用户，请在此输入手机号！"
                }
            }
        });

    </script>
    </form>
</body>
</html>
