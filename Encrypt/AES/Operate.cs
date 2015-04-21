using System;
using System.Collections.Generic;
using System.Text;

namespace AES
{
    public class Operate
    {
        private static char[] alphabet = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };

        public static string Encrypt(string Source, string Key, byte KeyLengthChoiced = 16)
        {            
            if (String.IsNullOrEmpty(Source))
            {
                throw new Exception("没有输入明文！");
            }

            int KeyByteLength = Encoding.Default.GetBytes(Key).Length;
            switch (KeyLengthChoiced)
            {
                case 16:
                    {
                        if (KeyByteLength != 16)
                        {
                            throw new Exception("密钥必须为16个字符或8个汉字！");
                        }
                        break;
                    }

                case 24:
                    {
                        if (KeyByteLength != 24)
                        {
                            throw new Exception("密钥必须为24个字符或12个汉字！");
                        }
                        break;
                    }

                case 32:
                    {
                        if (KeyByteLength != 32)
                        {
                            throw new Exception("密钥必须为32个字符或16个汉字！");
                        }
                        break;
                    }
                default:
                    {
                        throw new Exception("所选密钥位数错误，请选择16、24或32位密匙");
                    }
            }

            int[,] key = KeyExpansion.GetKeyExpansion(Key);
            int[,] cipher = Encryption.Getencryption(Source, key);
            StringBuilder strB = new StringBuilder();
            for (int i = 0; i < cipher.GetLength(0); i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    StringBuilder s = new StringBuilder();
                    byte[] buf = new byte[2];
                    s = SubBytes.GetStr(cipher[i, j]);
                    buf[0] = Convert.ToByte(s.ToString(0, 4), 2);
                    buf[1] = Convert.ToByte(s.ToString(4, 4), 2);
                    strB.Append(alphabet[buf[0]] + "" + alphabet[buf[1]]);
                }
            }
            return strB.ToString();
        }

        public static string Decrypt(string Source, string Key, byte KeyLengthChoiced = 16)
        {
            if (String.IsNullOrEmpty(Source))
            {
                throw new Exception("没有输入明文！");
            }

            int KeyByteLength = Encoding.Default.GetBytes(Key).Length;
            switch (KeyLengthChoiced)
            {
                case 16:
                    {
                        if (KeyByteLength != 16)
                        {
                            throw new Exception("密钥个数必须为16个字符或8个汉字！");
                        }
                        break;
                    }

                case 24:
                    {
                        if (KeyByteLength != 24)
                        {
                            throw new Exception("密钥个数必须为24个字符或12个汉字！");
                        }
                        break;
                    }

                case 32:
                    {
                        if (KeyByteLength != 32)
                        {
                            throw new Exception("密钥个数必须为32个字符或16个汉字！");
                        }
                        break;
                    }
                default:
                    {
                        throw new Exception("所选密钥个数错误，请选择16、24或32位密匙");
                    }
            }

            try
            {
                //用于检测，"密文内容有误！（密文内容应为16进制）"
                int temp;
                for (int i = 0; i < Source.Length; i++)
                    temp = Convert.ToInt32(Source[i].ToString(), 16);
            }
            catch 
            {
                throw new Exception("密文内容有误！（密文内容应为16进制）");
            }            

            int[,] key = KeyExpansion.GetKeyExpansion(Key);
            int[,] cipherKey = new int[key.GetLength(0), key.GetLength(1)];
            int[] key1 = new int[key.GetLength(1)];
            for (int i = 0; i < key.GetLength(1); i++)
            {
                cipherKey[0, i] = key[0, i];
                cipherKey[key.GetLength(0) - 1, i] = key[key.GetLength(0) - 1, i];
            }
            for (int i = 1; i < key.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < key.GetLength(1); j++)
                {
                    key1[j] = key[i, j];
                }
                key1 = MixColumn.InvMixColumn(key1);
                for (int j = 0; j < key.GetLength(1); j++)
                {
                    cipherKey[i, j] = key1[j];
                }
            }

            int[,] plain = Decryption.Getdecryption(Source, cipherKey);
            StringBuilder strB = new StringBuilder();
            StringBuilder s = new StringBuilder();
            byte[] result = new byte[plain.GetLength(0) * 16];

            for (int i = 0; i < plain.GetLength(0); i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    for (int h = 7; h >= 0; h--)
                    {
                        s.Append(plain[i, j] >> h & 1);
                    }
                }
            }
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Convert.ToByte(s.ToString(i * 8, 8), 2);
            }
            strB.Append(Encoding.UTF8.GetString(result));
            return strB.ToString();
        }
    }
}
