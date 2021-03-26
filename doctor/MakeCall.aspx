<%@ Page Title="" Language="C#" MasterPageFile="~/doctor/Doctor.master" AutoEventWireup="true" CodeFile="MakeCall.aspx.cs" Inherits="doctor_MakeCall" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <nav aria-label="breadcrumb" class="page-breadcrumb">
								<ol class="breadcrumb">
									<li class="breadcrumb-item"><a href="index-2.html">Home</a></li>
									<li class="breadcrumb-item active" aria-current="page">Treatment</li>
								</ol>
							</nav>
							<h2 class="breadcrumb-title">Treatment</h2>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
     <div class="col-md-7 col-lg-12">
							<div class="card">
								<div class="card-body">
								<h4> Appoint No : WEB#<asp:Label ID="lbl_appoint" runat="server"></asp:Label></h4>
									<!-- Checkout Form -->
									<div class="col-lg-4">
                                        	<div class="form-group form-focus">												
                                             <label><b>Patient No  : #PT</b> </label>
                                                        <asp:Label ID="lbl_Id" runat="server"></asp:Label>
											</div>
										
											<div class="form-group form-focus">												
                                          <label><b>Phone : </b></label>
                                                        <asp:Label ID="lbl_phone" runat="server"></asp:Label>
											</div>
                                       
                                        <div class="form-group form-focus">
											      <label><b> Age:</b> </label>
                                                        <asp:Label ID="lbl_age" runat="server"></asp:Label>
											</div>
									</div>
                                    <div class="col-lg-4">
                                        <div class="form-group form-focus">
											  <label><b>Patient Name :</b> </label>
                                                        <asp:Label ID="lbl_Name" runat="server"></asp:Label>
											</div>
                                        	<div class="form-group form-focus">
											      <label><b> Address:</b> </label>
                                                        <asp:Label ID="lbl_address" runat="server"></asp:Label>
											</div>
                                           <div class="form-group form-focus">
											      <label><b> Gender:</b> </label>
                                                        <asp:Label ID="lbl_gender" runat="server"></asp:Label>
											</div>
                                    </div>
									<div class="col-lg-4">
                                        		<div class="form-group form-focus">
											  <label><b>FatherName  :</b> </label>
                                                        <asp:Label ID="lbl_father" runat="server"></asp:Label>
											</div>
                                    
										 <div class="form-group form-focus">	
                                         <label><b>City :</b> </label>
                                                        <asp:Label ID="lbl_city" runat="server"></asp:Label>
											</div>
                                     
                                        <div class="form-group form-focus">
											      <label><b> BloodGroup:</b> </label>
                                                        <asp:Label ID="lbl_blood" runat="server"></asp:Label>
											</div>
									</div>
									
                                   
									<!-- /Checkout Form -->
									
								</div>
							</div>
							
					
         </div>
    <div class="col-md-7 col-lg-12">
							<div class="card">
								<div class="card-body">
								
									<div class="table-responsive">
															<table class="table table-hover table-center mb-0">
																<thead>
																	<tr>
																		<th>Appoint Date</th>
																		<th>Time</th>
																		<th>Purpose</th>
																		<th>Type</th>
																	
																	</tr>
																</thead>
																<tbody>
                                                                    <tr>
                                                                     <td><asp:Label ID="lbl_Date" runat="server"></asp:Label></td>
                                                                     <td><asp:Label ID="lbl_Time" runat="server"></asp:Label></td>
                                                                     <td><asp:Label ID="lbl_Purpose" runat="server"></asp:Label></td>
                                                                     <td><asp:Label ID="lbl_Type" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Button ID="Button1" runat="server" Text="Make Call" class=" form-control" BackColor="#01CAE4" ForeColor="White" OnClick="Button1_Click" />
										</td>
                                                                    </tr>
                                                                  
                                                                    </tbody>
                                                                </table>
									
								</div>
							</div>
							
					
         </div>
        </div>
    <h3 style="margin-left:20px;">Pre. Appointments(History)</h3>
    <div class="col-md-7 col-lg-12">
     
													<div class="card-body">
														<div class="table-responsive">
															<table class="table table-hover table-center mb-0">
																<thead>
																	<tr>
																		<th>Previous Appoint Date</th>
																		<th>Disease</th>
																		<th>Prescription</th>
																		<th>Attachment</th>
																	
																	</tr>
																</thead>
																<tbody>
                                                                                                              			  <asp:Repeater ID="d1" runat="server">
        <HeaderTemplate>
        
        </HeaderTemplate>
        <ItemTemplate>  
																	<tr>
								                                  <td><%#Eval("AppointDate") %> <span class="d-block text-info"><%#Eval("Timeslot") %></span></td>																	
																		<td><%#Eval("Disease") %></td>
																		<td><%#Eval("Prescription") %></td>
																		<td class="text-center"><a href="<%#Eval("Attachment") %>">file</a>
  
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
     <h3 style="margin-left:20px;">Add Prescription</h3>
    <asp:Label ID="lblmsg" runat="server" Text="" CssClass="text-danger"></asp:Label>
    <div class="col-md-7 col-lg-12">
							<div class="card">
								<div class="card-body">
								
									<!-- Checkout Form -->
									<div class="col-lg-8">
                                        	<div class="form-group form-focus">												
                                             <label><b>Disease :</b> </label>
                                                       <asp:TextBox ID="txtdisease" runat="server" class="form-control"></asp:TextBox>
                           <%--                     <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" controltovalidate="txtdisease" ErrorMessage="*"/>--%>
											</div>
										<br />
											<div class="form-group form-focus">												
                                          <label><b>Prescription : </b></label>
                                                       <asp:TextBox ID="txtprescription" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
