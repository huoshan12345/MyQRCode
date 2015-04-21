using System;
using System.Security.Cryptography;

namespace Encryption.RSA
{
    public class Operate
    {
        /// <summary>
        /// RSA加密方法
        /// </summary>
        /// <param name="Source">待加密文本</param>
        /// <returns>返回一个长度为3的数组：｛密文，公钥，私钥｝</returns>
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

        /// <summary>
        /// RSA解密方法
        /// </summary>
        /// <param name="Source">密文</param>
        /// <param name="PrivateKey">私钥</param>
        /// <returns>明文</returns>
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
