<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BuilderLogin.aspx.cs" Inherits="BuilderLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Smart City</title>
    <style type="text/css">
        .auto-style1 {
            height: 41px;
            color:blueviolet;
            margin-left:auto;
          margin-right:auto;
          width:40%;
        }
        body{
             background-color:aliceblue;
            text-align:center;
           margin-left:auto;
          margin-right:auto;
          width:40%;
        }
        h1{
            color:#e61818;
            font:100;
            //background-color:aqua;
            font-family:'Tempus Sans ITC';
        }
        .auto-style2 {
            width: 24%;
        }
        .auto-style3 {
            height: 41px;
            color: blueviolet;
            margin-left: auto;
            margin-right: auto;
            width: 24%;
        }
    </style>
</head>
<body   >
    <form id="form1" runat="server">
        <h1>Builder Application</h1>
        <table border="0">
            
            <tr>
                <td class="auto-style3"> Username:
                </td>
                <td>
                    <asp:TextBox ID="bunames" runat="server" Width="300"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required"
                        ControlToValidate="bunames" ForeColor="Red" Enabled="False"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Password:
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="buildpass" runat="server" TextMode="Password" Width="300px"></asp:TextBox>
                </td>
                <td class="auto-style1">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Required"
                        ControlToValidate="buildpass" ForeColor="Red" Enabled="False"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td>
                    <asp:Button ID="sending" runat="server" Text="Login" OnClick="btnSend_Click" BackColor="#3333FF" Height="45px" Width="167px" />
                </td>
                <td></td>
                </tr>
                <tr>
                <td class="auto-style2"></td>
                <td>
                    &nbsp;</td>
                <td></td>
            
            </tr>
        </table>
    </form>
</body>
</html>
