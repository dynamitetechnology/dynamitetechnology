<%@ Page Title="" Language="C#" MasterPageFile="~/doctor/Doctor.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="doctor_Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <nav aria-label="breadcrumb" class="page-breadcrumb">
								<ol class="breadcrumb">
									<li class="breadcrumb-item"><a href="index-2.html">Home</a></li>
									<li class="breadcrumb-item active" aria-current="page">Profile Settings</li>
								</ol>
							</nav>
							<h2 class="breadcrumb-title">Profile Settings</h2>
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
										
<%--											<li>
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
						
							<!-- Basic Information -->
							<div class="card">
								<div class="card-body">
									<h4 class="card-title">Basic Information</h4>
									<div class="row form-row">
										<div class="col-md-12">
										<div class="form-group">
													<div class="change-avatar">
														  <asp:Image ID="Image1" runat="server" CssClass="media-object" Height="81px" Width="95px" />
                                        
                                            <label for="form-field-select-1">
                                                Profile Pic
                                            </label>
                                            <asp:FileUpload ID="FileUpload1" runat="server" onchange="javascript:showBrowse(this.value,0);"
                                                accept="gif|jpeg|png|jpg" maxlength="5" CssClass="form-control underline" />                                            
                                            <asp:Button ID="btnUpload" runat="server" Text="Upload" CausesValidation="False"
                                                AutoPostBack="false" OnClick="btnUpload_Click" CssClass="btn btn-wide btn-o btn-primary" />
                                   
													</div>
												</div>
										</div>
										<div class="col-md-6">
											<div class="form-group">
												<label>Name <span class="text-danger">*</span></label>
												<asp:TextBox ID="txtName" runat="server" class="form-control"></asp:TextBox>
											</div>
										</div>
										<div class="col-md-6">
											<div class="form-group">
												<label>Email <span class="text-danger">*</span></label>
												<asp:TextBox ID="txtemail" runat="server" class="form-control"></asp:TextBox>
											</div>
										</div>
									
										<div class="col-md-6">
											<div class="form-group">
												<label>Phone Number</label>
												<asp:TextBox ID="txtphone" runat="server" class="form-control"></asp:TextBox>
											</div>
										</div>
										<div class="col-md-6">
											<div class="form-group">
												<label>Gender</label>
											  <asp:DropDownList ID="ddlGender" runat="server" class="form-control">
                                                            <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                                            <asp:ListItem Text="FeMale" Value="FeMale"></asp:ListItem>
                                                        </asp:DropDownList>
											</div>
										</div>
									
									</div>
								</div>
							</div>
							<!-- /Basic Information -->
							
							

							<!-- Contact Details -->
							<div class="card contact-card">
								<div class="card-body">
									<h4 class="card-title">Contact Details</h4>
									<div class="row form-row">
										<div class="col-md-6">
											<div class="form-group">
												<label>Address Line 1</label>
											<asp:TextBox ID="txtaddress1" runat="server" class="form-control"></asp:TextBox>
											</div>
										</div>
										<div class="col-md-6">
											<div class="form-group">
												<label class="control-label">Address Line 2</label>
												<asp:TextBox ID="txtaddress2" runat="server" class="form-control"></asp:TextBox>
											</div>
										</div>
										<div class="col-md-6">
											<div class="form-group">
												<label class="control-label">City</label>
												<asp:TextBox ID="txtcity" runat="server" class="form-control"></asp:TextBox>
											</div>
										</div>

										<div class="col-md-6">
											<div class="form-group">
												<label class="control-label">State / Province</label>
												<asp:TextBox ID="txtstate" runat="server" class="form-control"></asp:TextBox>
											</div>
										</div>
										<div class="col-md-6">
											<div class="form-group">
												<label class="control-label">Country</label>
												<asp:TextBox ID="txtcountry" runat="server" class="form-control"></asp:TextBox>
											</div>
										</div>
										<div class="col-md-6">
											<div class="form-group">
												<label class="control-label">Postal Code</label>
												<asp:TextBox ID="txtpin" runat="server" class="form-control"></asp:TextBox>
											</div>
										</div>
									</div>
								</div>
							</div>
							<!-- /Contact Details -->
							
							<!-- Pricing -->
							<div class="card">
								<div class="card-body">
									<h4 class="card-title">Pricing</h4>
									
										<div class="form-group mb-0">
										<asp:TextBox ID="txtfee" runat="server" class="input-tags form-control"></asp:TextBox>
										<small class="form-text text-muted">Note : Only fill Numbers eg-500</small>
									</div> 

									</div>
								
							</div>
							<!-- /Pricing -->
							
							<!-- Services and Specialization -->
							<div class="card services-card">
								<div class="card-body">
									<h4 class="card-title">Others</h4>
									<div class="form-group">
										<label>Qualification</label>
                                        <asp:TextBox ID="txtquali" runat="server" class="input-tags form-control"></asp:TextBox>
										<small class="form-text text-muted">eg : MBBS,MS</small>
									</div> 
									<div class="form-group mb-0">
										<label>Specialization </label>
                                        <asp:TextBox ID="txtspecialization" runat="server" class="input-tags form-control"></asp:TextBox>
										<small class="form-text text-muted">eg : Othopedics,Surgeon</small>
									</div> 
                                    	<div class="form-group mb-0">
										<label>Experince(Year) </label>
                                            <asp:TextBox ID="txtexp" runat="server" class="input-tags form-control"></asp:TextBox>
										
										<small class="form-text text-muted">eg : 10</small>
									</div> 
                                    	<div class="form-group mb-0">
										<label>Awards </label>
                                            <asp:TextBox ID="txtaward" runat="server" class="input-tags form-control"></asp:TextBox>
										
										
									</div> 
								</div>              
							</div>
							<!-- /Services and Specialization -->
						 
						
						
							
						
						
							
							<div class="submit-section submit-btn-bottom">
							<asp:Button ID="Button1" runat="server" Text="Save Changes" OnClick="Button1_Click" class=" form-control" BackColor="#01CAE4" ForeColor="White" />
							</div>
							
						</div>
</asp:Content>

