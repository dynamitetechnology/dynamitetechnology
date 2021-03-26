<%@ Page Title="" Language="C#" MasterPageFile="~/doctor/Doctor.master" AutoEventWireup="true" CodeFile="Message.aspx.cs" Inherits="doctor_Message" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <nav aria-label="breadcrumb" class="page-breadcrumb">
								<ol class="breadcrumb">
									<li class="breadcrumb-item"><a href="index-2.html">Home</a></li>
									<li class="breadcrumb-item active" aria-current="page">Send Message</li>
								</ol>
							</nav>
							<h2 class="breadcrumb-title">Send Message</h2>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="col-md-5 col-lg-4 col-xl-3 theiaStickySidebar">
						
							<!-- Profile Sidebar -->
							<div class="profile-sidebar">
								<div class="widget-profile pro-widget-content">
									<div class="profile-info-widget">
										<a href="#" class="booking-doc-img">
											<img src="../assets/img/doctors/doctor-thumb-02.jpg" alt="User Image">
										</a>
										<div class="profile-det-info">
											<h3>Dr. Darren Elder</h3>
											
											<div class="patient-details">
												<h5 class="mb-0">BDS, MDS - Oral & Maxillofacial Surgery</h5>
											</div>
										</div>
									</div>
								</div>
								<div class="dashboard-widget">
									<nav class="dashboard-menu">
										<ul>
											<li class="active">
												<a href="doctor/Ddashboard.aspx">
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
												<a href="doctor/Mypatient.aspx">
													<i class="fas fa-user-injured"></i>
													<span>My Patients</span>
												</a>
											</li>
											<li>
												<a href="doctor/ScheduleTiming.aspx">
													<i class="fas fa-hourglass-start"></i>
													<span>Schedule Timings</span>
												</a>
											</li>
										
											<li>
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
											</li>
											<li>
												<a href="doctor/Profile.aspx">
													<i class="fas fa-user-cog"></i>
													<span>Profile Settings</span>
												</a>
											</li>
											
											<li>
												<a href="doctor/ChangePassword.aspx">
													<i class="fas fa-lock"></i>
													<span>Change Password</span>
												</a>
											</li>
											<li>
												<a href="doctor/logout.aspx">
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
						 
							<div class="row">
								<div class="col-sm-12">
									<div class="card">
										<div class="card-body">
											<h4 class="card-title">Schedule Timings</h4>
											<div class="profile-box">
												<div class="row">

													<div class="col-lg-4">
														<div class="form-group">               
															<label>Timing Slot Duration</label>
															<select class="select form-control">
																<option>-</option>
																<option>15 mins</option>
																<option selected="selected">30 mins</option>  
																<option>45 mins</option>
																<option>1 Hour</option>
															</select>
														</div>
													</div>

												</div>     
												<div class="row">
													<div class="col-md-12">
														<div class="card schedule-widget mb-0">
														
															<!-- Schedule Header -->
															<div class="schedule-header">
															
																<!-- Schedule Nav -->
																<div class="schedule-nav">
																	<ul class="nav nav-tabs nav-justified">
																		<li class="nav-item">
																			<a class="nav-link" data-toggle="tab" href="#slot_sunday">Sunday</a>
																		</li>
																		<li class="nav-item">
																			<a class="nav-link active" data-toggle="tab" href="#slot_monday">Monday</a>
																		</li>
																		<li class="nav-item">
																			<a class="nav-link" data-toggle="tab" href="#slot_tuesday">Tuesday</a>
																		</li>
																		<li class="nav-item">
																			<a class="nav-link" data-toggle="tab" href="#slot_wednesday">Wednesday</a>
																		</li>
																		<li class="nav-item">
																			<a class="nav-link" data-toggle="tab" href="#slot_thursday">Thursday</a>
																		</li>
																		<li class="nav-item">
																			<a class="nav-link" data-toggle="tab" href="#slot_friday">Friday</a>
																		</li>
																		<li class="nav-item">
																			<a class="nav-link" data-toggle="tab" href="#slot_saturday">Saturday</a>
																		</li>
																	</ul>
																</div>
																<!-- /Schedule Nav -->
																
															</div>
															<!-- /Schedule Header -->
															
															<!-- Schedule Content -->
															<div class="tab-content schedule-cont">
															
																<!-- Sunday Slot -->
																<div id="slot_sunday" class="tab-pane fade">
																	<h4 class="card-title d-flex justify-content-between">
																		<span>Time Slots</span> 
																		<a class="edit-link" data-toggle="modal" href="#add_time_slot"><i class="fa fa-plus-circle"></i> Add Slot</a>
																	</h4>
																	<p class="text-muted mb-0">Not Available</p>
																</div>
																<!-- /Sunday Slot -->

																<!-- Monday Slot -->
																<div id="slot_monday" class="tab-pane fade show active">
																	<h4 class="card-title d-flex justify-content-between">
																		<span>Time Slots</span> 
																		<a class="edit-link" data-toggle="modal" href="#edit_time_slot"><i class="fa fa-edit mr-1"></i>Edit</a>
																	</h4>
																	
																	<!-- Slot List -->
																	<div class="doc-times">
																		<div class="doc-slot-list">
																			8:00 pm - 11:30 pm
																			<a href="javascript:void(0)" class="delete_schedule">
																				<i class="fa fa-times"></i>
																			</a>
																		</div>
																		<div class="doc-slot-list">
																			11:30 pm - 1:30 pm
																			<a href="javascript:void(0)" class="delete_schedule">
																				<i class="fa fa-times"></i>
																			</a>
																		</div>
																		<div class="doc-slot-list">
																			3:00 pm - 5:00 pm
																			<a href="javascript:void(0)" class="delete_schedule">
																				<i class="fa fa-times"></i>
																			</a>
																		</div>
																		<div class="doc-slot-list">
																			6:00 pm - 11:00 pm
																			<a href="javascript:void(0)" class="delete_schedule">
																				<i class="fa fa-times"></i>
																			</a>
																		</div>
																	</div>
																	<!-- /Slot List -->
																	
																</div>
																<!-- /Monday Slot -->

																<!-- Tuesday Slot -->
																<div id="slot_tuesday" class="tab-pane fade">
																	<h4 class="card-title d-flex justify-content-between">
																		<span>Time Slots</span> 
																		<a class="edit-link" data-toggle="modal" href="#add_time_slot"><i class="fa fa-plus-circle"></i> Add Slot</a>
																	</h4>
																	<p class="text-muted mb-0">Not Available</p>
																</div>
																<!-- /Tuesday Slot -->

																<!-- Wednesday Slot -->
																<div id="slot_wednesday" class="tab-pane fade">
																	<h4 class="card-title d-flex justify-content-between">
																		<span>Time Slots</span> 
																		<a class="edit-link" data-toggle="modal" href="#add_time_slot"><i class="fa fa-plus-circle"></i> Add Slot</a>
																	</h4>
																	<p class="text-muted mb-0">Not Available</p>
																</div>
																<!-- /Wednesday Slot -->

																<!-- Thursday Slot -->
																<div id="slot_thursday" class="tab-pane fade">
																	<h4 class="card-title d-flex justify-content-between">
																		<span>Time Slots</span> 
																		<a class="edit-link" data-toggle="modal" href="#add_time_slot"><i class="fa fa-plus-circle"></i> Add Slot</a>
																	</h4>
																	<p class="text-muted mb-0">Not Available</p>
																</div>
																<!-- /Thursday Slot -->

																<!-- Friday Slot -->
																<div id="slot_friday" class="tab-pane fade">
																	<h4 class="card-title d-flex justify-content-between">
																		<span>Time Slots</span> 
																		<a class="edit-link" data-toggle="modal" href="#add_time_slot"><i class="fa fa-plus-circle"></i> Add Slot</a>
																	</h4>
																	<p class="text-muted mb-0">Not Available</p>
																</div>
																<!-- /Friday Slot -->

																<!-- Saturday Slot -->
																<div id="slot_saturday" class="tab-pane fade">
																	<h4 class="card-title d-flex justify-content-between">
																		<span>Time Slots</span> 
																		<a class="edit-link" data-toggle="modal" href="#add_time_slot"><i class="fa fa-plus-circle"></i> Add Slot</a>
																	</h4>
																	<p class="text-muted mb-0">Not Available</p>
																</div>
																<!-- /Saturday Slot -->

															</div>
															<!-- /Schedule Content -->
															
														</div>
													</div>
												</div>
											</div>
										</div>
									</div>
								</div>
							</div>
								
						</div>
</asp:Content>

