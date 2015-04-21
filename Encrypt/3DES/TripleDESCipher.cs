using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TripleDES
{
    class TripleDESCipher
    {
        private int[,] SBox ={{14,4,13,1,2,15,11,8,3,10,6,12,5,9,0,7},//S1
                                {0,15,7,4,14,2,13,1,10,6,12,11,9,5,3,8},
                                {4,1,14,8,13,6,2,11,15,12,9,7,3,10,5,0},
                                {15,12,8,2,4,9,1,7,5,11,3,14,10,0,6,13},
                                        
                                {15,1,8,14,6,11,3,4,9,7,2,13,12,0,5,10},//s2
                                {3,13,4,7,15,2,8,14,12,0,1,10,6,9,11,5},
                                {0,14,7,11,10,4,13,1,5,8,12,6,9,3,2,15},
                                {13,8,10,1,3,15,4,2,11,6,7,12,0,5,14,9},
                                                       
                                {10,0,9,14,6,3,15,5,1,13,12,7,11,4,2,8},//s3
                                {13,7,0,9,3,4,6,10,2,8,5,14,12,11,15,1},
                                {13,6,4,9,8,15,3,0,11,1,2,12,5,10,14,7},
                                {1,10,13,0,6,9,8,7,4,15,14,3,11,5,2,12},
                                                       
                                {7,13,14,3,0,6,9,10,1,2,8,5,11,12,4,15},//s4
                                {13,8,11,5,6,15,0,3,4,7,2,12,1,10,14,9},
                                {10,6,9,0,12,11,7,13,15,1,3,14,5,2,8,4},
                                {3,15,0,6,10,1,13,8,9,4,5,11,12,7,2,14},
                                                       
                                {2,12,4,1,7,10,11,6,8,5,3,15,13,0,14,9},//s5
                                {14,11,2,12,4,7,13,1,5,0,15,10,3,9,8,6},
                                {4,2,1,11,10,13,7,8,15,9,12,5,6,3,0,14},
                                {11,8,12,7,1,14,2,13,6,15,0,9,10,4,5,3},
                                                       
                                {12,1,10,15,9,2,6,8,0,13,3,4,14,7,5,11},//s6
                                {10,15,4,2,7,12,9,5,6,1,13,14,0,11,3,8},
                                {9,14,15,5,2,8,12,3,7,0,4,10,1,13,11,6},
                                {4,3,2,12,9,5,15,10,11,14,1,7,6,0,8,13},

                                {4,11,2,14,15,0,8,13,3,12,9,7,5,10,6,1},//s7
                                {13,0,11,7,4,9,1,10,14,3,5,12,2,15,8,6},
                                {1,4,11,13,12,3,7,14,10,15,6,8,0,5,9,2},
                                {6,11,13,8,1,4,10,7,9,5,0,15,14,2,3,12},

                                {13,2,8,4,6,15,11,1,10,9,3,14,5,0,12,7},//s8
                                {1,15,13,8,10,3,7,4,12,5,6,11,0,14,9,2},
                                {7,11,4,1,9,12,14,2,0,6,10,13,15,3,5,8},
                                {2,1,14,7,4,10,8,13,15,12,9,0,3,5,6,11}};


        private int[] IP ={58, 50, 42, 34, 26, 18, 10, 2,
                            60, 52, 44, 36, 28, 20, 12, 4,
                            62, 54, 46, 38, 30, 22, 14, 6,
	                        64, 56, 48, 40, 32, 24, 16, 8,
	                        57, 49, 41, 33, 25, 17,  9,  1,
	                        59, 51, 43, 35, 27, 19, 11, 3,
	                        61, 53, 45, 37, 29, 21, 13, 5,
	                        63, 55, 47, 39, 31, 23, 15, 7};
        private int[] E ={32,  1,  2,  3,  4,  5,
                            4,   5,  6,  7,  8,  9,
                            8,   9, 10, 11, 12, 13,
                           12, 13, 14, 15, 16, 17,
                            16, 17, 18, 19, 20, 21,
                            20, 21, 22, 23, 24, 25,
                            24, 25, 26, 27, 28, 29,
                            28, 29, 30, 31, 32,  1};
        private int[] P ={16,  7, 20, 21,
                           29, 12, 28, 17,
                            1, 15, 23, 26,
                            5, 18, 31, 10,
                            2,  8, 24, 14,
                            32, 27,  3, 9,
                            19, 13, 30, 6,
                            22, 11,  4, 25};
        private int[] IP_1 ={40,8,48,16,56,24,64,32,
                              39,7,47,15,55,23,63,31,
                              38,6,46,14,54,22,62,30,
                              37,5,45,13,53,21,61,29,
                              36,4,44,12,52,20,60,28,
                              35,3,43,11,51,19,59,27,
                              34,2,42,10,50,18,58,26,
                              33,1,41, 9,49,17,57,25};
        private StringBuilder outStr = new StringBuilder(5000);

        private int[] l = new int[32];
        private int[] r = new int[32];
        private int seq = 0;
        private byte[] outBytes;

        //Encoding ecd;



        public TripleDESCipher(String textStr, byte[] textByte, DESKey desKey, bool flag)//加密&解密构造器
        {
            if(flag == true)//加密
            {
                doCipher(textByte, desKey);
            }
            else//解密
            {
                textByte = new byte[textStr.Length / 8];
                int[] textInt = new int[textStr.Length / 8];
                char[] textChar = new char[textStr.Length / 8];
                for(int i = 0; i < textByte.Length; i++)
                {
                    textInt[i] = Convert.ToInt32(textStr.Substring(i * 8, 8), 2);
                    textByte[i] = (byte)textInt[i];
                }
                seq = 15;
                doCipher(textByte, desKey);

                for(int i = 0; i < textInt.Length; i++)
                {
                    textInt[i] = Convert.ToInt32(outStr.ToString().Substring(i * 8, 8), 2);
                    textByte[i] = (byte)textInt[i];
                }
                outBytes = textByte;
                outStr.Remove(0, outStr.Length);
                outStr.Append(Encoding.Unicode.GetString(textByte));



            }
        }


        private void doCipher(byte[] textByte, DESKey desKey)
        {
            int loop = 0;
            int pos = 0;


            while(loop < textByte.Length / 8)
            {
                int[] text64 = new int[64];
                int[] lr = new int[64];
                int n = 0;
                for(int i = pos; i < pos + 8; i++)
                {
                    for(int j = 7; j >= 0; j--)
                        text64[n++] = (textByte[i] >> j & 1);
                }
                for(int i = 0; i < 32; i++)//生成l0
                    l[i] = text64[IP[i] - 1];
                for(int i = 0; i < 32; i++)
                    r[i] = text64[IP[i + 32] - 1];//生成r0

                dolr(desKey);//得到16次加密之后最终的l和r

                for(int i = 0; i < 32; i++)
                    lr[i] = r[i];
                for(int i = 0; i < 32; i++)
                    lr[i + 32] = l[i];
                for(int i = 0; i < 64; i++)
                {
                    text64[i] = lr[IP_1[i] - 1];
                    outStr.Append(text64[i]);
                }

                pos += 8;
                loop++;
            }

        }


        private void dolr(DESKey desKey)
        {
            int[] r48 = new int[48];
            int[] K;
            int[] r32 = this.r;

            for(int i = 0; i < 16; i++)
            {
                K = desKey.getK(Math.Abs(i - seq));
                for(int j = 0; j < 48; j++)
                {
                    r48[j] = (r32[E[j] - 1] + K[j]) % 2;
                }

                r32 = doSBox(r48);//进盒子
                for(int j = 0; j < 32; j++)
                    r32[j] = (r32[j] + this.l[j]) % 2;
                this.l = this.r;
                this.r = r32;

            }
        }

        private int[] doSBox(int[] num48)
        {
            int[] num = new int[32];
            int[] num32 = new int[32];

            String strX = "";
            String strY = "";
            int pos = 0;
            int x = 0;
            int y = 0;
            StringBuilder str32 = new StringBuilder(50);
            int zero = 0;
            for(int i = 0; i < 8; i++)//48个字符，一次进来6个，一共进来8次
            {
                strX = "";
                strY = "";
                strX = (strX + num48[pos] + num48[pos + 5]).Trim();

                for(int j = pos + 1; j <= pos + 4; j++)
                    strY = strY + num48[j];

                x = Convert.ToInt32(strX, 2) + i * 4;
                y = Convert.ToInt32(strY, 2);

                zero = 4 - Convert.ToString(SBox[x, y], 2).Length;
                for(int j = 0; j < zero; j++)
                    str32.Append(0);
                str32.Append(Convert.ToString(SBox[x, y], 2));

                pos += 6;

            }

            for(int i = 0; i < 32; i++)
            {
                num[i] = Convert.ToInt32(str32.ToString().Substring(i, 1), 10);
            }
            for(int i = 0; i < 32; i++)//P置换
                num32[i] = num[P[i] - 1];

            return num32;

        }

        public String getOutStr()
        {
            return outStr.ToString();
        }

        public byte[] getOutBytes()
        {
            return outBytes;
        }

    }
}
