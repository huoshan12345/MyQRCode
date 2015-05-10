using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

namespace EncodeUtil
{
    public static class QRcodeHelper
    {
        private static readonly Dictionary<string, ImageFormat> imageFormats = new Dictionary<string, ImageFormat>()
        {
            {"jpg", ImageFormat.Jpeg},
            {"jpeg", ImageFormat.Jpeg},
            {"bmp", ImageFormat.Bmp},
            {"gif", ImageFormat.Gif},
            {"png", ImageFormat.Png},
            {"icon", ImageFormat.Icon},
        };

        public struct QRCodeInput
        {
            public string Source;
            public int Height;
            public int Width;
        };

        public static Image Encode(QRCodeInput qrCodeInput)
        {
            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new QrCodeEncodingOptions
                {
                    Margin = 1,
                    DisableECI = true,
                    CharacterSet = "UTF-8",
                    Height = qrCodeInput.Height,
                    Width = qrCodeInput.Width,
                },
            };
            return writer.Write(qrCodeInput.Source);
        }

        public static Image Encode(string source)
        {
            return Encode(new QRCodeInput { Width = 400, Height = 400, Source = source });
        }

        public static void EncodeToFile(QRCodeInput qrCodeInput, string filePath)
        {
            Image image = Encode(qrCodeInput);
            FileInfo fi = new FileInfo(filePath);
            string ext = fi.Extension;
            ImageFormat format;
            if (imageFormats.ContainsKey(ext))
            {
                format = imageFormats[ext];
            }
            else
            {
                format = ImageFormat.Png;
            }
            image.Save(filePath, format);
        }

        public static void EncodeToFile(string source, string filePath)
        {
            EncodeToFile(new QRCodeInput { Width = 400, Height = 400, Source = source }, filePath);
        }

        public static string Decode(Image image)
        {
            var reader = new BarcodeReader
            {
                AutoRotate = true,
                TryInverted = true,
                Options = new DecodingOptions
                {
                    PossibleFormats = new List<BarcodeFormat> { BarcodeFormat.QR_CODE },
                    TryHarder = true,
                }
            };
            using (Bitmap bitmap = new Bitmap(image))
            {
                string result = reader.Decode(bitmap).Text;
                return result;
            }

        }

        public static string Decode(string fileName)
        {
            using (Image image = Image.FromFile(fileName))
            {
                return Decode(image);
            }
        }
    }

    public static class FileOperate
    {
        public static string ReadFile(string filePath, string encoding = "utf-8")
        {
            return ReadFile(filePath, Encoding.GetEncoding(encoding));
        }

        public static string ReadFile(string filePath, Encoding encoding)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs, encoding))
                {
                    string sContext = sr.ReadToEnd();
                    return sContext;
                }
            }
        }

        public static void WriteFile(string filePath, string source, Encoding encoding)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sr = new StreamWriter(fs, encoding))
                {
                    sr.Write(source);
                }
            }
        }

        public static void WriteFile(string filePath, string source, string encoding = "utf-8")
        {
            WriteFile(filePath, source, Encoding.GetEncoding(encoding));
        }

        public static void WriteFile(string filePath, byte[] source)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                fs.Write(source, 0, source.Length);
            }
        }

        /// <summary>
        /// C#读取文件时自动判断编码函数
        /// </summary>
        /// <param name="fileName">需要判断编码方式文件的物理路径</param>
        /// <returns></returns>
        public static Encoding GetEncodingType(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            Encoding r = GetEncodingType(fs);
            fs.Close();
            return r;
        }

        public static Encoding GetEncodingType(FileStream fs)
        {
            /*byte[] Unicode=new byte[]{0xFF,0xFE};  
            byte[] UnicodeBIG=new byte[]{0xFE,0xFF};  
            byte[] UTF8=new byte[]{0xEF,0xBB,0xBF};*/

            BinaryReader r = new BinaryReader(fs, Encoding.Default);
            byte[] ss = r.ReadBytes(4);
            r.Close();
            //编码类型 Coding=编码类型.ASCII;   
            if (ss[0] <= 0xEF)
            {
                if (ss[0] == 0xEF && ss[1] == 0xBB && ss[2] == 0xBF)
                {
                    return Encoding.UTF8;
                }
                else if (ss[0] == 0xFE && ss[1] == 0xFF)
                {
                    return Encoding.BigEndianUnicode; // 也就是大端的UTF-16
                }
                else if (ss[0] == 0xFF && ss[1] == 0xFE)
                {
                    return Encoding.Unicode; // 也就是小端的UTF-16
                }
                else
                {
                    return Encoding.Default;
                }
            }
            else
            {
                return Encoding.Default;
            }
        }

        public static IEnumerable<string> GetFileLine(string filePath, Encoding encoding)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs, encoding))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        yield return line;
                    }
                }
            }
        }

        public static IEnumerable<string> GetFileLine(string filePath, string encoding = "utf-8")
        {
            return GetFileLine(filePath, Encoding.GetEncoding(encoding));
        }
    }
}
