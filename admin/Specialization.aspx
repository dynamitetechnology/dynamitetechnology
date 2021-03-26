<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMaster.master" AutoEventWireup="true" CodeFile="Specialization.aspx.cs" Inherits="admin_Specialization" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 	<div class="col-sm-7 col-auto">
								<h3 class="page-title">Specialities</h3>
								<ul class="breadcrumb">
									<li class="breadcrumb-item"><a href="index.html">Dashboard</a></li>
									<li class="breadcrumb-item active">Specialities</li>
								</ul>
							</div>
							<div class="col-sm-5 col">
								<a href="#Add_Specialities_details" data-toggle="modal" class="btn btn-primary float-right mt-2">Add</a>
							</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="card">
								<div class="card-body">
									<div class="table-responsive">
										<table class="datatable table table-hover table-center mb-0">
											<thead>
												<tr>
													<th>Specialities</th>
													<th>Edit</th>
													<th class="text-right">Delete</th>
												</tr>
											</thead>
											<tbody>
                                                  <asp:Repeater ID="dlRoutDirectory" runat="server">
                                              
                                                <ItemTemplate>  
												<tr>
													<td>
                                                         <asp:Label ID="Label3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Name")%>'
                                                                    Visible="true"> </asp:Label>
													</td>
													  
												 <td class="text-right">
                                                                <a href="ScheduleTiming.aspx?xyzabc=<%# DataBinder.Eval(Container.DataItem, "Id")%>">
                                                                    <img width="17px" height="17px" src='../../Images/Edite.png' /></a>
                                                            </td>
													<td class="text-right">
														 <a href="ScheduleTiming.aspx?abcxyz=<%# DataBinder.Eval(Container.DataItem, "Id")%>"
                                                                    onclick="return confirm('Are you sure you want to delete this record?')">
                                                                    <img width="17px" height="17px" src='../../Images/deletes.png' /></a>
													</td>
												</tr>
												   </ItemTemplate>
                                                
                                            </asp:Repeater>
											</tbody>
										</table>
									</div>
								</div>
							</div>
					
			<!-- /Page Wrapper -->
			
			
			<!-- Add Modal -->
			<div class="modal fade" id="Add_Specialities_details" aria-hidden="true" role="dialog">
				<div class="modal-dialog modal-dialog-centered" role="document" >
					<div class="modal-content">
						<div class="modal-header">
							<h5 class="modal-title">Add Specialities</h5>
							<button type="button" class="close" data-dismiss="modal" aria-label="Close">
								<span aria-hidden="true">&times;</span>
							</button>
						</div>
						<div class="modal-body">
						
								<div class="row form-row">
									<div class="col-12 col-sm-10">
										<div class="form-group">
											<label>Specialities</label>
											<input type="text" class="form-control">
										</div>
									</div>							
									
								</div>
								<button type="submit" class="btn btn-primary btn-block">Save Changes</button>
						
						</div>
					</div>
				</div>
			</div>
			<!-- /ADD Modal -->
		
       
</asp:Content>

