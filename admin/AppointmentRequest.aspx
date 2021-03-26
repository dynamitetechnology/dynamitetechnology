<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMaster.master" AutoEventWireup="true" CodeFile="AppointmentRequest.aspx.cs" Inherits="admin_AppointmentRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    	<h3 class="page-title">Appointment Request</h3>
								<ul class="breadcrumb">
									<li class="breadcrumb-item"><a href="index.html">Dashboard</a></li>
									<li class="breadcrumb-item active">Appointment Request</li>
								</ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    	<div class="card">
								<div class="card-body">
									<div class="table-responsive">
										<table class="datatable table table-hover table-center mb-0">
											<thead>
												<tr>
													<th>Order Id</th>
													<th>BookingDate</th>
													<th>Appointment Duration</th>
													<th>Problem</th>
													<th>Status</th>
													<th class="text-right">Amount</th>
                                                    <th></th>
												</tr>
											</thead>
											<tbody>
                                                 <asp:Repeater ID="d2" runat="server">
        <HeaderTemplate>
        
        </HeaderTemplate>
        <ItemTemplate>  
												<tr>
													<td><%#Eval("ReqId")%></td>
													<td><%#Eval("BookingDate") %></td>												
													<td><%#Eval("AppointTime") %></td>
                                                    <td><%#Eval("Problem") %></td>
													<td><%#Eval("Appointment_Status")%></td>
                                                    <td><%#Eval("Bill_Amount")%></td>
															<td class="text-right">
																			<div class="table-action">
																				<a href="ViewRequest.aspx?id=<%#Eval("AptId") %>&Appointid=<%#Eval("PatientID") %>" class="btn btn-sm bg-info-light" >
																					<i class="fas fa-check"></i>View
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
							<!-- /Recent Orders -->
				
</asp:Content>

