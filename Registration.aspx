<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <nav aria-label="breadcrumb" class="page-breadcrumb">
								<ol class="breadcrumb">
									<li class="breadcrumb-item"><a href="index-2.html">Home</a></li>
									<li class="breadcrumb-item active" aria-current="page">Registration</li>
								</ol>
							</nav>
							<h2 class="breadcrumb-title">Registration</h2>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-md-8 offset-md-2">
								
							<!-- Register Content -->
							<div class="account-content">
								<div class="row align-items-center justify-content-center">
									<div class="col-md-7 col-lg-6 login-left">
										<img src="assets/img/login-banner.png" class="img-fluid" alt="Doccure Register">	
									</div>
									<div class="col-md-12 col-lg-6 login-right">
										<div class="login-header">
											<h3>Patient Register</h3>
										</div>
										
										<!-- Register Form -->
									
											<div class="form-group form-focus">
												 <asp:TextBox ID="txtName" runat="server" class="form-control floating"></asp:TextBox>
												<label class="focus-label">Name</label>
                                                <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" controltovalidate="txtName" ErrorMessage="*"/>
											</div>
											<div class="form-group form-focus">
											 <asp:TextBox ID="txtPhone" runat="server" class="form-control floating"></asp:TextBox>
												<label class="focus-label">Mobile Number</label>
                                                <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" controltovalidate="txtPhone" ErrorMessage="*"/>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"  
ControlToValidate="txtPhone" ErrorMessage="Please Enter Valid Mobile No"  
ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
											</div>
										<br />
                                        
											<asp:Button ID="BtnSignup" runat="server" Text="Signup" onclick="BtnSignup_Click" class="btn btn-primary btn-block btn-lg login-btn" />
												<br />
										 <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
										 <asp:Label ID="lblotp" runat="server" Text="" Visible="False"></asp:Label>
										<!-- /Register Form -->
										
									</div>
								</div>
							</div>
							<!-- /Register Content -->
								
						</div>
					
</asp:Content>

