//-----------------------------------------------------------------------
// <copyright file="AspectRatio.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using Genesys.Extensions;

namespace Genesys.Extras.Mathematics
{
    /// <summary>
    /// MathHelper - Read Only Collection
    /// </summary>
    [CLSCompliant(true)]
    public class AspectRatio
    {
        /// <summary>
        /// Gets new width for changing height
        /// </summary>
        /// <param name="original">Original square</param>
        /// <param name="newHeight">New height</param>
        /// <returns>Width given original item was resized</returns>
        public static Square WidthChange(Square original, int newHeight)
        {
            var returnValue = new Square();
            var multiplier = TypeExtension.DefaultDecimal;

            // Height is only specified, have to calculate width
            multiplier = Arithmetic.Divide(newHeight.ToDecimal(), original.Height.ToDecimal());
            // Resize
            returnValue.Width = Arithmetic.Multiply(original.Width.ToDecimal(), multiplier).ToInt();

            return returnValue;
        }

        /// <summary>
        /// Gets new width for changing height
        /// </summary>
        /// <param name="original">Original square</param>
        /// <param name="newWidth">New width</param>
        /// <returns>Width given original item was resized</returns>
        public static Square HeightChange(Square original, int newWidth)
        {
            var returnValue = new Square();
            var multiplier = TypeExtension.DefaultDecimal;

            // Height is only specified, have to calculate width
            multiplier = Arithmetic.Divide(newWidth.ToDecimal(), original.Width.ToDecimal());
            // Resize
            returnValue.Height = Arithmetic.Multiply(original.Height.ToDecimal(), multiplier).ToInt();

            return returnValue;
        }
    }
}
