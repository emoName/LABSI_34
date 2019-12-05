using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SI_Lab
{
    class AlgoritmDSA
    {
        private DSACryptoServiceProvider DSA { get; set; }
        private DSASignatureFormatter DSASignatureFormatter { get; set; }
        private DSASignatureDeformatter DSASignatureDeformatter { get; set; }
        private DSAParameters privateKey { get; set; }
        private DSAParameters publicKey { get; set; }
        private byte[] hash { get; set; }
        private byte[] signedHash { get; set; }
        private SHA1 SHA1 { get; set; }

        public AlgoritmDSA()
        {
            this.DSA = new DSACryptoServiceProvider(1024);
            this.DSASignatureFormatter = new DSASignatureFormatter(this.DSA);
            this.DSASignatureDeformatter = new DSASignatureDeformatter(this.DSA);
            this.privateKey = this.DSA.ExportParameters(true);
            this.publicKey = this.DSA.ExportParameters(false);
            this.SHA1 = SHA1.Create();
            this.hash = this.SHA1.ComputeHash(Encoding.UTF8.GetBytes("my hash code"));
        }

        public void SetHash(string msg)
        {
            this.hash = this.SHA1.ComputeHash(Encoding.UTF8.GetBytes(msg));
        }

        public string EncryptData()
        {
            this.DSASignatureFormatter.SetHashAlgorithm("SHA1");
            this.signedHash = this.DSASignatureFormatter.CreateSignature(this.hash);
            return Convert.ToBase64String(this.signedHash);
        }

        public bool DecryptData(string msg)
        {
            this.signedHash = Convert.FromBase64String(msg);
            this.DSASignatureDeformatter.SetHashAlgorithm("SHA1");
            var signed = this.DSASignatureDeformatter.VerifySignature(this.hash, this.signedHash);
            return signed;
        }
    }
}
