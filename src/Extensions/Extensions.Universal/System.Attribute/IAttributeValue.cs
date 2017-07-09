//-----------------------------------------------------------------------
// <copyright file="IAttributeValue.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------

namespace Genesys.Extensions
{
    /// <summary>
    /// An attribute that has a string Value {get; set;} property
    /// </summary>
    public interface IAttributeValue<TValue>
    {
        /// <summary>
        /// string value of the attribute
        /// </summary>
        TValue Value { get; set; }
    }
}
