//-----------------------------------------------------------------------
// <copyright file="IQuerableExtension.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Linq;

namespace Genesys.Extensions
{
    /// <summary>
    /// IQueryableExtension
    /// </summary>
    [CLSCompliant(true)]
    public static class IQueryableExtension
    {
        /// <summary>
        /// Finds first item in IQueryable, else returns new() constructed item
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="item">Item to search</param>
        /// <returns>First item in IQueryable, else returns new() constructed item</returns>
        public static T FirstOrDefaultSafe<T>(this IQueryable<T> item) where T : new()
        {
            return (item != null && item.FirstOrDefault() != null) ? item.FirstOrDefault() : new T();
        }

        /// <summary>
        /// Finds last item in IQueryable, else returns new() constructed item
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="item">Item to search</param>
        /// <returns>First item in IQueryable, else returns new() constructed item</returns>
        public static T LastOrDefaultSafe<T>(this IQueryable<T> item) where T : new()
        {
            return (item != null && item.LastOrDefault() != null) ? item.LastOrDefault() : new T();
        }
    }
}
