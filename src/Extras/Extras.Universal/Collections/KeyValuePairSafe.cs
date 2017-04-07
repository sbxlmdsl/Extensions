//-----------------------------------------------------------------------
// <copyright file="KeyValuePairSafe.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Genesys.Extensions;

namespace Genesys.Extras.Collections
{
    /// <summary>
    /// Simple serializable KeyValuePair strongly typed
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <remarks></remarks>
    [CLSCompliant(true)]
    public class KeyValuePairSafe<TKey, TValue> : IKeyValuePair<TKey, TValue>, IEquatable<KeyValuePairSafe<TKey, TValue>> where TKey : new() where TValue : new()
    {
        private int hashCode = TypeExtension.DefaultInteger;

        /// <summary>
        /// Key
        /// </summary>
        protected TKey keyField = new TKey();

        /// <summary>
        /// Value
        /// </summary>
        protected TValue valueField = new TValue();
        
        /// <summary>
        /// Key, self-initializes to be null safe
        /// </summary>
        public virtual TKey Key { get { return keyField; } set { keyField = value == null ? new TKey() : value; } }
        
        /// <summary>
        /// Value, self-initializes to be null safe
        /// </summary>
        public virtual TValue Value { get { return valueField; } set { valueField = value == null ? new TValue() : value; } }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <remarks></remarks>
        public KeyValuePairSafe() : base() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <remarks></remarks>
        public KeyValuePairSafe(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        /// <summary>
        /// Unique hash of (Key.GetHashCode() * 17 + Value.GetHashCode());
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            if (hashCode == TypeExtension.DefaultInteger)
            {
                hashCode = (Key == null ? new TKey() : Key).GetHashCode() * 17 + (Value == null ? new TValue() : Value).GetHashCode();
            }
            return hashCode;
        }

        /// <summary>
        /// Default comparer
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(KeyValuePairSafe<TKey, TValue> other)
        {
            return (Key.ToStringSafe() == other.Key.ToStringSafe() && Value.ToStringSafe() == other.Value.ToStringSafe());
        }
    }
}
