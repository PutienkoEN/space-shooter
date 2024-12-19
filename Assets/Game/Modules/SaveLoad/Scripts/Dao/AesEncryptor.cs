using System;
using System.Security.Cryptography;
using System.Text;

namespace Game.Modules.SaveLoad
{
    public class AesEncryptor
    {
        private readonly string _encryptionKey;
        private readonly byte[] _ivStored = new byte[16];

        public AesEncryptor(string encryptionKey)
        {
            _encryptionKey = encryptionKey;
        }

        public string Encrypt(string plainText)
        {
            var plainBytes = Encoding.UTF8.GetBytes(plainText);

            var encryptedBytes = EncryptBytes(plainBytes);

            return Convert.ToBase64String(encryptedBytes);
        }

        public string Decrypt(string cipherText)
        {
            var cipherBytes = Convert.FromBase64String(cipherText);

            var decryptedBytes = DecryptBytes(cipherBytes);

            return Encoding.UTF8.GetString(decryptedBytes);
        }

        private byte[] EncryptBytes(byte[] plainBytes)
        {
            using var aes = Aes.Create();
            ConfigureAes(aes);

            using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            var encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
            return encryptedBytes;
        }

        private byte[] DecryptBytes(byte[] cipherBytes)
        {
            using var aes = Aes.Create();
            ConfigureAes(aes);

            using var decryptor = aes.CreateDecryptor();
            var decryptedBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
            return decryptedBytes;
        }

        private void ConfigureAes(Aes aes)
        {
            aes.Key = Encoding.UTF8.GetBytes(_encryptionKey);
            aes.IV = _ivStored;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
        }
    }
}