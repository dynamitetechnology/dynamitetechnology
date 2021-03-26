<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Adminlogin.aspx.cs" Inherits="admin_Adminlogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
        <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0"/>
        <title>Doctor Call - Login</title>
		
		<!-- Favicon -->
        <link rel="shortcut icon" type="image/x-icon" href="assets/img/favicon.png"/>

		<!-- Bootstrap CSS -->
        <link rel="stylesheet" href="assets/css/bootstrap.min.css"/>
		
		<!-- Fontawesome CSS -->
        <link rel="stylesheet" href="assets/css/font-awesome.min.css"/>
		
		<!-- Main CSS -->
</head>
<body>
    <form id="form1" runat="server">
        <div class="main-wrapper login-body">
            <div class="login-wrapper">
            	<div class="container">
                	<div class="loginbox">
                    	<div class="login-left">
							<img class="img-fluid" src="assets/img/logo-white.png" alt="Logo">
                        </div>
                        <div class="login-right">
							<div class="login-right-wrap">
								<h1>Login</h1>
								<p class="account-subtitle">Access to our dashboard</p>
								
								<!-- Form -->
								
									<div class="form-group">
										<asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="UserName"></asp:TextBox>
                                                 <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" controltovalidate="TextBox1" ErrorMessage="*"/>
									</div>
									<div class="form-group">
								<asp:TextBox ID="TextBox2" runat="server" class="form-control" placeholder="Password"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" controltovalidate="TextBox2" ErrorMessage="*"/>
									</div>
									<div class="form-group">
										       <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" class=" form-control" BackColor="#01CAE4" ForeColor="White" />
									</div>
							
								 <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
								<div class="text-center forgotpass"><a href="#">Forgot Password?</a></div>

							</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
		<!-- /Main Wrapper -->
		
		<!-- jQuery -->
        <script src="assets/js/jquery-3.2.1.min.js"></script>
		
		<!-- Bootstrap Core JS -->
        <script src="assets/js/popper.min.js"></script>
        <script src="assets/js/bootstrap.min.js"></script>
		
		<!-- Custom JS -->
		<script src="assets/js/script.js"></script>
        <script type="text/javascript">
    function ValidatorUpdateDisplay(val) {
        if (typeof (val.display) == "string") {
            if (val.display == "None") {
                return;
            }
            if (val.display == "Dynamic") {
                val.style.display = val.isvalid ? "none" : "inline";
                return;
            }

        }
        val.style.visibility = val.isvalid ? "hidden" : "visible";
        if (val.isvalid) {
            document.getElementById(val.controltovalidate).style.border = '1px solid #333';
        }
        else {
            document.getElementById(val.controltovalidate).style.border = '1px solid red';
        }          
    }
</script>
    </form>
</body>
</html>
