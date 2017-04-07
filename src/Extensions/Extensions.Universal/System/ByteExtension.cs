//-----------------------------------------------------------------------
// <copyright file="ByteExtension.cs" company="Genesys Source">
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
    /// Byte Extender
    /// </summary>
    [CLSCompliant(true)]
    public static class ByteExtension
    {
        /// <summary>
        /// Converts a byte array to a String
        /// </summary>
        /// <param name="item">Byte array containing the string.</param>
        /// <returns>string from the byte array, or empty string</returns>
        public static string ToString(this byte[] item)
        {
            var returnValue = TypeExtension.DefaultString;
            if ((item == null == false) && (item.Length > 0))
            {
                returnValue = System.Text.Encoding.UTF8.GetString(item, 0, item.Length - 1);
            }

            return returnValue;
        }
        
        /// <summary>
        /// Convert an image byte[] to RGBA
        /// </summary>
        /// <param name="item">Item to convert</param>
        /// <param name="heightInPixels">Height of image</param>
        /// <param name="widthInPixels">Width of image</param>
        /// <returns>Converted byte array</returns>
        public static byte[] ToRGB(this byte[] item, int heightInPixels, int widthInPixels)
        {
            var byteOffset = TypeExtension.DefaultInteger;
            byte[] returnValue = item;

            for (var row = 0; row < (uint)heightInPixels; row++)
            {
                for (var column = 0; column < (uint)widthInPixels; column++)
                {
                    byteOffset = (row * (int)widthInPixels * 4) + (column * 4);
                    byte b = returnValue[byteOffset];
                    byte g = returnValue[byteOffset + 1];
                    byte r = returnValue[byteOffset + 2];
                    byte a = returnValue[byteOffset + 3];
                    returnValue[byteOffset] = r; // Red
                    returnValue[byteOffset + 1] = g; // Green
                    returnValue[byteOffset + 2] = b; // Blue
                    returnValue[byteOffset + 3] = a; // Alpha
                }
            }

            return returnValue;
        }
    }
}
