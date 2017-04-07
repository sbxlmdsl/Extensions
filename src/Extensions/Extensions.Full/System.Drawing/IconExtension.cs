//-----------------------------------------------------------------------
// <copyright file="IconExtension.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
// 
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Drawing;
using System.IO;

namespace Genesys.Extensions
{
    /// <summary>
    /// Icon Extension
    /// </summary>
    [CLSCompliant(true)]
    public static class IconExtension
    {
        /// <summary>
        /// Converts a System.Drawing.Icon to a byte array
        /// </summary>
        /// <returns>Byte array containing the icon</returns>
        public static byte[] ToBytes(this Icon item)
        {
            var returnValue = new MemoryStream();
            if ((item == null == false) && (item.Size.Width > 0 & item.Size.Height > 0))
            {
                item.Save(returnValue);
            }
            return returnValue.ToArray();
        }
    }
}
