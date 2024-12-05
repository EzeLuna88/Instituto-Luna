using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Security
{
    public class Encriptar
    {

        public static string Encriptacion(string texto)
        {
            try
            {
                string key = "qualityinfosolutions";
                byte[] keyArray;
                byte[] ArregloACifrar = UTF8Encoding.UTF8.GetBytes(texto);

                MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
                keyArray = mD5CryptoServiceProvider.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                mD5CryptoServiceProvider.Clear();

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;
                ICryptoTransform cryptoTransform = tdes.CreateEncryptor();
                byte[] ArrayResultado = cryptoTransform.TransformFinalBlock(ArregloACifrar, 0, ArregloACifrar.Length);
                tdes.Clear();

                texto = Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);
            }
            catch (Exception)
            {

                throw;
            }
            return texto;
        }

        public static string Desencriptacion(string textoCifrado)
        {
            try
            {
                string key = "qualityinfosolutions";
                byte[] keyArray;
                byte[] ArregloADescifrar = Convert.FromBase64String(textoCifrado);

                MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
                keyArray = mD5CryptoServiceProvider.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                mD5CryptoServiceProvider.Clear();

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;
                ICryptoTransform cryptoTransform = tdes.CreateDecryptor();
                byte[] ArrayResultado = cryptoTransform.TransformFinalBlock(ArregloADescifrar, 0, ArregloADescifrar.Length);
                tdes.Clear();

                textoCifrado = UTF8Encoding.UTF8.GetString(ArrayResultado);
            }
            catch (Exception)
            {
                throw;
            }
            return textoCifrado;
        }

    }
}
