<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="CS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Send free SMS in ASP.Net using C# and VB.Net</title>
    <style type="text/css">
        body {
            font-family: Arial;
            font-size: 10pt;
        }
    </style>

   


</head>
<body   >
    <form id="form1" runat="server">
        <table border="0">
            
            <tr>
                <td>Customer name:
                </td>
                <td>
                    <asp:TextBox ID="txtRecieveNumber" runat="server" Width="300"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required"
                        ControlToValidate="txtRecieveNumber" ForeColor="Red" Enabled="False"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Message Body Text:
                </td>
                <td>
                    <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Required"
                        ControlToValidate="txtMessage" ForeColor="Red" Enabled="False"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnSendsms" runat="server" Text="Send" OnLoad="btnSend_Click" />
                </td>
                <td></td>
                </tr>
                <tr>
                <td></td>
                <td>
                    &nbsp;</td>
                <td></td>
            
            </tr>
        </table>
    </form>
</body>
</html>