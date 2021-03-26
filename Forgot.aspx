<%@ Page Title="" Language="C#" MasterPageFile="~/doctor/Doctor.master" AutoEventWireup="true" CodeFile="Forgot.aspx.cs" Inherits="Forgot" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <h2 class="breadcrumb-title">Forgot Password</h2>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    	<div class="col-md-8 offset-md-2">
							
							<!-- Account Content -->
							<div class="account-content">
								<div class="row align-items-center justify-content-center">
									<div class="col-md-7 col-lg-6 login-left">
										<img src="assets/img/login-banner.png" class="img-fluid" alt="Login Banner">	
									</div>
									<div class="col-md-12 col-lg-6 login-right">
										<div class="login-header">
											<h3>Forgot Password?</h3>
											<p class="small text-muted">Enter your mobile no to get a password </p>
										</div>
										
										<!-- Forgot Password Form -->
										
											<div class="form-group form-focus">
												 <asp:TextBox ID="TextBox1" runat="server" class="form-control floating"></asp:TextBox>
												<label class="focus-label">Mobile No</label>
                                                     <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" controltovalidate="TextBox1" ErrorMessage="*"/>
											</div>
											<div class="text-right">
												<a class="forgot-link" href="Patientlogin.aspx">Remember your password?</a>
											</div>
                                        <asp:Button ID="Button1" runat="server" Text="Reset Password" OnClick="Button1_Click" class=" form-control" BackColor="#01CAE4" ForeColor="White"  />
											<%--<button class="btn btn-primary btn-block btn-lg login-btn" type="submit">Reset Password</button>--%>
										<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
										<!-- /Forgot Password Form -->
										
									</div>
								</div>
							</div>
							<!-- /Account Content -->
							
						</div>
</asp:Content>

