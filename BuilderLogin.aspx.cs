using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BuilderLogin : System.Web.UI.Page
{

    protected void btnSend_Click(object sender, EventArgs e)
    {
        variables.buildername = bunames.Text.Trim();
        variables.password = buildpass.Text;
        if (variables.password == "1234" && variables.buildername == "Mantri" || variables.password == "12345" && variables.buildername == "Prestige")
        {
           Response.Redirect("customerdetails.aspx");
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Incorrect password, please re-enter');", true);
            return;
        }
    }
}