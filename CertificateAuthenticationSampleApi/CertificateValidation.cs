using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace CertificateAuthenticationSampleApi
{
    internal class CertificateValidation
    {
        public bool ValidateCertificate(X509Certificate2 clientCertificate)
        {
            string[] allowedThumbprints = {
                "13874323536A3BEFFFA4BB2FE97BFAFB8357240A"
            };
            System.Console.WriteLine(clientCertificate.Thumbprint);
            if (allowedThumbprints.Contains(clientCertificate.Thumbprint))
            {
                return true;
            }
            return false;
        }
    }
}