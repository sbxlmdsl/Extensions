//-----------------------------------------------------------------------
// <copyright file="ByteExtensionFull.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Drawing;
using System.IO;
using System.Web.Mvc;

namespace Genesys.Extensions
{
    /// <summary>
    /// Extensions to byte class
    /// </summary>
    [CLSCompliant(true)]
    public static class ByteExtension
    {
        /// <summary>
        /// Converts a byte array to System.Drawing.Image class
        /// </summary>
        /// <param name="item">Byte array of valid image-compatible data</param>
        /// <returns>Converted image class, or empty transparent 1px by 1px image</returns>
        public static Image ToImage(this Byte[] item)
        {
            Image returnValue = null;
            MemoryStream stream = null;

            if ((item == null == false) && (item.Length > 0))
            {
                stream = new MemoryStream(item, 0, item.Length);
                returnValue = Image.FromStream(stream);
            }
            else
            {
                returnValue = ImageExtension.ImageEmpty;
            }

            return returnValue;
        }

        /// <summary>
        /// Converts a byte Array to FileContentResult.
        /// Typically to show an image returned from MVC controller in an Html Img tag.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="contentType"></param>
        /// <returns>Content (typically images) to display from MVC controller.</returns>
        public static FileContentResult ToFileContentResult(this Byte[] item, string contentType)
        {
            return new FileContentResult(item, contentType);
        }
        
        /// <summary>
        /// Validates a byte array to be a image-like type and is less than a maximum size
        /// </summary>
        /// <param name="item">Byte array to check if it is an image.</param>
        /// <param name="maxSizeInKb">Invalidate if over this size in Kb. Default is 4mb/4096kb.</param>
        /// <returns>True if the byte array is an image</returns>
        public static bool IsImage(this byte[] item, int maxSizeInKb = 4096)
        {
            var returnValue = TypeExtension.DefaultBoolean;
            Image testImage;

            try
            {
                using (var ms = new MemoryStream(item))
                {
                    testImage = Image.FromStream(ms);
                    if (ms.Length <= (maxSizeInKb * 1024))
                    {
                        returnValue = true;
                    }
                }
            }
            catch (ArgumentException)
            {
                returnValue = false;
            }

            return returnValue;
        }
    }
}
