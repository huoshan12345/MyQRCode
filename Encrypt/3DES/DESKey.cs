using System;
using System.Collections.Generic;
using System.Text;

namespace TripleDES
{
    class DESKey
    {
        private  int[] zh1 = {57, 49, 41, 33, 25, 17, 9,
                                1,  58, 50, 42, 34, 26,18,
                               10,  2,  59, 51, 43, 35, 27,
                                19, 11, 3, 60, 52, 44, 36,
                                63, 55, 47, 39, 31, 23, 15,
                                7, 62, 54, 46, 38, 30, 22,
                                14, 6, 61, 53, 45, 37, 29,
                                21, 13, 5, 28, 20, 12, 4};

        private int[] zh2 = {14, 17, 11, 24, 1, 5,
                               3, 28, 15, 6, 21, 10,
                               23, 19, 12, 4, 26, 8,
                               16, 7, 27, 20, 13, 2,
                               41, 52, 31, 37, 47, 55,
                               30, 40, 51, 45, 33, 48,
                               44, 49, 39, 56, 34, 53,
                               46, 42, 50, 36, 29, 32};

        private  int[] N = {1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1};
        private int[][] K = new int[16][];
        private int[] c = new int[28];
        private int[] d = new int[28];
        private int[] cd = new int[56];
        //Encoding ecd;

        public DESKey(String keyStr)
        {
            int[] key64 = new int[64];
            int pos = 0;
            byte[] keyByte = Encoding.Default.GetBytes(keyStr);
            for (int i = 0; i < 8; i++)
            {
                for (int j = 7; j >= 0; j--)
                    key64[pos++] = (keyByte[i] >> j & 1);
            }


            for (int i = 0; i < 28; i++) //生成c0
            {
                c[i] = key64[zh1[i] - 1];
            }

            for (int i = 0; i < 28; i++) //生成d0
            {
                d[i] = key64[zh1[i + 28] - 1];
            }


            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < N[i]; j++)//循环左移
                {
                    loopLeft(c);
                    loopLeft(d);
                }

                K[i] = change2(c, d);//生成Ki

            }
        }

        //循环左移方法
        private int[] loopLeft(int[] num)
        {
            int t = num[0];
            for (int i = 0; i < 27; i++)
            {
                num[i] = num[i + 1];
            }
            num[27] = t;
            return num;
        }

        //置换选择2  生成Ki
        private int[] change2(int[] num1, int[] num2)
        {
            int[] num = new int[48];
            for (int i = 0; i < 28; i++)
            {
                cd[i] = num1[i];
            }
            for (int i = 28; i < 56; i++)
            {
                cd[i] = num2[i - 28];
            }
            for (int i = 0; i < 48; i++)
            {
                num[i] = cd[zh2[i] - 1];
            }
            return num;
        }

        public int[] getK(int i)
        {
            return K[i];
        }
    }
}
