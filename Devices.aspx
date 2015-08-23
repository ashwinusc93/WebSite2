<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Devices.aspx.cs" Inherits="Devices" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
       
        body{
            background-color:aliceblue;
            text-align:center;
          margin-left:auto;
          margin-right:auto;
          width:40%;

                
        }
       
      
       
    </style>
</head>
<body>
    <form id="form1" runat="server">
   <div>
       
<br />
<br />
<asp:DropDownList ID="ddldevices" runat="server"  OnInit="loading" AutoPostBack="True" 
            onselectedindexchanged="index" Width="200px">
    <asp:ListItem Text="----DEVICES----" Value=""  ></asp:ListItem>
</asp:DropDownList>
       <br />  <br />  <br />
       <asp:TextBox ID="TextBox1" runat="server" Width="200px" ReadOnly="True" ></asp:TextBox>

   </div><br />
<br />
         <div>
    <br />
         <asp:RadioButton ID="RadioButton1" runat="server" Text="LINE GRAPH" GroupName="Software" AutoPostBack="true" OnCheckedChanged="RadioButton_CheckedChanged" />  
         <br />    <br />   <asp:RadioButton ID="RadioButton2" runat="server" Text="BAR GRAPH" GroupName="Software" AutoPostBack="true" OnCheckedChanged="RadioButton_CheckedChanged" />  
    </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
