using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace YudianBlog.Infrastructure.Common
{
    /// <summary>
    /// 加密类
    /// </summary>
    public class DEncryptHelper
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public DEncryptHelper()
        {
        }

        #region 使用 缺省密钥字符串 加密/解密string

        /// <summary>
        /// 使用缺省密钥字符串加密string
        /// </summary>
        /// <param name="original">明文</param>
        /// <returns>密文</returns>
        public static string Encrypt(string original)
        {
            return Encrypt(original, "ZXJ");
        }
        /// <summary>
        /// 使用缺省密钥字符串解密string
        /// </summary>
        /// <param name="original">密文</param>
        /// <returns>明文</returns>
        public static string Decrypt(string original)
        {
            return Decrypt(original, "ZXJ", System.Text.Encoding.Default);
        }

        #endregion

        #region 使用 给定密钥字符串 加密/解密string
        /// <summary>
        /// 使用给定密钥字符串加密string
        /// </summary>
        /// <param name="original">原始文字</param>
        /// <param name="key">密钥</param>
        /// <param name="encoding">字符编码方案</param>
        /// <returns>密文</returns>
        public static string Encrypt(string original, string key)
        {
            byte[] buff = System.Text.Encoding.Default.GetBytes(original);
            byte[] kb = System.Text.Encoding.Default.GetBytes(key);
            return Convert.ToBase64String(Encrypt(buff, kb));
        }
        /// <summary>
        /// 使用给定密钥字符串解密string
        /// </summary>
        /// <param name="original">密文</param>
        /// <param name="key">密钥</param>
        /// <returns>明文</returns>
        public static string Decrypt(string original, string key)
        {
            return Decrypt(original, key, System.Text.Encoding.Default);
        }

        /// <summary>
        /// 使用给定密钥字符串解密string,返回指定编码方式明文
        /// </summary>
        /// <param name="encrypted">密文</param>
        /// <param name="key">密钥</param>
        /// <param name="encoding">字符编码方案</param>
        /// <returns>明文</returns>
        public static string Decrypt(string encrypted, string key, Encoding encoding)
        {
            byte[] buff = Convert.FromBase64String(encrypted);
            byte[] kb = System.Text.Encoding.Default.GetBytes(key);
            return encoding.GetString(Decrypt(buff, kb));
        }
        #endregion

        #region 使用 缺省密钥字符串 加密/解密/byte[]
        /// <summary>
        /// 使用缺省密钥字符串解密byte[]
        /// </summary>
        /// <param name="encrypted">密文</param>
        /// <param name="key">密钥</param>
        /// <returns>明文</returns>
        public static byte[] Decrypt(byte[] encrypted)
        {
            byte[] key = System.Text.Encoding.Default.GetBytes("MATICSOFT");
            return Decrypt(encrypted, key);
        }
        /// <summary>
        /// 使用缺省密钥字符串加密
        /// </summary>
        /// <param name="original">原始数据</param>
        /// <param name="key">密钥</param>
        /// <returns>密文</returns>
        public static byte[] Encrypt(byte[] original)
        {
            byte[] key = System.Text.Encoding.Default.GetBytes("MATICSOFT");
            return Encrypt(original, key);
        }
        #endregion

        #region  使用 给定密钥 加密/解密/byte[]

        /// <summary>
        /// 生成MD5摘要
        /// </summary>
        /// <param name="original">数据源</param>
        /// <returns>摘要</returns>
        public static byte[] MakeMD5(byte[] original)
        {
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            byte[] keyhash = hashmd5.ComputeHash(original);
            hashmd5 = null;
            return keyhash;
        }


        /// <summary>
        /// 使用给定密钥加密
        /// </summary>
        /// <param name="original">明文</param>
        /// <param name="key">密钥</param>
        /// <returns>密文</returns>
        public static byte[] Encrypt(byte[] original, byte[] key)
        {
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = MakeMD5(key);
            des.Mode = CipherMode.ECB;

            return des.CreateEncryptor().TransformFinalBlock(original, 0, original.Length);
        }

        /// <summary>
        /// 使用给定密钥解密数据
        /// </summary>
        /// <param name="encrypted">密文</param>
        /// <param name="key">密钥</param>
        /// <returns>明文</returns>
        public static byte[] Decrypt(byte[] encrypted, byte[] key)
        {
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = MakeMD5(key);
            des.Mode = CipherMode.ECB;

            return des.CreateDecryptor().TransformFinalBlock(encrypted, 0, encrypted.Length);
        }

        /// <summary>
        /// 使用yyyyMMddHHmmss加密
        /// </summary>
        /// <returns></returns>
        public static string GetRandomNumber()
        {
            string randomNumber = "";
            randomNumber = DateTime.Now.ToString("yyyyMMddHHmmss");
            Random rdm = new Random();
            randomNumber = randomNumber + rdm.Next(0x989680, 0x5f5e0ff).ToString();
            rdm = null;
            return randomNumber;
        }

        public static string GetRandomNumber(int length, bool isSleep)
        {
            if (isSleep)
            {
                Thread.Sleep(3);
            }
            string result = "";
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                result = result + random.Next(10).ToString();
            }
            return result;
        }

        public static string GetRandWord(int length)
        {
            string checkCode = string.Empty;
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                char code;
                int number = random.Next();
                if ((number % 2) == 0)
                {
                    code = (char)(0x30 + ((ushort)(number % 10)));
                }
                else
                {
                    code = (char)(0x41 + ((ushort)(number % 0x1a)));
                }
                checkCode = checkCode + code.ToString();
            }
            return checkCode;
        }

        #endregion

        #region 用户名密码加密

        #region 加密算法名称
        /// <summary>
        /// 用于对密码进行散列的算法名称
        /// </summary>
        /// <returns>加密算法的名称</returns>
        public static string PasswordHashType(int passwordHashType)
        {
            string strPasswordHashType = string.Empty;
            switch (passwordHashType)
            {
                case 1:
                    {
                        strPasswordHashType = "SHA1";
                        break;
                    }
                case 2:
                    {
                        strPasswordHashType = "MD5";
                        break;
                    }
                case 3:
                    {
                        strPasswordHashType = "SHA256";
                        break;
                    }
                case 4:
                    {
                        strPasswordHashType = "SHA384";
                        break;
                    }
                case 5:
                    {
                        strPasswordHashType = "SHA512";
                        break;
                    }
                case 6:
                    {
                        strPasswordHashType = "RIPEMD160";
                        break;
                    }
                default:
                    {
                        strPasswordHashType = "SHA1";
                        break;
                    }
            }
            return strPasswordHashType;
        }
        #endregion

        #region 生成随机salt值
        /// <summary>
        /// 生成随机的Salt值
        /// </summary>
        /// <returns>表示Salt值的base64字符串</returns>
        public static string GenerateSalt()
        {
            byte[] data = new byte[0x10];
            new RNGCryptoServiceProvider().GetBytes(data);
            return Convert.ToBase64String(data);
        }
        #endregion

        #region 根据给定的salt值加密字符串
        /// <summary>
        /// 使用给定的Salt值对密码进行散列。
        /// </summary>
        /// <param name="password">密码。</param>
        /// <param name="salt">Salt值。</param>
        /// <param name="passwordHashType">加密类型，可能的值：1,2,3,4,5,6</param>
        /// <returns>经过散列的密码。</returns>
        public static string EncodePassword(string password, string salt, int passwordHashType)
        {
            byte[] src = Encoding.Unicode.GetBytes(password);
            byte[] saltbuf = Convert.FromBase64String(salt);
            byte[] dst = new byte[saltbuf.Length + src.Length];
            byte[] inArray = null;
            Buffer.BlockCopy(saltbuf, 0, dst, 0, saltbuf.Length);
            Buffer.BlockCopy(src, 0, dst, saltbuf.Length, src.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create(PasswordHashType(passwordHashType));
            inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
        #endregion

        #endregion

    }
}
