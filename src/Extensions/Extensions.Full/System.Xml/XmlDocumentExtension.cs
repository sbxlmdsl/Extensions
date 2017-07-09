//-----------------------------------------------------------------------
// <copyright file="HttpRequestExtension.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Xml;

namespace Genesys.Extensions
{
    /// <summary>
    /// Extends the XmlDocument class
    /// </summary>
    public static class XmlDocumentExtension
    {
        /// <summary>
        /// Outputs a string equivalent to the xml document
        /// </summary>
        /// <param name="item">XmlDocument to output</param>
        /// <returns>XML document serialized as a string</returns>
        [SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
        public static string Serialize(this XmlDocument item)
        {
            var returnValue = TypeExtension.DefaultString;

            using (var stringWrite = new StringWriter())
            {
                using (var xmlWrite = XmlWriter.Create(stringWrite))
                {
                    item.WriteTo(xmlWrite);
                    xmlWrite.Flush();
                    returnValue = stringWrite.GetStringBuilder().ToString();
                }
            }

            return returnValue;
        }
    }
}
