//-----------------------------------------------------------------------
// <copyright file="StreamExtension.cs" company="Genesys Source">
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
    /// Extension methods to the System.IO.Stream class
    /// </summary>
    [CLSCompliant(true)]
    public static class StreamExtension
    {
        /// <summary>
        /// Validates a stream to be a image-like type and is less than a maximum size
        /// </summary>
        /// <param name="item">Stream array to check for image</param>
        /// <param name="maxSizeInKb">Default is 4 Mb</param>
        /// <returns>True if stream is image</returns>
        public static bool IsImage(this Stream item, int maxSizeInKb = 4096)
        {            
            return new Bitmap(item).ToBytes().IsImage(maxSizeInKb);
        }
    }
}
