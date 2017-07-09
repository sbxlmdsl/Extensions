//-----------------------------------------------------------------------
// <copyright file="CleanserFactory.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Genesys.Extras.Text.Cleansing
{
    /// <summary>
    /// Factories out cleanser classes
    /// </summary>
    public class CleanserFactory
    {
        /// <summary>
        /// Cleansers registered with the system
        /// </summary>
        public Dictionary<CleanserIDs, Type> Cleansers { get; } = new Dictionary<CleanserIDs, Type>();

        /// <summary>
        /// Constructor
        /// Add approved and functional cleansers to the list here.
        /// </summary>
        public CleanserFactory() : base()
        {
            Cleansers.Add(CleanserIDs.Default, typeof(DefaultCleanser));
            Cleansers.Add(CleanserIDs.UnsafeHtml, typeof(HtmlUnsafeCleanser));
            Cleansers.Add(CleanserIDs.SqlInjection, typeof(SqlInjectionCleanser));
            Cleansers.Add(CleanserIDs.XmlInvalidChars, typeof(XmlInvalidCharacterCleanser));
        }

        /// <summary>
        /// Constructs a cleanser by generic type
        /// </summary>
        /// <returns></returns>
        public static Cleanser Construct(CleanserIDs id, string itemToCleanse)
        {
            Type cleanserType = null;
            CleanserFactory factory = new CleanserFactory();
            Cleanser returnValue;

            cleanserType = factory.Cleansers[id];
            returnValue = (Cleanser)Activator.CreateInstance(cleanserType);
            returnValue.TextToCleanse = itemToCleanse;

            return returnValue;
        }
    }    

    /// <summary>
    /// enumeration to allow the attribute to use strongly-typed ID
    /// </summary>
    [CLSCompliant(true)]
    [Flags]
    public enum CleanserIDs
    {
        /// <summary>
        /// 
        /// </summary>
        Default = 0x0,

        /// <summary>
        /// Cross-site scripting attacking browser exposed objects
        /// </summary>
        UnsafeHtml = 0x1,

        /// <summary>
        /// T-SQL Injection attack
        /// </summary>
        SqlInjection = 0x2,

        /// <summary>
        /// Invalid XML characters
        /// </summary>
        XmlInvalidChars = 0x4
    }
}
