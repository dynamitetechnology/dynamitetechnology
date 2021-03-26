<%@ Page Title="" Language="C#" MasterPageFile="~/patient/PatientMaster.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="patient_Profile" %>

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
									<%--		<li>
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
						<!-- /Profile Sidebar -->
						
						<div class="col-md-7 col-lg-8 col-xl-9">
							<div class="card">
								<div class="card-body">
									
									<!-- Profile Settings Form -->
								
										<div class="row form-row">
											<div class="col-12 col-md-12">
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
											<div class="col-12 col-md-6">
												<div class="form-group">
													<label>Full Name</label>
													 <asp:TextBox ID="txtName" runat="server" class="form-control"></asp:TextBox>
												</div>
											</div>
											<div class="col-12 col-md-6">
												<div class="form-group">
													<label>Father Name</label>
													 <asp:TextBox ID="txtfather" runat="server" class="form-control"></asp:TextBox>
												</div>
											</div>
											<div class="col-12 col-md-6">
												<div class="form-group">
													<label>Age</label>
													<div class="cal-icon">
														 <asp:TextBox ID="txtage" runat="server" class="form-control"></asp:TextBox>
													</div>
												</div>
											</div>
											<div class="col-12 col-md-6">
												<div class="form-group">
													<label>Blood Group</label>
                                                    <asp:DropDownList ID="ddlBloodgroup" runat="server" class="form-control">
                                                          <asp:ListItem Text="A+" Value="A+"></asp:ListItem>
                                                        <asp:ListItem Text="A-" Value="A-"></asp:ListItem>
                                                            <asp:ListItem Text="B+" Value="B+"></asp:ListItem>
                                                        <asp:ListItem Text="B-" Value="B-"></asp:ListItem>
                                                         <asp:ListItem Text="O+" Value="O+"></asp:ListItem>
                                                        <asp:ListItem Text="O-" Value="O-"></asp:ListItem>
                                                            <asp:ListItem Text="AB+" Value="AB+"></asp:ListItem>
                                                        <asp:ListItem Text="AB-" Value="AB-"></asp:ListItem>
                                                            </asp:DropDownList>
													
												</div>
											</div>
                                            	<div class="col-12 col-md-6">
												<div class="form-group">
												<label>Gender</label>													
                                                        <asp:DropDownList ID="ddlGender" runat="server" class="form-control">
                                                            <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                                            <asp:ListItem Text="FeMale" Value="FeMale"></asp:ListItem>
                                                        </asp:DropDownList>
													
												</div>
											</div>
											<div class="col-12 col-md-6">
												<div class="form-group">
													<label>Email ID</label>
													 <asp:TextBox ID="txtemail" runat="server" class="form-control"></asp:TextBox>
												</div>
											</div>
											<div class="col-12 col-md-6">
												<div class="form-group">
													<label>Mobile</label>
												 <asp:TextBox ID="txtphone" runat="server" class="form-control"></asp:TextBox>
												</div>
											</div>
											<div class="col-12">
												<div class="form-group">
												<label>Address</label>
												 <asp:TextBox ID="txtaddress" runat="server" class="form-control"></asp:TextBox>
												</div>
											</div>
											<div class="col-12 col-md-6">
												<div class="form-group">
													<label>City</label>
													 <asp:TextBox ID="txtcity" runat="server" class="form-control"></asp:TextBox>
												</div>
											</div>
											<div class="col-12 col-md-6">
												<div class="form-group">
													<label>State</label>
												 <asp:TextBox ID="txtstate" runat="server" class="form-control"></asp:TextBox>
												</div>
											</div>
											<div class="col-12 col-md-6">
												<div class="form-group">
													<label>Pin Code</label>
												 <asp:TextBox ID="txtpin" runat="server" class="form-control"></asp:TextBox>
												</div>
											</div>
											<div class="col-12 col-md-6">
												<div class="form-group">
													<label>Country</label>
													 <asp:TextBox ID="txtcountry" runat="server" class="form-control"></asp:TextBox>
												</div>
											</div>
										</div>
										<div class="submit-section">
                                             <asp:Button ID="Button1" runat="server" Text="Save Changes" OnClick="Button1_Click" class=" form-control" BackColor="#01CAE4" ForeColor="White" />
										<%--	<button type="submit" class="btn btn-primary submit-btn">Save Changes</button>--%>
										</div>
								
									<!-- /Profile Settings Form -->
									
								</div>
							</div>
						</div>
</asp:Content>

