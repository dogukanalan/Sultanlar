using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Sultanlar.Class
{
    public class Sifreleme
    {
        private static string _Key = "ri8jthmDQca=";
        private static string _Vektor = "8pHPik6Ix/q=";
        private static SymmetricAlgorithm _SymAl = new DESCryptoServiceProvider();

        public static string Encrypt(string Value)
        {
            MemoryStream mStrm = new MemoryStream();
            ICryptoTransform cryTrns = _SymAl.CreateEncryptor(Convert.FromBase64String(_Key), Convert.FromBase64String(_Vektor));

            CryptoStream cStrm = new CryptoStream(mStrm, cryTrns, CryptoStreamMode.Write);

            byte[] byteValue = System.Text.Encoding.UTF8.GetBytes(Value);
            cStrm.Write(byteValue, 0, byteValue.Length);
            cStrm.Close();

            return Convert.ToBase64String(mStrm.ToArray());
        }

        public static string Encrypt(string Key, string Value)
        {
            MemoryStream mStrm = new MemoryStream();
            ICryptoTransform cryTrns = _SymAl.CreateEncryptor(Convert.FromBase64String(Key), Convert.FromBase64String(_Vektor));

            CryptoStream cStrm = new CryptoStream(mStrm, cryTrns, CryptoStreamMode.Write);

            byte[] byteValue = System.Text.Encoding.UTF8.GetBytes(Value);
            cStrm.Write(byteValue, 0, byteValue.Length);
            cStrm.Close();

            return Convert.ToBase64String(mStrm.ToArray());
        }

        public static string Decrypt(string Value)
        {
            MemoryStream mStrm = new MemoryStream();
            ICryptoTransform cryTrns = _SymAl.CreateDecryptor(Convert.FromBase64String(_Key), Convert.FromBase64String(_Vektor));

            CryptoStream cStrm = new CryptoStream(mStrm, cryTrns, CryptoStreamMode.Write);

            byte[] byteValue = Convert.FromBase64String(Value);
            cStrm.Write(byteValue, 0, byteValue.Length);
            cStrm.Close();

            return System.Text.Encoding.UTF8.GetString(mStrm.ToArray());
        }

        public static string Decrypt(string Key, string Value)
        {
            MemoryStream mStrm = new MemoryStream();
            ICryptoTransform cryTrns = _SymAl.CreateDecryptor(Convert.FromBase64String(Key), Convert.FromBase64String(_Vektor));

            CryptoStream cStrm = new CryptoStream(mStrm, cryTrns, CryptoStreamMode.Write);

            byte[] byteValue = Convert.FromBase64String(Value);
            cStrm.Write(byteValue, 0, byteValue.Length);
            cStrm.Close();

            return System.Text.Encoding.UTF8.GetString(mStrm.ToArray());
        }

        /*public static string GetRandomKey()
        {
            _SymAl.GenerateKey();
            return Convert.ToBase64String(_SymAl.Key);
        }

        public static string GetRandomVektor()
        {
            _SymAl.GenerateIV();
            return Convert.ToBase64String(_SymAl.IV);
        }*/
    }
}
