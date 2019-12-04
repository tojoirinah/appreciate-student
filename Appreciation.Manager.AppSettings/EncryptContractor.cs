using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Appreciation.Manager.Utils
{
    public class EncryptContractor
    {
        private string DefaultIv;
        private string DefaultKey;

        private static readonly int MAX_SALT_LEN = 8;
        private static readonly int MIN_SALT_LEN = 4;

#pragma warning disable CS0649 // Le champ 'EncryptContractor._instance' n'est jamais assigné et aura toujours sa valeur par défaut null
        private static readonly EncryptContractor _instance;
#pragma warning restore CS0649 // Le champ 'EncryptContractor._instance' n'est jamais assigné et aura toujours sa valeur par défaut null

        public static EncryptContractor Instance
        {
            get
            {
                return _instance ?? new EncryptContractor();
            }
        }

        private EncryptContractor() { }

        public EncryptContractor SetDefault(string defaultIv, string defaultKey)
        {
            DefaultIv = defaultIv;
            DefaultKey = defaultKey;
            return this;
        }

        public string GenerateEncryptedSecuritySalt()
        {
            // 1. On génère une taille de SALT aleatoire
            Random random = new Random(Guid.NewGuid().GetHashCode());
            int saltSize = random.Next(MIN_SALT_LEN, MAX_SALT_LEN);

            byte[] saltBytes = new byte[saltSize];

            // 2. On génère un SALT aleatoire
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetNonZeroBytes(saltBytes);
            var dynamicSalt = Convert.ToBase64String(saltBytes);

            var iVBt = GetBytes(DefaultIv);
            var keyBt = GetBytes(DefaultKey);

            // 3. On encrypte le SALT
            var encryptedDynamicSalt = dynamicSalt + "|" + Encoding.ASCII.GetString(iVBt, 0, iVBt.Length) + "|" + Encoding.ASCII.GetString(keyBt, 0, keyBt.Length);

            return encryptedDynamicSalt;
        }



        byte[] GetBytes(string Data)
        {
            const string chars = "aAbBcCdDeEfFgGhHiIjJkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ0123456789";
            var random = new Random();
            string Key = new string(Enumerable.Repeat(chars, 64).Select(s => s[random.Next(s.Length)]).ToArray());
            string IV = new string(Enumerable.Repeat(chars, 64).Select(s => s[random.Next(s.Length)]).ToArray());

            // String EData = EncryptString(Data,IV,Key);
            String SendData = Data + "|" + Key + "|" + IV;

            return Encoding.ASCII.GetBytes(SendData);
        }


    }
}
