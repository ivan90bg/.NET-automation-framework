using Renci.SshNet;

namespace Everstox.Infrastructure
{
    public static class SFTPHandlers
    {
        static PasswordConnectionInfo qa1_Storelogix_login = new PasswordConnectionInfo("34.253.149.210", "qa1_whc_storelogix", "YJay48TM8Vaqj6Sw");
        static PasswordConnectionInfo qa1_Xentral_login = new PasswordConnectionInfo("34.253.149.210", "qa1_sc_xentral", "xB26aNqp7euUEErG");

        public static void UploadSFTPXentral(string filename)
        {
            using (SftpClient client = new SftpClient(qa1_Xentral_login))
            {
                client.Connect();

                string sourceFile = @"..\..\..\Xentral_Orders\" + filename + ".xml";
                using (Stream stream = File.OpenRead(sourceFile))
                {
                    client.UploadFile(stream, @"/export/" + Path.GetFileName(sourceFile));
                }

                client.Disconnect();

            }
        }

        public static void DownloadSFTPStorelogix(string filename, string fulfillmentname)
        {
            using (SftpClient client = new SftpClient(qa1_Storelogix_login))
            {
                client.Connect();


                string serverFile = @"/import/" + filename + ".xml";
                string localFile = @"..\..\..\Storelogix_Fulfillments\" + fulfillmentname + ".xml";

                using (Stream stream = File.OpenWrite(localFile))
                {
                    client.DownloadFile(serverFile, stream);
                }

                client.Disconnect();

            }
        }
    }

     
}
