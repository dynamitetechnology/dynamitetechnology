<%@ Page Title="" Language="C#" MasterPageFile="~/patient/PatientMaster.master" AutoEventWireup="true" CodeFile="Prescriptiondash.aspx.cs" Inherits="patient_Prescriptiondash" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
										<%--	<li>
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
						<!-- / Profile Sidebar -->
						
						<div class="col-md-7 col-lg-8 col-xl-9">
							<div class="card">
								<div class="card-body pt-0">
								
									<!-- Tab Menu -->
									<nav class="user-tabs mb-4">
										<ul class="nav nav-tabs nav-tabs-bottom nav-justified">
											
											<li class="nav-item">
												<a class="nav-link active" href="#pat_prescriptions" data-toggle="tab">Prescriptions</a>
											</li>
											
										</ul>
									</nav>
									<!-- /Tab Menu -->
									
									<!-- Tab Content -->
									<div class="tab-content pt-0">
										
										
										<!-- Prescription Tab -->
										<div class="ab-pane show active" id="pat_prescriptions">
											<div class="card card-table mb-0">
												<div class="card-body">
													<div class="table-responsive">
														<table class="table table-hover table-center mb-0">
															<thead>
																<tr>
																	<th>AppointId </th>
                                                                    <th>Date</th>									
																	<th>Disease</th>
                                                                    <th>File</th>
																	<th>Next Visit</th>									
																	<th>Created by </th>
																	<th></th>
																</tr>     
															</thead>
															<tbody>
		  <asp:Repeater ID="d2" runat="server">
        <HeaderTemplate>
        
        </HeaderTemplate>
        <ItemTemplate>  
																<tr>
                                                                      <td>WEB#<%#Eval("AppointID") %></td>
																	<td>1<%#Eval("Date") %></td>
																	<td><%#Eval("Disease") %></td>                                                                  
                                                                    <td><a href="<%#Eval("Attachment") %>">file</a></td>
                                                                      <td><a href="<%#Eval("NextVisitDate") %>"></a></td>
																	<td>
																		<h2 class="table-avatar">
																		
																			<a href="doctor-profile.html"><%#Eval("Doctor_Name") %> <span><%#Eval("Specialization") %></span></a>
																		</h2>
																	</td>
																	<td class="text-right">
																		<div class="table-action">																			
																			<a href="Prescription.aspx?AppointId=<%#Eval("AppointID") %>" class="btn btn-sm bg-info-light">
																				<i class="far fa-eye"></i> View
																			</a>
																		</div>
																	</td>
																</tr>
															</ItemTemplate>
        <FooterTemplate>
          
        </FooterTemplate>
    </asp:Repeater>
															</tbody>	
														</table>
													</div>
												</div>
											</div>
										</div>
										<!-- /Prescription Tab -->
											
										
										
									</div>
									<!-- Tab Content -->
									
								</div>
							</div>
						</div>
</asp:Content>

