using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
public partial class graph : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (variables.graph.Equals("line"))
            linedraw();
        else
            barDraw();
    }
    protected void barDraw()
    {
            //     double[] yvalues= {10, 20.65 ,30,45.75,85.5,94.5,25.2} ;
        //    string[] xvalues = { "Computer Science", "Information Technology", "Mechanical", "Electronics", "EEE", "CIVIL", "TC" };

        cEntity cee = new cEntity(); int keeee = 0;
        string[] dat = new string[30];
        double[] ene = new double[30];
        for (int i = 0; i < variables.AddressListnew.Count; i++)
        {
            cee = variables.AddressListnew.ElementAt(i);
            if (cee.devicename.Equals(variables.deviceName))
            {
                dat[keeee] = cee.datetime;
                ene[keeee++] = Math.Abs(Convert.ToInt32(Convert.ToDouble(cee.energy2)) - (Convert.ToInt32(Convert.ToDouble(cee.energy1))));
            }
        }
        double[] yvalues = new double[keeee];
        string[] xvalues = new string[keeee];
        for (int k = 0; k < keeee; k++)
        {
            xvalues[k] = dat[k];
            yvalues[k] = ene[k];
        }

        Chart1.Series["Series1"].Points.DataBindXY(xvalues, yvalues);
        Chart1.Series["Series1"].Color = System.Drawing.Color.Green;
        Chart1.Series["Series1"].BorderColor = System.Drawing.Color.Yellow;
        //     Chart1.Series["Series1"].ChartType = SeriesChartType.Line;
        Chart1.Series["Series1"].IsValueShownAsLabel = true;
    }
    protected void linedraw()
    {
        Chart1.ChartAreas["ChartArea"].Area3DStyle.Enable3D = false;
        //    double[] yvalues = { 10, 20.65, 30, 45.75, 85.5, 94.5, 25.2 };
        //   string[] xvalues = { "Computer Science", "Information Technology", "Mechanical", "Electronics", "EEE", "CIVIL", "TC" };

        cEntity cee = new cEntity(); int keeee = 0;
        string[] dat = new string[30];
        double[] ene = new double[30];
        for (int i = 0; i < variables.AddressListnew.Count; i++)
        {
            cee = variables.AddressListnew.ElementAt(i);
            if (cee.devicename.Equals(variables.deviceName))
            {
                dat[keeee] = cee.datetime;
                ene[keeee++] = Math.Abs(Convert.ToInt32(Convert.ToDouble(cee.energy2)) - (Convert.ToInt32(Convert.ToDouble(cee.energy1))));
            }
        }
        double[] yvalues = new double[keeee];
        string[] xvalues = new string[keeee];
        for (int k = 0; k < keeee; k++)
        {
            xvalues[k] = dat[k];
            yvalues[k] = ene[k];
        }
        Chart1.Series["Series1"].Points.DataBindXY(xvalues, yvalues);
        Chart1.Series["Series1"].Color = System.Drawing.Color.Green;
        Chart1.Series["Series1"].BorderColor = System.Drawing.Color.Yellow;
        Chart1.Series["Series1"].ChartType = SeriesChartType.Line;
        Chart1.Series["Series1"].IsValueShownAsLabel = true;
    }
}