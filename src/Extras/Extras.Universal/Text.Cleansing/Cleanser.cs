//-----------------------------------------------------------------------
// <copyright file="Cleanser.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Reflection;
using Genesys.Extensions;

namespace Genesys.Extras.Text.Cleansing
{
    /// <summary>
    /// Text Cleanser interface
    /// </summary>
    [CLSCompliant(true)]
    public abstract class Cleanser
    {
        /// <summary>
        /// ID of the target of this cleanser
        /// </summary>
        public abstract CleanserIDs CleanserID { get; }

        /// <summary>
        /// Item to cleanse
        /// </summary>
        public string TextToCleanse { get; set; }

        /// <summary>
        /// Result after cleanse
        /// </summary>
        public string TextCleansed { get; protected set; }

        /// <summary>
        /// Worker that cleanses the text
        /// </summary>
        /// <returns></returns>
        public abstract string Cleanse();

        /// <summary>
        /// Cleanses all properties marked with CleanseFor attribute
        /// </summary>
        /// <param name="classToCleanse"></param>
        public static void CleanseAll(object classToCleanse)
        {
            // Get properties with CleanseFor() attribute
            IEnumerable<PropertyInfo> props = classToCleanse.GetPropertiesByAttribute(typeof(CleanseFor));
            foreach (var item in props)
            {
                var ValueToSet = item.GetValue(classToCleanse, null).ToStringSafe();
                Cleanser cleanserWorker = CleanserFactory.Construct(item.GetAttributeValue<CleanseFor, CleanserIDs>(CleanserIDs.Default), ValueToSet);
                ValueToSet = cleanserWorker.Cleanse();
                item.SetValue(classToCleanse, ValueToSet);
            }
        }
    }
}
