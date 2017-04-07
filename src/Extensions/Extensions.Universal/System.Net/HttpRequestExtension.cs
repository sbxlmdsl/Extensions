//-----------------------------------------------------------------------
// <copyright file="HttpRequestExtension.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Net;

namespace Genesys.Extensions
{
    /// <summary>
    /// HttpRequestBaseExtension
    /// </summary>
    [CLSCompliant(true)]
    public static class HttpWebRequestExtension
    {
        /// <summary>
        /// Finds the root of the URL in format: HTTP://SERVER_NAME:SERVER_PORT
        /// </summary>
        /// <param name="item">Item to parse</param>
        /// <returns>Url from item</returns>
        public static string TryParseUrl(this HttpWebRequest item)
        {
            return item.RequestUri.AbsolutePath;
        }
        
        /// <summary>
        /// Checks for HTTPS, or returns true if ://localhost
        /// </summary>
        /// <param name="item">Item to parse</param>
        /// <returns>True if secured</returns>
        public static bool IsSecured(this HttpWebRequest item)
        {
            bool returnValue = TypeExtension.DefaultBoolean;

            if (item.IsSecured() | item.RequestUri.ToString().ToString().Contains("://localhost"))
            {
                returnValue = true;
            }

            return returnValue;
        }               
    }
}
