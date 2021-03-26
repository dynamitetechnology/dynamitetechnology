<%@ Page Title="" Language="C#" MasterPageFile="~/patient/PatientMaster.master" AutoEventWireup="true" CodeFile="ConfirmOrder.aspx.cs" Inherits="patient_ConfirmOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
          <nav aria-label="breadcrumb" class="page-breadcrumb">
								<ol class="breadcrumb">
									<li class="breadcrumb-item"><a href="index-2.html">Home</a></li>
									<li class="breadcrumb-item active" aria-current="page">Medicine Order</li>
								</ol>
							</nav>
							<h2 class="breadcrumb-title">Medicine</h2>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-md-5 col-lg-4 col-xl-3 theiaStickySidebar">
							<div class="profile-sidebar">
								<div class="widget-profile pro-widget-content">
									<div class="profile-info-widget">
										<a href="#" class="booking-doc-img">
											<asp:Image ID="Image2" runat="server" />
										</a>
										<div class="profile-det-info">
											<h3><asp:Label ID="lblname" runat="server" Text="Label"></asp:Label></h3>
											<div class="patient-details">
												<h5><i class="fas fa-mobile"></i><asp:Label ID="lblcity" runat="server" Text="Label"></asp:Label></h5>
												<h5 class="mb-0"><i class="fas fa-map-marker-alt"></i><asp:Label ID="lbladdress" runat="server" Text="Label"></asp:Label></h5>
											</div>
										</div>
									</div>
								</div>
								<div class="dashboard-widget">
									<nav class="dashboard-menu">
										<ul>
											<li class="active">
												<a href="Pdashboard.aspx">
													<i class="fas fa-columns"></i>
													<span>Dashboard</span>
												</a>
											</li>
											<li>
												<a href="MakeAppointment.aspx">
													<i class="fas fa-bookmark"></i>
													<span>Quick Appointment</span>
												</a>
											</li>
                                            		<li>
												<a href="Prescriptiondash.aspx">
													<i class="fas fa-bookmark"></i>
													<span>Prescription</span>
												</a>
											</li>
                                               <li>
												<a href="MedicineOrderDetail.aspx">
													<i class="fas fa-bookmark"></i>
													<span>Medicine Order Detail</span>
												</a>
											</li>
											<%--<li>
												<a href="SendMessage.aspx">
													<i class="fas fa-comments"></i>
													<span>Message</span>
													<small class="unread-msg">23</small>
												</a>
											</li>
                                            	<li>
												<a href="Inbox.aspx">
													<i class="fas fa-comments"></i>
													<span>Inbox</span>
													<small class="unread-msg">23</small>
												</a>
											</li>
                                            	<li>
												<a href="Outbox.aspx">
													<i class="fas fa-comments"></i>
													<span>Outbox</span>
													<small class="unread-msg">23</small>
												</a>
											</li>--%>
											<li>
												<a href="Profile.aspx">
													<i class="fas fa-user-cog"></i>
													<span>Profile Settings</span>
												</a>
											</li>
											<li>
												<a href="ChangePassword.aspx">
													<i class="fas fa-lock"></i>
													<span>Change Password</span>
												</a>
											</li>
											<li>
												<a href="/logout.aspx">
													<i class="fas fa-sign-out-alt"></i>
													<span>Logout</span>
												</a>
											</li>
										</ul>
									</nav>
								</div>

							</div>
						</div>
    <div class="col-md-7 col-lg-8 col-xl-9">
							<div class="card">
								<div class="card-body">
									                                    <div class="row" id="confirmdiv" runat="server">
										<di
v class="col-md-12 col-lg-6">
										
											<!-- Change Password Form -->
											
												<div class="form-group">
													<label>OTP</label>
													 <asp:TextBox ID="txtotp" runat="server" class="form-control"></asp:TextBox>
												</div>
											
												<div class="submit-section">
													   <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                                     <asp:Button ID="Button1" runat="server" Text="Confirm Order" OnClick="Button1_Click" class=" form-control" BackColor="#01CAE4" ForeColor="White" />
												</div>
											
											<!-- /Change Password Form -->
											
										</di>
									</div>
							
                                    <div class="col-lg-6" id="successdiv" runat="server">
						
							<!-- Success Card -->
							<div class="card success-card">
								<div class="card-body">
									<div class="success-cont">
										<i class="fas fa-check"></i>
										<h3>Yoyr Order Placed Successfully!</h3>
										<p>Yoor Order No :<strong><asp:Label ID="lblorder" runat="server" Text='' /></strong><br> on <strong><asp:Label ID="lblDate" runat="server" Text='' /></strong></p>

									</div>
								</div>
							</div>
							<!-- /Success Card -->
							
						</div>
                                </div>
							</div>
						</div>
</asp:Content>

