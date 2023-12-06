using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Azure;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;


namespace TableRole
{
    public class ContactEntity : TableEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public ContactEntity() { }
        public ContactEntity(string name, string email, string contactNumber, string contactType)
        {
            Name = name;
            Email = email;
            PartitionKey = contactType;
            RowKey = contactNumber;
        }
    }
    public partial class Default : System.Web.UI.Page
    {
        CloudStorageAccount sa;
        CloudTableClient client;
        CloudTable table;
        protected void Page_Load(object sender, EventArgs e)
        {
            sa = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("TableCS"));
            client = sa.CreateCloudTableClient();
            table = client.GetTableReference("contactbook");
            table.CreateIfNotExists();
            TableQuery<ContactEntity> query = new TableQuery<ContactEntity>();
            ContactGrid.DataSource = table.ExecuteQuery<ContactEntity>(query);
            ContactGrid.DataBind();
        }

        protected void cmdInsert_Click(object sender, EventArgs e)
        {
            string name = txtname.Text;
            string email = txtemail.Text;
            string contactNumber = txtcn.Text;
            string contactType = txtct.Text;
            ContactEntity contact = new ContactEntity(name, email, contactNumber, contactType);
            TableOperation iop = TableOperation.Insert(contact);
            table.Execute(iop);
            Response.Redirect("~/Default.aspx");
        }

        protected void cmdEdit_Click(object sender, EventArgs e)
        {
            TableOperation rop = TableOperation.Retrieve<ContactEntity>(txtedct.Text, txtedcn.Text);
            TableResult result = table.Execute(rop);
            ContactEntity rcontact = (ContactEntity)result.Result;
            rcontact.Name = txtedname.Text;
            rcontact.Email = txtedemail.Text;
            table.Execute(TableOperation.Replace(rcontact));
            Response.Redirect("~/Default.aspx");
        }

        protected void cmdDelete_Click(object sender, EventArgs e)
        {
            TableOperation dop = TableOperation.Retrieve<ContactEntity>(txtedct.Text, txtedcn.Text);
            TableResult result = table.Execute(dop);
            ContactEntity dcontact = (ContactEntity)result.Result;
            table.Execute(TableOperation.Delete(dcontact));
            Response.Redirect("~/Default.aspx");
        }

        protected void ContactGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            tbladdrecord.Visible = false;
            ContactGrid.Visible = false;
            tbleditrecord.Visible = true;
            int index = Int32.Parse(e.CommandArgument.ToString());
            GridViewRow row = ContactGrid.Rows[index];
            txtedname.Text = row.Cells[0].Text;
            txtedemail.Text = row.Cells[1].Text;
            txtedct.Text = row.Cells[2].Text;
            txtedcn.Text = row.Cells[3].Text;
        }
    }
}
