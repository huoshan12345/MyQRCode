using System.Drawing;
using System.Text;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace Encryption
{
    public static class Operate
    {
        public static class CompressionHelper
        {
            public static class BinToHex
            {
                public static string Compress(string Source)
                {
                    for (int i = 0; i < Source.Length; i++)
                    {
                        if ((!Source[i].ToString().Equals("1")) && (!Source[i].ToString().Equals("0")))
                        {
                            throw new Exception("内容有误！（内容仅含有0或1）");
                        }
                    }

                    int rest = Source.Length % 8;
                    if (rest != 0)
                    {
                        StringBuilder SB = new StringBuilder();
                        for (int i = 0; i < rest; i++)
                        {
                            SB.Append('0');
                        }
                        Source = SB.ToString() + Source;
                    }

                    int ByteNum = Source.Length / 8;
                    StringBuilder newStr = new StringBuilder();
                    byte[] bStr = new byte[ByteNum];
                    for (int i = 0; i < ByteNum; i++)
                    {
                        bStr[i] = Convert.ToByte(Source.Substring(i * 8, 8), 2);
                        newStr.Append(bStr[i].ToString("x2"));
                    }
                    return newStr.ToString();
                }

                public static string Decompress(string Source)
                {
                    try
                    {
                        //用于检测，"密文内容有误！（密文内容应为16进制）"
                        byte temp;
                        for (int i = 0; i < Source.Length; i++)
                            temp = Convert.ToByte(Source[i].ToString(), 16);
                    }
                    catch
                    {
                        throw new Exception("密文内容有误！（密文内容应为16进制）");
                    }

                    int rest = Source.Length % 2;
                    if (rest != 0)
                    {
                        Source = '0' + Source;
                    }

                    int ByteNum = Source.Length / 2;
                    byte[] bStr = new byte[ByteNum];
                    StringBuilder newStr = new StringBuilder();

                    for (int i = 0; i < ByteNum; i++)
                    {
                        bStr[i] = byte.Parse(Source.Substring(i * 2, 2), NumberStyles.HexNumber);
                        newStr.Append(Convert.ToString(bStr[i], 2).PadLeft(8, '0'));
                    }
                    return newStr.ToString();
                }
            }

            public static class BinToBase64
            {
                public static string Compress(byte[] Source)
                {
                    return Convert.ToBase64String(Source);
                }

                public static string Compress(string Source)
                {
                    for (int i = 0; i < Source.Length; i++)
                    {
                        if ((!Source[i].ToString().Equals("1")) && (!Source[i].ToString().Equals("0")))
                        {
                            throw new Exception("内容有误！（内容仅含有0或1）");
                        }
                    }

                    int rest = Source.Length % 8;
                    if (rest != 0)
                    {
                        StringBuilder SB = new StringBuilder();
                        for (int i = 0; i < rest; i++)
                        {
                            SB.Append('0');
                        }
                        Source = SB.ToString() + Source;
                    }

                    int ByteNum = Source.Length / 8;
                    StringBuilder newStr = new StringBuilder();
                    byte[] bStr = new byte[ByteNum];
                    for (int i = 0; i < ByteNum; i++)
                    {
                        bStr[i] = Convert.ToByte(Source.Substring(i * 8, 8), 2);                        
                    }
                    return Convert.ToBase64String(bStr);
                }

                public static string Decompress(string Source)
                {
                    byte[] Base64Byte;
                    try
                    {
                        Base64Byte = Convert.FromBase64String(Source);
                    }
                    catch
                    {
                        throw new Exception("密文内容有误！（密文内容应为Base64字符串）");
                    }
                    StringBuilder newStr = new StringBuilder();
                    for (int i = 0; i < Base64Byte.Length; i++)
                    {
                        newStr.Append(Convert.ToString(Base64Byte[i], 2).PadLeft(8, '0'));
                    }
                    return newStr.ToString();
                }
            }

            public static class ZipHelper
            {
                /// <summary>
                /// 将传入字符串以GZip算法压缩后，返回Base64编码字符
                /// </summary>
                /// <param name="rawString">需要压缩的字符串</param>
                /// <returns>压缩后的Base64编码的字符串</returns>
                public static string Compress(string rawString)
                {
                    if (string.IsNullOrEmpty(rawString) || rawString.Length == 0)
                    {
                        return "";
                    }
                    else
                    {
                        byte[] rawData = System.Text.Encoding.UTF8.GetBytes(rawString.ToString());
                        byte[] zippedData = Compress(rawData);
                        return Convert.ToBase64String(zippedData);
                    }

                }
                /// <summary>
                /// GZip压缩
                /// </summary>
                /// <param name="rawData"></param>
                /// <returns></returns>
                public static byte[] Compress(byte[] rawData)
                {
                    MemoryStream ms = new MemoryStream();
                    GZipStream compressedzipStream = new GZipStream(ms, CompressionMode.Compress, true);
                    compressedzipStream.Write(rawData, 0, rawData.Length);
                    compressedzipStream.Close();
                    return ms.ToArray();
                }
                /// <summary>
                /// 将传入的二进制字符串资料以GZip算法解压缩
                /// </summary>
                /// <param name="zippedString">经GZip压缩后的二进制字符串</param>
                /// <returns>原始未压缩字符串</returns>
                public static string Decompress(string zippedString)
                {
                    if (string.IsNullOrEmpty(zippedString) || zippedString.Length == 0)
                    {
                        return "";
                    }
                    else
                    {
                        byte[] zippedData = Convert.FromBase64String(zippedString.ToString());
                        return (string)(System.Text.Encoding.UTF8.GetString(Decompress(zippedData)));
                    }
                }
                /// <summary>
                /// ZIP解压
                /// </summary>
                /// <param name="zippedData"></param>
                /// <returns></returns>
                public static byte[] Decompress(byte[] zippedData)
                {
                    MemoryStream ms = new MemoryStream(zippedData);
                    GZipStream compressedzipStream = new GZipStream(ms, CompressionMode.Decompress);
                    MemoryStream outBuffer = new MemoryStream();
                    byte[] block = new byte[1024];
                    while (true)
                    {
                        int bytesRead = compressedzipStream.Read(block, 0, block.Length);
                        if (bytesRead <= 0)
                            break;
                        else
                            outBuffer.Write(block, 0, bytesRead);
                    }
                    compressedzipStream.Close();
                    return outBuffer.ToArray();
                }
            }
        }

        public static class ReadWriteFile
        {
            public static void String2File(string data, string fileName)
            {
                Byte2File(Encoding.UTF8.GetBytes(data), fileName);
            }

            public static void Byte2File(byte[] data, string fileName)
            {
                FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                fs.Write(data, 0, data.Length);
                fs.Close();
            }

            public static byte[] File2Byte(string fileName)
            {
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                byte[] data = new byte[fs.Length];
                fs.Read(data, 0, (int)fs.Length);
                fs.Close();
                return data;
            }

            public static string File2String(string fileName)
            {
                return Encoding.UTF8.GetString(File2Byte(fileName));
            }

        }
    }
}
