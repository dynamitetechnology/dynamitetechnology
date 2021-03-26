<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Patientlogin.aspx.cs" Inherits="Patientlogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
         <nav aria-label="breadcrumb" class="page-breadcrumb">
								<ol class="breadcrumb">
									<li class="breadcrumb-item"><a href="index-2.html">Home</a></li>
									<li class="breadcrumb-item active" aria-current="page">Login</li>
								</ol>
							</nav>
							<h2 class="breadcrumb-title">Login</h2>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-md-8 offset-md-2">
							
							<!-- Login Tab Content -->
							<div class="account-content">
								<div class="row align-items-center justify-content-center">
									<div class="col-md-7 col-lg-6 login-left">
										<img src="assets/img/login-banner.png" class="img-fluid" alt="Doccure Login">	
									</div>
									<div class="col-md-12 col-lg-6 login-right">
										<div class="login-header">
											<h3>Login </h3>
										</div>
									
											<div class="form-group form-focus">
                                                 <asp:TextBox ID="TextBox1" runat="server" class="form-control floating"></asp:TextBox>
											
												<label class="focus-label">Mobile No</label>
                                                 <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" controltovalidate="TextBox1" ErrorMessage="*"/>
											</div>
											<div class="form-group form-focus">
												<asp:TextBox ID="TextBox2" runat="server" class="form-control floating"></asp:TextBox>
												<label class="focus-label">Password</label>
                                                 <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" controltovalidate="TextBox2" ErrorMessage="*"/>
											</div>
											<div class="text-right">
                                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
												<a class="forgot-link" href="Forgot.aspx">Forgot Password ?</a>
											</div>
											<%--<button class="btn btn-primary btn-block btn-lg login-btn" type="submit">Login</button>--%>
									               <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" class=" form-control" BackColor="#01CAE4" ForeColor="White" />
											<div class="text-center dont-have">Don’t have an account? <a href="Registration.aspx">Register</a></div>
										
									</div>
								</div>
							</div>
							<!-- /Login Tab Content -->
								
						</div>
					

</asp:Content>

