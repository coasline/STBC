<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Login" %>

<!DOCTYPE HTML>
<html>
<head runat="server">
    <title>水土保持措施适应性评价-登陆</title>
  <%--  <link href="../css/index.css" type="text/css" rel="stylesheet" />--%>
    <link href="Script/login/index.css" rel="stylesheet" type="text/css" />
 <%--   <script language="javascript" src="../js/index.js"></script>--%>
    <script src="Script/login/index.js" type="text/javascript"></script>
    <%--<script language="javascript" src="../js/jquery.js"></script>--%>
    <script src="Script/login/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            setSize();
        }
   	)
        $(window).resize(function () {
            setSize();
        });
        function setSize() {
            var height1 = $("#bgConsure").height();
            var height2 = $("#footer").height();
            var number = parseInt(height1);
            var right_nav = $("#right-nav").height();
            var min_height = number - 110;
            var r_min_height = min_height - right_nav;
            $("#login-content").css('min-height', min_height);

            //alert(left);
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
    
    <div id="bgConsure" style="position: absolute; z-index: -1px; height: 100%; width: 40px">
    </div>

	<div id="head">	
		
	</div>
	
	<div id="login-content">
		<div id="login-box">
			<form>
				<div id="login-head">
					<span>用户登录</span>
					
				</div>
				<input placeholder=" 账号:" id="login-user" type="text"   name="login-user" required="required"/>
				<input placeholder=" 密码:" id="login-pass" type="password"   name="login-password" required="required"/></br>
				<div id="login-re">
					<input type="checkbox" name="re-pass" />记住密码

					<a href="register.html">立即注册</a>
				</div>		
	            <button class="btn-serach login-btn">登&nbsp;&nbsp;&nbsp; 录</button>
			</form>
		</div>
		
				
	</div>
	<div id="footer">
	</div>

    </form>
</body>
</html>
