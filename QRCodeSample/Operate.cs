using System.Drawing;
using System.Text;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using Encryption;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.Rendering;

namespace QRCodeSample
{
    public static class Operate
    {
        /// <summary>
        /// 编辑距离：莱文斯坦距离 Damerau-Levenshtein Distance
        /// </summary>
        public static class EditDistanceHelper
        {
            public struct Result
            {
                public int distance;
                public double similarity;
            }

            /// <summary>
            /// 莱文斯坦距离（Levenshtein Distance）
            /// </summary>
            /// <param name="source">源串</param>
            /// <param name="target">目标串</param>
            /// <param name="isCaseSensitive">是否大小写敏感</param>
            /// <returns>源串和目标串之间的编辑距离</returns>
            /// <remarks>http://en.wikipedia.org/wiki/Levenshtein_distance</remarks>
            public static Result LevenshteinDistance(String source, String target, Boolean isCaseSensitive = false)
            {
                if (String.IsNullOrEmpty(source))
                {
                    if (String.IsNullOrEmpty(target))
                    {
                        return new Result
                        {
                            similarity = 1,
                            distance = 0,
                        };
                    }
                    else
                    {
                        return new Result
                        {
                            similarity = 0,
                            distance = target.Length,
                        };
                    }
                }
                else if (String.IsNullOrEmpty(target))
                {
                    return new Result
                    {
                        similarity = 0,
                        distance = source.Length,
                    };
                }

                String From, To;
                if (isCaseSensitive)
                {   // 大小写敏感
                    From = source;
                    To = target;
                }
                else
                {   // 大小写无关
                    From = source.ToLower();
                    To = target.ToLower();
                }

                // 初始化
                Int32 m = From.Length;
                Int32 n = To.Length;
                Int32[,] H = new Int32[m + 1, n + 1];
                for (Int32 i = 0; i <= m; i++) H[i, 0] = i;  // 注意：初始化[0,0]
                for (Int32 j = 1; j <= n; j++) H[0, j] = j;

                // 迭代
                for (Int32 i = 1; i <= m; i++)
                {
                    Char SI = From[i - 1];
                    for (Int32 j = 1; j <= n; j++)
                    {   // 删除（deletion） 插入（insertion） 替换（substitution）
                        if (SI == To[j - 1])
                            H[i, j] = H[i - 1, j - 1];
                        else
                            H[i, j] = Math.Min(H[i - 1, j - 1], Math.Min(H[i - 1, j], H[i, j - 1])) + 1;
                    }
                }

                // 计算相似度（此相似度未必合理）
                Int32 MaxLength = Math.Max(m, n);   // 两字符串的最大长度

                return new Result
                {
                    similarity = ((double)(MaxLength - H[m, n])) / MaxLength,
                    distance = H[m, n],
                };
            }

            /// <summary>
            /// 受限的Damerau-Levenshtein Distance（只允许相邻字符交换）
            /// </summary>
            /// <param name="source">源串</param>
            /// <param name="target">目标串</param>
            /// <param name="isCaseSensitive">是否大小写敏感</param>
            /// <returns>源串和目标串之间的编辑距离</returns>
            /// <remarks>http://en.wikipedia.org/wiki/Damerau%E2%80%93Levenshtein_distance</remarks>
            public static Result OptimalStringAlignmentDistance(String source, String target, Boolean isCaseSensitive = false)
            {
                if (String.IsNullOrEmpty(source))
                {
                    if (String.IsNullOrEmpty(target))
                    {
                        return new Result
                        {
                            similarity = 1,
                            distance = 0,
                        };
                    }
                    else
                    {
                        return new Result
                        {
                            similarity = 0,
                            distance = target.Length,
                        };
                    }
                }
                else if (String.IsNullOrEmpty(target))
                {
                    return new Result
                    {
                        similarity = 0,
                        distance = source.Length,
                    };
                }

                String From, To;
                if (isCaseSensitive)
                {   // 大小写敏感
                    From = source;
                    To = target;
                }
                else
                {   // 大小写无关
                    From = source.ToLower();
                    To = target.ToLower();
                }

                // 初始化
                Int32 m = From.Length;
                Int32 n = To.Length;
                Int32[,] H = new Int32[m + 1, n + 1];
                for (Int32 i = 0; i <= m; i++) H[i, 0] = i;  // 注意：初始化[0,0]
                for (Int32 j = 1; j <= n; j++) H[0, j] = j;

                // 迭代
                for (Int32 i = 1; i <= m; i++)
                {
                    Char SI = From[i - 1];
                    for (Int32 j = 1; j <= n; j++)
                    {   // 删除（deletion） 插入（insertion） 替换（substitution）
                        Char DJ = To[j - 1];
                        if (SI == DJ)
                            H[i, j] = H[i - 1, j - 1];
                        else
                            H[i, j] = Math.Min(H[i - 1, j - 1], Math.Min(H[i - 1, j], H[i, j - 1])) + 1;

                        if (i > 1 && j > 1)
                        {   // 交换相邻字符（transposition of two adjacent characters）
                            if (SI == To[j - 2] && DJ == From[i - 2])
                            {
                                H[i, j] = Math.Min(H[i, j], H[i - 2, j - 2] + 1);
                            }
                        }
                    }
                }

                // 计算相似度（此相似度未必合理）
                Int32 MaxLength = Math.Max(m, n);   // 两字符串的最大长度

                return new Result
                {
                    similarity = ((double)(MaxLength - H[m, n])) / MaxLength,
                    distance = H[m, n],
                };
            }

