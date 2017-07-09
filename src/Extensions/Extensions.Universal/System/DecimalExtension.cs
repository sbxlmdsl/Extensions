//-----------------------------------------------------------------------
// <copyright file="DecimalExtension.cs" company="Genesys Source">
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
    /// Extension to decimal class
    /// </summary>
    [CLSCompliant(true)]
    public static class  DecimalExtension
    {
        /// <summary>
        /// FormatCurrency With Comma
        /// </summary>
        public const string FormatCurrencyWithComma = "C";

        /// <summary>
        /// FormatPercent With Comma
        /// </summary>
        public const string FormatPercentWithComma = "P";

        /// <summary>
        /// Quick converts
        /// </summary>
        /// <param name="item">Decimal to convert to double</param>
        /// <returns>Double of the passed decimal, or 0.</returns>
        public static double ToDouble(this decimal item)
        {
            return Decimal.ToDouble(item);
        }

        /// <summary>
        /// Quick converts
        /// </summary>
        /// <param name="item">Decimal to convert to integer.</param>
        /// <returns>Converted value, or default -1.</returns>
        public static short ToShort(this decimal item)
        {
            return Decimal.ToInt16(item);
        }

        /// <summary>
        /// Quick converts
        /// </summary>
        /// <param name="item">Decimal to convert to integer.</param>
        /// <returns>Converted value, or default -1.</returns>
        public static int ToInt(this decimal item)
        {            
            return Decimal.ToInt32(item);
        }

        /// <summary>
        /// Quick converts
        /// </summary>
        /// <param name="item">Decimal to convert to integer.</param>
        /// <returns>Converted value, or default -1.</returns>
        public static long ToLong(this decimal item)
        {
            return Decimal.ToInt64(item);
        }
    }
}