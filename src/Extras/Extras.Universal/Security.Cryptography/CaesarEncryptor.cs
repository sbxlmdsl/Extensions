//-----------------------------------------------------------------------
// <copyright file="CaesarEncryptor.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Text;
using Genesys.Extensions;
using Genesys.Extras.Mathematics;
using Genesys.Extras.Text.Encoding;

namespace Genesys.Extras.Security.Cryptography
{
    /// <summary>
    /// Caesar substitution encryption
    /// </summary>
    [CLSCompliant(true)]
    public class CaesarEncryptor : IEncryptor
    {
        /// <summary>
        /// Key
        /// </summary>
        public string Key { get; private set; } = "25";

        /// <summary>
        /// Salt
        /// </summary>
        public string Salt { get; private set; } = Arithmetic.Random().ToString();

        /// <summary>
        /// EncodeForURL
        /// </summary>
        public bool EncodeForURL { get; protected set; } = TypeExtension.DefaultBoolean;
        
        /// <summary>
        /// Force immutability
        /// </summary>
        private CaesarEncryptor()
            : base()
        {
            EncodeForURL = true;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="encryptionKey"></param>
        /// <param name="urlEncode"></param>
        public CaesarEncryptor(string encryptionKey = "", bool urlEncode = true)
            : this()
        {
            Key = Arithmetic.Addition(encryptionKey.TryParseDecimal(), this.Key.TryParseInt16()).ToShort().ToString();
            EncodeForURL = urlEncode;
        }
        
        /// <summary>
        /// Encrypts a String
        /// </summary>
        public string Encrypt(string originalString)
        {
            var returnValue = TypeExtension.DefaultString;
            var shiftedString = TypeExtension.DefaultString;
            byte[] encryptedByte;

            try
            {
                shiftedString = this.ShiftString(originalString, this.Key.TryParseInt16());
                encryptedByte = Encoding.Unicode.GetBytes(shiftedString);
                returnValue = Convert.ToBase64String(encryptedByte);
                if (this.EncodeForURL)
                {
                    returnValue = UrlEncoder.Encode(returnValue);
                }
            }
            catch (Exception ex)
            {
                returnValue = ex.Message;
                returnValue = TypeExtension.DefaultString;
            }

            return returnValue;
        }
        
        /// <summary>
        /// Decrypts an salted String
        /// </summary>
        /// <param name="originalString"></param>
        public string Decrypt(string originalString)
        {
            var returnValue = TypeExtension.DefaultString;
            byte[] encryptedByte;

            try
            {
                originalString = this.EncodeForURL == true ? UrlEncoder.Decode(originalString) : originalString;
                encryptedByte = Convert.FromBase64String(originalString);
                originalString = Encoding.Unicode.GetString(encryptedByte, 0, encryptedByte.Length);
                returnValue = this.ShiftString(originalString, Arithmetic.Multiply(this.Key.TryParseInt16(), -1).ToShort());
            }
            catch(Exception ex)
            {
                returnValue = ex.Message;
                returnValue = TypeExtension.DefaultString;
            }

            return returnValue;
        }
        
        /// <summary>
        /// Perform the encryption
        /// </summary>
        /// <param name="source"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        private string ShiftString(string source, short shift)
        {
            var returnValue = TypeExtension.DefaultString;
            var shiftedValue = TypeExtension.DefaultInteger;
            var charMax = Convert.ToInt32(char.MaxValue);
            var charMin = Convert.ToInt32(char.MinValue);
            char[] chars = source.ToCharArray();

            for (var Count = 0; Count < chars.Length; Count++)
            {
                shiftedValue = Convert.ToInt32(chars[Count]) + shift;

                if (shiftedValue > charMax)
                {
                    shiftedValue -= charMax;
                } else if (shiftedValue < charMin)
                {
                    shiftedValue += charMax;
                }

                chars[Count] = Convert.ToChar(shiftedValue);
            }
            returnValue = new String(chars);

            return returnValue;
        }
    }
}
