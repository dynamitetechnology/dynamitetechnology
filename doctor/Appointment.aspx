<%@ Page Title="" Language="C#" MasterPageFile="~/doctor/Doctor.master" AutoEventWireup="true" CodeFile="Appointment.aspx.cs" Inherits="doctor_Appointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <nav aria-label="breadcrumb" class="page-breadcrumb">
								<ol class="breadcrumb">
									<li class="breadcrumb-item"><a href="index-2.html">Home</a></li>
									<li class="breadcrumb-item active" aria-current="page">Appointments</li>
								</ol>
							</nav>
							<h2 class="breadcrumb-title">Appointments</h2>
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
							<div class="appointments">
							
								<!-- Appointment List -->
								<div class="appointment-list">
									<div class="profile-info-widget">
										<a href="patient-profile.html" class="booking-doc-img">
											<img src="../assets/img/patients/patient.jpg" alt="User Image">
										</a>
										<div class="profile-det-info">
											<h3><a href="patient-profile.html">Richard Wilson</a></h3>
											<div class="patient-details">
												<h5><i class="far fa-clock"></i> 14 Nov 2019, 10.00 AM</h5>
												<h5><i class="fas fa-map-marker-alt"></i> Newyork, United States</h5>
												<h5><i class="fas fa-envelope"></i> richard@example.com</h5>
												<h5 class="mb-0"><i class="fas fa-phone"></i> +1 923 782 4575</h5>
											</div>
										</div>
									</div>
									<div class="appointment-action">
										<a href="#" class="btn btn-sm bg-info-light" data-toggle="modal" data-target="#appt_details">
											<i class="far fa-eye"></i> View
										</a>
										<a href="javascript:void(0);" class="btn btn-sm bg-success-light">
											<i class="fas fa-check"></i> Accept
										</a>
										<a href="javascript:void(0);" class="btn btn-sm bg-danger-light">
											<i class="fas fa-times"></i> Cancel
										</a>
									</div>
								</div>
								<!-- /Appointment List -->
							
								<!-- Appointment List -->
								<div class="appointment-list">
									<div class="profile-info-widget">
										<a href="patient-profile.html" class="booking-doc-img">
											<img src="../assets/img/patients/patient1.jpg" alt="User Image">
										</a>
										<div class="profile-det-info">
											<h3><a href="patient-profile.html">Charlene Reed </a></h3>
											<div class="patient-details">
												<h5><i class="far fa-clock"></i> 12 Nov 2019, 5.00 PM</h5>
												<h5><i class="fas fa-map-marker-alt"></i> North Carolina, United States</h5>
												<h5><i class="fas fa-envelope"></i> charlenereed@example.com</h5>
												<h5 class="mb-0"><i class="fas fa-phone"></i> +1 828 632 9170</h5>
											</div>
										</div>
									</div>
									<div class="appointment-action">
										<a href="#" class="btn btn-sm bg-info-light" data-toggle="modal" data-target="#appt_details">
											<i class="far fa-eye"></i> View
										</a>
										<a href="javascript:void(0);" class="btn btn-sm bg-success-light">
											<i class="fas fa-check"></i> Accept
										</a>
										<a href="javascript:void(0);" class="btn btn-sm bg-danger-light">
											<i class="fas fa-times"></i> Cancel
										</a>
									</div>
								</div>
								<!-- /Appointment List -->
								
								<!-- Appointment List -->
								<div class="appointment-list">
									<div class="profile-info-widget">
										<a href="patient-profile.html" class="booking-doc-img">
											<img src="../assets/img/patients/patient2.jpg" alt="User Image">
										</a>
										<div class="profile-det-info">
											<h3><a href="patient-profile.html">Travis Trimble</a></h3>
											
											<div class="patient-details">
												<h5><i class="far fa-clock"></i> 11 Nov 2019, 8.00 PM</h5>
												<h5><i class="fas fa-map-marker-alt"></i> Maine, United States</h5>
												<h5><i class="fas fa-envelope"></i> travistrimble@example.com</h5>
												<h5 class="mb-0"><i class="fas fa-phone"></i> +1 207 729 9974</h5>
											</div>
										</div>
									</div>
									<div class="appointment-action">
										<a href="#" class="btn btn-sm bg-info-light" data-toggle="modal" data-target="#appt_details">
											<i class="far fa-eye"></i> View
										</a>
										
										<a href="javascript:void(0);" class="btn btn-sm bg-success-light">
											<i class="fas fa-check"></i> Accept
										</a>
										<a href="javascript:void(0);" class="btn btn-sm bg-danger-light">
											<i class="fas fa-times"></i> Cancel
										</a>
									</div>
								</div>
								<!-- /Appointment List -->
								
								<!-- Appointment List -->
								<div class="appointment-list">
									<div class="profile-info-widget">
										<a href="patient-profile.html" class="booking-doc-img">
											<img src="../assets/img/patients/patient3.jpg" alt="User Image">
										</a>
										<div class="profile-det-info">
											<h3><a href="patient-profile.html">Carl Kelly</a></h3>
											<div class="patient-details">
												<h5><i class="far fa-clock"></i> 9 Nov 2019, 9.00 AM</h5>
												<h5><i class="fas fa-map-marker-alt"></i> Newyork, United States</h5>
												<h5><i class="fas fa-envelope"></i> carlkelly@example.com</h5>
												<h5 class="mb-0"><i class="fas fa-phone"></i> +1 260 724 7769</h5>
											</div>
										</div>
									</div>
									<div class="appointment-action">
										<a href="#" class="btn btn-sm bg-info-light" data-toggle="modal" data-target="#appt_details">
											<i class="far fa-eye"></i> View
										</a>
										<a href="javascript:void(0);" class="btn btn-sm bg-success-light">
											<i class="fas fa-check"></i> Accept
										</a>
										<a href="javascript:void(0);" class="btn btn-sm bg-danger-light">
											<i class="fas fa-times"></i> Cancel
										</a>
									</div>
								</div>
								<!-- /Appointment List -->
								
								<!-- Appointment List -->
								<div class="appointment-list">
									<div class="profile-info-widget">
										<a href="patient-profile.html" class="booking-doc-img">
											<img src="../assets/img/patients/patient4.jpg" alt="User Image">
										</a>
										<div class="profile-det-info">
											<h3><a href="patient-profile.html">Michelle Fairfax</a></h3>
											<div class="patient-details">
												<h5><i class="far fa-clock"></i> 9 Nov 2019, 1.00 PM</h5>
												<h5><i class="fas fa-map-marker-alt"></i> Indiana, United States</h5>
												<h5><i class="fas fa-envelope"></i> michellefairfax@example.com</h5>
												<h5 class="mb-0"><i class="fas fa-phone"></i> +1 504 368 6874</h5>
											</div>
										</div>
									</div>
									<div class="appointment-action">
										<a href="#" class="btn btn-sm bg-info-light" data-toggle="modal" data-target="#appt_details">
											<i class="far fa-eye"></i> View
										</a>
										<a href="javascript:void(0);" class="btn btn-sm bg-success-light">
											<i class="fas fa-check"></i> Accept
										</a>
										<a href="javascript:void(0);" class="btn btn-sm bg-danger-light">
											<i class="fas fa-times"></i> Cancel
										</a>
									</div>
								</div>
								<!-- /Appointment List -->
								
								<!-- Appointment List -->
								<div class="appointment-list">
									<div class="profile-info-widget">
										<a href="patient-profile.html" class="booking-doc-img">
											<img src="../assets/img/patients/patient5.jpg" alt="User Image">
										</a>
										<div class="profile-det-info">
											<h3><a href="patient-profile.html">Gina Moore</a></h3>
											<div class="patient-details">
												<h5><i class="far fa-clock"></i> 8 Nov 2019, 3.00 PM</h5>
												<h5><i class="fas fa-map-marker-alt"></i> Florida, United States</h5>
												<h5><i class="fas fa-envelope"></i> ginamoore@example.com</h5>
												<h5 class="mb-0"><i class="fas fa-phone"></i> +1 954 820 7887</h5>
											</div>
										</div>
									</div>
									<div class="appointment-action">
										<a href="#" class="btn btn-sm bg-info-light" data-toggle="modal" data-target="#appt_details">
											<i class="far fa-eye"></i> View
										</a>
										<a href="javascript:void(0);" class="btn btn-sm bg-success-light">
											<i class="fas fa-check"></i> Accept
										</a>
										<a href="javascript:void(0);" class="btn btn-sm bg-danger-light">
											<i class="fas fa-times"></i> Cancel
										</a>
									</div>
								</div>
								<!-- /Appointment List -->
								
								<!-- Appointment List -->
								<div class="appointment-list">
									<div class="profile-info-widget">
										<a href="patient-profile.html" class="booking-doc-img">
											<img src="../assets/img/patients/patient6.jpg" alt="User Image">
										</a>
										<div class="profile-det-info">
											<h3><a href="patient-profile.html">Elsie Gilley</a></h3>
											<div class="patient-details">
												<h5><i class="far fa-clock"></i> 6 Nov 2019, 9.00 AM</h5>
												<h5><i class="fas fa-map-marker-alt"></i> Kentucky, United States</h5>
												<h5><i class="fas fa-envelope"></i> elsiegilley@example.com</h5>
												<h5 class="mb-0"><i class="fas fa-phone"></i> +1 315 384 4562</h5>
											</div>
										</div>
									</div>
									<div class="appointment-action">
										<a href="#" class="btn btn-sm bg-info-light" data-toggle="modal" data-target="#appt_details">
											<i class="far fa-eye"></i> View
										</a>
										<a href="javascript:void(0);" class="btn btn-sm bg-success-light">
											<i class="fas fa-check"></i> Accept
										</a>
										<a href="javascript:void(0);" class="btn btn-sm bg-danger-light">
											<i class="fas fa-times"></i> Cancel
										</a>
									</div>
								</div>
								<!-- /Appointment List -->
								
								<!-- Appointment List -->
								<div class="appointment-list">
									<div class="profile-info-widget">
										<a href="patient-profile.html" class="booking-doc-img">
											<img src="../assets/img/patients/patient7.jpg" alt="User Image">
										</a>
										<div class="profile-det-info">
											<h3><a href="patient-profile.html">Joan Gardner</a></h3>
											<div class="patient-details">
												<h5><i class="far fa-clock"></i> 5 Nov 2019, 12.00 PM</h5>
												<h5><i class="fas fa-map-marker-alt"></i> California, United States</h5>
												<h5><i class="fas fa-envelope"></i> joangardner@example.com</h5>
												<h5 class="mb-0"><i class="fas fa-phone"></i> +1 707 2202 603</h5>
											</div>
										</div>
									</div>
									<div class="appointment-action">
										<a href="#" class="btn btn-sm bg-info-light" data-toggle="modal" data-target="#appt_details">
											<i class="far fa-eye"></i> View
										</a>
										<a href="javascript:void(0);" class="btn btn-sm bg-success-light">
											<i class="fas fa-check"></i> Accept
										</a>
										<a href="javascript:void(0);" class="btn btn-sm bg-danger-light">
											<i class="fas fa-times"></i> Cancel
										</a>
									</div>
								</div>
								<!-- /Appointment List -->
								
								<!-- Appointment List -->
								<div class="appointment-list">
									<div class="profile-info-widget">
										<a href="patient-profile.html" class="booking-doc-img">
											<img src="../assets/img/patients/patient8.jpg" alt="User Image">
										</a>
										<div class="profile-det-info">
											<h3><a href="patient-profile.html">Daniel Griffing</a></h3>
											<div class="patient-details">
												<h5><i class="far fa-clock"></i> 5 Nov 2019, 7.00 PM</h5>
												<h5><i class="fas fa-map-marker-alt"></i> New Jersey, United States</h5>
												<h5><i class="fas fa-envelope"></i> danielgriffing@example.com</h5>
												<h5 class="mb-0"><i class="fas fa-phone"></i> +1 973 773 9497</h5>
											</div>
										</div>
									</div>
									<div class="appointment-action">
										<a href="#" class="btn btn-sm bg-info-light" data-toggle="modal" data-target="#appt_details">
											<i class="far fa-eye"></i> View
										</a>
										<a href="javascript:void(0);" class="btn btn-sm bg-success-light">
											<i class="fas fa-check"></i> Accept
										</a>
										<a href="javascript:void(0);" class="btn btn-sm bg-danger-light">
											<i class="fas fa-times"></i> Cancel
										</a>
									</div>
								</div>
								<!-- /Appointment List -->
								
								<!-- Appointment List -->
								<div class="appointment-list">
									<div class="profile-info-widget">
										<a href="patient-profile.html" class="booking-doc-img">
											<img src="../assets/img/patients/patient9.jpg" alt="User Image">
										</a>
										<div class="profile-det-info">
											<h3><a href="patient-profile.html">Walter Roberson</a></h3>
											<div class="patient-details">
												<h5><i class="far fa-clock"></i> 4 Nov 2019, 10.00 AM</h5>
												<h5><i class="fas fa-map-marker-alt"></i> Florida, United States</h5>
												<h5><i class="fas fa-envelope"></i> walterroberson@example.com</h5>
												<h5 class="mb-0"><i class="fas fa-phone"></i> +1 850 358 4445</h5>
											</div>
										</div>
									</div>
									<div class="appointment-action">
										<a href="#" class="btn btn-sm bg-info-light" data-toggle="modal" data-target="#appt_details">
											<i class="far fa-eye"></i> View
										</a>
										<a href="javascript:void(0);" class="btn btn-sm bg-success-light">
											<i class="fas fa-check"></i> Accept
										</a>
										<a href="javascript:void(0);" class="btn btn-sm bg-danger-light">
											<i class="fas fa-times"></i> Cancel
										</a>
									</div>
								</div>
								<!-- /Appointment List -->
								
								<!-- Appointment List -->
								<div class="appointment-list">
									<div class="profile-info-widget">
										<a href="patient-profile.html" class="booking-doc-img">
											<img src="../assets/img/patients/patient10.jpg" alt="User Image">
										</a>
										<div class="profile-det-info">
											<h3><a href="patient-profile.html">Robert Rhodes</a></h3>
											<div class="patient-details">
												<h5><i class="far fa-clock"></i> 4 Nov 2019, 11.00 AM</h5>
												<h5><i class="fas fa-map-marker-alt"></i> California, United States</h5>
												<h5><i class="fas fa-envelope"></i> robertrhodes@example.com</h5>
												<h5 class="mb-0"><i class="fas fa-phone"></i> +1 858 259 5285</h5>
											</div>
										</div>
									</div>
									<div class="appointment-action">
										<a href="#" class="btn btn-sm bg-info-light" data-toggle="modal" data-target="#appt_details">
											<i class="far fa-eye"></i> View
										</a>
										<a href="javascript:void(0);" class="btn btn-sm bg-success-light">
											<i class="fas fa-check"></i> Accept
										</a>
										<a href="javascript:void(0);" class="btn btn-sm bg-danger-light">
											<i class="fas fa-times"></i> Cancel
										</a>
									</div>
								</div>
								<!-- /Appointment List -->
								
								<!-- Appointment List -->
								<div class="appointment-list">
									<div class="profile-info-widget">
										<a href="patient-profile.html" class="booking-doc-img">
											<img src="../assets/img/patients/patient11.jpg" alt="User Image">
										</a>
										<div class="profile-det-info">
											<h3><a href="patient-profile.html">Harry Williams</a></h3>
											<div class="patient-details">
												<h5><i class="far fa-clock"></i> 3 Nov 2019, 6.00 PM</h5>
												<h5><i class="fas fa-map-marker-alt"></i> Colorado, United States</h5>
												<h5><i class="fas fa-envelope"></i> harrywilliams@example.com</h5>
												<h5 class="mb-0"><i class="fas fa-phone"></i> +1 303 607 7075</h5>
											</div>
										</div>
									</div>
									<div class="appointment-action">
										<a href="#" class="btn btn-sm bg-info-light" data-toggle="modal" data-target="#appt_details">
											<i class="far fa-eye"></i> View
										</a>
										<a href="javascript:void(0);" class="btn btn-sm bg-success-light">
											<i class="fas fa-check"></i> Accept
										</a>
										<a href="javascript:void(0);" class="btn btn-sm bg-danger-light">
											<i class="fas fa-times"></i> Cancel
										</a>
									</div>
								</div>
								<!-- /Appointment List -->
								
							</div>
						</div>
					

</asp:Content>

