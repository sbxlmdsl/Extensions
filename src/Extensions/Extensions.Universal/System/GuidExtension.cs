//-----------------------------------------------------------------------
// <copyright file="GuidExtension.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
// 
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace Genesys.Extensions
{
    /// <summary>
    /// DoubleExtension
    /// </summary>    
    [CLSCompliant(true)]
    public static class  GuidExtension
    {
        /// <summary>
        /// Parses without exceptions
        /// </summary>
        /// <param name="item">Integer to convert to guid.</param>
        /// <returns>Converted value, or default -1.</returns>
        public static int ToInteger(this Guid item)
        {
            var returnValue = TypeExtension.DefaultInteger;

            try
            {
            var b = item.ToByteArray();
                var bint = BitConverter.ToInt32(b, 0);
                returnValue = bint;
            }
            catch
            {
                returnValue = TypeExtension.DefaultInteger;
            }
            return returnValue;
        }
    }
}