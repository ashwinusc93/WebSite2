<%@ Page Language="C#" AutoEventWireup="true" CodeFile="customerdetails.aspx.cs" Inherits="customerdetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Details</title>
    <style type="text/css">
        .auto-style1 {
            height: 41px;
        color:blueviolet;
        margin-left:inherit;
         margin-right:auto;
         width:24%;
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
            width: 55px;
        }
        .auto-style3 {
            height: 41px;
            color: blueviolet;
            width: 55px;
        }
        .auto-style4 {
            height: 41px;
            color: blueviolet;
            margin-left: auto;
            margin-right: auto;
            width: 70%;
        }
        .auto-style5 {
            width: 61%;
        }
    </style>
</head>
<body   >
    <form id="form1" runat="server">
        <h1>Builder Application</h1>
        <table border="0">
            
            <tr>
                <td class="auto-style4">Project Name:
                </td>
                <td>
                    <asp:DropDownList ID="project" runat="server" Height="40px" style="margin-left: 0px" Width="297px" OnSelectedIndexChanged="project_SelectedIndexChanged">
                    <asp:ListItem Text="----PROJECTS----" Value=""   ></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style2">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required"
                        ControlToValidate="project" ForeColor="Red" Enabled="False"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Location:
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="location" runat="server" Width="300px" BackColor="#CCCCFF" Height="38px" style="margin-left: 0px" ReadOnly="True"></asp:TextBox>
                </td>
                <td class="auto-style3">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Required"
                        ControlToValidate="location" ForeColor="Red" Enabled="False"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td class="auto-style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5"></td>
                <td>
                    <asp:Button ID="sending" runat="server" Text="Get Details" OnClick="btnSend_Click" BackColor="#3333FF" Height="54px" Width="179px" />
                </td>
                <td class="auto-style2"></td>
                </tr>
                <tr>
                <td class="auto-style5"></td>
                <td>
                    &nbsp;</td>
                <td class="auto-style2"></td>
            
            </tr>
        </table>
       
        <asp:GridView ID="GridView1" runat="server" Height="115px" Width="755px">
        
        </asp:GridView>
       
    </form>
</body>
</html>
