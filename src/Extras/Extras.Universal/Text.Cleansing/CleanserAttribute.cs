//-----------------------------------------------------------------------
// <copyright file="CleansingModeValues.cs" company="Genesys Source">
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
    /// Connection string Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false), CLSCompliant(true)]
    public class CleanseFor : Attribute, IAttributeValue<CleanserIDs>
    {
        private static CleanserIDs defaultValue = CleanserIDs.Default;

        /// <summary>
        /// Value of attribute
        /// </summary>
        public CleanserIDs Default { get; set; } = defaultValue;

        /// <summary>
        /// Value of attribute
        /// </summary>
        public CleanserIDs Value { get; set; } = defaultValue;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">Value to hydrate</param>
        public CleanseFor(CleanserIDs value)
        {
            Value = value;
        }
    }
}
