//-----------------------------------------------------------------------
// <copyright file="ContentType.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Extensions;

namespace Genesys.Extras.Net
{
    /// <summary>
    /// Holds a float content type and file extension
    /// </summary>
    public class ContentType
    {        
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; protected set; } = TypeExtension.DefaultString;
        /// <summary>
        /// Extension
        /// </summary>
        public string Extension { get; protected set; } = TypeExtension.DefaultString;
        
        /// <summary>
        /// Force immutability
        /// </summary>
        private ContentType() : base() { }

        /// <summary>
        /// Constructor with data
        /// </summary>
        /// <param name="name"></param>
        public ContentType(string name)
            : this()
        {
            Name = name;
        }

        /// <summary>
        /// Constructor with data
        /// </summary>
        /// <param name="name"></param>
        /// <param name="extension"></param>
        public ContentType(string name, string extension)
            : this()
        {
            Name = name;
            Extension = extension;
        }
    }
}
