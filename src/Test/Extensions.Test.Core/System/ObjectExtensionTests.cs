﻿//-----------------------------------------------------------------------
// <copyright file="ObjectExtensionTests.cs" company="Genesys Source">
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

namespace Genesys.Extensions.Test
{
    /// <summary>
    /// Tests the extensions
    /// </summary>
    [TestClass()]
    public class ObjectExtensionTests
    {
        public interface IMyClass
        {
            string MyProperty { get; set; }
        }
        public class MyClass1 : IMyClass
        {
            public string MyProperty { get; set; } = "PropertyData1";
        }
        public class MyClass2 : IMyClass
        {
            public string MyProperty { get; set; } = "PropertyData2";
        }
        public class MyClass3
        {
            public string MyProperty { get; set; } = "PropertyData3";
        }

        /// <summary>
        /// Extensions_Object_CastSafe
        /// </summary>
        [TestMethod()]
        public void Object_CastSafe()
        {
            var testItem = new MyClass1();
            var compareItem = new MyClass3();
            Assert.IsTrue(testItem.CastSafe<MyClass3>().GetType() == compareItem.GetType());
        }

        /// <summary>
        /// Extensions_Object_CastSafe
        /// </summary>
        [TestMethod()]
        public void Object_CastOrFill()
        {
            var testItem = new MyClass1();
            var compareItem = new MyClass3();
            Assert.IsTrue(testItem.CastOrFill<MyClass3>().GetType() == compareItem.GetType());
        }

        /// <summary>
        /// Extensions_Object_Fill
        /// </summary>
        [TestMethod()]
        public void Object_Fill()
        {
            var testItem = new MyClass1();
            var fillItem1 = new MyClass2();
            var fillItem2 = new MyClass3();
            fillItem1.Fill(testItem);
            fillItem2.Fill(testItem);
            Assert.IsTrue(testItem.MyProperty == fillItem1.MyProperty);
            Assert.IsTrue(testItem.MyProperty == fillItem2.MyProperty);
            Assert.IsTrue(testItem.MyProperty != new MyClass2().MyProperty);
        }
    }
}