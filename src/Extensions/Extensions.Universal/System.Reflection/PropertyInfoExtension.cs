//-----------------------------------------------------------------------
// <copyright file="PropertyInfoExtension.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Reflection;

namespace Genesys.Extensions
{
    /// <summary>
    /// HttpRequestBaseExtension
    /// </summary>
    [CLSCompliant(true)]
    public static class PropertyInfoExtension
    {
        /// <summary>
        /// Gets the value of an attribute that implements IAttributeValue
        /// </summary>
        /// <param name="item">Object containing the attribute</param>
        /// <param name="notFoundValue">Will use this string if no attribute is found</param>
        /// <returns></returns>
        public static TValue GetAttributeValue<TAttribute, TValue>(this PropertyInfo item, TValue notFoundValue) where TAttribute : Attribute, IAttributeValue<TValue>
        {
            TValue returnValue = notFoundValue;

            foreach (object attribute in item.GetCustomAttributes(false))
            {
                if ((attribute is TAttribute) == true)
                {
                    returnValue = ((TAttribute)attribute).Value;
                    break;
                }
            }

            return returnValue;
        }
    }
}
