using Renci.SshNet;

namespace Everstox.Infrastructure
{
    public static class SFTPHandlers
    {
        public static void UploadSFTPXentral(string filename)
        {
            using (SftpClient client = new SftpClient(new PasswordConnectionInfo("34.253.149.210", "qa1_sc_xentral", "xB26aNqp7euUEErG")))
            {
                client.Connect();

                string sourceFile = @"C:\Users\Ivan\.NET Projects\Everstox\Everstox.API.IntegrationTests\Xentral_Orders\" + filename;
                using (Stream stream = File.OpenRead(sourceFile))
                {
                    client.UploadFile(stream, @"/export/" + Path.GetFileName(sourceFile));
                }

                client.Disconnect();

            }
        }

        public static void DownloadSFTPStorelogix(string filename, string shipmentname)
        {
            using (SftpClient client = new SftpClient(new PasswordConnectionInfo("34.253.149.210", "qa1_whc_storelogix", "YJay48TM8Vaqj6Sw")))
            {
                client.Connect();


                string serverFile = @"/import/" + filename;
                string localFile = @"C:\Users\Ivan\.NET Projects\Everstox\Everstox.API.IntegrationTests\Storelogix_Shipments\" + shipmentname;

                using (Stream stream = File.OpenWrite(localFile))
                {
                    client.DownloadFile(serverFile, stream);
                }

                client.Disconnect();

            }
        }
    }
}
