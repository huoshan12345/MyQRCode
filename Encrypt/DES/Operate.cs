using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DES
{
    public class Operate
    {
        private static readonly byte[] iv = { 59, 76, 55, 186, 78, 4, 217, 32 };

        public static string Encrypt(string Source, string Key)
        {
            Source = Source.Trim();
            byte[] key = Encoding.UTF8.GetBytes(Key);
            if (String.IsNullOrEmpty(Source))
            {
                throw new Exception("没有输入明文！");
            }

            if (key.Length != 8)
            {
                throw new Exception("密钥个数必须为8个字符或4个汉字！");
            }

            byte[] bytIn = System.Text.Encoding.Default.GetBytes(Source);
            DESCryptoServiceProvider mobjCryptoService = new DESCryptoServiceProvider();
            mobjCryptoService.Key = key;
            mobjCryptoService.IV = DES.Operate.iv;
            ICryptoTransform encrypto = mobjCryptoService.CreateEncryptor();
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);
            cs.Write(bytIn, 0, bytIn.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }

        public static string Decrypt(string Source, string Key)
        {
            if (String.IsNullOrEmpty(Source))
            {
                throw new Exception("没有输入密文！");
            }

            byte[] key = Encoding.UTF8.GetBytes(Key);
            if (key.Length != 8)
            {
                throw new Exception("密钥个数必须为8个字符或4个汉字！");
            }

            byte[] bytIn = Convert.FromBase64String(Source);
            DESCryptoServiceProvider mobjCryptoService = new DESCryptoServiceProvider();
            mobjCryptoService.Key = key;
            mobjCryptoService.IV = DES.Operate.iv;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(bytIn, 0, bytIn.Length);
            ICryptoTransform encrypto = mobjCryptoService.CreateDecryptor();
            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read);
            StreamReader strd = new StreamReader(cs, Encoding.Default);
            return strd.ReadToEnd();
        }
    }
}
