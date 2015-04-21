using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace RSA
{
    class DESManager
    {
        private static readonly byte[] iv = { 59, 76, 55, 186, 78, 4, 217, 32 };
        private static readonly byte[] key = { 155, 101, 246, 179, 46, 96, 56, 39 };
        //DES加密
        public static string DesEncrypt(string Source)
        {
            byte[] bytIn = System.Text.Encoding.Default.GetBytes(Source);
            DESCryptoServiceProvider mobjCryptoService = new DESCryptoServiceProvider();
            mobjCryptoService.Key = key;
            mobjCryptoService.IV = iv;
            ICryptoTransform encrypto = mobjCryptoService.CreateEncryptor();
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);
            cs.Write(bytIn, 0, bytIn.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }

        //DES解密
        public static string DesDecrypt(string Source)
        {
            byte[] bytIn = Convert.FromBase64String(Source);
            DESCryptoServiceProvider mobjCryptoService = new DESCryptoServiceProvider();
            mobjCryptoService.Key = key;
            mobjCryptoService.IV = iv;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(bytIn, 0, bytIn.Length);
            ICryptoTransform encrypto = mobjCryptoService.CreateDecryptor();
            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read);
            StreamReader strd = new StreamReader(cs, Encoding.Default);
            return strd.ReadToEnd();
        }
    }

    //下面开始RSA处理-方法：
    class RSAGenerator
    {
        private RSACryptoServiceProvider RSACSP;
        //构造函数
        public RSAGenerator()
        {
            RSACSP = new RSACryptoServiceProvider();
        }
        public RSAGenerator(CspParameters parameters)
        {
            RSACSP = new RSACryptoServiceProvider(parameters);
        }
        public RSAGenerator(int dwKeySize, CspParameters parameters)
        {
            RSACSP = new RSACryptoServiceProvider(dwKeySize, parameters);
        }

        //获取公钥
        internal string GetPublicKey()
        {
            string publicKey = RSACSP.ToXmlString(false);
            string encryptedPK = DESManager.DesEncrypt(publicKey);
            return encryptedPK;
        }

        //获取私钥
        internal string GetPrivateKey()
        {
            string privateKey = RSACSP.ToXmlString(true);
            return DESManager.DesEncrypt(privateKey);
        }

        public byte[] EncryptToByte(string Source, string PublicKey)
        {
            RSACSP.FromXmlString(DESManager.DesDecrypt(PublicKey));
            return RSACSP.Encrypt(Encoding.UTF8.GetBytes(Source), false);
        }

        public string Encrypt(string Source, string PublicKey)
        {
            RSACSP.FromXmlString(DESManager.DesDecrypt(PublicKey));
            byte[] tempByte = EncryptToByte(Source, PublicKey);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in tempByte)
            {
                sb.Append(b.ToString().PadLeft(3, '0'));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 根据公钥加密字符串
        /// </summary>
        /// <param name="originalString">要加密的字符串</param>
        /// <param name="publicKey">公钥</param>
        /// <returns></returns>
        public string EncryptToBase64String(string Source, string PublicKey)
        {
            RSACSP.FromXmlString(DESManager.DesDecrypt(PublicKey));
            byte[] tempByte = EncryptToByte(Source, PublicKey);
            string result = Convert.ToBase64String(tempByte);
            return result;
        }

        public string Decrypt(string Source, string PrivateKey)
        {
            int ByteNum = Source.Length / 3;
            byte[] tempByte = new byte[ByteNum];
            StringBuilder sb = new StringBuilder();
            try
            {
                for (int i = 0; i < ByteNum; i++)
                {
                    tempByte[i] = Convert.ToByte(Source.Substring(i * 3, 3), 10);
                }
            }
            catch
            {
                throw new Exception("密文内容有误");
            }
            RSACSP.FromXmlString(DESManager.DesDecrypt(PrivateKey));
            string result = Encoding.UTF8.GetString(RSACSP.Decrypt(tempByte, false));
            return result;
        }

        /// <summary>
        /// 根据私钥解密
        /// </summary>
        /// <param name="encriptedString">要解密的字符串</param>
        /// <param name="privateKey">私钥</param>
        /// <returns></returns>
        public string DecryptFromBase64String(string Source, string PrivateKey)
        {
            byte[] tempByte = System.Convert.FromBase64String(Source);
            RSACSP.FromXmlString(DESManager.DesDecrypt(PrivateKey));
            string result = Encoding.UTF8.GetString(RSACSP.Decrypt(tempByte, false));
            return result;
        }

        //如果证书是以文件的形式保存在本地的话，可以用下面的方法加载：
        private static byte[] EncryptDataByCert(byte[] data)
        {
            //实例化一个X509Certificate2对象，并加载证书testCertificate.cer
            X509Certificate2 cert = new X509Certificate2(@"c:\testCertificate.cer");
            //将证书的公钥强制转换成一个RSACryptoServiceProvider对象，
            //然后可以使用这个对象执行加密操作
            RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)cert.PublicKey.Key;
            byte[] enData = rsa.Encrypt(data, false);
            return enData;
        }

        //加载私钥数字证书
        private static byte[] DecryptByCert(byte[] endata)
        {   //实例化一个X509Certificate2对象，并加载证书testCertificate.pfx。
            //由于证书testCertificate.pfx包含私钥，所以需要提供私钥的保护密码（第二个参数）
            X509Certificate2 cert = new X509Certificate2(@"c:\testCertificate.pfx", "123456");
            //将证书testCertificate.pfx的私钥强制转换为一个RSACryptoServiceProvider对象，用于解密操作
            RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)cert.PrivateKey;
            byte[] data = rsa.Decrypt(endata, false);
            return data;
        }

        //访问证书存储区
        private X509Certificate2 GetCertificate(string CertName)
        {  //声明X509Store对象，指定存储区的名称和存储区的类型
            //StoreName中定义了系统默认的一些存储区的逻辑名称
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            //以只读的方式打开这个存储区，OpenFlags定义的打开的方式
            store.Open(OpenFlags.ReadOnly);
            //获取这个存储区中的数字证书的集合
            X509Certificate2Collection certCol = store.Certificates;
            //查找满足证书名称的证书并返回
            foreach (X509Certificate2 cert in certCol)
            {
                if (cert.SubjectName.Name == "CN=" + CertName)
                {
                    store.Close();
                    return cert;
                }
            }
            store.Close();
            return null;
        }
    }
}


