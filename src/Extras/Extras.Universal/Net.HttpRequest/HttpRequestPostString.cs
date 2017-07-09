//-----------------------------------------------------------------------
// <copyright file="HttpRequestPostString.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Genesys.Extensions;
using Genesys.Extras.Security.Cryptography;

namespace Genesys.Extras.Net
{
    /// <summary>
    /// Communicates via POST, string in and string out
    /// </summary>
    [CLSCompliant(true)]
    public class HttpRequestPostString : HttpRequestClient
    {
        /// <summary>
        /// DataToSend
        /// </summary>
        public string DataToSend { get; set; } = TypeExtension.DefaultString;
        /// <summary>
        /// Mime content type of data to send
        /// </summary>
        public string ContentType { get; set; } = ContentTypes.Types.Json;

        /// <summary>
        /// Construct with data
        /// </summary>
        public HttpRequestPostString(Uri url) : base(url) { }

        /// <summary>
        /// Construct with data
        /// </summary>
        public HttpRequestPostString(string url) : base(new Uri(url, UriKind.RelativeOrAbsolute)) { }

        /// <summary>
        /// Construct with data
        /// </summary>
        public HttpRequestPostString(Uri url, string dataToSend) : this(url) { DataToSend = dataToSend; }

        /// <summary>
        /// Construct with data
        /// </summary>
        public HttpRequestPostString(Uri url, string dataToSend, IEncryptor encrptor) : this(url, dataToSend) { Encryptor = Encryptor; }
        
        /// <summary>
        /// Sends a GET request, Receives string response
        ///     Overrides HttpRequestBase.Send()
        /// </summary>
        /// <returns></returns>
        public override string Send()
        {
            var returnValue = TypeExtension.DefaultString;
            var client = new HttpClientBuilder();
            var data = new StringContent(DataToSend, System.Text.Encoding.UTF8, this.ContentType);

            Response = client.PostAsync(this.Url, data).Result;
            if (this.Response.IsSuccessStatusCode)
            {
                DataReceivedRaw = this.Response.Content.ReadAsStringAsync().Result;
                if (SendPlainText == false)
                { DataReceivedDecrypted = this.Encryptor.Decrypt(DataReceivedRaw); } else { DataReceivedDecrypted = DataReceivedRaw; }
            }

            return DataReceivedDecrypted;
        }

        /// <summary>
        /// Sends a GET request, Receives string response
        ///     Overrides HttpRequestBase.SendAsync()
        /// </summary>
        /// <returns></returns>
        public override async Task<string> SendAsync()
        {
            var returnValue = TypeExtension.DefaultString;
            var client = new HttpClientBuilder();
            var data = new StringContent(DataToSend, System.Text.Encoding.UTF8, this.ContentType);

            Response = await client.PostAsync(this.Url, data);
            if (this.Response.IsSuccessStatusCode)
            {
                DataReceivedRaw = await this.Response.Content.ReadAsStringAsync();
                if (SendPlainText == false)
                { DataReceivedDecrypted = this.Encryptor.Decrypt(DataReceivedRaw); } else { DataReceivedDecrypted = DataReceivedRaw; }
            }

            return DataReceivedDecrypted;
        }
    }
}