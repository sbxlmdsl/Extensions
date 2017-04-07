//-----------------------------------------------------------------------
// <copyright file="ImageFormatExtension.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
// 
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Drawing.Imaging;

namespace Genesys.Extensions
{
    /// <summary>
    /// Extends the Image Format class
    /// </summary>
    [CLSCompliant(true)]
    public static class ImageFormatExtension
    {
        /// <summary>
        /// Returns mime content type for an Image Format item
        /// </summary>
        /// <param name="item">MIME content type of item</param>
        /// <returns>string containing the MIME content type text</returns>
        public static string ToContentType(this ImageFormat item)
        {
            var returnValue = "image/unknown";
            Guid imgguid = item.Guid;
            foreach (ImageCodecInfo codec in ImageCodecInfo.GetImageDecoders())
            {
                if (codec.FormatID == imgguid)
                {
                    returnValue = codec.MimeType;
                    break;
                }
            }

            return returnValue;
        }
    }
}
