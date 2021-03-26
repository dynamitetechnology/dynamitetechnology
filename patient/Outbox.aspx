<%@ Page Title="" Language="C#" MasterPageFile="~/patient/PatientMaster.master" AutoEventWireup="true" CodeFile="Outbox.aspx.cs" Inherits="patient_Outbox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-md-5 col-lg-4 col-xl-3 theiaStickySidebar">
							<div class="profile-sidebar">
								<div class="widget-profile pro-widget-content">
									<div class="profile-info-widget">
										<a href="#" class="booking-doc-img">
											<img src="../assets/img/patients/patient.jpg" alt="User Image">
										</a>
										<div class="profile-det-info">
											<h3><asp:Label ID="lblname" runat="server" Text="Label"></asp:Label></h3>
											<div class="patient-details">
												<h5><i class="fas fa-birthday-cake"></i><asp:Label ID="lbladdress" runat="server" Text="Label"></asp:Label></h5>
												<h5 class="mb-0"><i class="fas fa-map-marker-alt"></i><asp:Label ID="lblcity" runat="server" Text="Label"></asp:Label></h5>
											</div>
										</div>
									</div>
								</div>
								<div class="dashboard-widget">
									<nav class="dashboard-menu">
										<ul>
											<li class="active">
												<a href="patient/Pdashboard.aspx">
													<i class="fas fa-columns"></i>
													<span>Dashboard</span>
												</a>
											</li>
											<li>
												<a href="patient/MakeAppointment.aspx">
													<i class="fas fa-bookmark"></i>
													<span>Quick Appointment</span>
												</a>
											</li>
                                            	
											<li>
												<a href="patient/SendMessage.aspx">
													<i class="fas fa-comments"></i>
													<span>Message</span>
													<small class="unread-msg">23</small>
												</a>
											</li>
                                            	<li>
												<a href="patient/Inbox.aspx">
													<i class="fas fa-comments"></i>
													<span>Inbox</span>
													<small class="unread-msg">23</small>
												</a>
											</li>
                                            	<li>
												<a href="patient/Outbox.aspx">
													<i class="fas fa-comments"></i>
													<span>Outbox</span>
													<small class="unread-msg">23</small>
												</a>
											</li>
											<li>
												<a href="patient/Profile.aspx">
													<i class="fas fa-user-cog"></i>
													<span>Profile Settings</span>
												</a>
											</li>
											<li>
												<a href="patient/ChangePassword.aspx">
													<i class="fas fa-lock"></i>
													<span>Change Password</span>
												</a>
											</li>
											<li>
												<a href="patient/logout.aspx">
													<i class="fas fa-sign-out-alt"></i>
													<span>Logout</span>
												</a>
											</li>
										</ul>
									</nav>
								</div>

							</div>
						</div>
</asp:Content>

