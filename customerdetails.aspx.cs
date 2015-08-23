using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;
public partial class customerdetails : System.Web.UI.Page
{DataTable dt = new DataTable();
protected void Page_Load(object sender, EventArgs e)
{
    
    DataColumn dc4 = new DataColumn("Builder Name");
    DataColumn dc1 = new DataColumn("Project Name");
    DataColumn dc2 = new DataColumn("Room Number");
    DataColumn dc3 = new DataColumn("Customer Name");

    DataColumn dc5 = new DataColumn("Location");
    DataColumn dc6 = new DataColumn("Contact Number");
    dt.Columns.Add(dc4);
    dt.Columns.Add(dc1);
    dt.Columns.Add(dc2);
    dt.Columns.Add(dc3);
    dt.Columns.Add(dc5);
    dt.Columns.Add(dc6);
    DataRow dr1 = dt.NewRow();
    GridView1.DataSource = dt;
    GridView1.DataBind();

    CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
           ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);
    CloudTableClient tableClient1 = storageAccount.CreateCloudTableClient();
    CloudTable table1 = null;
    try
    {
        table1 = tableClient1.GetTableReference("builder");
        TableQuery<BuilderEntity> Query = new TableQuery<BuilderEntity>().Where(

        TableQuery.GenerateFilterCondition("buildername", QueryComparisons.Equal, variables.buildername));
        List<BuilderEntity> AddressList = new List<BuilderEntity>();
      
        foreach (BuilderEntity entity in table1.ExecuteQuery(Query))
        {
            if(!(project.Items.Contains(new ListItem(entity.PartitionKey))))
            {
                project.Items.Add(new ListItem(entity.PartitionKey));
            }
        }

    }
    catch (Exception e3)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No projects selected...........');", true);
       
    }
}


 protected void project_SelectedIndexChanged(object sender, EventArgs e)
{
    variables.projectname = project.Text.Trim();
    
    CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
           ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);
    CloudTableClient tableClient1 = storageAccount.CreateCloudTableClient();
    CloudTable table1 = null;
    try
    {
        table1 = tableClient1.GetTableReference("builder");
        TableQuery<BuilderEntity> Query = new TableQuery<BuilderEntity>().Where(
                   TableQuery.CombineFilters(
                   TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, variables.projectname),
                   TableOperators.And,
                   TableQuery.GenerateFilterCondition("buildername", QueryComparisons.Equal, variables.buildername)));
                    
        List<BuilderEntity> AddressList = new List<BuilderEntity>();
        //BuilderEntity bd = new BuilderEntity();
        foreach (BuilderEntity entity in table1.ExecuteQuery(Query))
        {
            location.Text=entity.location;
          
        }
       
    }
    catch (Exception e3)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No projects selected...........');", true);

    }
}

 public bool isString(string a)
  {
        char[] b = a.ToCharArray();
        int i,flag = 1;
     for(i = 0;i < b.Length;i++)
     {
         if ((b[i] - 'a' >= 0 && b[i] - 'a' <= 25) || (b[i] - 'A' >= 0 && b[i] - 'Z' <= 25))
             flag = 1;
         else
         {
             flag = 0;
             return false;
         }
         
     }
     return true;
    }

public bool isNonEmpty(string a)
 {
     if (a.Length < 1)
         return false;
     else
         return true;
 }

    protected void btnSend_Click(object sender, EventArgs e)
    {


        variables.projectname = project.Text.Trim();
        variables.locationname = location.Text.Trim();
        if (isNonEmpty(variables.projectname) && isNonEmpty(variables.locationname))
        {
            if ((isString(variables.projectname) && isString(variables.locationname)))
            {

                string tableName = "builder";
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);
                CloudTableClient tableClient1 = storageAccount.CreateCloudTableClient();
                CloudTable table1 = null;
                try
                {
                    table1 = tableClient1.GetTableReference(tableName);
                    TableQuery<BuilderEntity> Query = new TableQuery<BuilderEntity>().Where(
                    TableQuery.CombineFilters(TableQuery.CombineFilters(
                    TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, variables.projectname),
                    TableOperators.And,
                    TableQuery.GenerateFilterCondition("buildername", QueryComparisons.Equal, variables.buildername)), TableOperators.And, TableQuery.GenerateFilterCondition("location", QueryComparisons.Equal, variables.locationname)));
                    List<BuilderEntity> AddressList = new List<BuilderEntity>();
                    //BuilderEntity bd = new BuilderEntity();


                    foreach (BuilderEntity entity in table1.ExecuteQuery(Query))
                    {
                        DataRow dr1 = dt.NewRow();
                        dr1[0] = entity.buildername;
                        dr1[1] = entity.PartitionKey;
                        dr1[2] = entity.RowKey;
                        dr1[3] = entity.customername;

                        dr1[4] = entity.location;
                        dr1[5] = entity.contactnumber;
                        dt.Rows.Add(dr1);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }

                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {

                        HyperLink hlContro = new HyperLink();
                        hlContro.Text = GridView1.Rows[i].Cells[3].Text;

                        GridView1.Rows[i].Cells[3].Controls.Add(hlContro);

                        hlContro.NavigateUrl = "./LoginCustomer.aspx?id=" + hlContro.Text.ToString();
                        //hlContro.ImageUrl = "./sample.jpg";
                        variables.cust = hlContro.Text.ToString();
                    }


                }
                catch (Exception e1)
                {
                    System.Diagnostics.Debug.WriteLine(e1.Message);

                }
            }


            else
            {
                string message = "Enter only text input.";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            }
        }
        else
        {
            string message = "Input cannot be empty";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
    }
}