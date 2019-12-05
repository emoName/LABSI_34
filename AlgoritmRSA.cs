using System;
using System.Security.Cryptography;
using System.Text;

namespace SI_Lab
{
    public class AlgoritmRSA
    {
        private RSACryptoServiceProvider RSA { get; set; }
        public RSAParameters rsaPrivatKey { get; set; }
        public RSAParameters rsaPublicKey { get; set; }
        private string rsaPublicStringKey { get; set; }
        private string rsaPrivateStringKey { get; set; }

        public AlgoritmRSA()
        {
            this.RSA = new RSACryptoServiceProvider(2048);
            this.rsaPublicKey = RSA.ExportParameters(false);
            this.rsaPrivatKey = RSA.ExportParameters(true);
            this.rsaPublicStringKey = GetRSAStringKey(rsaPublicKey);
            this.rsaPrivateStringKey = GetRSAStringKey(rsaPrivatKey);

            //Console.WriteLine($"Private Key: {rsaPrivateStringKey}");
            //Console.WriteLine($"Public Key: {rsaPublicStringKey}");
        }

        public static string GetRSAStringKey(RSAParameters key)
        {
            var sw = new System.IO.StringWriter();
            //we need a serializer
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            //serialize the key into the stream
            xs.Serialize(sw, key);
            //get the string from the stream
            return sw.ToString();
        }

        public static RSAParameters GetRSAParametersKey(string key)
        {
            //get a stream from the string
            var sr = new System.IO.StringReader(key);
            //we need a deserializer
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            //get the object back from the stream
            return (RSAParameters)xs.Deserialize(sr);
        }

        public string RSADecriptText(string msg, RSAParameters key)
        {
            //first, get our bytes back from the base64 string ...
            var bytesCypherText = Convert.FromBase64String(msg);

            //we want to decrypt, therefore we need a csp and load our private key
            var csp = new RSACryptoServiceProvider();
            csp.ImportParameters(key);

            //decrypt and strip pkcs#1.5 padding
            var bytesPlainTextData = csp.Decrypt(bytesCypherText, false);

            //get our original plainText back...
            return Encoding.Unicode.GetString(bytesPlainTextData);
        }

        public string RSAEncriptText(string msg, RSAParameters pubKey)
        {
            var csp = new RSACryptoServiceProvider();
            csp.ImportParameters(pubKey);
            var bytesPlainTextData = Encoding.Unicode.GetBytes(msg);

            //apply pkcs#1.5 padding and encrypt our data 
            var bytesCypherText = csp.Encrypt(bytesPlainTextData, false);
            return Convert.ToBase64String(bytesCypherText);
        }

    }
}
