//-----------------------------------------------------------------------
// <copyright file="HttpRequestExtension.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
//      Licensed to the Apache Software Foundation (ASF) under one or more 
//      contributor license agreements.  See the NOTICE file distributed with 
//      this work for additional information regarding copyright ownership.
//      The ASF licenses this file to You under the Apache License, Version 2.0 
//      (the 'License'); you may not use this file except in compliance with 
//      the License.  You may obtain a copy of the License at 
//       
//        http://www.apache.org/licenses/LICENSE-2.0 
//       
//       Unless required by applicable law or agreed to in writing, software  
//       distributed under the License is distributed on an 'AS IS' BASIS, 
//       WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.  
//       See the License for the specific language governing permissions and  
//       limitations under the License. 
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

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
            var returnValue = TypeExtension.DefaultBoolean;

            if (item.IsSecured() | item.RequestUri.ToString().ToString().Contains("://localhost"))
            {
                returnValue = true;
            }

            return returnValue;
        }

        /// <summary>
        /// Formats the entire URL, complete with PROTOCOL://SERVER_NAME:PORT/APPLICATION_PATH
        /// No trailing slash.
        /// </summary>
        /// <param name="protocol">Protocol for Url. I.e. http</param>
        /// <param name="serverName">Server name for Url. I.e. www.YourDomain.com</param>
        /// <param name="port">Port for Url. I.e. 80</param>
        /// <param name="applicationPath">Application path for Url. I.e. /Home/Index</param>
        /// <returns>Constructed url</returns>
        public static string ConstructUrl(string protocol, string serverName, string port, string applicationPath)
        {
            var urlComplete = TypeExtension.DefaultString;

            if (protocol == null || protocol == "0")
            {
                protocol = "http://";
            } else
            {
                protocol = "https://";
            }
            if (port == null || port == "80" || port == "443")
            {
                port = "";
            } else
            {
                port = ":" + port;
            }
            urlComplete = protocol + serverName + port + applicationPath;
            urlComplete = urlComplete.RemoveLast("/");

            return urlComplete;
        }

        /// <summary>
        /// Formats the entire URL, complete with PROTOCOL://SERVER_NAME:PORT/APPLICATION_PATH?Param1=Value1
        /// </summary>
        /// <param name="urlNoQuerystring">Url with everything but parameters and punctuation</param>
        /// <param name="parametersAndValues">Collection of parameters to add to Url</param>
        /// <returns>Constructed url</returns>
        public static string ConstructUrl(string urlNoQuerystring, List<KeyValuePair<string, string>> parametersAndValues)
        {
            var returnValue = new StringBuilder();

            returnValue.Append(urlNoQuerystring.RemoveLast("/"));
            if (parametersAndValues.Count > 0)
            {
                returnValue.Append("?" + Uri.EscapeDataString(parametersAndValues[0].Key) + "=" + Uri.EscapeDataString(parametersAndValues[0].Value));
                parametersAndValues.RemoveAt(0);
            }
            foreach (var Item in parametersAndValues)
            {
                returnValue.Append("&" + Uri.EscapeDataString(Item.Key) + "=" + Uri.EscapeDataString(Item.Value));
            }

            return returnValue.ToString();
        }

        /// <summary>
        /// Formats the entire URL, complete with PROTOCOL://SERVER_NAME:PORT/APPLICATION_PATH?Param1=Value1
        /// </summary>
        /// <param name="urlNoQuerystring">Url with everything but parameters and punctuation</param>
        /// <param name="parametersAndValues">Collection of parameters to add to Url</param>
        /// <returns>Constructed url</returns>
        public static string ConstructUrl(string urlNoQuerystring, List<string> parametersAndValues)
        {
            var returnValue = new StringBuilder();

            returnValue.Append(urlNoQuerystring.RemoveLast("/"));
            foreach (var item in parametersAndValues)
            {
                returnValue.Append("/" + Uri.EscapeDataString(item));
            }

            return returnValue.ToString();
        }
    }
}
