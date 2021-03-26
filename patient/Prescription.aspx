<%@ Page Title="" Language="C#" MasterPageFile="~/patient/PatientMaster.master" AutoEventWireup="true" CodeFile="Prescription.aspx.cs" Inherits="patient_Prescription" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
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
									<h4 class="card-title">Prescription</h4>
								</div>
								<div class="card-body">
									<div class="table-responsive">
										<table class="table mb-0">
											<thead>
												
											</thead>
											<tbody>
												<tr>
													<td>Appointment No. :</td>
													<td><asp:Label ID="lblAppointNo" runat="server" Text=""></asp:Label></td>
													
												</tr>
												<tr>
													<td>Date :</td>
													<td><asp:Label ID="lblDate" runat="server" Text=""></asp:Label></td>
													
												</tr>
												<tr>
													<td>Disease :</td>
													<td><asp:Label ID="lbldisease" runat="server" Text=""></asp:Label></td>
												
												</tr>
                                                <tr>
													<td>Prescription :</td>
													<td><asp:Label ID="lblprescription" runat="server" Text=""></asp:Label></td>
													
												</tr>
												<tr>
													<td>Attachment :</td>
													<td><asp:Label ID="lblfile" runat="server" Text=""></asp:Label>
													 </td>
													
												</tr>
												<tr>
													<td>Remark :</td>
													<td><asp:Label ID="lblremark" runat="server" Text=""></asp:Label></td>
												
												</tr>
                                                <tr>
													<td>Next Visit Date :</td>
													<td><asp:Label ID="lblnext" runat="server" Text=""></asp:Label></td>
												
												</tr>
                                                <tr>
													<td>Created By :</td>
													<td><asp:Label ID="lblcreated" runat="server" Text=""></asp:Label></td>
												
												</tr>
                                                
                                             
											</tbody>
										</table>
									</div>
								</div>
							</div>
						</div>
                                
					<div class="submit-section" style="margin-left:30px;">
                        <asp:Label ID="Label2" runat="server" Text="Want To Order Medicine? Just Click Here "></asp:Label>
			
                        <br />
               <asp:Button ID="Button1" runat="server" Text="Order Medicine Now"  class=" form-control" BackColor="#01CAE4" ForeColor="White" OnClick="Button1_Click" />
                        <br />
												</div>
                                
                            </div>
     </div>
</asp:Content>

