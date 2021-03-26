<%@ Page Title="" Language="C#" MasterPageFile="~/doctor/Doctor.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="doctor_ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <nav aria-label="breadcrumb" class="page-breadcrumb">
								<ol class="breadcrumb">
									<li class="breadcrumb-item"><a href="index-2.html">Home</a></li>
									<li class="breadcrumb-item active" aria-current="page">Change Password</li>
								</ol>
							</nav>
							<h2 class="breadcrumb-title">Change Password</h2>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="col-md-5 col-lg-4 col-xl-3 theiaStickySidebar">
							
							<!-- Profile Sidebar -->
							<div class="profile-sidebar">
								<div class="widget-profile pro-widget-content">
									<div class="profile-info-widget">
										<a href="#" class="booking-doc-img">
											<asp:Image ID="Image2" runat="server" />
										</a>
										<div class="profile-det-info">
											<h3><asp:Label ID="lblname" runat="server" Text="Label"></asp:Label></h3>
											
											<div class="patient-details">
												<h5 class="mb-0"><asp:Label ID="lblspe" runat="server" Text="Label"></asp:Label></h5>
											</div>
										</div>
									</div>
								</div>
								<div class="dashboard-widget">
									<nav class="dashboard-menu">
										<ul>
											<li class="active">
												<a href="Ddashboard.aspx">
													<i class="fas fa-columns"></i>
													<span>Dashboard</span>
												</a>
											</li>
											<%--<li>
												<a href="doctor/Appointment.aspx">
													<i class="fas fa-calendar-check"></i>
													<span>Appointments</span>
												</a>
											</li>--%>
											<li>
												<a href="Mypatient.aspx">
													<i class="fas fa-user-injured"></i>
													<span>My Patients</span>
												</a>
											</li>
											<li>
												<a href="ScheduleTiming.aspx">
													<i class="fas fa-hourglass-start"></i>
													<span>Schedule Timings</span>
												</a>
											</li>
										
										<%--	<li>
												<a href="Message.aspx">
													<i class="fas fa-comments"></i>
													<span>Send Message</span>
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
							<!-- /Profile Sidebar -->
							
						</div>
						<div class="col-md-7 col-lg-8 col-xl-9">
							<div class="card">
								<div class="card-body">
									<div class="row">
										<div class="col-md-12 col-lg-6">
										
											<!-- Change Password Form -->
											
												<div class="form-group">
													<label>Old Password</label>
                                                     <asp:TextBox ID="txtOldpwd" runat="server" class="form-control"></asp:TextBox>
													
												</div>
												<div class="form-group">
													<label>New Password</label>
												<asp:TextBox ID="txtNewpwd" runat="server" class="form-control"></asp:TextBox>
												</div>
												<div class="form-group">
													<label>Confirm Password</label>
													<asp:TextBox ID="txtNewpwd2" runat="server" class="form-control"></asp:TextBox>
												</div>
												<div class="submit-section">
                                                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                                     <asp:Button ID="Button1" runat="server" Text="Save Changes" OnClick="Button1_Click" class=" form-control" BackColor="#01CAE4" ForeColor="White" />
												<%--	<button type="submit" class="btn btn-primary submit-btn">Save Changes</button>--%>
												</div>
										
											<!-- /Change Password Form -->
											
										</div>
									</div>
								</div>
							</div>
					</div>
</asp:Content>

