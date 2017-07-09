//-----------------------------------------------------------------------
// <copyright file="HttpRequestDeleteString.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Threading.Tasks;
using Genesys.Extensions;
using Genesys.Extras.Security.Cryptography;

namespace Genesys.Extras.Net
{
    /// <summary>
    /// Communicates via DELETE, all transmissions String
    /// </summary>
    [CLSCompliant(true)]
    public class HttpRequestDeleteString : HttpRequestClient
    {
        /// <summary>
        /// Immutable
        /// </summary>
        protected internal HttpRequestDeleteString() : base() { }

        /// <summary>
        /// Construct with data
        /// </summary>
        public HttpRequestDeleteString(Uri url) : base(url) { }

        /// <summary>
        /// Construct with data
        /// </summary>
        public HttpRequestDeleteString(string url) : base(new Uri(url, UriKind.RelativeOrAbsolute)) { }

        /// <summary>
        /// Construct with data
        /// </summary>
        public HttpRequestDeleteString(Uri url, IEncryptor encrptor) : base(url, encrptor) { }
        
        /// <summary>
        /// Synchronously sends a GET request, Receives string response
        /// </summary>
        /// <returns>Result</returns>
        public override string Send()
        {
            Response = this.Client.DeleteAsync(this.Url).Result;
            if (this.Response.IsSuccessStatusCode)
            {
                DataReceivedRaw = this.Response.Content.ReadAsStringAsync().Result;
                if (ThrowExceptionWithEmptyReponse == true && DataReceivedRaw == TypeExtension.DefaultString)
                { throw new System.DataMisalignedException("Response is empty. Expected data to be returned."); } else if (SendPlainText == false)
                { DataReceivedDecrypted = this.Encryptor.Decrypt(DataReceivedRaw); } else { DataReceivedDecrypted = DataReceivedRaw; }
            }
            return DataReceivedDecrypted;
        }

        /// <summary>
        /// Asynchronously sends a GET request, Receives strongly typed response
        /// </summary>
        /// <returns>Response data</returns>
        public override async Task<string> SendAsync()
        {
            Response = await this.Client.DeleteAsync(this.Url);
            if (this.Response.IsSuccessStatusCode)
            {
                DataReceivedRaw = await this.Response.Content.ReadAsStringAsync();
                if (ThrowExceptionWithEmptyReponse == true && DataReceivedRaw == TypeExtension.DefaultString)
                { throw new System.DataMisalignedException("Response is empty. Expected data to be returned."); } else if (SendPlainText == false)
                { DataReceivedDecrypted = this.Encryptor.Decrypt(DataReceivedRaw); } else { DataReceivedDecrypted = DataReceivedRaw; }
            }
            return DataReceivedDecrypted;
        }
    }
}
