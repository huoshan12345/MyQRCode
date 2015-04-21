/******************************** Module Header ********************************
 * Module Name: Cryptography
 * Project:     CommonLibrary    
 * Copyright (c) Jackson Huang.
 * 
 * Code Logic:
 * This helper includes Symmetric Algorithm and Asymmetric Algorithm
 * Symmetric Algorithm Method:
 * MD5, RC2, DES, TripleDES and Rijndael.
 * 
 * Symmetric Algorithm Method:
 * RSA and DSA, but we only provide RSA implemention.
 * 
 * Corresponding Source:
 * des key 64bit
 * http://msdn.microsoft.com/en-us/library/system.security.cryptography.des.key.aspx
 * 
 * rc2 key 40bits  to 128bits in increments of 8bits
 * http://msdn.microsoft.com/en-us/library/system.security.cryptography.rc2.keysize(v=VS.85).aspx
 * 
 * Rijndael
 * http://msdn.microsoft.com/en-us/library/system.security.cryptography.symmetricalgorithm.keysize.aspx
 * 
 * TripleDES This algorithm supports key lengths from 128 bits to 192 bits in increments of 64 bits.
 * http://msdn.microsoft.com/en-us/library/system.security.cryptography.tripledes.key.aspx
 * 
 * History:
 * 7-23-2011 16:07 Jackson Huang Created
 * Websiet:
 * http://www.cnblogs.com/rush/
 * *******************************************************************************/


#region Using Directives
using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
#endregion

namespace CommonLibrary.Cryptography
{
    /// <summary>
    /// The crytography helper.
    /// </summary>
    public class CryptographyUtils
    {
        public static List<byte[]> myArray { get; set; }
        public static string RSAPubicKey { get; set; }
        public static string RSAPrivateKey { get; set; }

        /// <summary>
        /// Creates the algo.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fullyQualifiedTypeName">Name of the fully qualified type.</param>
        /// <format>"Namespace.ClassName"</format>
        /// <returns></returns>
        public static T CreateAlgo<T>(string fullyQualifiedTypeName) where T : class
        {
            object algo = Activator.CreateInstance(Type.GetType(fullyQualifiedTypeName));
            return algo as T;
        }

        /// <summary>
        /// Creates the hash algo MD5.
        /// </summary>
        /// <returns></returns>
        public static HashAlgorithm CreateHashAlgoMd5()
        {
            return new MD5CryptoServiceProvider();
        }

        /// <summary>
        /// Creates the symm algo triple DES.
        /// </summary>
        /// <returns></returns>
        public static SymmetricAlgorithm CreateSymmAlgoTripleDes()
        {
            return new TripleDESCryptoServiceProvider();
        }

        /// <summary>
        /// Creates the symm algo R c2.
        /// </summary>
        /// <returns></returns>
        public static SymmetricAlgorithm CreateSymmAlgoRC2()
        {
            return new RC2CryptoServiceProvider();
        }

        /// <summary>
        /// Creates the symm algo rijndael.
        /// </summary>
        /// <returns></returns>
        public static SymmetricAlgorithm CreateSymmAlgoRijndael()
        {
            return new RijndaelManaged();
        }

        /// <summary>
        /// Creates the symm algo DES.
        /// </summary>
        /// <returns></returns>
        public static SymmetricAlgorithm CreateSymmAlgoDES()
        {
            return new DESCryptoServiceProvider();
        }

        /// <summary>
        /// Creates the asymm algo RSA.
        /// </summary>
        /// <returns></returns>
        public static RSACryptoServiceProvider CreateAsymmAlgoRSA()
        {
            return new RSACryptoServiceProvider();

        }

        /// <summary>
        /// Decrypts the specified algorithm.
        /// </summary>
        /// <param name="algorithm">The algorithm.</param>
        /// <param name="base64Text">The base64 text.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static string Decrypt(SymmetricAlgorithm algorithm, string base64Text, string key,
            CipherMode cipherMode, PaddingMode paddingMode)
        {
            using (MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

                byte[] Key;

                byte[] keyBytes = UTF8.GetBytes(key);

                using (SymmetricAlgorithm rijndaelCipher = new RijndaelManaged())
                {
                    PasswordDeriveBytes pdb = new PasswordDeriveBytes(keyBytes, new SHA1CryptoServiceProvider().ComputeHash(keyBytes));
                    Key = pdb.GetBytes(algorithm.KeySize / 8);
                }


                ////    algorithm.Mode = CipherMode.ECB;
                ////    algorithm.Padding = PaddingMode.PKCS7;
                ////    ICryptoTransform transformer = algorithm.CreateDecryptor();
                ////    byte[] Buffer = Convert.FromBase64String(base64Text);
                ////    return UTF8.GetString(transformer.TransformFinalBlock(Buffer, 0, Buffer.Length));
                return Decrypt(algorithm, base64Text, Key, cipherMode, paddingMode);
            }



        }

