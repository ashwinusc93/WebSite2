using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Net;
using System.IO;
using ASPSnippets.SmsAPI;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;

using Limilabs.Mail;
using Limilabs.Client.IMAP;
using Limilabs.Mail.MIME;

using System.IO;
using System.Net.Sockets;
using System.Xml.Serialization;
using System.Xml;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System.Configuration;
using System.Web.UI.HtmlControls;

public partial class CS : System.Web.UI.Page
{
   static string data="";
   string[] arr = new string[10];
    static string eventHubName = "mantri";
    static string connectionString = "Endpoint=sb://sampleehb.servicebus.windows.net/;SharedAccessKeyName=SendRule;SharedAccessKey=xjOuqjkgm43nSANkl5w+9C2KZ3YSQq9/OS1asFG144Y=";
  
   


    protected void btnSend_Click(object sender, EventArgs e)
    {
        SMS.APIType = SMSGateway.Site2SMS;
        SMS.MashapeKey = "pPsD7Kqfn2mshzjqhhbOkQMfGyQgp1TQAf7jsnRTMs6ygiLeUg";
        string text = "";
        //Email starts
        using (Imap imap = new Imap())
        {
            Limilabs.Mail.Log.Enabled = true;
            try
            {
                imap.ConnectSSL("imap.gmail.com", 993);   // or ConnectSSL for SSL

                imap.UseBestLogin("sem8team@gmail.com", "zeesense40");
            }
            catch(Exception E)
            {
                return;
            }

            imap.SelectInbox();

            List<long> uids = imap.Search(Flag.All);



            foreach (long uid in uids)
            {

                var eml = imap.GetMessageByUID(uid);

                IMail email = new MailBuilder()

                    .CreateFromEml(eml);


                 text = email.Text;

                 
            
             
           }

            imap.Close();
        }
           
        //Email ends
            string[] arr=text.Split('~');
            string recvName = "",alert="";
        if(arr[0]=="&")
        {
            recvName = arr[2].ToLower().Trim();
            alert = arr[3];
        }
        else if(arr[0]=="^" || arr[0]=="%")
        {
            recvName = arr[2].ToLower().Trim();
            alert = arr[1];
        }
        //txtyourmoNumber.Text = "9742984490";
        SMS.Username = "9241199520";
        //txtyourPassword.Text = "12345";
        SMS.Password = "12345";
        //string recvName = arr[2].ToLower().Trim();
      //  string alert = arr[3];
        string phone = null;
        string tableName = "builder";
        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);
                CloudTableClient tableClient1 = storageAccount.CreateCloudTableClient();
                CloudTable table1 = null;
                try
                {
                    table1 = tableClient1.GetTableReference(tableName);
                    TableQuery<CustomerEntity> query = new TableQuery<CustomerEntity>().Where(TableQuery.GenerateFilterCondition("customername", QueryComparisons.Equal, recvName.ToLower()));
                    List<CustomerEntity> AddressList = new List<CustomerEntity>();
                    CustomerEntity ce = new CustomerEntity();
                    foreach (CustomerEntity entity in table1.ExecuteQuery(query))
                    {
                        phone = entity.contactnumber;
                        break;
                    }
                    if (phone != null)
                    
                        SMS.SendSms(phone, alert);
                        //SendingRandomMessages(recvName, data).Wait();
                    
                }
               catch(Exception e1)
                {
                 
                }
    }
    static async Task SendingRandomMessages(string cn, string res)
    {
        var eventHubClient = EventHubClient.CreateFromConnectionString(connectionString, eventHubName);

        try
        {
            var message = DateTime.Now.ToString() + "      " + res;
            Console.WriteLine("{0} > Sending message: {1}", DateTime.Now.ToString(), message);
            EventData data = new EventData(Encoding.UTF8.GetBytes(message));
            data.PartitionKey = cn.ToLower();
            await eventHubClient.SendAsync(data);
        }
        catch (Exception exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0} > Exception: {1}", DateTime.Now.ToString(), exception.Message);
            Console.ResetColor();
        }


    }
}