//-----------------------------------------------------------------------
// <copyright file="IEncryptor.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace Genesys.Extras.Security.Cryptography
{
    /// <summary>
    /// Encryptor interface
    /// </summary>
    [CLSCompliant(true)]
    public interface IEncryptor
    {
        /// <summary>
        /// Key
        /// </summary>
        string Key { get; }

        /// <summary>
        /// Salt
        /// </summary>
        string Salt { get; }

        /// <summary>
        /// EncodeForURL
        /// </summary>
        bool EncodeForURL { get; }

        /// <summary>
        /// Encrypt
        /// </summary>
        /// <param name="plainString"></param>
        /// <returns></returns>
        string Encrypt(string plainString);

        /// <summary>
        /// EncryptedString
        /// </summary>
        /// <param name="encryptedString"></param>
        /// <returns></returns>
        string Decrypt(string encryptedString);
    }
}
