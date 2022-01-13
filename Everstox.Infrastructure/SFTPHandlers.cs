using Polly;
using Renci.SshNet;
using System.Diagnostics;

namespace Everstox.Infrastructure
{
    public static class SFTPHandlers
    {
      
        private static ConnectionInfo GetXentralSftpLogin()
        {
            var ip = "34.253.149.210";
            var username = "qa1_sc_xentral";
            var password = "xB26aNqp7euUEErG";

            return new PasswordConnectionInfo(ip, username, password);
        }

        private static ConnectionInfo GetStoreLogixSftpLogin()
        {
            var ip = "34.253.149.210";
            var username = "qa1_whc_storelogix";
            var password = "YJay48TM8Vaqj6Sw";

            return new PasswordConnectionInfo(ip, username, password);
        }      

        public static void UploadSFTPXentral(string fileName)
        {
            using var client = new SftpClient(GetXentralSftpLogin());           
            client.Connect();

            string path = @"..\\..\\..\\Xentral_Orders\\" + fileName + ".xml";

            string sourceFile = path.Replace('\\', Path.PathSeparator);

            using (Stream stream = File.OpenRead(sourceFile))
                 client.UploadFile(stream, @"/export/" + Path.GetFileName(sourceFile));
             
             client.Disconnect();
            
        }

        public static void DownloadSFTPStorelogix(string fileName, string fulfillmentName)
        {
            var retryPolicy = Policy.Handle<Exception>().WaitAndRetry(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                 (timeSpan, retryAttempt) =>
                 {
                     Debug.WriteLine($"{retryAttempt} File not found..." );
                    // Debug.WriteLine(timeSpan);
                 });

            using var client = new SftpClient(GetStoreLogixSftpLogin());
            client.Connect();

            retryPolicy.Execute(() =>
            {               
                string serverFile = @"/import/" + fileName + ".xml";
                string path = @"..\\..\\..\\Storelogix_Fulfillments\\" + fulfillmentName + ".xml";

                string localFile = path.Replace('\\', Path.PathSeparator);

                using (Stream stream = File.OpenWrite(localFile))
                    client.DownloadFile(serverFile, stream);
                
            });

            client.Disconnect();
        }        
    }

}
