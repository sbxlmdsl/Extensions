﻿//-----------------------------------------------------------------------
// <copyright file="HttpClientBuilder.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Genesys.Extras.Net
{
    /// <summary>
    /// Builds an HttpClient object
    /// </summary>
    /// <returns></returns>
    /// <remarks></remarks>
    [CLSCompliant(true)]
    public class HttpClientBuilder : HttpClient
    {
        /// <summary>
        /// MaxResponseContentBufferSize
        /// </summary>
        public static long MaxResponseContentBufferSizeDefault { get; } = 2560000;

        /// <summary>
        /// Default user agent string
        /// </summary>
        public static KeyValuePair<string, string> UserAgentDefault { get; } = new KeyValuePair<string, string>("user-agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");

        /// <summary>
        /// Constructor parameterless
        /// </summary>
        public HttpClientBuilder()
            : this(MaxResponseContentBufferSizeDefault, UserAgentDefault)
        {            
        }

        /// <summary>
        /// Builds a HttpClient with specific content buffer size and request header
        /// </summary>
        public HttpClientBuilder(Int64 maxResponseContentBufferSize, KeyValuePair<string, string> additionalHeader)
            : base()
        {
            base.MaxResponseContentBufferSize = maxResponseContentBufferSize;
            base.DefaultRequestHeaders.Add(additionalHeader.Key, additionalHeader.Value);
        }

        /// <summary>
        /// Builds a HttpClient with specific content buffer size and request header
        /// </summary>
        public HttpClientBuilder(Int64 maxResponseContentBufferSize, IEnumerable<KeyValuePair<string, string>> additionalHeaders)
            : base()
        {
            base.MaxResponseContentBufferSize = maxResponseContentBufferSize;
            foreach(var item in additionalHeaders)
            {
                base.DefaultRequestHeaders.Add(item.Key, item.Value);
            }            
        }
    }
}
