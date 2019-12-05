using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SI_Lab
{
    class Cryptography
    {
        public int privateKey { get; set; }
        public int publicKey { get; set; }
        public int n { get; set; }
        public int phi { get; set; }

        public void CreateKey()
        {
            int p = 2;
            int q = 7;
            this.n = p * q;
            this.phi = (p - 1) * (q - 1); //n of coprime numbers

            this.publicKey = GeneratePublicKey();
            this.privateKey = GeneratePrivateKey();
        }

        public int gcd(int a, int b)
        {
            // Everything divides 0 
            if (a == 0 || b == 0)
                return 0;

            // base case 
            if (a == b)
                return a;

            // a is greater 
            if (a > b)
                return gcd(a - b, b);

            return gcd(a, b - a);
        }

        public int GeneratePublicKey()
        {
            for (int i = 2; i < this.phi; i++)
            {
                if (coprime(i, this.n) && coprime(i, this.phi))
                {
                    return i;
                }
            }
            return 0;
        }

        private int GeneratePrivateKey()
        {
            var i = new Random().Next(1,1024);
            for (; (this.publicKey * i) % this.phi != 1; i++) { }

            return i;
        }

        public bool coprime(int a, int b)
        {
            var c = gcd(a, b);
            if (c == 1)
                return true;
            else
                return false;
        }

        public List<double> Encript(string msg)
        {
            var ascii = new List<double>();
            foreach (var item in msg)
            {
                ascii.Add(Math.Pow(item, this.publicKey) % this.n);
            }
            return ascii;
        }

        public string Decript(List<double> msg)
        {
            var text = "";
            foreach (var item in msg)
            {
                var a = Math.Pow(item, this.privateKey) % this.n;
                text += (char)a;
            }

            return text;
        }
    }
}
