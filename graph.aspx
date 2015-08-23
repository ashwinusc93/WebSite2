<%@ Page Language="C#" AutoEventWireup="true" CodeFile="graph.aspx.cs" Inherits="graph" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    
<body>
    <form id="form1" runat="server">
   
   
    <asp:Chart ID="Chart1" runat="server" Height="500px" Width="1000px">
       
        <Series>
         
            <asp:Series Name="Series1" ChartArea="ChartArea">
              
            </asp:Series>

        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea">
            <Area3DStyle Enable3D="True" />
            </asp:ChartArea>
             
        </ChartAreas>
    </asp:Chart>
        
         
        
        
         
         </form>
</body>
</html>