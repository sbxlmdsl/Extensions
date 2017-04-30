//-----------------------------------------------------------------------
// <copyright file="IWpfApplication.cs" company="Genesys Source">
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
using System;
using System.Threading.Tasks;
using Genesys.Extras.Configuration;

namespace Genesys.Extras.Application
{
    /// <summary>
    /// Global application information
    /// </summary>
    public interface IWpfApplication : IApplication
    {
        /// <summary>
        /// Persistent ConfigurationManager class, automatically loaded with this project .config files
        /// </summary>
        ConfigurationManagerFull ConfigurationManager { get; }

        /// <summary>
        /// Entry point Screen (Typically login screen)
        /// </summary>
        Uri LandingPage { get; }

        /// <summary>
        /// Home dashboard screen
        /// </summary>
        Uri HomePage { get; }

        /// <summary>
        /// Error screen
        /// </summary>
        Uri ErrorPage { get; }
    }
}
