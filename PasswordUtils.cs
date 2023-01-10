using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Buffers.Text;

namespace AlphaTap
{
    public static class PasswordUtils
    {
        public const int KEYSIZE = 256;

        public static byte[] Encrypt(byte[] data, string password, byte[] salt, byte[] iv)
        {
            var rij = new RijndaelManaged()
            {
                KeySize = KEYSIZE,
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7
            };

            var rfc = new Rfc2898DeriveBytes(password, salt);
            rij.Key = rfc.GetBytes(KEYSIZE / 8);
            rij.IV = iv;

            var ms = new MemoryStream();
            var cs = new CryptoStream(ms, rij.CreateEncryptor(), CryptoStreamMode.Write);

            using (var bw = new BinaryWriter(cs))
            {
                bw.Write(data);
            }

            return ms.ToArray();
        }

        public static byte[] Decrypt(byte[] data, string password, byte[] salt, byte[] iv)
        {
            var rij = new RijndaelManaged()
            {
                KeySize = KEYSIZE,
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7
            };

            var rfc = new Rfc2898DeriveBytes(password, salt);
            rij.Key = rfc.GetBytes(KEYSIZE / 8);
            rij.IV = iv;

            var ms = new MemoryStream(data);
            var cs = new CryptoStream(ms, rij.CreateDecryptor(), CryptoStreamMode.Read);

            var br = new BinaryReader(cs);
            return br.ReadBytes(data.Length);
        }
    }
}
