//-----------------------------------------------------------------------
// <copyright file="UrlEncoder.cs" company="Genesys Source">
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
    public class UrlEncoder : IEncoder
    {
        private string dataIn = TypeExtension.DefaultString;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dataToProcess">Data to encrypt or decrypt</param>
        public UrlEncoder(string dataToProcess) : base()
        {
            this.dataIn = dataToProcess;
        }

        /// <summary>
        /// Encodes to Base64
        /// </summary>
        /// <returns></returns>
        public string Encode()
        {            
            return Uri.EscapeDataString(dataIn).Replace("+", "%20");
        }

        /// <summary>
        /// Encodes to Base64
        /// </summary>
        /// <param name="stringToEncode"></param>
        /// <returns></returns>
        public static string Encode(string stringToEncode)
        {
            UrlEncoder encoder = new UrlEncoder(stringToEncode);
            return encoder.Encode();
        }

        /// <summary>
        /// Decodes from Base64
        /// </summary>
        /// <returns></returns>
        public string Decode()
        {
            return Uri.UnescapeDataString(dataIn).Replace("%20", "+");
        }

        /// <summary>
        /// Decodes from Base64
        /// </summary>
        /// <param name="stringToDecode"></param>
        /// <returns></returns>
        public static string Decode(string stringToDecode)
        {
            UrlEncoder encoder = new UrlEncoder(stringToDecode);
            return encoder.Decode();
        }
    }
}
