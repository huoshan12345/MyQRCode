using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RSA
{
    public class Operate
    {
        public static string[] Encrypt(string Source)
        {
            if (String.IsNullOrEmpty(Source))
            {
                throw new Exception("没有输入明文！");
            }

            RSAGenerator rsa = new RSAGenerator();
            string PublicKey = rsa.GetPublicKey();
            string PrivateKey = rsa.GetPrivateKey();
            string Plain = rsa.EncryptToBase64String(Source, PublicKey);
            return new string[] { Plain, PublicKey, PrivateKey };
        }

        public static string[] Encrypt(string Source, CspParameters parameters)
        {
            if (String.IsNullOrEmpty(Source))
            {
                throw new Exception("没有输入明文！");
            }

            RSAGenerator rsa = new RSAGenerator(parameters);
            string PublicKey = rsa.GetPublicKey();
            string PrivateKey = rsa.GetPrivateKey();
            string Plain = rsa.EncryptToBase64String(Source, PublicKey);
            return new string[] { Plain, PublicKey, PrivateKey };
        }

        public static string[] Encrypt(string Source, int dwKeySize, CspParameters parameters)
        {
            if (String.IsNullOrEmpty(Source))
            {
                throw new Exception("没有输入明文！");
            }

            RSAGenerator rsa = new RSAGenerator(dwKeySize, parameters);
            string PublicKey = rsa.GetPublicKey();
            string PrivateKey = rsa.GetPrivateKey();
            string Plain = rsa.EncryptToBase64String(Source, PublicKey);
            return new string[] { Plain, PublicKey, PrivateKey };
        }

        public static string Decrypt(string Source, string PrivateKey)
        {
            if (String.IsNullOrEmpty(Source))
            {
                throw new Exception("没有输入密文！");
            }
            return new RSA.RSAGenerator().Decrypt(Source, PrivateKey);
        }

        public static string Decrypt(string Source, CspParameters parameters)
        {
            if (String.IsNullOrEmpty(Source))
            {
                throw new Exception("没有输入密文！");
            }
            RSAGenerator rsa = new RSAGenerator(parameters);
            string PrivateKey = rsa.GetPrivateKey();
            return rsa.DecryptFromBase64String(Source, PrivateKey);
        }

        public static string Decrypt(string Source, int dwKeySize, CspParameters parameters)
        {
            if (String.IsNullOrEmpty(Source))
            {
                throw new Exception("没有输入密文！");
            }
            RSAGenerator rsa = new RSAGenerator(dwKeySize, parameters);
            string PrivateKey = rsa.GetPrivateKey();
            return rsa.DecryptFromBase64String(Source, PrivateKey);
        }
    }
}
