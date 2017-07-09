//-----------------------------------------------------------------------
// <copyright file="RandomString.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Text;
using Genesys.Extensions;

namespace Genesys.Extras.Text
{
    /// <summary>
    /// Produces random strings of mixed characters and integers
    /// </summary>
    [CLSCompliant(true)]
    public class RandomString
    {
        /// <summary>
        /// Generates a random string of the given length
        /// </summary>
        /// <param name="length">Size of the string</param>
        /// <returns>Random string</returns>
        public static string Next(int length = 10)
        {
            var returnValue = TypeExtension.DefaultString;
            var builder = new StringBuilder();
            var randomClass = new Random();
            char character = '\0';

            // Build the string
            for (var Count = 0; Count <= length - 1; Count++)
            {
                character = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * randomClass.NextDouble() + 65)));
                builder.Append(character);
            }
            returnValue = builder.ToString();

            return returnValue;
        }
    }
}
