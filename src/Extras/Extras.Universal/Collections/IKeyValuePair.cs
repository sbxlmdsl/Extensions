//-----------------------------------------------------------------------
// <copyright file="IKeyValuePair.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace Genesys.Extras.Collections
{
    /// <summary>
    /// Serializer interface
    /// </summary>
    [CLSCompliant(true)]
    public interface IKeyValuePair<TKey, TValue>
    {
        /// <summary>
        /// Key
        /// </summary>
        TKey Key { get; set; }
        /// <summary>
        /// Value of key
        /// </summary>
        TValue Value { get; set; }
    }
 }
