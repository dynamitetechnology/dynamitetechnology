<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMaster.master" AutoEventWireup="true" CodeFile="TimeSchedule.aspx.cs" Inherits="admin_TimeSchedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
       	<nav aria-label="breadcrumb" class="page-breadcrumb">
								<ol class="breadcrumb">
									<li class="breadcrumb-item"><a href="index-2.html">Home</a></li>
									<li class="breadcrumb-item active" aria-current="page">Schedule Timings</li>
								</ol>
							</nav>
							<h2 class="breadcrumb-title">Schedule Timings</h2>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
						 
							<div class="row">
								<div class="col-sm-12">
									<div class="card">
										<div class="card-body">
											<h4 class="card-title">Schedule Timings</h4>
											<div class="profile-box">											    
												<div class="row">
													<div class="col-md-12">
														<div class="card schedule-widget mb-0">
														
														 <div class="row">

        <div class="col-md-12">


            <div class="card m-b-30">
                <asp:Label ID="Label1" runat="server" Font-Size="Medium" ForeColor="#0066FF" Visible="False"></asp:Label>
                <div class="card-body">
                         <div class="form-group" >
                        <label class="col-sm-4 control-label" style="border: solid red 0px; float: left; padding: 10px;">Doctor*:</label>
                        <div class="col-sm-8" style="border: solid red 0px; float: left; padding: 10px;">
                            <asp:DropDownList ID="ddldoctor" runat="server" CssClass="form-control">  
                                 <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                       	<asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" InitialValue="0" runat="server" ErrorMessage="Please Select Day" Display="Dynamic"
										ControlToValidate="ddldoctor">
									</asp:RequiredFieldValidator>
                        </div>
                    </div>
                       <div class="form-group">
                        <label class="col-sm-4 control-label" style="border: solid red 0px; float: left; padding: 10px;">Day*:</label>
                        <div class="col-sm-8" style="border: solid red 0px; float: left; padding: 10px;">
                           <asp:DropDownList ID="ddlday" runat="server" CssClass="form-control"> 
                               <asp:ListItem></asp:ListItem>
                             
                            </asp:DropDownList>
                          	<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" InitialValue="0" runat="server" ErrorMessage="Please Select Day" Display="Dynamic"
										ControlToValidate="ddlday">
									</asp:RequiredFieldValidator>


                        </div>
                    </div>
                         <div class="form-group" >
                        <label class="col-sm-4 control-label" style="border: solid red 0px; float: left; padding: 10px;">Shift Name:</label>
                        <div class="col-sm-8" style="border: solid red 0px; float: left; padding: 10px;">
                            <asp:DropDownList ID="ddlshift" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlshift_Changed">                              
                          <asp:ListItem> </asp:ListItem>
                                </asp:DropDownList> 
                            	<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" InitialValue="0" runat="server" ErrorMessage="Shift Name is required" Display="Dynamic"
										ControlToValidate="ddlshift">
									</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-4 control-label" style="border: solid red 0px; float: left; padding: 10px;">From Time*:</label>
                        <div class="col-sm-8" style="border: solid red 0px; float: left; padding: 10px;">
                         		   <asp:TextBox ID="txtTime" runat="server" CssClass="form-control" ReadOnly />


                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-sm-4 control-label" style="border: solid red 0px; float: left; padding: 10px;">To Time*:</label>
                        <div class="col-sm-8" style="border: solid red 0px; float: left; padding: 10px;">
                      <asp:TextBox ID="txtTime1" runat="server" CssClass="form-control"  ReadOnly />

                        </div>
                    </div>
              
            <div class="form-group">
                        <label class="col-sm-4 control-label" style="border: solid red 0px; float: left; padding: 10px;">Active:</label>

                        <div class="col-sm-8">
                            <asp:RadioButton ID="rdoactive" runat="server" Text="Active" Checked="true" GroupName="db" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rdoinactive" runat="server"  Text="InActive" GroupName="db" />
                        </div>
                    </div>
                
                   
                </div>
                <!-- panel-body -->

            </div>
            <!-- panel-default -->


        </div>
       


        <div class="col-xl-12">
           <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btnSave_Click" ValidationGroup="ps" />
           
        </div>
        <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
        <!-- panel-footer -->
    </div>
    <div style="margin-bottom: 10px; text-align: center;">
        <asp:Label ID="Label2" runat="server" Font-Size="Medium" ForeColor="#0066FF"></asp:Label>
    </div>
															
														</div>
													</div>
												</div>
											</div>
                                            <br />
                                            <hr />
                                            <div class="row">
                               
                                            <div class="table-responsive">
                                               
                       <table style="border: solid red 0px; float: left; width: 100%;" id="myTable">
                                            <asp:Repeater ID="dlRoutDirectory" runat="server">
                                              
                                                <ItemTemplate>                                                  
                                                        <tr>
                                                            <td style="width: 20%;">
                                                                <asp:Label ID="Label3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Doctor_Name")%>'
                                                                    Visible="true"> </asp:Label>
                                                            </td>
                                                             <td style="width: 20%;">
                                                                <asp:Label ID="Day" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Day")%>'
                                                                    Visible="true"> </asp:Label>
                                                            </td>
                                                            <td style="width: 20%;">
                                                                <asp:Label ID="ShiftName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ShiftName")%>'
                                                                    Visible="true"> </asp:Label>
                                                            </td>
                                                            <td style="width: 20%;">
                                                                <asp:Label ID="Fromtime" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "FromTime")%>'
                                                                    Visible="true"> </asp:Label>
                                                            </td>
                                                            <td style="width: 20%;">
                                                                <asp:Label ID="ToTime" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ToTime")%>'
                                                                    Visible="true"> </asp:Label>
                                                            </td>
                                                             
                                                            <td style="width: 20%;">
                                                                <a href="ScheduleTiming.aspx?xyzabc=<%# DataBinder.Eval(Container.DataItem, "SchId")%>">
                                                                    <img width="17px" height="17px" src='../../Images/Edite.png' /></a>
                                                            </td>
                                                            <td style="width: 20%; ">
                                                                <a href="ScheduleTiming.aspx?abcxyz=<%# DataBinder.Eval(Container.DataItem, "SchId")%>"
                                                                    onclick="return confirm('Are you sure you want to delete this record?')">
                                                                    <img width="17px" height="17px" src='../../Images/deletes.png' /></a>
                                                            </td>
                                                        </tr>                                                    
                                                </ItemTemplate>
                                                
                                            </asp:Repeater>
       </table>
            
                                            </div>
                                      
                              
                      
						</div>
										</div>
                                    
                                       
									</div>
								</div>
							</div>
						
</asp:Content>

