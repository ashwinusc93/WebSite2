using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage.Table;

/// <summary>
/// Summary description for CustomerEntity
/// </summary>

    public class CustomerEntity : TableEntity
    {
        public CustomerEntity(string lastName, string firstName)
        {
            this.PartitionKey = lastName;
            this.RowKey = firstName;
        }

        public CustomerEntity() { }

        public string Vender { get; set; }
        public string Time { get; set; }
        public string Type { get; set; }
        public string custname { get; set; }
        public string contactnumber { get; set; }
        public string Value { get; set; }
    }
