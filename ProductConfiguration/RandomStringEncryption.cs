using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductConfiguration
{
   
   
 
    public class RandomStringEncryptor
    {
        private string[] Keys = new string[]{"eserncer", "uietdsbej", "decatyss","dfadfadseke", "fsdvdfrfdsaf" };
        private int EncriptCount = 5; 
        private Random random = new Random(Environment.TickCount);

        public string Encrypt(string rawstring)
        {
            
        
            var input = rawstring;
            for (int i = 0; i < this.EncriptCount; i++) {
                int keyIndex = random.Next() % this.Keys.Length;
                input = this.Encrypt(input, this.Keys[keyIndex]) + keyIndex;
            }
            return input;
        }
        public string Decrypt(string encryptedString)
        {
            var reverted = encryptedString;
            for (int i = 0; i < this.EncriptCount; i++)
            {
                var stringParts = reverted.Substring(0, reverted.Length - 1);
                var patternIdParts = int.Parse(reverted[reverted.Length - 1].ToString());
                reverted = this.Decrypt(stringParts, this.Keys[patternIdParts]);
            }

            return reverted;
  
        }

        private string Encrypt(string input, string key)
        {
            char[] encryptedChars = new char[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                char originalChar = input[i];
                char keyChar = key[i % key.Length];

                // 文字の暗号化
                char encryptedChar = (char)(originalChar ^ keyChar);

                encryptedChars[i] = encryptedChar;
            }

            return new string(encryptedChars);
        }
        private string Decrypt(string input, string key)
        {
             return Encrypt(input, key);
        }

    }
}
