﻿//-----------------------------------------------------------------------
// <copyright file="UrlBuilderTests.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Genesys.Extras.Net;
using System.Collections.Generic;
using System;
using Genesys.Extensions;
using Genesys.Extras.Collections;
using Genesys.Extras.Text;

namespace Genesys.Extras.Test
{
    [TestClass()]
    public class UrlBuilderTests
    {
        public Uri LocalhostWithPortAsUri { get; set; } = TypeExtension.DefaultUri;
        public string LocalhostWithPortAsString { get; set; } = "http://localhost:80";
        public List<string> ParameterList = new List<string>() { "param1", "param2", "param3" };
        public KeyValueListString QuerystringList = new KeyValueListString() { { "key1", "param1" }, { "key2", "param2" }, { "key3", "param3" } };

        [TestMethod()]
        public void Net_UrlBuilder()
        {
            var testItem = new UrlBuilder(LocalhostWithPortAsString);
            Assert.IsTrue(testItem.ToString() == LocalhostWithPortAsString);
            Assert.IsTrue(testItem.ToString() == LocalhostWithPortAsUri.OriginalString);
        }

        [TestMethod()]
        public void Net_UrlBuilder_ParameterBinding()
        {
            var parameterValues = new List<string>() { "param1", "param2", "param3" };
            var testItem = new UrlBuilder(LocalhostWithPortAsUri.ToString(), parameterValues);
            Assert.IsTrue(testItem.ToString().Contains("http://"));
            Assert.IsTrue(testItem.ToString().Contains("/param1/param2/param3"));
        }

        [TestMethod()]
        public void Net_UrlBuilder_Querystring()
        {
            // Test manually building querystring uri
            string manualQuerystring = "http://localhost:80";
            manualQuerystring += String.Join("&", QuerystringList.ToString("QS"));
            manualQuerystring = manualQuerystring.RemoveFirst("&");
            manualQuerystring = manualQuerystring.AddFirst("?");
            Assert.IsTrue(manualQuerystring.Contains(LocalhostWithPortAsString));
            Assert.IsTrue(manualQuerystring.Contains("?key1=param1"));
            Assert.IsTrue(manualQuerystring.Contains("&key2=param2"));
            Assert.IsTrue(manualQuerystring.Contains("&key3=param3"));

            // Now test UrlBuilder
            var testItem = new UrlBuilder(LocalhostWithPortAsUri.ToString(), QuerystringList);
            Assert.IsTrue(testItem.ToString().Contains(LocalhostWithPortAsString));
            Assert.IsTrue(testItem.ToString().Contains("?key1=param1"));
            Assert.IsTrue(testItem.ToString().Contains("&key2=param2"));
            Assert.IsTrue(testItem.ToString().Contains("&key3=param3"));
        }

        [TestMethod()]
        public void Net_UrlBuilder_ToString()
        {
            var testItem = new UrlBuilder(LocalhostWithPortAsUri.ToString());
            Assert.IsTrue(testItem.ToString() == LocalhostWithPortAsString);
        }

        [TestMethod()]
        public void Net_UrlBuilder_Encode()
        {
            Assert.IsTrue(UrlBuilder.Encode("@Test") == "%40Test", "Encode failed");
        }

        [TestMethod()]
        public void Net_UrlBuilder_Decode()
        {
            Assert.IsTrue(UrlBuilder.Decode("%40Test") == "@Test", "Encode failed");
        }
    }
}