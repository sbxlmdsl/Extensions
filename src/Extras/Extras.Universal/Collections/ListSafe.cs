//-----------------------------------------------------------------------
// <copyright file="ListSafe.cs" company="Genesys Source">
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
    /// Contains an enumerable list of types
    /// </summary>
    [CLSCompliant(true)]
    public class ListSafe<ListType> : List<ListType>, IListSafe<ListType> where ListType : class
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ListSafe() : base() { }
        
        /// <summary>
        /// Index overload
        /// </summary>
        /// <param name="key">Item to find</param>
        /// <returns>Item that matches key</returns>
        public ListType this[ListType key]
        {
            get { return base[base.IndexOf(base.Find(x => x.ToString() == key.ToString()))]; }
            set { base[base.IndexOf(base.Find(x => x.ToString() == key.ToString()))] = value; }
        }

        /// <summary>
        /// Gets an item that matches key
        /// </summary>
        /// <param name="key">Item to find</param>
        /// <returns>Item that matches key</returns>
        public ListType GetValue(ListType key)
        {
            return base.Find(x => x == key);
        }

        /// <summary>
        /// Normalizes and Adds a new member to the list
        /// </summary>
        /// <param name="newItem">Item to add</param>
        public new void Add(ListType newItem)
        {
            if (this.GetValue(newItem).ToStringSafe() != TypeExtension.DefaultString)
            {
                base.RemoveAt(this.FindIndex(newItem));
            }
            base.Add(newItem);
        }

        /// <summary>
        /// Remove a member from the list
        /// </summary>
        /// <param name="itemToRemove">Item to be removed</param>
        public new void Remove(ListType itemToRemove)
        {
            if (this.GetValue(itemToRemove).ToStringSafe() != TypeExtension.DefaultString)
            {
                base.RemoveAt(this.FindIndex(itemToRemove));
            }
        }

        /// <summary>
        /// Finds the index
        /// </summary>
        /// <param name="key">Key of item to find</param>
        /// <returns>Index of item matches passed item</returns>
        public int FindIndex(ListType key)
        {
            var returnValue = TypeExtension.DefaultInteger;

            for (var count = 0; count < this.Count; count++)
            {
                if (this[count] == key)
                {
                    returnValue = count;
                    break;
                }
            }

            return returnValue;
        }
    }    
}
