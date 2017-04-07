//-----------------------------------------------------------------------
// <copyright file="HttpRequestBaseTests.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
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
using Genesys.Extensions;
using Genesys.Extras.Configuration;
using Genesys.Extras.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Genesys.Extras.Test
{
    [TestClass()]
    public class HttpRequestGetTests
    {
        [TestMethod()]
        public async Task Net_HttpRequestGetString_SendAsync()
        {
            ConfigurationManagerSafe configuration = ConfigurationManagerSafeTests.Create();
            var dataOut = TypeExtension.DefaultString;            
            HttpRequestGetString request = new HttpRequestGetString(configuration.AppSettingValue("MyWebService") + "/HomeApi");
            dataOut = await request.SendAsync();
            Assert.IsTrue(request.Response.IsSuccessStatusCode == true);
        }

        [TestMethod()]
        public async Task Net_HttpRequestGet_SendAsync()
        {
            ConfigurationManagerSafe configuration = ConfigurationManagerSafeTests.Create();
            object dataOut;
            HttpRequestGet<object> request = new HttpRequestGet<object>(configuration.AppSettingValue("MyWebService") + "/HomeApi");
            dataOut = await request.SendAsync();
            Assert.IsTrue(request.Response.IsSuccessStatusCode == true);
        }

        public async Task Net_HttpRequestGet_ComplexObject()
        {
            var url = ConfigurationManagerSafeTests.Create().AppSettingValue("MyWebService");
            var request = new HttpRequestGet<CustomerSearchModel>(url);
            var returnValue = await request.SendAsync();
            Assert.IsTrue(returnValue.Results.Count > 0);
        }

        public class CustomerSearchModel
        {
            public int ID { get; set; } = TypeExtension.DefaultInteger;
            public Guid Key { get; set; } = TypeExtension.DefaultGuid;
            public string FirstName { get; set; } = TypeExtension.DefaultString;
            public string MiddleName { get; set; } = TypeExtension.DefaultString;
            public string LastName { get; set; } = TypeExtension.DefaultString;
            public DateTime BirthDate { get; set; } = TypeExtension.DefaultDate;
            public int GenderID { get; set; } = TypeExtension.DefaultInteger;
            public Guid CustomerTypeKey { get; set; } = TypeExtension.DefaultGuid;
            public List<CustomerModel> Results { get; set; } = new List<CustomerModel>();
            public CustomerSearchModel()
                    : base()
            {
            }
        }

        public class CustomerModel
        {
            public int ID { get; set; } = TypeExtension.DefaultInteger;
            public Guid Key { get; set; } = TypeExtension.DefaultGuid;
            public string FirstName { get; set; } = TypeExtension.DefaultString;
            public string MiddleName { get; set; } = TypeExtension.DefaultString;
            public string LastName { get; set; } = TypeExtension.DefaultString;
            public DateTime BirthDate { get; set; } = TypeExtension.DefaultDate;
            public int GenderID { get; set; } = TypeExtension.DefaultInteger;
            public Guid CustomerTypeKey { get; set; } = TypeExtension.DefaultGuid;

            public CustomerModel()
            {
            }            
        }
    }
}
