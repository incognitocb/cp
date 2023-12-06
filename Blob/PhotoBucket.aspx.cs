using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.Azure;

namespace BlobWebRole
{
    public partial class PhotoBucket : System.Web.UI.Page
    {
        CloudStorageAccount sa;
        CloudBlobClient client;
        CloudBlobContainer container;                                                                             
           CloudBlockBlob blob;
        protected void Page_Load(object sender, EventArgs e)
        {
            sa = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("BlobCS"));
            client = sa.CreateCloudBlobClient();
            container = client.GetContainerReference("photobucket");
            container.CreateIfNotExists();
            container.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            imageGrid.DataSource = container.ListBlobs();
            imageGrid.DataBind();
        }

        protected void cmdUpload_Click(object sender, EventArgs e)
        {
            blob = container.GetBlockBlobReference(imageSelector.FileName);
            blob.UploadFromStream(imageSelector.FileContent);
            Response.Redirect("~/PhotoBucket.aspx");
        }
    }
}