            /// <summary>
            /// 不受限的Damerau-Levenshtein Distance（允许交换字符间的删除插入操作）
            /// 我在维基百科中贡献了此段代码的修改版（去掉了相似度和大小写敏感）
            /// </summary>
            /// <param name="source">源串</param>
            /// <param name="target">目标串</param>
            /// <param name="isCaseSensitive">是否大小写敏感</param>
            /// <remarks>http://en.wikipedia.org/wiki/Damerau%E2%80%93Levenshtein_distance</remarks>
            public static Result DamerauLevenshteinDistance(String source, String target, Boolean isCaseSensitive = false)
            {
                if (String.IsNullOrEmpty(source))
                {
                    if (String.IsNullOrEmpty(target))
                    {
                        return new Result
                        {
                            similarity = 1,
                            distance = 0,
                        };
                    }
                    else
                    {
                        return new Result
                        {
                            similarity = 0,
                            distance = target.Length,
                        };
                    }
                }
                else if (String.IsNullOrEmpty(target))
                {
                    return new Result
                    {
                        similarity = 0,
                        distance = source.Length,
                    };
                }

                String From, To;
                if (isCaseSensitive)
                {   // 大小写敏感
                    From = source;
                    To = target;
                }
                else
                {   // 大小写无关
                    From = source.ToLower();
                    To = target.ToLower();
                }

                // 初始化
                Int32 m = From.Length;
                Int32 n = To.Length;
                Int32[,] H = new Int32[m + 2, n + 2];

                Int32 INF = m + n;
                H[0, 0] = INF;
                for (Int32 i = 0; i <= m; i++)
                {
                    H[i + 1, 1] = i;
                    H[i + 1, 0] = INF;
                }
                for (Int32 j = 0; j <= n; j++)
                {
                    H[1, j + 1] = j;
                    H[0, j + 1] = INF;
                }

                // 对维基百科中给出ActionScript代码优化，去掉参数C，可以更好地适合各国语言
                SortedDictionary<Char, Int32> sd = new SortedDictionary<Char, Int32>();
                foreach (Char Letter in (From + To))
                {
                    if (!sd.ContainsKey(Letter))
                        sd.Add(Letter, 0);
                }

                // 迭代
                for (Int32 i = 1; i <= m; i++)
                {
                    Int32 DB = 0;
                    for (Int32 j = 1; j <= n; j++)
                    {
                        Int32 i1 = sd[To[j - 1]];   // 定位字符To[j-1]在源串From[0:i-2]中的最后一次索引
                        Int32 j1 = DB;              // 定位字符From[i-1]在目标串To[0:j-2]中的最后一次索引

                        // 删除（deletion） 插入（insertion） 替换（substitution）
                        if (From[i - 1] == To[j - 1])
                        {
                            H[i + 1, j + 1] = H[i, j];
                            DB = j;
                        }
                        else
                        {
                            H[i + 1, j + 1] = Math.Min(H[i, j], Math.Min(H[i + 1, j], H[i, j + 1])) + 1;
                        }

                        // transposition of two adjacent characters
                        // 将源串i1-1到i-1内的字符删除，然后交换i1-1和i-1的字符，再加上目标串j1-1到j-1内的字符  
                        H[i + 1, j + 1] = Math.Min(H[i + 1, j + 1], H[i1, j1] + (i - i1 - 1) + 1 + (j - j1 - 1));
                    }

                    sd[From[i - 1]] = i;
                }

                // 计算相似度（此相似度未必合理）
                Int32 MaxLength = Math.Max(m, n);   // 两字符串的最大长度

                return new Result
                {
                    similarity = ((double)(MaxLength - H[m + 1, n + 1])) / MaxLength,
                    distance = H[m + 1, n + 1],
                };
            }

