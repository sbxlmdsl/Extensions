//-----------------------------------------------------------------------
// <copyright file="ISerialize.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace Genesys.Extras.Serialization
{
    /// <summary>
    /// Data access entity that can only read
    /// </summary>
    [CLSCompliant(true)]
    public interface ISerialize<T>
    {
        /// <summary>
        /// Serializes this object into a string
        /// </summary>
        /// <returns></returns>
        string Serialize();

        /// <summary>
        /// De-serializes a string into this object
        /// </summary>
        /// <returns></returns>
        T Deserialize(string data);
    }
}
