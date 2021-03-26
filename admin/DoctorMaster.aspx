<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMaster.master" AutoEventWireup="true" CodeFile="DoctorMaster.aspx.cs" Inherits="admin_DoctorMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <h3 class="page-title">Appointments</h3>
								<ul class="breadcrumb">
									<li class="breadcrumb-item"><a href="index.html">Dashboard</a></li>
									<li class="breadcrumb-item active">Doctor Master</li>
								</ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
						<!-- Basic Information -->
							<div class="card">
								<div class="card-body">
                                     <asp:Label ID="lblshowmsg" runat="server" Font-Size="Small" ForeColor="Red" Font-Bold="true"></asp:Label>
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
												<label>Name* <span class="text-danger">*</span></label>
												<asp:TextBox ID="txtName" runat="server" class="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" controltovalidate="txtName" ErrorMessage="*"/>
											</div>
										</div>
										<div class="col-md-6">
											<div class="form-group">
												<label>Email* <span class="text-danger">*</span></label>
												<asp:TextBox ID="txtemail" runat="server" class="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" controltovalidate="txtemail" ErrorMessage="*"/>
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
                                       	<div class="form-group mb-0">
										<label>Password for website *</label>
                                            <asp:TextBox ID="txtpassword" runat="server" class="input-tags form-control"></asp:TextBox>
										  <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator3" controltovalidate="txtpassword" ErrorMessage="*"/>
										
									</div> 
								</div>              
							</div>
							<!-- /Services and Specialization -->
						 
						
						
							
						
						
							
							<div class="submit-section submit-btn-bottom  col-sm-2">
                                <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
							<asp:Button ID="btnSave" runat="server" Text="Save Changes" OnClick="btnSave_Click" class=" form-control" BackColor="#01CAE4" ForeColor="White" />
							</div>

    <br />
    <hr />
    <div class="row">
                               
                                            <div class="table-responsive">
                                               
                       <table style="border: solid red 0px; float: left; width: 100%;" id="DoctorTable">
                                            <asp:Repeater ID="dlRoutDirectory" runat="server">
                                              
                                                <ItemTemplate>                                                  
                                                        <tr>
                                                            <td style="width: 20%;">
                                                                <asp:Label ID="Label3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Doctor_Name")%>'
                                                                    Visible="true"> </asp:Label>
                                                            </td>
                                                             <td style="width: 20%;">
                                                                <asp:Label ID="Day" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Email")%>'
                                                                    Visible="true"> </asp:Label>
                                                            </td>
                                                            <td style="width: 20%;">
                                                                <asp:Label ID="ShiftName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Password")%>'
                                                                    Visible="true"> </asp:Label>
                                                            </td>
                                                       
                                                             
                                                            <td style="width: 20%;">
                                                                <a href="DoctorMaster.aspx?xyzabc=<%# DataBinder.Eval(Container.DataItem, "id")%>">
                                                                    <img width="17px" height="17px" src='../../Images/Edite.png' /></a>
                                                            </td>
                                                            <td style="width: 20%; ">
                                                                <a href="DoctorMaster.aspx?abcxyz=<%# DataBinder.Eval(Container.DataItem, "id")%>"
                                                                    onclick="return confirm('Are you sure you want to delete this record?')">
                                                                    <img width="17px" height="17px" src='../../Images/deletes.png' /></a>
                                                            </td>
                                                        </tr>                                                    
                                                </ItemTemplate>
                                                
                                            </asp:Repeater>
       </table>
            
                                            </div>
                                      
                              
                      
						</div>
							
						
</asp:Content>

