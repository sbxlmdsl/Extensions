//-----------------------------------------------------------------------
// <copyright file="KeyValueListString.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using Genesys.Extras.Text;
using System.Collections;

namespace Genesys.Extras.Collections
{
    /// <summary>
    /// Serializable Key Value List strongly typed as string
    /// </summary>
    [CLSCompliant(true)]
    public class KeyValueListString : KeyValueList<StringMutable, StringMutable>, IEnumerable
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <remarks></remarks>
        public KeyValueListString() : base() { }       
    }
}
