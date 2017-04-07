//-----------------------------------------------------------------------
// <copyright file="HttpRequestExtension.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
// 
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Web;

namespace Genesys.Extensions
{
    /// <summary>
    /// HttpRequestExtension
    /// </summary>
    [CLSCompliant(true)]
    public static class HttpRequestExtension
    {
        /// <summary>
        /// Finds the root of the url in format: http://SERVER_NAME:SERVER_PORT
        /// </summary>
        /// <param name="item">Request to supply url</param>
        /// <returns>Parsed Url</returns>
        public static string TryParseUrl(this HttpRequest item)
        {
            return HttpRequestBaseExtension.ConstructUrl(item.ServerVariables["SERVER_PORT_SECURE"], item.ServerVariables["SERVER_NAME"], item.ServerVariables["SERVER_PORT"], item.ApplicationPath);
        }

        /// <summary>
        /// Checks for HTTPS, or returns true if localhost
        /// </summary>
        /// <param name="item">Request to check security</param>
        /// <returns>True if request is secured with ssl, or localhost</returns>
        public static bool IsSecured(this HttpRequest item)  
        {
            return HttpRequestBaseExtension.IsSecured(item.IsSecureConnection, item.Url.ToString());
        }

        /// <summary>
        /// Writes bytes to Html Binary Output Stream. 
        /// Mainly for sending Images/Blobs over http, typically from data access framework to a Html Page img tag.
        /// </summary>
        /// <param name="item">Item to write byte array</param>
        /// <param name="blobBytes">Byte array to write</param>
        public static void BinaryWriteSafe(this HttpResponse item, byte[] blobBytes)
        {
            if ((blobBytes == null == false) && (blobBytes.Length > 0))
            {
                item.BinaryWrite(blobBytes);
            }
        }
    }
}
