using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Linq;
using ET.SchoolBus.Integration.Interfaces;
using Microsoft.Extensions.Configuration;

namespace ET.SchoolBus.Integration.Implementations;

public class CypherService : ICypherService
{
    private readonly IConfiguration _configuration;
    private const int Keysize = 256;
    private const int DerivationIterations = 1000;

    public CypherService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string Encrypte(string clearText)
    {
        var key = _configuration["ApiConfig:Key"];
        var iv = _configuration["ApiConfig:IV"];

        var keyByte = Encoding.UTF8.GetBytes(key);
        var ivBytes = Encoding.UTF8.GetBytes(iv);

        if (clearText == null || clearText.Length <= 0)
            throw new ArgumentNullException("clearText");

        if (keyByte == null || keyByte.Length <= 0)
            throw new ArgumentNullException("key");

        if (ivBytes == null || ivBytes.Length <= 0)
            throw new ArgumentNullException("ivBytes");

        byte[] encrypted;

        using var rijAlg = new RijndaelManaged();
        rijAlg.Mode = CipherMode.CBC;
        rijAlg.Padding = PaddingMode.PKCS7;
        rijAlg.FeedbackSize = 128;

        rijAlg.Key = keyByte;
        rijAlg.IV = ivBytes;

        var encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

        using (var msEncrypt = new MemoryStream())
        {
            using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            {
                using (var swEncrypt = new StreamWriter(csEncrypt))
                {
                    swEncrypt.Write(clearText);
                }
                encrypted = msEncrypt.ToArray();
            }
        }

        return Convert.ToBase64String(encrypted);
    }

    public string Decrypte(string encryptedText)
    {
        var key = _configuration["ApiConfig:Key"];
        var iv = _configuration["ApiConfig:IV"];

        var keyByte = Encoding.UTF8.GetBytes(key);
        var ivBytes = Encoding.UTF8.GetBytes(iv);

        var encryptedTextBytes = Convert.FromBase64String(encryptedText);

        if (encryptedTextBytes == null || encryptedTextBytes.Length <= 0)
            throw new ArgumentNullException("encryptedTextBytes");

        if (keyByte == null || keyByte.Length <= 0)
            throw new ArgumentNullException("key");

        if (ivBytes == null || ivBytes.Length <= 0)
            throw new ArgumentNullException("ivBytes");

        string plaintext = null;

        using (var rijAlg = new RijndaelManaged())
        {

            rijAlg.Mode = CipherMode.CBC;
            rijAlg.Padding = PaddingMode.PKCS7;
            rijAlg.FeedbackSize = 128;

            rijAlg.Key = keyByte;
            rijAlg.IV = ivBytes;

            var decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
            try
            {
                using (var msDecrypt = new MemoryStream(encryptedTextBytes))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }

                    }
                }
            }
            catch
            {
                plaintext = "keyError";
            }
        }

        return plaintext;
    }


}
