using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;
using System.Net.NetworkInformation;
using System.Management;

namespace iptv.Negocio.Utilidades
{
  public class CifradoDatos
  {
    IConfiguration configuration;
    private string SecretKey = "1NT3R4CT1V3";
    private string SecretLic = "1NT3R4CT1V3S0LUT10NS";
    public CifradoDatos(IConfiguration configuration)
    {
      this.configuration = configuration;
    }
    #region Encriptar
    public string Encriptar(string texto)
    {
      byte[] keyArray;
      byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(texto);
      MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
      keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(SecretKey));
      hashmd5.Clear();
      TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
      tdes.Key = keyArray;
      tdes.Mode = CipherMode.ECB;
      tdes.Padding = PaddingMode.PKCS7;
      ICryptoTransform cTransform = tdes.CreateEncryptor();
      byte[] arrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);
      tdes.Clear();
      return Convert.ToBase64String(arrayResultado, 0, arrayResultado.Length);
    }

    public string Desencriptar(string textoEncriptado)
    {
      byte[] keyArray;
      Console.WriteLine(textoEncriptado);
      Console.WriteLine(Convert.FromBase64String(textoEncriptado));
      byte[] arrayADescifrar = Convert.FromBase64String(textoEncriptado);
      MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
      keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(SecretKey));
      hashmd5.Clear();
      TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
      tdes.Key = keyArray;
      tdes.Mode = CipherMode.ECB;
      tdes.Padding = PaddingMode.PKCS7;
      ICryptoTransform cTransform = tdes.CreateDecryptor();
      byte[] resultArray = cTransform.TransformFinalBlock(arrayADescifrar, 0, arrayADescifrar.Length);
      tdes.Clear();
      return UTF8Encoding.UTF8.GetString(resultArray);
    }

    public string EncryptText(string input)
    {
      string result = "";
      try
      {
        // Get the bytes of the string
        byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
        byte[] passwordBytes = Encoding.UTF8.GetBytes(SecretLic);

        // Hash the password with SHA256
        passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

        byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

        result = Convert.ToBase64String(bytesEncrypted);


      }
      catch (Exception Error)
      {
        Console.WriteLine(Error.ToString());
      }
      return result;
    }

    public string DecryptText(string input)
    {
      string result = null;
      try
      {
        // Get the bytes of the string
        byte[] bytesToBeDecrypted = Convert.FromBase64String(input);
        byte[] passwordBytes = Encoding.UTF8.GetBytes(SecretLic);
        passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

        byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);

        result = Encoding.UTF8.GetString(bytesDecrypted);
      }
      catch (Exception Error)
      {
        Console.WriteLine(Error.ToString());
      }
      return result;
    }

    public byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
    {
      byte[] decryptedBytes = null;
      // Set your salt here, change it to meet your flavor:
      // The salt bytes must be at least 8 bytes.
      byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
      try
      {
        using (MemoryStream ms = new MemoryStream())
        {
          using (RijndaelManaged AES = new RijndaelManaged())
          {
            AES.KeySize = 256;
            AES.BlockSize = 128;

            var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);

            AES.Mode = CipherMode.CBC;

            using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
            {
              cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
              cs.Close();
            }
            decryptedBytes = ms.ToArray();
          }
        }
      }
      catch (Exception Error)
      {
        Console.WriteLine(Error.ToString());
      }
      return decryptedBytes;
    }

    public byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
    {
      byte[] encryptedBytes = null;
      // Set your salt here, change it to meet your flavor:
      // The salt bytes must be at least 8 bytes.
      byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
      try
      {
        using (MemoryStream ms = new MemoryStream())
        {
          using (RijndaelManaged AES = new RijndaelManaged())
          {
            AES.KeySize = 256;
            AES.BlockSize = 128;

            var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);

            AES.Mode = CipherMode.CBC;

            using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
            {
              cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
              cs.Close();
            }
            encryptedBytes = ms.ToArray();
          }
        }
      }
      catch (Exception Error)
      {
        Console.WriteLine(Error.ToString());
      }
      return encryptedBytes;
    }

    #endregion
    #region EncriptarLicencia
    public RijndaelManaged GetRijndaelManaged(String secretKey)
    {
      var keyBytes = new byte[16];
      var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
      Array.Copy(secretKeyBytes, keyBytes, Math.Min(keyBytes.Length, secretKeyBytes.Length));
      return new RijndaelManaged
      {
        Mode = CipherMode.CBC,
        Padding = PaddingMode.PKCS7,
        KeySize = 128,
        BlockSize = 128,
        Key = keyBytes,
        IV = keyBytes
      };
    }
    public byte[] Encrypt(byte[] plainBytes, RijndaelManaged rijndaelManaged)
    {
      return rijndaelManaged.CreateEncryptor()
          .TransformFinalBlock(plainBytes, 0, plainBytes.Length);
    }
    public byte[] Decrypt(byte[] encryptedData, RijndaelManaged rijndaelManaged)
    {
      return rijndaelManaged.CreateDecryptor()
          .TransformFinalBlock(encryptedData, 0, encryptedData.Length);
    }
    public String EncriptarLicencia(String plainText)
    {
      var plainBytes = Encoding.UTF8.GetBytes(plainText);
      return Convert.ToBase64String(Encrypt(plainBytes, GetRijndaelManaged(SecretLic)));
    }
    public String DesencriptarLicencia(String encryptedText)
    {
      var encryptedBytes = Convert.FromBase64String(encryptedText);
      return Encoding.UTF8.GetString(Decrypt(encryptedBytes, GetRijndaelManaged(SecretLic)));
    }
    #endregion
    #region ObtenerMac
    public String ObtenerDireccionMAC()
    {
      string macAddresses = "";
      foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
      {
        // Only consider Ethernet network interfaces, thereby ignoring any
        // loopback devices etc.
        if (nic.NetworkInterfaceType != NetworkInterfaceType.Ethernet) continue;
        if (nic.OperationalStatus == OperationalStatus.Up)
        {
          macAddresses = nic.GetPhysicalAddress().ToString();
          //break;
        }
      }
      return macAddresses;
    }
    public String SerialNumberBios()
    {
      var serialNumber = "";
      ManagementObjectSearcher Bios = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS");
      foreach (ManagementObject getserial in Bios.Get())
      {
        serialNumber = getserial["SerialNumber"].ToString();
      }
      return serialNumber;
    }
    public String SeralNumberBase()
    {
      var serialNumber = "";
      ManagementObjectSearcher MOS = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
      foreach (ManagementObject getserial in MOS.Get())
      {
        serialNumber = getserial["SerialNumber"].ToString();
      }
      return serialNumber;
    }
    #endregion
  }
}
