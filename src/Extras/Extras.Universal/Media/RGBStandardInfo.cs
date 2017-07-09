//-----------------------------------------------------------------------
// <copyright file="HttpClientBuilder.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using Genesys.Extensions;

namespace Genesys.Extras.Media
{
    /// <summary>
    /// Color info in RGB converted format
    /// </summary>
    [CLSCompliant(true)]
    public class RGBStandardInfo
    {
        /// <summary>
        /// Alpha channel (transparency)
        /// </summary>
        public float Alpha { get; set; } = TypeExtension.DefaultSingle;
        /// <summary>
        /// Blue channel
        /// </summary>
        public float Blue { get; set; } = TypeExtension.DefaultSingle;
        /// <summary>
        /// Green channel
        /// </summary>
        public float Green { get; set; } = TypeExtension.DefaultSingle;
        /// <summary>
        /// Red channel
        /// </summary>
        public float Red { get; set; } = TypeExtension.DefaultSingle;
        
        /// <summary>
        /// Inverses the current RGB values
        /// </summary>
        /// <returns></returns>
        public RGBStandardInfo Inverse()
        {
            RGBStandardInfo returnValue = new RGBStandardInfo();
            returnValue.Red = (1.0f - this.Red);
            returnValue.Green = (1.0f - this.Green);
            returnValue.Blue = (1.0f - this.Blue);
            return returnValue;
        }
    }
}
