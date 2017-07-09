//-----------------------------------------------------------------------
// <copyright file="DefaultCleanser.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using Genesys.Extensions;

namespace Genesys.Extras.Text.Cleansing
{
    /// <summary>
    /// Cleanses and removes Html unsafe characters
    /// </summary>
    [CLSCompliant(true)]
    public class DefaultCleanser : Cleanser
    {
        /// <summary>
        /// Target of this cleanser
        /// </summary>
        public override CleanserIDs CleanserID { get; } = CleanserIDs.Default;
        
        /// <summary>
        /// Constructor
        /// </summary>
        public DefaultCleanser() : base() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="textToCleanse">Plain text to have characters cleansed</param>
        public DefaultCleanser(string textToCleanse)
            : this()
        {
            TextToCleanse = textToCleanse;
        }

        /// <summary>
        /// Cleanses a string
        /// </summary>
        public override string Cleanse()
        {
            TextCleansed = TextToCleanse;
            return TextCleansed;
        }
    }
}
