﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Common.Authentication.Factories;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Common.Authentication.Properties;
using System;
using System.IO;

namespace Microsoft.Azure.Common.Authentication
{
    /// <summary>
    /// Represents current Azure session.
    /// </summary>
    public static class AzureSession
    {        
        /// <summary>
        /// Gets or sets Azure client factory.
        /// </summary>
        public static IClientFactory ClientFactory { get; set; }

        /// <summary>
        /// Gets or sets current Azure profile
        /// </summary>
        public static AzureProfile Profile { get; set; }

        /// <summary>
        /// Gets or sets Azure authentication factory.
        /// </summary>
        public static IAuthenticationFactory AuthenticationFactory { get; set; }

        /// <summary>
        /// Gets or sets data persistence store.
        /// </summary>
        public static IDataStore DataStore { get; set; }

        /// <summary>
        /// Gets or sets profile directory.
        /// </summary>
        public static string ProfileDirectory { get; set; }

        /// <summary>
        /// Gets or sets token cache file path.
        /// </summary>
        public static string TokenCacheFile { get; set; }

        /// <summary>
        /// Gets or sets profile file name.
        /// </summary>
        public static string ProfileFile { get; set; }

        /// <summary>
        /// Gets or sets file name for the migration backup.
        /// </summary>
        public static string OldProfileFileBackup { get; set; }

        /// <summary>
        /// Gets or sets old profile file name.
        /// </summary>
        public static string OldProfileFile { get; set; }

        static AzureSession()
        {
            ClientFactory = new ClientFactory();
            AuthenticationFactory = new AuthenticationFactory();
            DataStore = new DiskDataStore();
            Profile = new AzureProfile();
            AzureSession.OldProfileFile = "WindowsAzureProfile.xml";
            AzureSession.OldProfileFileBackup = "WindowsAzureProfile.xml.bak";
            AzureSession.ProfileDirectory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                Resources.AzureDirectoryName); ;
            AzureSession.ProfileFile = "AzureProfile.json";
            AzureSession.TokenCacheFile = "TokenCache.dat";
        }
    }
}
