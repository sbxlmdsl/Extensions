//-----------------------------------------------------------------------
// <copyright file="Square.cs" company="Genesys Source">
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
    /// Square class
    /// </summary>
    [CLSCompliant(true)]
    public class Square
    {
        /// <summary>
        /// Width of the square
        /// </summary>
        public int Width { get; set; } = TypeExtension.DefaultInteger;

        /// <summary>
        /// Height of the square
        /// </summary>
        public int Height { get; set; } = TypeExtension.DefaultInteger;
    }
}