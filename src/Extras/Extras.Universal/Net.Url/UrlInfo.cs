//-----------------------------------------------------------------------
// <copyright file="UrlInfo.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using Genesys.Extensions;

namespace Genesys.Extras.Net
{
    /// <summary>
    /// Encapsulates common Uri and Routing components
    /// </summary>
    /// <returns></returns>
    /// <remarks></remarks>
    [CLSCompliant(true)]
    public class UrlInfo : UrlBuilder
    {        
        /// <summary>
        /// DisplayName of this Url
        /// </summary>
        public string Name { get; set; } = TypeExtension.DefaultString;
        /// <summary>
        /// RootValue
        /// </summary>
        private string RootValue = TypeExtension.DefaultString;
        /// <summary>
        /// Root
        /// </summary>
        public string Root { get { return RootValue; } protected set { RootValue = value.RemoveLast("/"); } }
        /// <summary>
        /// Controller
        /// </summary>
        public string Controller { get; protected set; } = TypeExtension.DefaultString;
        /// <summary>
        /// Action
        /// </summary>
        public string Action { get; protected set; } = TypeExtension.DefaultString;
        /// <summary>
        /// Route
        /// </summary>
        public string Route { get { return Path.RemoveFirst("/").RemoveLast("/"); } }

        /// <summary>
        /// Constructor
        /// </summary>
        public UrlInfo() : base() { }
        /// <summary>
        /// Constructor
        /// </summary>
        public UrlInfo(string rootUrl, string path) : base(rootUrl, path) { }
        /// <summary>
        /// Constructor tuned for MVC pattern
        /// </summary>
        public UrlInfo(string rootUrl, string controller, string action) : base(String.Format("{0}/{1}/{2}", rootUrl.RemoveLast("/"), controller, action))
        {
            Root = rootUrl;
            Controller = controller;
            Action = action;
        }
        /// <summary>
        /// Constructor tuned for MVC pattern
        /// </summary>
        public UrlInfo(string fullUrl) : base(fullUrl) { }
        
    }    
}
