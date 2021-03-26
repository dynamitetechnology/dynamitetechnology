using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace Paykun
{
    public class Crypto
    {
        private static readonly Encoding encoding = Encoding.UTF8;

        public string Encrypt(string _plainText, string _encKey)
        {
            string _iv = null;
            string _encText = this.EncryptInternal(_plainText, _encKey, ref _iv);
            string _hmac = this.GetHMAC((_iv + _encText), _encKey);
            Dictionary<string, string> _encData = new Dictionary<string, string>();
            _encData.Add("iv", _iv);
            _encData.Add("value", _encText);
            _encData.Add("mac", _hmac);
            string _finalString = this.DictionaryToJson(_encData);
    
            return Convert.ToBase64String(encoding.GetBytes(_finalString));
        }

        private string EncryptInternal(string _plainText, string _encKey, ref string _iv)
        {
            try
            {
                RijndaelManaged aes = new RijndaelManaged();
                aes.KeySize = 256;
                aes.BlockSize = 128;
                aes.Padding = PaddingMode.PKCS7;
                aes.Mode = CipherMode.CBC;

                aes.Key = encoding.GetBytes(_encKey);
                aes.GenerateIV();

                var IV = aes.IV;
                _iv = Convert.ToBase64String(IV);
                ICryptoTransform AESEncrypt = aes.CreateEncryptor(aes.Key, IV);

                _plainText = (new Serializer()).Serialize(_plainText);

                byte[] buffer = encoding.GetBytes(_plainText);

                string encryptedText = Convert.ToBase64String(AESEncrypt.TransformFinalBlock(buffer, 0, buffer.Length));

                return encryptedText;
            }
            catch (Exception e)
            {
                throw new Exception("Error encrypting: " + e.Message);
            }
        }

        private String GetHMAC(String text, String key)
        {
            // change according to your needs, an UTF8Encoding
            // could be more suitable in certain situations
            ASCIIEncoding encoding = new ASCIIEncoding();

            Byte[] textBytes = encoding.GetBytes(text);
            Byte[] keyBytes = encoding.GetBytes(key);

            Byte[] hashBytes;

            using (HMACSHA256 hash = new HMACSHA256(keyBytes))
                hashBytes = hash.ComputeHash(textBytes);

            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }

        public string DictionaryToJson(Dictionary<string, string> dict)
        {
            var entries = dict.Select(d =>
                string.Format("\"{0}\": \"{1}\"", d.Key, string.Join(",", d.Value)));
            return "{" + string.Join(",", entries) + "}";
        }

    }

    public class Serializer
    {
        //types:
        // N = null
        // s = string
        // i = int
        // d = double
        // a = array (hashtable)

        private Dictionary<Hashtable, bool> seenHashtables; //for serialize (to infinte prevent loops)
        private Dictionary<ArrayList, bool> seenArrayLists; //for serialize (to infinte prevent loops) lol

        private int pos; //for unserialize

        public bool XMLSafe = true; //This member tells the serializer wether or not to strip carriage returns from strings when serializing and adding them back in when deserializing
                                    //http://www.w3.org/TR/REC-xml/#sec-line-ends

        public Encoding StringEncoding = new System.Text.UTF8Encoding();

        private System.Globalization.NumberFormatInfo nfi;

        public Serializer()
        {
            this.nfi = new System.Globalization.NumberFormatInfo();
            this.nfi.NumberGroupSeparator = "";
            this.nfi.NumberDecimalSeparator = ".";
        }

        public string Serialize(object obj)
        {
            this.seenArrayLists = new Dictionary<ArrayList, bool>();
            this.seenHashtables = new Dictionary<Hashtable, bool>();

            return this.serialize(obj, new StringBuilder()).ToString();
        }//Serialize(object obj)

        private StringBuilder serialize(object obj, StringBuilder sb)
        {
            if (obj == null)
            {
                return sb.Append("N;");
            }
            else if (obj is string)
            {
                string str = (string)obj;
                if (this.XMLSafe)
                {
                    str = str.Replace("\r\n", "\n");//replace \r\n with \n
                    str = str.Replace("\r", "\n");//replace \r not followed by \n with a single \n  Should we do this?
                }
                return sb.Append("s:" + this.StringEncoding.GetByteCount(str) + ":\"" + str + "\";");
            }
            else if (obj is bool)
            {
                return sb.Append("b:" + (((bool)obj) ? "1" : "0") + ";");
            }
            else if (obj is int)
            {
                int i = (int)obj;
                return sb.Append("i:" + i.ToString(this.nfi) + ";");
            }
            else if (obj is long)
            {
                long i = (long)obj;
                return sb.Append("i:" + i.ToString(this.nfi) + ";");
            }
            else if (obj is double)
            {
                double d = (double)obj;

                return sb.Append("d:" + d.ToString(this.nfi) + ";");
            }
            else if (obj is ArrayList)
            {
                if (this.seenArrayLists.ContainsKey((ArrayList)obj))
                    return sb.Append("N;");//cycle detected
                else
                    this.seenArrayLists.Add((ArrayList)obj, true);

                ArrayList a = (ArrayList)obj;
                sb.Append("a:" + a.Count + ":{");
                for (int i = 0; i < a.Count; i++)
                {
                    this.serialize(i, sb);
                    this.serialize(a[i], sb);
                }
                sb.Append("}");
                return sb;
            }
            else if (obj is Hashtable)
            {
                if (this.seenHashtables.ContainsKey((Hashtable)obj))
                    return sb.Append("N;");//cycle detected
                else
                    this.seenHashtables.Add((Hashtable)obj, true);

                Hashtable a = (Hashtable)obj;
                sb.Append("a:" + a.Count + ":{");
                foreach (DictionaryEntry entry in a)
                {
                    this.serialize(entry.Key, sb);
                    this.serialize(entry.Value, sb);
                }
                sb.Append("}");
                return sb;
            }
            else
            {
                return sb;
            }
        }//Serialize(object obj)

        public object Deserialize(string str)
        {
            this.pos = 0;
            return deserialize(str);
        }//Deserialize(string str)

        private object deserialize(string str)
        {
            if (str == null || str.Length <= this.pos)
                return new Object();

            int start, end, length;
            string stLen;
            switch (str[this.pos])
            {
                case 'N':
                    this.pos += 2;
                    return null;
                case 'b':
                    char chBool;
                    chBool = str[pos + 2];
                    this.pos += 4;
                    return chBool == '1';
                case 'i':
                    string stInt;
                    start = str.IndexOf(":", this.pos) + 1;
                    end = str.IndexOf(";", start);
                    stInt = str.Substring(start, end - start);
                    this.pos += 3 + stInt.Length;
                    object oRet = null;
                    try
                    {
                        //firt try to parse as int
                        oRet = Int32.Parse(stInt, this.nfi);
                    }
                    catch
                    {
                        //if it failed, maybe it was too large, parse as long
                        oRet = Int64.Parse(stInt, this.nfi);
                    }
                    return oRet;
                case 'd':
                    string stDouble;
                    start = str.IndexOf(":", this.pos) + 1;
                    end = str.IndexOf(";", start);
                    stDouble = str.Substring(start, end - start);
                    this.pos += 3 + stDouble.Length;
                    return Double.Parse(stDouble, this.nfi);
                case 's':
                    start = str.IndexOf(":", this.pos) + 1;
                    end = str.IndexOf(":", start);
                    stLen = str.Substring(start, end - start);
                    int bytelen = Int32.Parse(stLen);
                    length = bytelen;
                    //This is the byte length, not the character length - so we might  
                    //need to shorten it before usage. This also implies bounds checking
                    if ((end + 2 + length) >= str.Length) length = str.Length - 2 - end;
                    string stRet = str.Substring(end + 2, length);
                    while (this.StringEncoding.GetByteCount(stRet) > bytelen)
                    {
                        length--;
                        stRet = str.Substring(end + 2, length);
                    }
                    this.pos += 6 + stLen.Length + length;
                    if (this.XMLSafe)
                    {
                        stRet = stRet.Replace("\n", "\r\n");
                    }
                    return stRet;
                case 'a':
                    //if keys are ints 0 through N, returns an ArrayList, else returns Hashtable
                    start = str.IndexOf(":", this.pos) + 1;
                    end = str.IndexOf(":", start);
                    stLen = str.Substring(start, end - start);
                    length = Int32.Parse(stLen);
                    Hashtable htRet = new Hashtable(length);
                    ArrayList alRet = new ArrayList(length);
                    this.pos += 4 + stLen.Length; //a:Len:{
                    for (int i = 0; i < length; i++)
                    {
                        //read key
                        object key = deserialize(str);
                        //read value
                        object val = deserialize(str);

                        if (alRet != null)
                        {
                            if (key is int && (int)key == alRet.Count)
                                alRet.Add(val);
                            else
                                alRet = null;
                        }
                        htRet[key] = val;
                    }
                    this.pos++; //skip the }
                    if (this.pos < str.Length && str[this.pos] == ';')//skipping our old extra array semi-colon bug (er... php's weirdness)
                        this.pos++;
                    if (alRet != null)
                        return alRet;
                    else
                        return htRet;
                default:
                    return "";
            }//switch
        }//unserialzie(object)	
    }//class Serializer
}