        /// <summary>
        /// Decrypts the specified algorithm.
        /// </summary>
        /// <param name="algorithm">The algorithm.</param>
        /// <param name="base64Text">The base64 text.</param>
        /// <param name="key">The key.</param>
        /// <param name="cipherMode">The cipher mode.</param>
        /// <param name="paddingMode">The padding mode.</param>
        /// <returns> The recovered text. </returns>
        public static string Decrypt(SymmetricAlgorithm algorithm, string base64Text, byte[] key,
            CipherMode cipherMode, PaddingMode paddingMode)
        {
            byte[] plainBytes;

            //// Convert the base64 string to byte array. 
            byte[] cipherBytes = Convert.FromBase64String(base64Text);
            algorithm.Key = key;
            algorithm.Mode = cipherMode;
            algorithm.Padding = paddingMode;

            using (MemoryStream memoryStream = new MemoryStream(cipherBytes))
            {
                using (CryptoStream cs = new CryptoStream(memoryStream,
                    algorithm.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    plainBytes = new byte[cipherBytes.Length];
                    cs.Read(plainBytes, 0, cipherBytes.Length);
                }
            }

            string recoveredMessage;
            using (MemoryStream stream = new MemoryStream(plainBytes, false))
            {
                BinaryFormatter bf = new BinaryFormatter();
                recoveredMessage = bf.Deserialize(stream).ToString();
            }

            return recoveredMessage;

        }

        /// <summary>
        /// Encrypts the specified hash algorithm.
        /// 1. Generates a cryptographic Hash Key for the provided text data.
        /// </summary>
        /// <param name="hashAlgorithm">The hash algorithm.</param>
        /// <param name="dataToHash">The data to hash.</param>
        /// <returns></returns>
        public static string Encrypt(HashAlgorithm hashAlgorithm, string dataToHash)
        {

            string[] tabStringHex = new string[16];
            UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            byte[] data = UTF8.GetBytes(dataToHash);
            byte[] result = hashAlgorithm.ComputeHash(data);
            StringBuilder hexResult = new StringBuilder(result.Length);

            for (int i = 0; i < result.Length; i++)
            {
                //// Convert to hexadecimal
                hexResult.Append(result[i].ToString("X2"));
            }
            return hexResult.ToString();
        }

        /// <summary>
        /// 
        /// Encrypts the specified algorithm.
        /// We use the MD5 hash generator as the result is a 128 bit byte array.
        /// Which is a valid length (key lengths: 64 bit, 128 bit and 192 bit) 
        /// for the TripleDES encoder we use below.
        /// 
        /// </summary>
        /// <param name="algorithm">The algorithm.</param>
        /// <param name="plainText">The plain text.</param>
        /// <param name="key">The key.</param>
        /// <param name="cipherMode">The cipher mode.</param>
        /// <param name="paddingMode">The padding mode.</param>
        /// <returns></returns>
        public static string Encrypt(SymmetricAlgorithm algorithm, string plainText, string key,
            CipherMode cipherMode, PaddingMode paddingMode)
        {
            using (MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding UTF8 = new System.Text.UTF8Encoding();


                byte[] Key; //= new byte[algorithm.KeySize];

                byte[] keyBytes = UTF8.GetBytes(key);

                using (SymmetricAlgorithm rijndaelCipher = new RijndaelManaged())
                {
                    PasswordDeriveBytes pdb = new PasswordDeriveBytes(keyBytes,
                                                                      new SHA1CryptoServiceProvider().ComputeHash(
                                                                          keyBytes));
                    Key = pdb.GetBytes(algorithm.KeySize / 8);
                }


                return Encrypt(algorithm, plainText, Key, cipherMode, paddingMode);
            }
        }

        /// <summary>
        /// Encrypts the specified algorithm.
        /// The type of algorithm is SymmetricAlgorithm, so the Encrypt
        /// supports all kind of Symmetric Algorithm (cf: DES, TripleDes etc).
        /// </summary>
        /// 
        /// <param name="algorithm">The algorithm.</param>
        /// <param name="plainText">The plain text.</param>
        /// <param name="key">The key.</param>
        /// <param name="cipherMode">The cipher mode.</param>
        /// <param name="paddingMode">The padding mode.</param>
        /// <returns> The string base on base64. </returns>
        public static string Encrypt(SymmetricAlgorithm algorithm, string plainText, byte[] key,
            CipherMode cipherMode, PaddingMode paddingMode)
        {
            byte[] plainBytes;
            byte[] cipherBytes;
            algorithm.Key = key;
            algorithm.Mode = cipherMode;
            algorithm.Padding = paddingMode;

            BinaryFormatter bf = new BinaryFormatter();

            using (MemoryStream stream = new MemoryStream())
            {
                bf.Serialize(stream, plainText);
                plainBytes = stream.ToArray();
            }

            using (MemoryStream ms = new MemoryStream())
            {
                // Defines a stream for cryptographic transformations
                CryptoStream cs = new CryptoStream(ms, algorithm.CreateEncryptor(), CryptoStreamMode.Write);

                // Writes a sequence of bytes for encrption
                cs.Write(plainBytes, 0, plainBytes.Length);

                // Closes the current stream and releases any resources 
                cs.Close();
                // Save the ciphered message into one byte array
                cipherBytes = ms.ToArray();
                // Closes the memorystream object
                ms.Close();
            }
            string base64Text = Convert.ToBase64String(cipherBytes);

            return base64Text;
        }

        /// <summary>
        /// Encrypts the specified algorithm.
        /// The Asymmetric Algorithm includes DSA，ECDiffieHellman， ECDsa and RSA.
        /// Code Logic:
        /// 1. Input encrypt algorithm and plain text.
        /// 2. Read the public key from stream.
        /// 3. Serialize plian text to byte array.
        /// 4. Encrypt the plian text array by public key.
        /// 5. Return ciphered string.
        /// </summary>
        /// <param name="algorithm">The algorithm.</param>
        /// <param name="plainText">The plain text.</param>
        /// <returns></returns>
        public static string Encrypt(RSACryptoServiceProvider algorithm, string plainText)
        {
            string publicKey;
            List<Byte[]> cipherArray = new List<byte[]>();

            //// read the public key.
            using (StreamReader streamReader = new StreamReader("PublicOnlyKey.xml"))
            {
                publicKey = streamReader.ReadToEnd();
            }
            algorithm.FromXmlString(publicKey);

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            byte[] plainBytes = null;


            //// Use BinaryFormatter to serialize plain text.
            using (MemoryStream memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, plainText);
                plainBytes = memoryStream.ToArray();
            }

            int totLength = 0;
            int index = 0;

            //// Encrypt plain text by public key.
            if (plainBytes.Length > 80)
            {
                byte[] partPlainBytes;
                byte[] cipherBytes;
                myArray = new List<byte[]>();
                while (plainBytes.Length - index > 0)
                {
                    partPlainBytes = plainBytes.Length - index > 80 ? new byte[80] : new byte[plainBytes.Length - index];

                    for (int i = 0; i < 80 && (i + index) < plainBytes.Length; i++)
                        partPlainBytes[i] = plainBytes[i + index];
                    myArray.Add(partPlainBytes);

                    cipherBytes = algorithm.Encrypt(partPlainBytes, false);
                    totLength += cipherBytes.Length;
                    index += 80;

                    cipherArray.Add(cipherBytes);
                }
            }

            //// Convert to byte array.
            byte[] cipheredPlaintText = new byte[totLength];
            index = 0;
            foreach (byte[] item in cipherArray)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    cipheredPlaintText[i + index] = item[i];
                }

