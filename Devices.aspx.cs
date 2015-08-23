using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Devices : System.Web.UI.Page
{
    
    protected void RadioButton_CheckedChanged(object sender, EventArgs e)
    {
        if (RadioButton1.Checked == true)
        {
            variables.graph = "line";
        }
        else
            variables.graph = "bar";

        Server.Transfer("graph.aspx", true);

    }

   

     protected void loading(object sender, EventArgs e)
     {
         int i1,x,k=0;
         String[] valuenew = new String[10];
         cEntity cee = new cEntity();
         for (int i = 0; i < variables.count; i++)
             for (x = 0; x < variables.AddressListnew.Count; x++)
             {
                 cee = variables.AddressListnew.ElementAt(x);
                 if (variables.realieee[i].Equals(cee.IEEE) && (variables.realep[i].Equals(cee.ep)))
                 {
                     valuenew[k++] = cee.devicename;

                     break;
                 }
             }
      
         for (i1 = 0; i1 < variables.count; i1++)
         {
             ddldevices.Items.Add(new ListItem(valuenew[i1]));
         }


     }

     protected void index(object sender, EventArgs e)
     {
         string val = ddldevices.SelectedItem.Text;
         TextBox1.Text = val;
         variables.deviceName = val;
     }
    
}