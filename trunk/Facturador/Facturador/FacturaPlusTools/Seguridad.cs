using System;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Text;
using System.Configuration;


namespace FacturaPlusTools
{
    public class Crypt
    {
        public string MD5(string input)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] data = md5Hasher.ComputeHash(System.Text.Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public string B64Encode(string input)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            return Convert.ToBase64String(encoding.GetBytes(input));
        }

        public string B64Decode(string input)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            return encoding.GetString(Convert.FromBase64String(input));
        }
        public bool compare(string string1, string string2)
        {
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            if (comparer.Compare(string1, string2) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string getToken(string s)
        {
            Regex r = new Regex("[^a-zA-Z]");
            return r.Replace(this.MD5(s), "");
        }


        public string makeToken(int uid)
        {
            DateTime today = DateTime.Now;
            string day = today.ToString("%d");
            string hour = today.ToString("%H");
            string ampm = (Convert.ToInt32(hour) < 12) ? "a" : "p";
            return this.getToken(Convert.ToString(uid) + day + ampm);
        }

        public bool checkToken(int uid, string token)
        {
            uid = (uid == 0) ? 99999999 : uid;
            if (token == this.makeToken(uid))
            {
                return true;
            }
            else
            {
                DateTime today = DateTime.Now;
                string day = today.ToString("%d");
                string hour = today.ToString("%H");
                string ampm = (Convert.ToInt32(hour) < 12) ? "p" : "a";
                if (hour == "12")
                {
                    return (this.getToken(Convert.ToString(uid) + day + ampm) == token);
                }
                else if (Convert.ToInt32(hour) < 2)
                {
                    DateTime yesterday = today.AddHours(-5);
                    day = yesterday.ToString("%d");
                    return (this.getToken(Convert.ToString(uid) + day + ampm) == token);
                }
                else
                {
                    return false;
                }
            }
        }


        public static string readPublicKeyFromWebConfig()
        {
            return ConfigurationManager.AppSettings["PublicKey"]; 
        }


        public static string readPrivateKeyFromWebConfig()
        {
            return  ConfigurationManager.AppSettings["PrivateKey"];
        }


        public static byte[] encryptRSAFromWebConfig(String text)
        {
            String publicKey = readPublicKeyFromWebConfig();
            if (!publicKey.Equals(String.Empty))
            {
                return encryptRSA(text, publicKey);
            }
            else
            {
                return null;
            }
        }


        public static String decryptRSAFromWebConfig(byte[] encryptedData)
        {
            String privateKey = readPublicKeyFromWebConfig();
            if (!privateKey.Equals(String.Empty))
            {
                return decryptRSA(encryptedData, privateKey);
            }
            else
            {
                return null;
            }
        }


        public static string readKeyFromFile(String pathToFile)
        {
            try
            {
                System.IO.FileStream fs = new System.IO.FileStream(pathToFile, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
                System.IO.StreamReader reader = new System.IO.StreamReader(fs);
                String key = reader.ReadToEnd();
                return key;
            }
            catch (Exception ex)
            {
                return String.Empty;
            }
        }


        public static Byte[] encryptRSAFromFile(String text, String publicKeyPath)
        {
            String publicKey = readKeyFromFile(publicKeyPath);
            if (!publicKey.Equals(String.Empty))
            {
                return encryptRSA(text, publicKey);
            }
            else
            {
                return null;
            }
        }


        public static String decryptRSAFromFile(byte[] encryptedData, String privateKeyPath)
        {
            String privateKey = readKeyFromFile(privateKeyPath);
            if (!privateKey.Equals(String.Empty))
            {
                return decryptRSA(encryptedData, privateKey);
            }
            else
            {
                return null;
            }
        }


        public static Byte[] encryptRSA(String text, String publicKey)
        {

            try
            {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(publicKey);
                Byte[] data = Encoding.Default.GetBytes(text);

                return rsa.Encrypt(data, false);
            }
            catch (System.Security.XmlSyntaxException xmle)
            {
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static String decryptRSA(byte[] encryptedData, String privateKey)
        {
            try
            {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(privateKey);

                Byte[] decryptedData = rsa.Decrypt(encryptedData, false);
                return Encoding.Default.GetString(decryptedData);
            }
            catch (System.Security.XmlSyntaxException xmle)
            {
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}