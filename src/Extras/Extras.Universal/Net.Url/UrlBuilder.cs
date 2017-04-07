//-----------------------------------------------------------------------
// <copyright file="UrlBuilder.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using Genesys.Extensions;
using Genesys.Extras.Text.Encoding;

namespace Genesys.Extras.Net
{
    /// <summary>
    /// Builds URLs similary to and dependent on the UriBuilder class
    /// Uri Layout: [scheme]://[user]:[password]@[host/authority]:[port]/[path];[params]?[querystring]#[fragment]
    /// </summary>
    /// <returns></returns>
    /// <remarks></remarks>
    [CLSCompliant(true)]
    public class UrlBuilder : UriBuilder
    {
        /// <summary>
        /// Default Url value when initialized or in lieu of an exception for invalid Uri format scenarios
        /// </summary>
        public virtual string DefaultUrl { get; set; } = "http://localhost";

        /// <summary>
        /// Constructor
        /// </summary>
        public UrlBuilder() : base() { }

        /// <summary>
        /// Constructor
        /// </summary>
        public UrlBuilder(string fullUrl) : base(fullUrl) { }

        /// <summary>
        /// Constructor
        /// </summary>
        public UrlBuilder(string rootUrl, string path) : this(rootUrl.RemoveLast("/") + "/" + path.RemoveLast("/")) { }

        /// <summary>
        /// Constructor
        /// </summary>
        public UrlBuilder(string rootUrl, string controller, string action) : this(UrlBuilder.Format(rootUrl, controller, action)) { }

        /// <summary>
        /// Constructor
        /// </summary>
        public UrlBuilder(string rootUrl, string controller, string action, string parametersWithNoLeadingQuestionMark) : this(rootUrl.RemoveLast("/"), controller, action)
        {
            Query = parametersWithNoLeadingQuestionMark;
        }

        /// <summary>
        /// handles URL formation issues
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var returnValue = TypeExtension.DefaultString;
            try
            {
                returnValue = base.ToString();
            }
            catch
            {
                returnValue = this.DefaultUrl;
            }
            return returnValue;
        }

        /// <summary>
        /// Formats full URL based on Mvc pattern segments
        /// </summary>
        /// <param name="rootUrl"></param>
        /// <param name="controller"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static string Format(string rootUrl, string controller, string action)
        {
            return String.Format("{0}/{1}/{2}", rootUrl.RemoveLast("/"), controller, action);
        }

        /// <summary>
        /// Encodes to URL friendly
        /// </summary>
        /// <param name="originalString"></param>
        /// <returns></returns>
        public static string Encode(string originalString)
        {
            return UrlEncoder.Encode(originalString);
        }

        /// <summary>
        /// Decodes to URL friendly
        /// </summary>
        /// <param name="originalString"></param>
        /// <returns></returns>
        public static string Decode(string originalString)
        {
            return UrlEncoder.Decode(originalString);
        }
    }
}
