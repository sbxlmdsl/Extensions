//-----------------------------------------------------------------------
// <copyright file="KeyValuePairString.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using Genesys.Extras.Text;

namespace Genesys.Extras.Collections
{
    /// <summary>
    /// Simple serializable KeyValuePair string typed
    /// </summary>
    /// <remarks></remarks>
    [CLSCompliant(true)]
    public class KeyValuePairString : KeyValuePairSafe<StringMutable, StringMutable>
    {        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <remarks></remarks>
        public KeyValuePairString() : base() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <remarks></remarks>
        public KeyValuePairString(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
