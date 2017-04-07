//-----------------------------------------------------------------------
// <copyright file="NameValueCollectionExtension.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
// 
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Specialized;

namespace Genesys.Extensions
{
    /// <summary>
    /// Extends System.Type
    /// </summary>
    [CLSCompliant(true)]
    public static class NameValueCollectionExtension
    {
        /// <summary>
        /// Converts to flattened array of string, string
        /// </summary>
        /// <param name="item">NameValueCollection to convert to string[count, 2] array</param>
        /// <returns>True if this connection can be opened</returns>
        public static string[,] ToArraySafe(this NameValueCollection item)
        {
            NameValueCollection itemToConvert = item ?? new NameValueCollection();
            string[,] returnValue = new string[itemToConvert.Count, 2];

            for (var count = 0; count < itemToConvert.Count; count++)
            {
                returnValue[count, 0] = itemToConvert.Keys[count];
                returnValue[count, 1] = itemToConvert[count];
            }

            return returnValue;
        }
    }
}
