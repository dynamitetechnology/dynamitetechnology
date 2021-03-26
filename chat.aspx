<%@ Page Language="C#" AutoEventWireup="true" CodeFile="chat.aspx.cs" Inherits="chat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>


<tr>
<td  style="width:100px; text-align:right;" >
<strong>UserName</strong>:</td>
<td style="width:94px;">
<asp:TextBox ID="txtname" runat="server"></asp:TextBox>
<asp:Button ID="brnadd" runat="server" OnClick="brnadd_Click" Text="ADD" Font-Bold="true" />
<asp:Label ID="lbluname" runat="server" Font-Bold="True" ForeColor="#004000"></asp:Label></td>
</tr>
<tr>
<td style="width: 100px; height: 260px;">
</td>
<td style="width: 94px; height: 260px;">

 <iframe frameborder="0" width="100%" height="300px" src="msg.aspx"></iframe>
</td>
</tr>
<tr>
<td style="width: 100px; height: 77px;">
</td>
<td style="width: 94px; height: 77px;">
<table style="width: 480px;">
<tr>
<td style="width: 100px; height: 50px;">
<asp:TextBox ID="txtsend" runat="server" Height="40px" TextMode="MultiLine" Width="384px"></asp:TextBox></td>
<td style="width: 100px; height: 50px;">
<asp:Button ID="Button1" runat="server" Height="47px" OnClick="Button1_Click" Text="SEND"
Width="72px" Font-Bold="true" /></td>
</tr>
</table>
</td>
</tr>
</table>
        </div>
    </form>
</body>
</html>
