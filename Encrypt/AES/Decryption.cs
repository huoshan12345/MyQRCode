using System;
using System.Collections.Generic;
using System.Text;

namespace AES
{
    class Decryption
    {
        private static char[] alphabet = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };

        public static int[,] Getdecryption(string str, int[,] key)
        {
            int[] cipherkey = new int[16];
            str = str.ToLower();
            char[] ch = str.ToCharArray();

            int[,] cipher = new int[str.Length / 32, 16];
            int[,] plian = new int[str.Length / 32, 16];
            int[] plaintext = new int[16];

            StringBuilder s = new StringBuilder(100000);
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 3; j >= 0; j--)
                {
                    s = s.Append(Decryption.GetNum(ch[i]) >> j & 1);
                }
            }
            for (int i = 0; i < cipher.GetLength(0); i++)
            {
                for (int j = 0; j < 16; j++)
                    cipher[i, j] = Convert.ToInt32(s.ToString(j * 8 + i * 128, 8), 2);
            }

            for (int i = 0; i < cipher.GetLength(0); i++)
            {
                for (int h = 0; h < 16; h++)
                {
                    cipherkey[h] = key[key.GetLength(0) - 1, h];
                    plaintext[h] = cipher[i, h];
                }
                plaintext = AddRoundKey(plaintext, cipherkey);
                for (int j = key.GetLength(0) - 2; j > 0; j--)
                {
                    for (int h = 0; h < 16; h++)
                    {
                        cipherkey[h] = key[j, h];
                    }
                    for (int h = 0; h < plaintext.Length; h++)
                    {
                        plaintext[h] = SubBytes.GetByteSub(plaintext[h]);
                    }
                    plaintext = InvShiftRows(plaintext);
                    plaintext = MixColumn.InvMixColumn(plaintext);
                    plaintext = AddRoundKey(plaintext, cipherkey);
                }
                for (int h = 0; h < 16; h++)
                {
                    cipherkey[h] = key[0, h];
                }
                for (int h = 0; h < plaintext.Length; h++)
                {
                    plaintext[h] = SubBytes.GetByteSub(plaintext[h]);
                }
                plaintext = InvShiftRows(plaintext);
                plaintext = AddRoundKey(plaintext, cipherkey);
                for (int j = 0; j < 16; j++)
                    plian[i, j] = plaintext[j];
            }
            return plian;
        }

        public static int[] AddRoundKey(int[] cipher, int[] key)
        {
            for (int i = 0; i < 16; i++)
            {
                cipher[i] ^= key[i];
            }
            return cipher;
        }

        public static int[] InvShiftRows(int[] cipher)
        {
            int[] cipherX = new int[16];

            for (int i = 0; i < 16; i++)
            {
                if (i % 4 == 0)
                    cipherX[i] = cipher[i];
                if (i % 4 == 1)
                    cipherX[i] = cipher[(i + 12) % 16];
                if (i % 4 == 2)
                    cipherX[i] = cipher[(i + 8) % 16];
                if (i % 4 == 3)
                    cipherX[i] = cipher[(i + 4) % 16];
            }
            return cipherX;
        }

        public static int GetNum(char c)
        {
            int i = 0;
            for (; i < alphabet.Length; i++)
            {
                if (c == alphabet[i])
                {
                    break;
                }
            }
            return i;
        }
    }
}
