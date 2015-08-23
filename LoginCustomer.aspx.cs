using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;

public partial class LoginCustomer : System.Web.UI.Page
{
    static string cun=null;
    static string pw = null;
    static string hr = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        /*if(Request.QueryString["id"]!=null)
        {
            cun = Request.QueryString["id"];
        }
        customer.Text = cun;*/
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
       cun = customer.Text.ToLower().Trim() ;
     
     
        
       hr = idh.Text.Trim();
        string tableName=cun + hr;
        customer.Text = cun;

        if (Convert.ToInt32(hr) >= 0 && Convert.ToInt32(hr) <= 23)
        {

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
               ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);
            CloudTableClient tableClient1 = storageAccount.CreateCloudTableClient();
            CloudTable table12 = null;
            variables.AddressListnew = new List<cEntity>();
            try
            {


                table12 = tableClient1.GetTableReference(tableName);

                if (!(table12.Exists()))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Table Does not exist');", true);
                    return;
                }

                TableQuery<cEntity> query1 = new TableQuery<cEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.NotEqual, "xyzzzz"));

                foreach (cEntity entity in table12.ExecuteQuery(query1))
                {
                    cEntity ce = new cEntity();
                    ce.PartitionKey = entity.PartitionKey;
                    ce.RowKey = entity.RowKey;
                    ce.id = entity.id;
                    ce.devicefunction = entity.devicefunction;
                    ce.devicename = entity.devicename;
                    ce.devicetype = entity.devicetype;
                    ce.devtabid = entity.devtabid;
                    ce.ep = entity.ep;
                    ce.vendorname = entity.vendorname;
                    ce.IEEE = entity.IEEE;
                    ce.datetime = entity.datetime;
                    ce.energy1 = entity.energy1;
                    ce.energy2 = entity.energy2;
                    variables.AddressListnew.Add(ce);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Table does not exist');", true);
                return;
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Hour input out of range');", true);
            return;
        }
                  cEntity c =  variables.AddressListnew[0];
                  variables.realieee[0] = c.IEEE;
                  variables.realep[0] = c.ep;
                  cEntity cee = new cEntity();
                  int x, y, flag = 0;
                  for (x = 1; x <  variables.AddressListnew.Count; x++)
                  {
                      flag = 0;
                      for (y = 0; y < variables.count; y++)
                      {
                          cee = variables.AddressListnew.ElementAt(x);
                          if (cee.IEEE.Equals(variables.realieee[y]) && cee.ep.Equals(variables.realep[y]))
                          {
                              { flag = 1; break; }
                          }
                      }
                      if (flag == 0)
                      {
                          variables.realieee[variables.count] = cee.IEEE;
                          variables.realep[variables.count] = cee.ep;
                          variables.count++;
                      }
                  }

                  string display = "";
                  for (int i = 0; i < variables.count; i++)
                  {
                      display += variables.realieee[i] + "  " + variables.realep[i] + "\n";

                  }

                  //custPass.Text = display;
                  Server.Transfer("Devices.aspx", true);
                  
              



            
    //      Server.Transfer("Devices.aspx", true);


        

    }
    
}