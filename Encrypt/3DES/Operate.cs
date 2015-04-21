using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace TripleDES
{
    public class Operate
    {
        public static string Encrypt(string Source, string[] Key)
        {
            if (String.IsNullOrEmpty(Source))
            {
                throw new Exception("没有输入明文！");
            }

            if (Key.Length < 3)
            {
                throw new Exception("密匙个数不足（需3个密匙）！");
            }
            else
            {
                int kl1 = Encoding.Default.GetBytes(Key[0]).Length;
                int kl2 = Encoding.Default.GetBytes(Key[1]).Length;
                int kl3 = Encoding.Default.GetBytes(Key[2]).Length;

                if (kl1 != 8 || kl2 != 8 || kl3 != 8)
                {
                    throw new Exception("每个密钥必须均为8个字符或4个汉字！");
                }
            }

            DESKey desKey1 = new DESKey(Key[0]);
            DESKey desKey2 = new DESKey(Key[1]);
            DESKey desKey3 = new DESKey(Key[2]);

            int space = (8 - (Encoding.Unicode.GetBytes(Source)).Length % 8) % 8;
            for (int i = 0; i < space; i++)
                Source = Source + " ";
            byte[] textByte = Encoding.Unicode.GetBytes(Source);

            TripleDESCipher cipher = new TripleDESCipher(null, textByte, desKey1, true);
            TripleDESCipher decipher = new TripleDESCipher(cipher.getOutStr(), null, desKey2, false);
            cipher = new TripleDESCipher(null, decipher.getOutBytes(), desKey3, true);
            return cipher.getOutStr();
        }

        public static string Encrypt(string Source, string Key)
        {
            if (Encoding.Default.GetBytes(Key).Length != 24)
            {
                throw new Exception("密钥须为24个字符或12个汉字！");
            }
            string[] key = { Key.Substring(0, 8), Key.Substring(8, 8), Key.Substring(16, 8) };
            return Encrypt(Source, key);
        }

        public static string Decrypt(string Source, string[] Key)
        {
            if (String.IsNullOrEmpty(Source))
            {
                throw new Exception("没有输入明文！");
            }

            if (Key.Length < 3)
            {
                throw new Exception("密匙个数不足（需3个密匙）！");
            }
            else
            {
                int kl1 = Encoding.Default.GetBytes(Key[0]).Length;
                int kl2 = Encoding.Default.GetBytes(Key[1]).Length;
                int kl3 = Encoding.Default.GetBytes(Key[2]).Length;

                if (kl1 != 8 || kl2 != 8 || kl3 != 8)
                {
                    throw new Exception("每个密钥必须均为8个字符或4个汉字！");
                }
            }
            for (int i = 0; i < Source.Length; i++)
            {
                if ((!Source[i].ToString().Equals("1")) && (!Source[i].ToString().Equals("0")))
                {
                    throw new Exception("密文内容有误！（密文内容仅含有0或1）");
                }
            }

            DESKey desKey1 = new DESKey(Key[0]);
            DESKey desKey2 = new DESKey(Key[1]);
            DESKey desKey3 = new DESKey(Key[2]);

            TripleDESCipher decipher = new TripleDESCipher(Source, null, desKey3, false);
            TripleDESCipher cipher = new TripleDESCipher(null, decipher.getOutBytes(), desKey2, true);
            decipher = new TripleDESCipher(cipher.getOutStr(), null, desKey1, false);
            return Encoding.Unicode.GetString(decipher.getOutBytes());
        }

        public static string Decrypt(string Source, string Key)
        {
            if (Encoding.Default.GetBytes(Key).Length != 24)
            {
                throw new Exception("密钥须为24个字符或12个汉字！");
            }
            string[] key = {Key.Substring(0,8), Key.Substring(8,8),Key.Substring(16,8)};
            return Decrypt(Source, key);
        }
    }
}
