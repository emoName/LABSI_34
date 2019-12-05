using System;

namespace SI_Lab
{
    class Program
    {
        public static AlgoritmRSA RSA { get; set; } = new AlgoritmRSA();
        public static AlgoritmDES DES { get; set; } = new AlgoritmDES();
        public static AlgoritmDSA DSA { get; set; } = new AlgoritmDSA();
        static void Main(string[] args)
        {
            //var msg = "My secret message SI";
            //var encMsg = "";
            //var decMsg = "";
            //Console.WriteLine($"Original MSG : {msg}");
            Console.WriteLine();

            var text = "";
            while (true)
            {
                Console.Write("Press Option : ");
                text = Console.ReadLine();
                if (text.Equals("0"))
                {
                    break;
                }

                switch (text)
                {
                    case "1":
                        ShowRSAMenu();
                        break;
                    case "2":
                        ShowDESMEnu();
                        break;
                    case "3":
                        ShowDSAMenu();
                        break;
                    default:
                        ShowMenu();
                        break;
                }

            }


            //var RSA = new AlgoritmRSA();
            //encMsg = RSA.RSAEncriptText(msg, RSA.rsaPrivatKey);
            //Console.WriteLine($"RSA Encrypt MSG : {encMsg}");
            //Console.WriteLine();
            //encMsg = Console.ReadLine();
            //decMsg = RSA.RSADecriptText(encMsg, RSA.rsaPrivatKey);
            //Console.WriteLine();
            //Console.WriteLine($"RSA Decrypt MSG : {decMsg}");
            //Console.WriteLine();
            //Console.WriteLine();

            //var DES = new AlgoritmDES();
            //encMsg = DES.EncryptDES(msg);
            //Console.WriteLine($"DES Encrypt MSG : {encMsg}");
            //Console.WriteLine();
            //encMsg = Console.ReadLine();
            //decMsg = DES.DecryptDES(encMsg);
            //Console.WriteLine();
            //Console.WriteLine($"DES Decrypt MSG : {decMsg}");
            //Console.WriteLine();
            //Console.WriteLine();

            //var DSA = new AlgoritmDSA();
            //encMsg = DSA.EncryptData();
            //Console.WriteLine(encMsg);
            //Console.WriteLine();
            //encMsg = Console.ReadLine();
            //Console.WriteLine($"Is message Valide : {DSA.DecryptData(encMsg)}");

        }

        private static void ShowDSAMenu()
        {
            while (true)
            {

                Console.WriteLine();
                Console.WriteLine("Pres key to chose option : ");
                Console.WriteLine(" 1: Sign");
                Console.WriteLine(" 2: Validate");
                Console.WriteLine(" 0: Back");
                Console.Write("Press Option : ");
                var text = Console.ReadLine();
                if (text.Equals("0"))
                {
                    return;
                }
                var msg = "";
                var msgEnc = "";
                switch (text)
                {
                    case "1":
                        Console.Write("Enter original Message : ");
                        msg = Console.ReadLine();
                        DSA.SetHash(msg);
                        Console.WriteLine($"Signature is : {DSA.EncryptData()}");
                        break;
                    case "2":
                        Console.Write("Enter your Message : ");
                        msg = Console.ReadLine();
                        DSA.SetHash(msg);
                        Console.Write("Enter Signature : ");
                        msgEnc = Console.ReadLine();
                        Console.WriteLine($"Is Valid MSG : {DSA.DecryptData(msgEnc)}");
                        break;
                }
            }
        }

        private static void ShowDESMEnu()
        {
            while (true)
            {

                Console.WriteLine();
                Console.WriteLine("Pres key to chose option : ");
                Console.WriteLine(" 1: Encrypt");
                Console.WriteLine(" 2: Decrypt");
                Console.WriteLine(" 0: Back");
                Console.Write("Press Option : ");
                var text = Console.ReadLine();
                if (text.Equals("0"))
                {
                    return;
                }
                switch (text)
                {
                    case "1":
                        Console.Write("Enter original Message : ");
                        var msg = Console.ReadLine();
                        Console.WriteLine($"Encripted MSG : {DES.EncryptDES(msg)}");
                        break;
                    case "2":
                        Console.Write("Enter Encrypt Message : ");
                        var msgEnc = Console.ReadLine();
                        Console.WriteLine($"Decripted MSG : {DES.DecryptDES(msgEnc)}");
                        break;
                }
            }
        }

        private static void ShowRSAMenu()
        {
            while (true)
            {

                Console.WriteLine();
                Console.WriteLine("Pres key to chose option : ");
                Console.WriteLine(" 1: Encrypt");
                Console.WriteLine(" 2: Decrypt");
                Console.WriteLine(" 0: Back");
                Console.Write("Press Option : ");
                var text = Console.ReadLine();
                if (text.Equals("0"))
                {
                    return;
                }
                switch (text)
                {
                    case "1":
                        Console.Write("Enter original Message : ");
                        var msg = Console.ReadLine();
                        Console.WriteLine($"Encripted MSG : {RSA.RSAEncriptText(msg, RSA.rsaPublicKey)}");
                        break;
                    case "2":
                        Console.Write("Enter Encrypt Message : ");
                        var msgEnc = Console.ReadLine();
                        Console.WriteLine($"Decripted MSG : {RSA.RSADecriptText(msgEnc, RSA.rsaPrivatKey)}");
                        break;
                }
            }

        }

        private static void ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Pres key to chose option : ");
            Console.WriteLine(" 1: RSA");
            Console.WriteLine(" 2: DES");
            Console.WriteLine(" 3: DSA");
            Console.WriteLine(" [any]: Menu");
            Console.WriteLine(" 0: EXIT");

        }
    }
}
