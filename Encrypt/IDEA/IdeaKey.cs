using System;
using System.Collections.Generic;
using System.Text;

namespace IDEA
{
    class IdeaKey
    {
        private int[][] key1 = new int[52][];
        private int[][] key2 = new int[52][];
        private int[] order ={49,50,51,52,47,48,
                               43,44,45,46,41,42,
                               37,38,39,40,35,36,
                               31,32,33,34,29,30,
                               25,26,27,28,23,24,
                               19,20,21,22,17,18,
                               13,14,15,16,11,12,
                                7, 8, 9, 10,5, 6,
                                1, 2, 3, 4};
        private bool flag;

        public IdeaKey(string str, bool flag)
        {
            this.flag = flag;
            byte[] keyByte = Encoding.Unicode.GetBytes(str);


            String keyStr = null;


            for(int i = 0; i < 52; i++)
                key1[i] = new int[16];

            for(int i = 0; i < keyByte.Length; i++)
                for(int j = 7; j >= 0; j--)
                    keyStr += ((keyByte[i] >> j) & 1);


            int pos = 0;
            for(int n = 0; n < 6; n++)
            {
                for(int i = 0; i < 8; i++)
                {
                    for(int j = 0; j < 16; j++)
                    {

                        key1[pos][j] = Convert.ToInt32(Convert.ToString(keyStr[i * 16 + j]));
                    }
                    pos++;
                }

                keyStr = keyStr.Substring(25) + keyStr.Substring(0, 25);
            }

            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 16; j++)
                    key1[pos][j] = Convert.ToInt32(Convert.ToString(keyStr[i * 16 + j]));

                pos++;
            }

            if(this.flag == false)
            {
                for(int i = 0; i < 52; i++)
                {
                    if((i + 1) % 6 == 1 || (i + 1) % 6 == 4)
                        key2[i] = CountKey2Mul(key1[order[i] - 1]);
                    else if((i + 1) % 6 == 2 || (i + 1) % 6 == 3)
                        key2[i] = CountKey2Add(key1[order[i] - 1]);
                    else
                        key2[i] = key1[order[i] - 1];
                }
            }


        }

        private int[] CountKey2Mul(int[] k)
        {
            StringBuilder temp = new StringBuilder(20);
            for(int i = 0; i < 16; i++)
                temp.Append(k[i]);
            long a = Convert.ToInt32(temp.ToString(), 2);

            for(int i = 1; ; i++)
            {
                if((a * i) % 65537 == 1)
                {
                    a = i;
                    break;
                }
            }

            temp.Remove(0, temp.Length);
            temp.Append(Convert.ToString(a, 2));

            int tempLength = 16 - temp.Length;//有点奇怪，直接用 i< temp.Length做为循环条件就会计算错,难道C#中的循环条件每次都计算？

            for(int i = 0; i < tempLength; i++)
                temp.Insert(0, "0");

            for(int i = 0; i < 16; i++)
                k[i] = Convert.ToInt32(temp.ToString(i, 1));
            return k;
        }

        private int[] CountKey2Add(int[] k)
        {
            StringBuilder temp = new StringBuilder(20);
            for(int i = 0; i < 16; i++)
                temp.Append(k[i]);
            int a = 65536 - Convert.ToInt32(temp.ToString(), 2);
            temp.Remove(0, temp.Length);
            temp.Append(Convert.ToString(a, 2));
            int tempLength = 16 - temp.Length;
            for(int i = 0; i < tempLength; i++)
                temp.Insert(0, "0");
            for(int i = 0; i < 16; i++)
                k[i] = Convert.ToInt32(temp.ToString(i, 1));

            return k;
        }

        public string getKey(int n)
        {
            StringBuilder str = new StringBuilder();
            if(this.flag == true)
            {
                for(int i = 0; i < 16; i++)
                    str.Append(key1[n - 1][i]);
                return str.ToString();
            }
            else
            {
                for(int i = 0; i < 16; i++)
                    str.Append(key2[n - 1][i]);
                return str.ToString();
            }
        }

    }
}