            /// <summary>
            /// 不受限的Damerau-Levenshtein Distance（允许交换字符间的删除插入操作）
            /// </summary>
            /// <param name="source">源串</param>
            /// <param name="target">目标串</param>
            /// <param name="isCaseSensitive">是否大小写敏感</param>
            /// <remarks>更好理解的代码</remarks>
            public static Result EZDamerauLevenshteinDistance(String source, String target, Boolean isCaseSensitive = false)
            {
                if (String.IsNullOrEmpty(source))
                {
                    if (String.IsNullOrEmpty(target))
                    {
                        return new Result
                        {
                            similarity = 1,
                            distance = 0,
                        };
                    }
                    else
                    {
                        return new Result
                        {
                            similarity = 0,
                            distance = target.Length,
                        };
                    }
                }
                else if (String.IsNullOrEmpty(target))
                {
                    return new Result
                    {
                        similarity = 0,
                        distance = source.Length,
                    };
                }

                String From, To;
                if (isCaseSensitive)
                {   // 大小写敏感
                    From = source;
                    To = target;
                }
                else
                {   // 大小写无关
                    From = source.ToLower();
                    To = target.ToLower();
                }

                // 初始化
                Int32 m = From.Length;
                Int32 n = To.Length;
                Int32[,] H = new Int32[m + 1, n + 1];
                for (Int32 i = 0; i <= m; i++) H[i, 0] = i;  // 注意：初始化[0,0]
                for (Int32 j = 1; j <= n; j++) H[0, j] = j;

                // 迭代
                for (Int32 i = 1; i <= m; i++)
                {
                    Char SI = From[i - 1];
                    for (Int32 j = 1; j <= n; j++)
                    {   // 删除（deletion） 插入（insertion） 替换（substitution）
                        Char DJ = To[j - 1];
                        if (SI == DJ)
                            H[i, j] = H[i - 1, j - 1];
                        else
                            H[i, j] = Math.Min(H[i - 1, j - 1], Math.Min(H[i - 1, j], H[i, j - 1])) + 1;

                        if (i > 1 && j > 1)
                        {   // 交换相邻字符（transposition of two adjacent characters）                       
                            Int32 i1 = From.LastIndexOf(DJ, i - 2, i - 1);
                            if (i1 != -1)
                            {
                                Int32 j1 = To.LastIndexOf(SI, j - 2, j - 1);
                                if (j1 != -1)
                                {   // 将源串i1到i-1内的字符删除，然后交换i1和i-1的字符，再加上目标串j1到j-1内的字符                              
                                    H[i, j] = Math.Min(H[i, j], H[i1, j1] + (i - i1 - 2) + 1 + (j - j1 - 2));
                                }
                            }
                        }
                    }
                }

                // 计算相似度（此相似度未必合理）
                Int32 MaxLength = Math.Max(m, n);   // 两字符串的最大长度

                return new Result
                {
                    similarity = ((double)(MaxLength - H[m, n])) / MaxLength,
                    distance = H[m, n],
                };
            }

            public static bool Compare(string source, string target, double similarityBoundary = 0.5)
            {
                bool CompareResult = false;
                Result LCompareResult = Operate.EditDistanceHelper.LevenshteinDistance(source, target);
                if (source.Contains(target) || LCompareResult.similarity > similarityBoundary)
                {
                    CompareResult = true;
                }
                return CompareResult;
            }

            public static bool Compare(string[] sources, string[] targets)
            {
                foreach (string source in sources)
                {
                    foreach (string target in targets)
                    {
                        if (Compare(source, target) == true)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        public static class QRcodeHelper
        {
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
