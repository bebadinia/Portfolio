// Encrypt_Decrypt.cs by Ben Ebadinia

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace WhatsItWorth
{
    class Encrypt_Decrypt
    {


        // Path to the symmetric encryption key file.
        private static string dbPath =
#if DEBUG
        @"..\..\Database\Key.txt";      // project folder during dev
#else
        @"Database\Key.txt";            // next to the exe for your final zip
#endif



        public static string EncryptString(string plainText)
        {
            // Read symmetric key from file. In production, use a secure secret store.
            StreamReader fileReader = new StreamReader($@"{dbPath}");
            String key = fileReader.ReadLine();

            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public static string DecryptString(string cipherText)
        {
            // Read symmetric key from file. In production, use a secure secret store.
            StreamReader fileReader = new StreamReader($@"{dbPath}");
            String key = fileReader.ReadLine();

            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
