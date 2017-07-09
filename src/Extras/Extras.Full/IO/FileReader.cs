//-----------------------------------------------------------------------
// <copyright file="FileReaderFull.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
// 
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.IO;
using System.Text;
using Genesys.Extensions;

namespace Genesys.Extras.IO
{
    /// <summary>
    /// Search a set of paths on a drive for a folder. 
    ///     Configure with auto search parent and children a certain levels in.
    /// </summary>
    [CLSCompliant(true)]
    public class FileReader
    {
        private string file = TypeExtension.DefaultString; 
        /// <summary>
        /// Constructor
        /// </summary>
        public FileReader() : base() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fileName">Path and file to read</param>
        public FileReader(string fileName)
            : this()
        {
            file = fileName;
        }

        /// <summary>
        /// Reads a file using StreamReader class
        /// </summary>
        public string ReadToEnd()
        {
            var returnValue = TypeExtension.DefaultString;
            using (var streamReader = new StreamReader(file, Encoding.UTF8))
            {
                returnValue = streamReader.ReadToEnd();
            }
            return returnValue;
        }        
    }
}
