using System;
using System.Linq;
using NETCore.Encrypt;

namespace Yashil.Common.SharedKernel.Helpers
{
    public static class CryptographyHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Value cannot be empty or whitespace only string.", nameof(password));

            using var hmac = new System.Security.Cryptography.HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

        public static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Value cannot be empty or whitespace only string.", nameof(password));
            if (storedHash.Length != 64)
                throw new ArgumentException("Invalid length of password hash (64 bytes expected).", nameof(storedHash));
            if (storedSalt.Length != 128)
                throw new ArgumentException("Invalid length of password salt (128 bytes expected).",
                    nameof(storedSalt));


            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                if (computedHash.Where((t, i) => t != storedHash[i]).Any())
                {
                    return false;
                }
            }

            return true;
        }

        /*
         *   CryptographyHelper.AesKey = "MhJMpckQWBMVZdkkRgMQPslZPSpIYfCY";
            CryptographyHelper.AesIv = "xApR40xu823N1DFs";
         */
        public static string AesKey = "MhJMpckQWBMVZdkkRgMQPslZPSpIYfCY";
        public static string AesIv = "xApR40xu823N1DFs";

        public static string AesDecrypt(string txt)
        {
            return EncryptProvider.AESDecrypt(txt, AesKey, AesIv);
        }

        public static string AesEncrypt(string txt)
        {
            return EncryptProvider.AESEncrypt(txt, AesKey, AesIv);
        }

        /*public static void aaa()
        {
            var aesKey = EncryptProvider.CreateAesKey();
            var key = aesKey.Key;
            var iv = aesKey.IV;


            var plaintext = "Hello world 123456789/*-+!@#$%^&*()-=_+";

            var decrypted = EncryptProvider.AESDecrypt(encrypted, key, iv);

            Console.WriteLine("Plaintext to encrypt: " + plaintext);
            Console.WriteLine();

            Console.WriteLine("** AES SecureRandom **");
            Console.WriteLine("Encrypted " + " (Length: " + encrypted.Length + ") " + encrypted);
            Console.WriteLine("Decrypted " + " (Length: " + decrypted.Length + ") " + decrypted);
            Console.WriteLine("Key: {0} IV: {1}", key, iv);

            Console.WriteLine();
            Console.WriteLine("** AES SecureRandom with Byte input/output **");
            byte[] bencrypted = EncryptProvider.AESEncrypt(Encoding.UTF8.GetBytes(plaintext), key, iv);
            byte[] bdecrypted = EncryptProvider.AESDecrypt(bencrypted, key, iv);

            Console.WriteLine("Encrypted " + " (Length: " + bencrypted.Length + ") " +
                              Encoding.UTF8.GetString(bencrypted));
            Console.WriteLine("Decrypted " + " (Length: " + bdecrypted.Length + ") " +
                              Encoding.UTF8.GetString(bdecrypted));
            Console.WriteLine("Key: {0} IV: {1}", key, iv);

            Console.WriteLine();

            Console.WriteLine("** AES Non-SecureRandom **");

            aesKey = EncryptProvider.CreateAesKey();
            key = aesKey.Key;
            iv = aesKey.IV;

            encrypted = EncryptProvider.AESEncrypt(plaintext, key, iv);
            decrypted = EncryptProvider.AESDecrypt(encrypted, key, iv);
            Console.WriteLine("Encrypted " + " (Length: " + encrypted.Length + ") " + encrypted);
            Console.WriteLine("Decrypted " + " (Length: " + decrypted.Length + ") " + decrypted);
            Console.WriteLine("Key: {0} IV: {1}", key, iv);

            Console.WriteLine();
            Console.WriteLine("** RSA **");
            var rsaKey = EncryptProvider.CreateRsaKey();

            var publicKey = rsaKey.PublicKey;
            var privateKey = rsaKey.PrivateKey;
            //var exponent = rsaKey.Exponent;
            //var modulus = rsaKey.Modulus;

            encrypted = EncryptProvider.RSAEncrypt(publicKey, plaintext);

            encrypted = EncryptProvider.RSAEncrypt(publicKey, plaintext, RSAEncryptionPadding.Pkcs1);
            decrypted = EncryptProvider.RSADecrypt(privateKey, encrypted, RSAEncryptionPadding.Pkcs1);


            Console.WriteLine("Encrypted: " + encrypted);
            Console.WriteLine("Decrypted: " + decrypted);
            //Console.WriteLine("publicKey: {0} privateKey: {1}", publicKey, privateKey);

            Console.WriteLine();
            Console.WriteLine("** SHA **");
            Console.WriteLine("SHA1: " + EncryptProvider.Sha1(plaintext));
            Console.WriteLine("SHA256: " + EncryptProvider.Sha256(plaintext));
            Console.WriteLine("SHA384: " + EncryptProvider.Sha384(plaintext));
            Console.WriteLine("SHA512: " + EncryptProvider.Sha512(plaintext));


            Console.WriteLine();
            Console.WriteLine("** Test issues #25  https://github.com/myloveCc/NETCore.Encrypt/issues/25 **");

            rsaKey = EncryptProvider.CreateRsaKey();

            publicKey = rsaKey.PublicKey;
            privateKey = rsaKey.PrivateKey;

            var testStr = "test issues #25 ";

            Console.WriteLine($"Test str:{testStr}");

            var saveDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Split("NETCore.Encrypt.Demo")[0],
                "Framework472.EncryptDemo\\bin\\Debug");

            //save public key
            var publicKeySavePath = Path.Combine(saveDir, "privateKey.txt");
            if (File.Exists(publicKeySavePath))
            {
                File.Delete(publicKeySavePath);
            }

            using (FileStream fs = new FileStream(publicKeySavePath, FileMode.CreateNew))
            {
                fs.Write(Encoding.UTF8.GetBytes(privateKey));
            }

            //save encrypt text
            var encryptStr = EncryptProvider.RSAEncrypt(publicKey, testStr, RSAEncryptionPadding.Pkcs1);
            Console.WriteLine($"encryped str:{encryptStr}");
            var encryptSavePath = Path.Combine(saveDir, "encrypt.txt");

            if (File.Exists(encryptSavePath))
            {
                File.Delete(encryptSavePath);
            }

            using (FileStream fs = new FileStream(encryptSavePath, FileMode.CreateNew))
            {
                fs.Write(Encoding.UTF8.GetBytes(encryptStr));
            }

            Console.ReadKey();
        }
    }
}*/
    }
}