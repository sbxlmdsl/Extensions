//-----------------------------------------------------------------------
// <copyright file="Base64Encoder.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using Genesys.Extensions;

namespace Genesys.Extras.Text.Encoding
{
    /// <summary>
    /// Encoders and decodes Base64 text
    /// </summary>
    [CLSCompliant(true)]
    public class Base64Encoder : IEncoder
    {
        private string dataIn = TypeExtension.DefaultString;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dataToProcess">Data to encrypt or decrypt</param>
        public Base64Encoder(string dataToProcess) : base()
        {
            dataIn = dataToProcess;
        }

        /// <summary>
        /// Encodes to Base64
        /// </summary>
        /// <returns></returns>
        public string Encode()
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(dataIn);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// Encodes to Base64
        /// </summary>
        /// <param name="stringToEncode"></param>
        /// <returns></returns>
        public static string Encode(string stringToEncode)
        {
            Base64Encoder encoder = new Base64Encoder(stringToEncode);
            return encoder.Encode();
        }

        /// <summary>
        /// Decodes from Base64
        /// </summary>
        /// <returns></returns>
        public string Decode()
        {
            byte[] bytes = Convert.FromBase64String(dataIn);
            return System.Text.Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Decodes from Base64
        /// </summary>
        /// <param name="stringToDecode"></param>
        /// <returns></returns>
        public static string Decode(string stringToDecode)
        {
            Base64Encoder encoder = new Base64Encoder(stringToDecode);
            return encoder.Decode();
        }
    }
}
