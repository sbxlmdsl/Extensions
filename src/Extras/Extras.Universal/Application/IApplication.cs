//-----------------------------------------------------------------------
// <copyright file="IApplication.cs" company="Genesys Source">
//      Licensed to the Apache Software Foundation (ASF) under one or more 
//      contributor license agreements.  See the NOTICE file distributed with 
//      this work for additional information regarding copyright ownership.
//      The ASF licenses this file to You under the Apache License, Version 2.0 
//      (the 'License'); you may not use this file except in compliance with 
//      the License.  You may obtain a copy of the License at 
//       
//        http://www.apache.org/licenses/LICENSE-2.0 
//       
//       Unless required by applicable law or agreed to in writing, software  
//       distributed under the License is distributed on an 'AS IS' BASIS, 
//       WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.  
//       See the License for the specific language governing permissions and  
//       limitations under the License. 
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Extras.Configuration;
using System;
using System.Threading.Tasks;

namespace Genesys.Extras.Application
{
    /// <summary>
    /// Global application information
    /// </summary>
    public interface IApplication : INavigate, IFrame
    {
        /// <summary>
        /// Configuration data, XML .config style
        /// </summary>
        ConfigurationManagerSafe Configuration { get; }

        /// <summary>
        /// MyWebService
        /// </summary>
        Uri MyWebService { get; }

        /// <summary>
        /// Initializes this class with data, and allows for proper async behavior
        /// </summary>
        /// <returns></returns>f
        Task InitializeAsync(Boolean hasServices);

        /// <summary>
        /// Loads config data
        /// </summary>
        /// <returns></returns>
        Task LoadConfigAsync();

        /// <summary>
        /// Wakes up any sleeping processes, and MyWebService chain
        /// </summary>
        /// <returns></returns>
        Task WakeServicesAsync();

        /// <summary>
        /// Init all locally stored data
        /// </summary>
        Task InitializeAsync();
    }
}