<%--                                                <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" controltovalidate="txtprescription" ErrorMessage="*"/>--%>
											</div>
                                       <br />
                                        <div class="form-group form-focus">
											      <label><b>Upload Attachment:</b> </label>
                                                      <asp:FileUpload ID="FileUpload1" runat="server" class="upload" />
                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.jpeg|.PNG|.JPG|.JPEG|.gif)$"
                                                                        ControlToValidate="FileUpload1" runat="server" ForeColor="Red" ErrorMessage="Please select a valid image file."
                                                                        Display="Dynamic" />
                                             <asp:Label ID="lbl_FileUpload1" runat="server" ForeColor="Blue"></asp:Label>
                                            <asp:Image ID="Image1" runat="server" Visible="false" />
											</div>
									</div>
                                    <div class="col-lg-4">
                                        <div class="form-group form-focus">
											  <label><b>Next Visit Date(If Any) :</b> </label>
                                                        <asp:TextBox ID="txtDate"  runat="server"  CssClass="form-control" ></asp:TextBox>
											</div>
                                        <br />
                                        	<div class="form-group form-focus">
											      <label><b> Remark:</b> </label>
                                                        <asp:TextBox ID="txtremark" runat="server" class="form-control"></asp:TextBox>
											</div>
                                        <br />
                                           <div class="form-group form-focus">
											 <asp:Button ID="Button2" runat="server" Text="Submit" class=" form-control" BackColor="#01CAE4" ForeColor="White" Width="200" Height="10" OnClick="Button2_Click" />
											</div>
                                    </div>
									
                                   
									<!-- /Checkout Form -->
									
								</div>
							</div>
							
					<div class="submit-section mt-4">
                        <a href="Pdashboard.aspx">
													<i class="fas fa-lock"></i>
													<span>Dashboard</span>
												</a>
<%--                                                    <asp:Label ID="lblId" runat="server" Text='' Visible = "false" />
                                                     <asp:Button ID="b1" runat="server" Text="Back" class=" form-control" BackColor="#01CAE4" ForeColor="White" OnClick="b1_Click"  />--%>

											</div>
         </div>
    	
</asp:Content>

