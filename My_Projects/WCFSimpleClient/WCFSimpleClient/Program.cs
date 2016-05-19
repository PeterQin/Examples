using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net;

namespace WCFSimpleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                HelloClient client = new HelloClient("NetPipeBinding_IHello");
                //Util.SetCertificatePolicy();
                Console.WriteLine(client.SayHello());
                Console.Read();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
            }
        }
    }

    public static class Util
    {
        /// <summary>
        /// Sets the cert policy.
        /// </summary>
        public static void SetCertificatePolicy()
        {
            ServicePointManager.ServerCertificateValidationCallback
                       += RemoteCertificateValidate;
        }

        /// <summary>
        /// Remotes the certificate validate.
        /// </summary>
        private static bool RemoteCertificateValidate(
           object sender, X509Certificate cert,
            X509Chain chain, SslPolicyErrors error)
        {
            // trust any certificate!!!
            System.Console.WriteLine("Warning, trust any certificate");
            return true;
        }
    }

}
