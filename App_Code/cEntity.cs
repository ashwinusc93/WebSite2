using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage.Table;
/// <summary>
/// Summary description for cEntity
/// </summary>
public class cEntity : TableEntity
{
    public cEntity(string customername, string Time)
	{

        this.PartitionKey = customername;
        this.RowKey = Time;
	}
    public cEntity() { }
    public string id { get; set; }
    public string devicefunction { get; set; }
    public string devicename { get; set; }
    public string devicetype { get; set; }
    public string devtabid { get; set; }
    public string ep { get; set; }
    public string vendorname { get; set; }
    public string IEEE { get; set; }
    public string energy1 { get; set; }
    public string energy2 { get; set; }
    public string datetime { get; set; }
}