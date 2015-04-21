using System;
using System.Collections.Generic;
using System.Text;

namespace IDEA
{
    class IdeaCipher
    {
        private string outStr=null;
        private bool flag;
        public IdeaCipher(string str, bool flag,IdeaKey key)
        {
            this.flag = flag;
            if (flag == true)
            {
                int blank = 8 - (Encoding.Unicode.GetBytes(str).Length) % 8;
                if (blank != 8)
                    for (int i = 0; i < blank; i++)
                        str += " ";
                byte[] strByte = Encoding.Unicode.GetBytes(str);
                StringBuilder strbdr = new StringBuilder();
                for (int i = 0; i < strByte.Length; i++)
                    for (int j = 7; j >= 0; j--)
                        strbdr.Append(((strByte[i] >> j) & 1));
                str = strbdr.ToString();

            }
            else
            {
                StringBuilder instrbd = new StringBuilder();
                int inint = 0;
                string instr = null;
                for (int i = 0; i < str.Length; i++)
                {
                    inint = Convert.ToInt32(str.Substring(i, 1), 16);
                    instr = Convert.ToString(inint, 2);
                    while (instr.Length < 4)
                    {
                        instr = 0 + instr;
                    }
                    instrbd.Append(instr);
                }
                str = instrbd.ToString();

            }

            string m1,m2,m3,m4;
            string[] c = new string[15];

            for (int n = 0; n < str.Length / 64; n++)
            {
                m1 = str.Substring(n * 64, 16);
                m2 = str.Substring(n * 64 + 16, 16);
                m3 = str.Substring(n * 64 + 32, 16);
                m4 = str.Substring(n * 64 + 48, 16);
                int pos = 1;
                
                for (int i = 0; i < 8; i++)//8轮的加密变换
                {
                    c[1] = Mul(m1, key.getKey(pos++));
                    c[2] = Add(m2, key.getKey(pos++));
                    c[3] = Add(m3, key.getKey(pos++));
                    c[4] = Mul(m4, key.getKey(pos++));
                    c[5] = Xor(c[1], c[3]);
                    c[6] = Xor(c[2], c[4]);
                    c[7] = Mul(c[5], key.getKey(pos++));
                    c[8] = Add(c[6], c[7]);
                    c[9] = Mul(c[8], key.getKey(pos++));
                    c[10] = Add(c[7], c[9]);
                    c[11] = Xor(c[1], c[9]);
                    c[12] = Xor(c[3], c[9]);
                    c[13] = Xor(c[2], c[10]);
                    c[14] = Xor(c[4], c[10]);
                    m1 = c[11];
                    m2 = c[13];
                    m3 = c[12];
                    m4 = c[14];
                }
                
                c[11] = Mul(m1, key.getKey(pos++));//开始第9轮的变换
                c[12] = Add(m2, key.getKey(pos++));
                c[13] = Add(m3, key.getKey(pos++));
                c[14] = Mul(m4, key.getKey(pos++));

                outStr = outStr + c[11] + c[12] + c[13] + c[14];

            }
            
               

        }

        private string Mul(string str1, string str2)
        {
            long a = Convert.ToInt32(str1, 2);
            long b = Convert.ToInt32(str2, 2);
            if (a == 0)
                a = 65536;
            if (b == 0)
                b = 65536;
            long c = (a * b) % 65537;
            if (c == 65536)
                c = 0;

            StringBuilder str3 = new StringBuilder(Convert.ToString(c, 2));
            int length = str3.Length;
            for (int i = 0; i < 16 - length; i++)
                str3.Insert(0, "0");
            return str3.ToString();

            //下面的是课本方法，可以执行，但我没看懂
            /*long a = Convert.ToInt32(str1, 2);
            long b = Convert.ToInt32(str2, 2);
            long c;
            if (a == 0)
                c = (65537 - b) % 65536;
            else if (b == 0)
                c = (65537 - a) % 65536;
            else
            {
                c = a * b;
                c = ((c & 0xffff) - (c >> 16));
                if (c < 0)
                    c = c + 0x10001;
            }

            StringBuilder str3 = new StringBuilder(Convert.ToString(c, 2));
            int length = str3.Length;
            for (int i = 0; i < 16 - length; i++)
                str3.Insert(0, "0");
            return str3.ToString();*/

        }

        private string Add(string str1, string str2)
        {
            long a = Convert.ToInt32(str1, 2);
            long b = Convert.ToInt32(str2, 2);
            long c = (a + b) % 65536;
            
            StringBuilder str3 = new StringBuilder(Convert.ToString(c, 2));
            int length = str3.Length;
            for (int i = 0; i < 16-length; i++)
                str3.Insert(0, "0");
            return str3.ToString();
        }

        private string Xor(string str1, string str2)
        {
            long a = Convert.ToInt32(str1, 2);
            long b = Convert.ToInt32(str2, 2);
            long c = a ^ b;

            StringBuilder str3 = new StringBuilder(Convert.ToString(c, 2));
            int length = str3.Length;
            for (int i = 0; i < 16-length; i++)
                str3.Insert(0, "0");
            return str3.ToString();
        }

        public string GetOutStr()
        {
            if (this.flag == false)
            {
                byte[] outByte = new byte[outStr.Length / 8];
                for (int i = 0; i < outByte.Length; i++)
                    outByte[i] = Convert.ToByte(outStr.Substring(i * 8, 8), 2);
                outStr = Encoding.Unicode.GetString(outByte);

            }
            else
            {
                StringBuilder outsb = new StringBuilder();
                int temp = 0;
                for (int i = 0;i<outStr.Length-3 ; i += 4)
                {
                    temp = Convert.ToInt32(outStr.Substring(i , 4), 2);
                    outsb.Append(Convert.ToString(temp, 16));
                }
                outStr = outsb.ToString();

            }
            return outStr;
        }

    }
}
