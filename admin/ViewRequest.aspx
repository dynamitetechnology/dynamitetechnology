<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMaster.master" AutoEventWireup="true" CodeFile="ViewRequest.aspx.cs" Inherits="admin_ViewRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    	<h3 class="page-title">Appointment Details</h3>
								<ul class="breadcrumb">
									<li class="breadcrumb-item"><a href="index.html">Dashboard</a></li>
									<li class="breadcrumb-item active">Appointment Details</li>
								</ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     
     
    	
         <div class="col-md-7 col-lg-12">
             <h4>Personal Details</h4>
							<div class="card">
								<div class="card-body">
                                <asp:Label ID="lbl_bill" runat="server" Visible="false"></asp:Label>
                                     <asp:Label ID="lbl_Req" runat="server" Visible="false"></asp:Label>
								<h4> Appointment Request No: WEB# <asp:Label ID="lbl_appoint" runat="server"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Date :<asp:Label ID="lbl_booking_date" runat="server"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Status :<asp:Label ID="lbl_status" runat="server" ForeColor="Red"></asp:Label></h4>
									<!-- Checkout Form -->
                                    <div class="form-row">

                                        	<div class="form-group form-focus col-sm-6">												
                                             <label><b>Patient No  : #PT</b> </label>
                                                        <asp:Label ID="lbl_Id" runat="server"></asp:Label>
											</div>
										
											<div class="form-group form-focus col-sm-6">												
                                          <label><b>Phone : </b></label>
                                                        <asp:Label ID="lbl_phone" runat="server"></asp:Label>
											</div>
                                        </div>
                                     <div class="form-row">
                                        <div class="form-group form-focus col-sm-6">
											      <label><b> Age:</b> </label>
                                                        <asp:Label ID="lbl_age" runat="server"></asp:Label>
											</div>
									
                               
                                        <div class="form-group form-focus col-sm-6">
											  <label><b>Patient Name :</b> </label>
                                                        <asp:Label ID="lbl_Name" runat="server"></asp:Label>
											</div>
                                         </div>
                                         <div class="form-row">
                                        	<div class="form-group form-focus col-sm-6">
											      <label><b> Address:</b> </label>
                                                        <asp:Label ID="lbl_address" runat="server"></asp:Label>
											</div>
                                           <div class="form-group form-focus col-sm-6">
											      <label><b> Gender:</b> </label>
                                                        <asp:Label ID="lbl_gender" runat="server"></asp:Label>
											</div>
                                    </div>
									<div class="form-row">
                                        		<div class="form-group form-focus col-sm-6">
											  <label><b>FatherName  :</b> </label>
                                                        <asp:Label ID="lbl_father" runat="server"></asp:Label>
											</div>
                                    
										 <div class="form-group form-focus col-sm-6">	
                                         <label><b>City :</b> </label>
                                                        <asp:Label ID="lbl_city" runat="server"></asp:Label>
											</div>
                                     </div>
                                    <div class="form-row">
                                        <div class="form-group form-focus col-sm-6">
											      <label><b> BloodGroup:</b> </label>
                                                        <asp:Label ID="lbl_blood" runat="server"></asp:Label>
											</div>
									</div>
                                    </div>
							</div>
             </div>
       
									<hr />
    <h4>Clinical Details</h4>
                                   <div class="col-md-7 col-lg-12">
							<div class="card">
								<div class="card-body">
										
                                        		<div class="form-group form-focus col-sm-12">
											  <label><b>Present Health Problem :</b> </label>
                                                        <asp:Label ID="lbl_problem" runat="server"></asp:Label>
											</div>
                                    
										 <div class="form-group form-focus col-sm-12">	
                                         <label><b>Any Previous Surgery/Hospitalization :</b> </label>
                                                        <asp:Label ID="lbl_surgey" runat="server"></asp:Label>
											</div>
                                     
                                        <div class="form-group form-focus col-sm-12">
											      <label><b> Any Cureent Illness:</b> </label>
                                                        <asp:Label ID="lbl_illness" runat="server"></asp:Label>
											</div>
									
                                    	
                                        		<div class="form-group form-focus col-sm-12">
											  <label><b>Present Treatment :</b> </label>
                                                        <asp:Label ID="lbl_treatment" runat="server"></asp:Label>
											</div>
                                    
										 <div class="form-group form-focus col-sm-12">	
                                         <label><b>Medical Records :</b> </label>
                                                       <asp:Label ID="lblfile" runat="server" Text=""></asp:Label>
											</div>
                                     
                                      <hr />
								
									
									</div>
                                    </div>
							</div>
     <div class="col-md-7 col-lg-12">
         <h4>Add Appointment</h4>
         <div class="card">
								<div class="card-body">
       <div class="row">
                                <div class="col-12">
                                   <%-- <div class="card m-b-30">
                                        <div class="card-body">--%>
            
                                              <div class="form-group row">
                                                <label for="example-text-input" class="col-sm-3 col-form-label">Doctor</label>
                                                <div class="col-sm-9">
                                                    <asp:DropDownList ID="ddldoctor" runat="server" class="form-control">
                                                        <asp:ListItem></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>                             
                                            <div class="form-group row">
                                                <label for="example-email-input" class="col-sm-3 col-form-label">Appointment Date</label>
                                                <div class="col-sm-9">
                                                   <asp:TextBox ID="txtappointdate" runat="server" class="form-control" TextMode="Date"></asp:TextBox>

                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <label for="example-url-input" class="col-sm-3 col-form-label">Appointment Time</label>
                                                <div class="col-sm-9">
                                                  <asp:TextBox ID="txttime" runat="server" class="form-control" TextMode="Time"></asp:TextBox>

                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <label for="example-tel-input" class="col-sm-3 col-form-label">Description</label>
                                                <div class="col-sm-9">
                                                   <asp:TextBox ID="txtdescription" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                        
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <label for="example-password-input" class="col-sm-3 col-form-label">Status</label>
                                                <div class="col-sm-9">
                                                    <asp:DropDownList ID="ddlstatus" runat="server" class="form-control">
                                                        <asp:ListItem Value="Select">Select </asp:ListItem>
                                                         <asp:ListItem Value="Open">Open </asp:ListItem>
                                                        <asp:ListItem Value="Close">Close </asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                          
                                            <div class="col-lg-4">
                                <div class="form-group form-focus">
											 <asp:Button ID="Button2" runat="server" Text="Submit" class="btn btn-primary btn-block btn-lg login-btn" OnClick="btn_save_Click" />
											</div>
                                     </div>
                                      <%--  </div>
                                    </div>--%>
                                    </div>
         </div>
                                </div>
             </div>
         </div>
</asp:Content>

