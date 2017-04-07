//-----------------------------------------------------------------------
// <copyright file="StreamExtension.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.IO;
using System.Xml.Linq;

namespace Genesys.Extensions
{
    /// <summary>
    /// Stream Extender
    /// </summary>
    [CLSCompliant(true)]
    public static class StreamExtension
    {
        /// <summary>
        /// Converts a Stream to XDocument. I.e. Reading an XML file
        /// </summary>
        /// <param name="item">Stream array containing the XDocument data.</param>
        /// <returns>XDocument from a valid Stream, or empty XDocument</returns>
        public static XDocument ToXDocument(this Stream item)
        {
            XDocument returnValue = new XDocument();

            try
            {
                if (item?.Length > 0)
                {
                    returnValue = XDocument.Load(item);
                }
            }
            catch (NullReferenceException)
            {
                returnValue = new XDocument();
            }

            return returnValue;
        }        
    }
}
