﻿using System;
using System.Security.Cryptography;
using System.Text;


namespace SafeChargeRest

{
    class GetSessionTokenChecksumCalc
    {
        private static void Main(string[] args)
        {

            string merchantId = "3832456837996201334";
            string merchantSiteId = "184063";
            string clientRequestId = DateTime.Now.ToString("hhmmddMMyy");
            string timeStamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string merchantSecretKey = "puT8KQYqIbbQDHN5cQNAlYyuDedZxRYjA9WmEsKq1wrIPhxQqOx77Ep1uOA7sUde";
            string checksum = ComputeSha256Hash(
                merchantId
                + merchantSiteId
                + clientRequestId
                + timeStamp
                + merchantSecretKey
                );
            Console.WriteLine("{");
            Console.WriteLine("\"merchantId\": \"{0}\",", merchantId);
            Console.WriteLine("\"merchantSiteId\": {0},", merchantSiteId);
            Console.WriteLine("\"clientRequestId\": \"{0}\",", clientRequestId);
            Console.WriteLine("\"timeStamp\": \"{0}\",", timeStamp);
            Console.WriteLine("\"checksum\": \"{0}\"", checksum);
            Console.WriteLine("}");

            Console.ReadLine();

            string ComputeSha256Hash(string rawData)
            {
                // Creates a SHA256   (Works the same way for SHA256)
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    // ComputeHash - returns byte array  
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                    // Converts byte array to a string   
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        // x2 for lowercase, X2 for uppercase
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    return builder.ToString();
                }
            }
        }
    }
}