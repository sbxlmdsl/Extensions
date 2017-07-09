//-----------------------------------------------------------------------
// <copyright file="HttpRequestGet.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Genesys.Extras.Security.Cryptography;
using Genesys.Extras.Serialization;

namespace Genesys.Extras.Net
{
    /// <summary>
    /// Communicates via GET, strongly typed
    /// </summary>
    [CLSCompliant(true)]
    public class HttpRequestGet<TypeToReceive> : HttpRequestGetString where TypeToReceive : new()
    {
        /// <summary>
        /// DataReceivedRaw value decrypted
        /// </summary>
        public TypeToReceive DataReceivedDeserialized { get; set; } = new TypeToReceive();
        /// <summary>
        /// De-serializer of response
        /// </summary>
        public ISerializer<TypeToReceive> Deserializer { get; protected set; } = new JsonSerializer<TypeToReceive>();
        /// <summary>
        /// KnownTypes assist the serializer with types that cannot be mapped by default
        /// </summary>
        public List<Type> KnownTypes { get; protected set; } = new List<Type>();
        
        /// <summary>
        /// Immutable
        /// </summary>
        public HttpRequestGet(Uri url) : base(url) { }

        /// <summary>
        /// Construct with data
        /// </summary>
        public HttpRequestGet(string url) : base(new Uri(url, UriKind.RelativeOrAbsolute)) { }

        /// <summary>
        /// Construct with data
        /// </summary>
        public HttpRequestGet(Uri url, ISerializer<TypeToReceive> deserializer) : this(url) { Deserializer = deserializer; }

        /// <summary>
        /// Construct with data
        /// </summary>
        public HttpRequestGet(Uri url, IEncryptor encrptor) : base(url, encrptor) { }
        
        /// <summary>
        /// Sync send and Receive
        /// </summary>
        /// <returns></returns>
        public virtual new TypeToReceive Send()
        {
            base.Send();
            DataReceivedDeserialized = this.Deserializer.Deserialize(base.DataReceivedDecrypted);
            return DataReceivedDeserialized; 
        }

        /// <summary>
        /// Async send and Receive
        /// </summary>
        /// <returns></returns>
        public virtual new async Task<TypeToReceive> SendAsync()
        {
            await base.SendAsync();
            DataReceivedDeserialized = this.Deserializer.Deserialize(base.DataReceivedDecrypted);
            return DataReceivedDeserialized;
        }
    }
}
