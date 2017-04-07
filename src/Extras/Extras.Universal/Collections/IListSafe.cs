//-----------------------------------------------------------------------
// <copyright file="IListSafe.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Genesys.Extras.Collections
{
    /// <summary>
    /// Serializer interface
    /// </summary>
    [CLSCompliant(true)]
    public interface IListSafe<ListType> : IEnumerable<ListType>
    {
        /// <summary>
        /// Adds a known type to the collection
        /// </summary>
        void Add(ListType itemToAdd);
        /// <summary>
        /// Adds a range of known types to the collection
        /// </summary>
        void AddRange(IEnumerable<ListType> itemsToAdd);
    }
 }