                index += item.Length;
            }
            return Convert.ToBase64String(cipheredPlaintText);

        }

        /// <summary>
        /// Decrypts the specified algorithm.
        /// </summary>
        /// <param name="algorithm">The algorithm.</param>
        /// <param name="base64Text">The base64 text.</param>
        /// <returns></returns>
        public static string Decrypt(RSACryptoServiceProvider algorithm, string base64Text)
        {
            byte[] cipherBytes = Convert.FromBase64String(base64Text);
            List<byte[]> plainArray = new List<byte[]>();
            string privateKey = string.Empty;

            //// Read the private key.
            using (StreamReader streamReader = new StreamReader("PublicPrivateKey.xml"))
            {
                privateKey = streamReader.ReadToEnd();
            }

            algorithm.FromXmlString(privateKey);

            int index = 0;
            int totLength = 0;
            byte[] partPlainText = null;
            byte[] plainBytes;
            int length = cipherBytes.Length / 2;
            //int j = 0;
            //// Decrypt the ciphered text through private key.
            while (cipherBytes.Length - index > 0)
            {
                partPlainText = cipherBytes.Length - index > 128 ? new byte[128] : new byte[cipherBytes.Length - index];

                for (int i = 0; i < 128 && (i + index) < cipherBytes.Length; i++)
                    partPlainText[i] = cipherBytes[i + index];

                plainBytes = algorithm.Decrypt(partPlainText, false);

                totLength += plainBytes.Length;
                index += 128;
                plainArray.Add(plainBytes);

            }

            byte[] recoveredPlaintext = new byte[length];

            index = 0;
            for (int i = 0; i < plainArray.Count; i++)
            {
                for (int j = 0; j < plainArray[i].Length; j++)
                {
                    recoveredPlaintext[index + j] = plainArray[i][j];
                }
                index += plainArray[i].Length;
            }

            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(recoveredPlaintext, 0, recoveredPlaintext.Length);
                stream.Position = 0;
                string msgobj = (string)bf.Deserialize(stream);
                return msgobj;
            }

        }

        public static string Decrypt(List<byte[]> cipherArray)
        {
            try
            {
                /////////////////////////////////////////////////////////////////
                // Create a RSACryptoServiceProvider object and initialize it 
                // with a public-private key pair.
                // 
                List<byte[]> recoveredArray = new List<byte[]>();
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                String publicPrivateKeyXml = string.Empty;
                using (StreamReader sr = new StreamReader("PublicPrivateKey.xml"))
                {
                    publicPrivateKeyXml = sr.ReadToEnd();
                }
                rsa.FromXmlString(publicPrivateKeyXml);
                recoveredArray.Clear();


                /////////////////////////////////////////////////////////////////
                // Get cipherd data as byte array and use the 
                // RSACryptoServiceProvider object to decrypt it.
                //

                int length = 0;
                for (int i = 0; i < cipherArray.Count; i++)
                {
                    byte[] partRecoveredPlainBytes = rsa.Decrypt(cipherArray[i], false);
                    recoveredArray.Add(partRecoveredPlainBytes);
                    length += partRecoveredPlainBytes.Length;
                }
                byte[] recoveredPlaintext = new byte[length];
                int index = 0;
                for (int i = 0; i < recoveredArray.Count; i++)
                {
                    for (int j = 0; j < recoveredArray[i].Length; j++)
                    {
                        recoveredPlaintext[index + j] = recoveredArray[i][j];
                    }
                    index += recoveredArray[i].Length;
                }


                /////////////////////////////////////////////////////////////////
                // Deserialize plaintext data to create message object and 
                // Display the data in UI.
                // 

                BinaryFormatter bf = new BinaryFormatter();
                using (MemoryStream stream = new MemoryStream())
                {
                    stream.Write(recoveredPlaintext, 0, recoveredPlaintext.Length);
                    stream.Position = 0;
                    string msgobj = (string)bf.Deserialize(stream);
                    return msgobj;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "";
        }

        /// <summary>
        /// Generates the RSA key.
        /// </summary>
        /// <param name="algorithm">The algorithm.</param>
        /// <returns></returns>
        public static void GenerateRSAKey(RSACryptoServiceProvider algorithm)
        {
            RSAPrivateKey = algorithm.ToXmlString(true);

            using (StreamWriter streamWriter = new StreamWriter("PublicPrivateKey.xml"))
            {
                streamWriter.Write(RSAPrivateKey);
            }

            RSAPubicKey = algorithm.ToXmlString(false);
            using (StreamWriter streamWriter = new StreamWriter("PublicOnlyKey.xml"))
            {
                streamWriter.Write(RSAPubicKey);
            }

        }

        /// <summary>
        /// Determines whether [is hash match] [the specified hash algorithm].
        /// </summary>
        /// <param name="hashAlgorithm">The hash algorithm.</param>
        /// <param name="hashedText">The hashed text.</param>
        /// <param name="unhashedText">The unhashed text.</param>
        /// <returns>
        ///   <c>true</c> if [is hash match] [the specified hash algorithm]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsHashMatch(HashAlgorithm hashAlgorithm, string hashedText, string unhashedText)
        {
            string hashedTextToCompare = Encrypt(hashAlgorithm, unhashedText);
            return (String.Compare(hashedText, hashedTextToCompare, false) == 0);
        }

    }
}
