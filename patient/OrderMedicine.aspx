<%@ Page Title="" Language="C#" MasterPageFile="~/patient/PatientMaster.master" AutoEventWireup="true" CodeFile="OrderMedicine.aspx.cs" Inherits="patient_OrderMedicine" %>

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
						 
							<div class="row">
						                                <div class="col-lg-12">
							<div class="card">
								<div class="card-header">
									<h4 class="card-title">Prescription Order</h4>
								</div>
								<div class="card-body">
									<div class="table-responsive">
										<table class="table mb-0">
											<thead>
												<asp:Label ID="Label2" runat="server" Text="" CssClass="text-danger"></asp:Label>
                                              
											</thead>
											<tbody>
												<tr>
													<td>Appointment No. :</td>
													<td> <asp:TextBox ID="txtAppointNo" runat="server" CssClass="form-control" ReadOnly></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator6" controltovalidate="txtAppointNo" ErrorMessage="*"/>
													</td>
                                                   
												</tr>
												<tr>
													<td>Prescription Date :</td>
													<td><asp:TextBox ID="txtDate" runat="server" CssClass="form-control" ReadOnly></asp:TextBox></td>
													
												</tr>
												<tr>
													<td>Disease :</td>
													<td><asp:TextBox ID="txtDisease" runat="server" CssClass="form-control" ReadOnly></asp:TextBox></td>
												
												</tr>
                                                <tr>
													<td>Prescription :</td>
													<td><asp:Label ID="lblprescription" runat="server" Text=""></asp:Label></td>
													
												</tr>
												<tr>
													<td>Attachment :</td>
													<td><asp:Label ID="lblfile" runat="server" Text=""></asp:Label>
                                                        <asp:Label ID="lblattach" runat="server" Text="" Visible="false"></asp:Label>
													 </td>
													
												</tr>
												<tr>
													<td>Remark :</td>
													<td><asp:TextBox ID="txtremark" runat="server" CssClass="form-control"></asp:TextBox>
                                                          <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator5" controltovalidate="txtremark" ErrorMessage="*"/>
													</td>
												
												</tr>
                                                <tr>
													<td>Dilivery Address :</td>
													<td><asp:TextBox ID="txtaddress" runat="server" CssClass="form-control"></asp:TextBox>
                                                          <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" controltovalidate="txtaddress" ErrorMessage="*"/>
													</td>
												
												</tr>
                                                  <tr>
													<td>City :</td>
													<td><asp:TextBox ID="txtcity" runat="server" CssClass="form-control"></asp:TextBox>
                                                          <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" controltovalidate="txtcity" ErrorMessage="*"/>
													</td>
												
												</tr>
                                                  <tr>
													<td>PinCode :</td>
													<td><asp:TextBox ID="txtpin" runat="server" CssClass="form-control"></asp:TextBox>
                                                          <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator3" controltovalidate="txtpin" ErrorMessage="*"/>
													</td>
												
												</tr>
                                                  <tr>
													<td>Phone :</td>
													<td><asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
                                                          <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator4" controltovalidate="txtPhone" ErrorMessage="*"/>
													</td>
												
												</tr>
                                             
                                                
                                             
											</tbody>
										</table>
									</div>
								</div>
							</div>
						</div>
                                
					<div class="submit-section" style="margin-left:30px;">
                    <asp:Label ID="lblotp" runat="server" Text=""></asp:Label>  
				<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        <br />
               <asp:Button ID="Button1" runat="server" Text="Order Now"  class=" form-control" BackColor="#01CAE4" ForeColor="White" OnClick="Button1_Click" />
                        <br />
												</div>
                                
                            </div>
     </div>
</asp:Content>

