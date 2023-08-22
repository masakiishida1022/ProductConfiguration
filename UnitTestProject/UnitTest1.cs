using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using ProductConfiguration;
using System.Drawing;
using System.Globalization;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int counts = 10;
            Random random = new Random();
            var encryptor = new RandomStringEncryptor();
            for (int i = 0; i < counts; i++) {
                string original = GenerateRandomString(10, random);
                string encrypted =  encryptor.Encrypt(original);
                string decrypted =  encryptor.Decrypt(encrypted);
                Assert.AreEqual(original,decrypted);
                
            }



        }

        public static string GenerateRandomString(int length, Random random)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            
            char[] stringChars = new char[length];

            for (int i = 0; i < length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(stringChars);
        }
    

       
    }

   
}
