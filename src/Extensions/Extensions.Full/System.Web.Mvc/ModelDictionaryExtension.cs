//-----------------------------------------------------------------------
// <copyright file="ModelDictionaryExtension.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
// 
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Genesys.Extensions
{
    /// <summary>
    /// Extends the System.Web.Mvc.ModelStateDictionary class
    /// </summary>
    [CLSCompliant(true)]
    public static class ModelStateDictionaryExtension
    {
        /// <summary>
        /// Clears and add new list of model state dictionary errors
        /// </summary>
        /// <remarks></remarks>
        public static void AddModelError(this ModelStateDictionary item, IEnumerable<String> errors)
        {
            item.Clear();
            foreach (var Error in errors)
            {
                item.AddModelError("Error", Error);
            }
        }
    }
}
