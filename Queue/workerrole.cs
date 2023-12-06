using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure;
using System.Collections;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace WorkerRole1
{
    public class WorkerRole : RoleEntryPoint
    {
        public override void Run()
        {
            CloudStorageAccount sa = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("QueueCS"));
            CloudQueueClient client = sa.CreateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference("mailqueue");
            queue.CreateIfNotExists();
            CloudQueueMessage msg = queue.GetMessage();

            if (msg != null)
            {
                String smsg = msg.AsString;
                String[] details = smsg.Split(';');
                SmtpClient sclient = new SmtpClient();
                sclient.UseDefaultCredentials = false;
                sclient.Host = "smtp.gmail.com";
                sclient.Port = 587;
                sclient.EnableSsl = true;
                MailMessage mmsg = new MailMessage();
                mmsg.From = new MailAddress("testbeccbds@gmail.com");
                mmsg.To.Add(details[0]);
                mmsg.Subject = details[1];
                mmsg.Body = details[2];
                sclient.Credentials = new NetworkCredential("testbeccbds@gmail.com", "legf fslh alcm wqav");
            }
        }

        public override bool OnStart()
        {
            // Use TLS 1.2 for Service Bus connections
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            // Set the maximum number of concurrent connections
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at https://go.microsoft.com/fwlink/?LinkId=166357.

            bool result = base.OnStart();

            Trace.TraceInformation("WorkerRole1 has been started");

            return result;
        }

        public override void OnStop()
        {
            Trace.TraceInformation("WorkerRole1 is stopping");
            base.OnStop();
            Trace.TraceInformation("WorkerRole1 has stopped");
        }

        private async Task RunAsync(CancellationToken cancellationToken)
        {
            // TODO: Replace the following with your own logic.
            while (!cancellationToken.IsCancellationRequested)
            {
                Trace.TraceInformation("Working");
                await Task.Delay(1000);
            }
        }
    }
}
