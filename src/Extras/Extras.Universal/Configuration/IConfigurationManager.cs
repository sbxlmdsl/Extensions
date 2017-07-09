//-----------------------------------------------------------------------
// <copyright file="IConfigurationManager.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace Genesys.Extras.Configuration
{
    /// <summary>
    /// Cross-platform emulator of System.Configuration.ConfigurationManager, for local .config files
    /// Target Projects: Universal Windows 10/8.1, Xamarin Forms, Windows Phone, Portable Class Library
    /// Usage: From the Application project, 1. Read .config XML from filesystem, 2. Pass xml into constructor as strings
    /// </summary>
    [CLSCompliant(true)]
    public interface IConfigurationManager
    {
        /// <summary>
        /// All application settings in the referenced config file
        /// </summary>
        AppSettingList AppSettings { get; }

        /// <summary>
        /// All connection strings in the referenced config file
        /// </summary>
        ConnectionStringList ConnectionStrings { get; }

        /// <summary>
        /// Allows for return of setting when instantiated
        /// </summary>
        /// <param name="key">Key of app setting to retrieve</param>
        /// <returns>App setting that matches the key</returns>
        AppSettingSafe AppSetting(string key);

        /// <summary>
        /// Allows for return of setting when instantiated
        /// </summary>
        /// <param name="key">Key of item to retrieve the value</param>
        /// <returns>Value contents</returns>
        string AppSettingValue(string key);

        /// <summary>
        /// Allows for return of setting when instantiated
        /// </summary>
        /// <param name="key">Key of item to retrieve the value</param>
        /// <returns>Value contents</returns>
        ConnectionStringSafe ConnectionString(string key);

        /// <summary>
        /// Allows for return of setting when instantiated
        /// </summary>
        /// <param name="key">Key of item to retrieve the value</param>
        /// <returns>Value contents</returns>
        string ConnectionStringValue(string key);
    }
}
