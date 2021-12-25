using Renci.SshNet;

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
            using (SftpClient client = new SftpClient(GetXentralSftpLogin()))
            {
                client.Connect();

                string sourceFile = @"..\..\..\Xentral_Orders\" + fileName + ".xml";
                using (Stream stream = File.OpenRead(sourceFile))
                {
                    client.UploadFile(stream, @"/export/" + Path.GetFileName(sourceFile));
                }

                client.Disconnect();

            }
        }

        public static void DownloadSFTPStorelogix(string fileName, string fulfillmentName, PasswordConnectionInfo connectionInfo)
        {
            using (SftpClient client = new SftpClient(GetStoreLogixSftpLogin()))
            {
                client.Connect();


                string serverFile = @"/import/" + fileName + ".xml";
                string localFile = @"..\..\..\Storelogix_Fulfillments\" + fulfillmentName + ".xml";

                using (Stream stream = File.OpenWrite(localFile))
                {
                    client.DownloadFile(serverFile, stream);
                }

                client.Disconnect();

            }
        }

        
    }

}
