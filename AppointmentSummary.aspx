<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AppointmentSummary.aspx.cs" Inherits="AppointmentSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <nav aria-label="breadcrumb" class="page-breadcrumb">
								<ol class="breadcrumb">
									<li class="breadcrumb-item"><a href="index-2.html">Home</a></li>
									<li class="breadcrumb-item active" aria-current="page">Checkout</li>
								</ol>
							</nav>
							<h2 class="breadcrumb-title">Checkout</h2>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-md-7 col-lg-8">
							<div class="card">
								<div class="card-body">
								
									<!-- Checkout Form -->
									
										<div class="form-group form-focus">												
                                             <asp:TextBox ID="TextBox1" runat="server" class="form-control floating"></asp:TextBox>
												<label class="focus-label">Mobile Number</label>
                                                  <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" controltovalidate="TextBox1" ErrorMessage="*"/>
											</div>
											<div class="form-group form-focus">
												<asp:TextBox ID="TextBox2" runat="server" class="form-control floating"></asp:TextBox>
												<label class="focus-label">Password</label>
                                                     <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" controltovalidate="TextBox2" ErrorMessage="*"/>
											</div>
											<div class="text-right">
												<a class="forgot-link" href="Forgot.aspx">Forgot Password ?</a>
											</div>		
                                     <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" class=" form-control" BackColor="#01CAE4" ForeColor="White" />
										<%--  <asp:Button ID="Button1" class="btn btn-primary btn-block btn-lg login-btn" runat="server" Text="Login" OnClick="Button1_Click"/>--%>
											<div class="text-center dont-have">Don’t have an account? <a href="Registration.aspx">Register</a></div>
										
										
								<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
									<!-- /Checkout Form -->
									
								</div>
							</div>
							
						</div>
    <div class="col-md-5 col-lg-4 theiaStickySidebar">
						  <asp:Repeater ID="d1" runat="server">
            <HeaderTemplate>
              
            </HeaderTemplate>
           <ItemTemplate>
						
						
							<!-- Booking Summary -->
							<div class="card booking-card">
								<div class="card-header">
									<h4 class="card-title">Booking Summary</h4>
								</div>
								<div class="card-body">
								
									<!-- Booking Doctor Info -->
									<div class="booking-doc-info">
										<a href="doctor-profile.html" class="booking-doc-img">
                                            <asp:Image ID="Image2" runat="server" ImageUrl='<%#Eval("images") %>' />
											<%--<img src='../<%#Eval("images") %>' alt="">--%>
										</a>
										<div class="booking-info">
											<h4><a href="doctor-profile.html"><%#Eval("name") %></a></h4>
                                            <p class="doc-speciality"><%#Eval ("qly") %></p>
                                            <p class="doc-department"><%#Eval("exp") %></p>
											<div class="rating">
												<i class="fas fa-star filled"></i>
												<i class="fas fa-star filled"></i>
												<i class="fas fa-star filled"></i>
												<i class="fas fa-star filled"></i>
												<i class="fas fa-star"></i>
												<span class="d-inline-block average-rating">35</span>
											</div>
                                           
											<div class="clinic-details">
												<%-- <p class="text-muted mb-0"><i class="far fa-money-bill-alt"></i> Rs.<%#Eval ("fee") %> (Consulting Fee)</p>--%>
											</div>
										</div>
									</div>
									<!-- Booking Doctor Info -->
									
									<div class="booking-summary">
										<div class="booking-item-wrap">
											<ul class="booking-date">
												<li>Date <span><%#Eval ("Adate") %></span></li>
												<li>Time-Slot <span><%#Eval ("ftime") %>-<%#Eval ("Ttime") %></span></li>
											</ul>
											<ul class="booking-fee">
												<li>Consulting Fee <span>Rs.<%#Eval ("fee") %></span></li>
												<li>Booking Fee <span>Rs.0</span></li>
												
											</ul>
											<div class="booking-total">
												<ul class="booking-total-list">
													<li>
														<span>Total</span>
														<span class="total-cost">Rs.<%#Eval ("fee") %></span>
													</li>
												</ul>
											</div>
										</div>
									</div>
								</div>
							</div>
							<!-- /Booking Summary -->
							
						
							 </ItemTemplate>
            <FooterTemplate>
           
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

