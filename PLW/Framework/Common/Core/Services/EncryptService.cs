using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Framework.Common.Core.Services
{
    public static class EncryptService
    {
        public static readonly string Key = "~!@#$%^&*()123456789";

        /// <summary>
        /// Encrypt a string.
        /// </summary>
        /// <param name="plainText">String to be encrypted</param>
        /// <param name="keyValue"></param>
        public static string Encrypt(string plainText, string keyValue = "")
        {
            if (plainText == null)
            {
                return null;
            }

            if (keyValue == "")
            {
                keyValue = Key;
            }

            // Get the bytes of the string
            var bytesToBeEncrypted = Encoding.UTF8.GetBytes(plainText);
            var passwordBytes = Encoding.UTF8.GetBytes(keyValue);

            var bytesEncrypted = Encrypt(bytesToBeEncrypted, SHA256.Create().ComputeHash(passwordBytes));

            return Convert.ToBase64String(bytesEncrypted);
        }

        /// <summary>
        /// Decrypt a string.
        /// </summary>
        /// <param name="encryptedText">String to be decrypted</param>
        /// <param name="keyValue"></param>
        /// <exception cref="FormatException"></exception>
        public static string Decrypt(string encryptedText, string keyValue = "")
        {
            if (encryptedText == null)
            {
                return null;
            }

            if (keyValue == "")
            {
                keyValue = Key;
            }


            // Get the bytes of the string
            var bytesToBeDecrypted = Convert.FromBase64String(encryptedText);
            var passwordBytes = Encoding.UTF8.GetBytes(keyValue);

            var bytesDecrypted = Decrypt(bytesToBeDecrypted, SHA256.Create().ComputeHash(passwordBytes));

            return Encoding.UTF8.GetString(bytesDecrypted);
        }

        private static byte[] Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged aes = new RijndaelManaged())
                {
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);

                    aes.KeySize = 256;
                    aes.BlockSize = 128;
                    aes.Key = key.GetBytes(aes.KeySize / 8);
                    aes.IV = key.GetBytes(aes.BlockSize / 8);

                    aes.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }

                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        private static byte[] Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged aes = new RijndaelManaged())
                {
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);

                    aes.KeySize = 256;
                    aes.BlockSize = 128;
                    aes.Key = key.GetBytes(aes.KeySize / 8);
                    aes.IV = key.GetBytes(aes.BlockSize / 8);
                    aes.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }

                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }
    }
}
