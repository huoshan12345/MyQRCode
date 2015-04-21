using System;
using System.Collections.Generic;
using System.Text;

namespace IDEA
{
    public class Operate
    {
        public static string Encrypt(string Source, string Key)
        {
            if(String.IsNullOrEmpty(Source))
            {
                throw new Exception("没有输入明文！");
            }

            if (Encoding.UTF8.GetBytes(Key).Length != 8)
            {
                throw new Exception("密钥个数必须为8个字符或4个汉字！");
            }

            IdeaKey key = new IdeaKey(Key, true);
            IdeaCipher idea = new IdeaCipher(Source, true, key);
            return idea.GetOutStr();
        }

        public static string Decrypt(string Source, string Key)
        {
            if (String.IsNullOrEmpty(Source))
            {
                throw new Exception("没有输入密文！");
            }
            else if (Source.Length % 16 != 0)
            {
                throw new Exception("密文长度有误！（密文长度须为16的倍数）");
            }

            if (Encoding.Default.GetBytes(Key).Length != 8)
            {
                throw new Exception("密钥个数必须为8个字符或4个汉字！");
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

            IdeaKey key = new IdeaKey(Key, false);
            IdeaCipher idea = new IdeaCipher(Source, false, key);
            return idea.GetOutStr();
        }
    }
}
