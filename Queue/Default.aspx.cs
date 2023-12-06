using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Azure;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace WebRole1
{
    public partial class Default : System.Web.UI.Page
    {
        CloudStorageAccount sa;
        CloudQueueClient client;
        CloudQueue queue;

        protected void Page_Load(object sender, EventArgs e)
        {
            sa = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("QueueCS"));
            client = sa.CreateCloudQueueClient();
            queue = client.GetQueueReference("mailqueue");
            queue.CreateIfNotExists();
        }

        protected void cmdsubmit_click(object sender, EventArgs e)
        {
            CloudQueueMessage msg = new CloudQueueMessage(txtmail.Text + ";" + txtsubject.Text + ";" + txtmailbody.Text);
            queue.AddMessage(msg);
        }
    }
}
