//-----------------------------------------------------------------------
// <copyright file="KeyValueListSafe.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Genesys.Extensions;
using Genesys.Extras.Serialization;

namespace Genesys.Extras.Collections
{
    /// <summary>
    /// Serializable Key Value List strongly typed
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <remarks></remarks>
    [CLSCompliant(true)]
    public class KeyValueListSafe<TKey, TValue> : List<KeyValuePairSafe<TKey, TValue>> where TKey : new() where TValue : new()
    {
        /// <summary>
        /// Item last selected from list
        /// </summary>
        public string SelectedItem { get; set; } = TypeExtension.DefaultString;

        /// <summary>
        /// Serialize and de-serialize
        /// </summary>
        public JsonSerializer<KeyValueListSafe<TKey, TValue>> Serializer = new JsonSerializer<KeyValueListSafe<TKey, TValue>>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <remarks></remarks>
        public KeyValueListSafe() : base() { }

        /// <summary>
        /// Normalizes and Adds a new member to the list
        /// </summary>
        /// <param name="key">Key of item to add</param>
        /// <param name="value">Value of item to add</param>
        /// <remarks></remarks>
        public virtual void Add(TKey key, TValue value)
        {
            Remove(key);
            Add(new KeyValuePairSafe<TKey, TValue>(key, value));
        }

        /// <summary>
        /// Remove a member from the list
        /// </summary>
        /// <param name="key"></param>
        /// <remarks></remarks>
        public virtual void Remove(TKey key)
        {
            var index = base.IndexOf(base.Find(x => x.Key.ToStringSafe() == key.ToStringSafe()));
            if (index > -1)
            { 
                RemoveAt(index);
            }
        }

        /// <summary>
        /// Null safe and self-normalizing indexer
        /// </summary>
        /// <param name="key">Item to get/set based on key index match</param>
        /// <returns>Get returns item from list, or not found will return new instantiation. Set will add/update match by key.</returns>
        public KeyValuePairSafe<TKey, TValue> this[TKey key]
        {
            get
            {
                KeyValuePairSafe<TKey, TValue> returnValue
                    = base.Find(x => x.Key.ToStringSafe() == key.ToStringSafe()).DirectCastSafe<KeyValuePairSafe<TKey, TValue>>();
                return returnValue;
            }
            set
            {
                Add(value);
            }
        }

        /// <summary>
        /// Adds another member to the list
        /// </summary>
        /// <param name="key">Key to search</param>
        /// <remarks>Returns value if found, else the default value for the type</remarks>
        public TValue GetValue(TKey key)
        {
            return this[key].Value;
        }
    }
}
