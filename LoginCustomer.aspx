<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginCustomer.aspx.cs" Inherits="LoginCustomer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Login Page</title>
    <style type="text/css">
       
        body{
            background-color:aliceblue;
            text-align:center;
          margin-left:auto;
          margin-right:auto;
          width:40%;

                
        }
       
        .auto-style1 {
            width: 125px;
            color: blueviolet;
        }
       
        .auto-style2 {
            width: 90px;
        }
       
    </style>
</head>
<body   >
    <form id="form1" runat="server">
        <table border="0">
            
            <tr>
                <td class="auto-style1">Customer name:
                </td>
                <td>
                    <asp:TextBox ID="customer" runat="server"  Width="195px" style="margin-left: 0px"></asp:TextBox>
                </td>
                <td class="auto-style2">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required" ValidationGroup="valid"
                        ControlToValidate="customer" ForeColor="Red" Enabled="False"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td class="auto-style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">ENTER HOUR(0-23):
                </td>
                <td>
                    <asp:TextBox ID="idh" runat="server" TextMode="Number" Width="195px"></asp:TextBox>
                </td>
                <td class="auto-style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1"></td>
                <td>
                    <asp:Button ID="sending" runat="server" Text="GET DETAILS" OnClick="btnSend_Click" ValidationGroup="valid" BackColor="#3333FF" Height="54px" Width="179px" />
                </td>
                <td class="auto-style2"></td>
                </tr>
                <tr>
                <td class="auto-style1"></td>
                <td>
                    &nbsp;</td>
                <td class="auto-style2"></td>
            
            </tr>
        </table>
    </form>
</body>
</html>
