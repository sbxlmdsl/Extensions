﻿//-----------------------------------------------------------------------
// <copyright file="StringExtensionTests.cs" company="Genesys Source">
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
using System;
using Genesys.Extensions;

namespace Genesys.Extensions.Test
{
    [TestClass()]
    public class StringExtensionTests
    {
        [TestMethod()]
        public void String_SubstringRight()
        {
            var TestItem = TypeExtension.DefaultUri;
            Assert.IsTrue(TestItem.ToString().SubstringRight(1) == TestItem.ToString().Substring(TestItem.ToString().Length - 1, 1));
        }

        [TestMethod()]
        public void String_SubstringLeft()
        {
            var TestItem = TypeExtension.DefaultUri;
            Assert.IsTrue(TestItem.ToString().SubstringLeft(1) == TestItem.ToString().Substring(0, 1));
        }

        [TestMethod()]
        public void String_SubstringSafe()
        {
            var TestItem = TypeExtension.DefaultUri;
            Assert.IsTrue(TestItem.ToString().SubstringSafe(0, 1).Length == 1);
        }

        [TestMethod()]
        public void String_RemoveFirst()
        {
            var TestItem = TypeExtension.DefaultUri;
            Assert.IsTrue(TestItem.ToString().RemoveFirst("h").Length == TestItem.ToString().Length - 1);
        }

        [TestMethod()]
        public void String_RemoveLast()
        {
            var TestItem = String.Format("{0}/", TypeExtension.DefaultUri);
            Assert.IsTrue(TestItem.RemoveLast("/").Length == TestItem.Length - 1);
        }

        [TestMethod()]
        public void String_ToPascalCase()
        {
            var lower = "hello";
            Assert.IsTrue(lower.ToPascalCase().SubstringLeft(2) == "He");
        }

        [TestMethod()]
        public void String_IsCaseUpper()
        {
            var mixed = "Hello";
            var upper = "HELLO";
            Assert.IsTrue(mixed.IsCaseUpper() == false);
            Assert.IsTrue(upper.IsCaseUpper());
        }

        [TestMethod()]
        public void String_IsCaseLower()
        {
            var mixed = "Hello";
            var lower = "hello";
            Assert.IsTrue(mixed.IsCaseLower() == false);
            Assert.IsTrue(lower.IsCaseLower());
        }

        [TestMethod()]
        public void String_IsCaseMixed()
        {
            var mixed = "Hello";
            var upper = "HELLO";            
            Assert.IsTrue(mixed.IsCaseMixed());
            Assert.IsTrue(upper.IsCaseMixed() == false);
        }

        [TestMethod()]
        public void String_IsFirst()
        {
            var testData = "Hello";
            Assert.IsTrue(testData.IsFirst("H"));
        }

        [TestMethod()]
        public void String_IsLast()
        {
            var testData = "Hello";
            Assert.IsTrue(testData.IsLast("o"));
        }

        [TestMethod()]
        public void String_IsEmail()
        {
            var testDataGood = "testing@GenesysFramework.com";
            var testDataBad = "testingATGenesysFramework.com";
            Assert.IsTrue(testDataGood.IsEmail());
            Assert.IsTrue(testDataBad.IsEmail() == false);
        }

        [TestMethod()]
        public void String_IsInteger()
        {
            var testDataGood = "1234";
            var testDataBad = "OneTwo12";
            Assert.IsTrue(testDataGood.IsInteger());
            Assert.IsTrue(testDataBad.IsInteger() == false);
        }

        [TestMethod()]
        public void String_TryParseBoolean()
        {
            var testDataTrue1 = "1";
            var testDataTrue2 = "11";
            var testDataFalse = "0";
            Assert.IsTrue(testDataTrue1.TryParseBoolean());
            Assert.IsTrue(testDataTrue2.TryParseBoolean());
            Assert.IsTrue(testDataFalse.TryParseBoolean() == false);
        }

        [TestMethod()]
        public void String_TryParseInt32()
        {
            var testDataGood = "1234";
            var testDataBad = "OneTwo12";
            Assert.IsTrue(testDataGood.TryParseInt32() == 1234);
            Assert.IsTrue(testDataBad.TryParseInt32() == TypeExtension.DefaultInteger);
        }

        [TestMethod()]
        public void String_TryParseInt64()
        {
            var testDataGood = "1234";
            var testDataBad = "OneTwo12";
            Assert.IsTrue(testDataGood.TryParseInt64() == 1234);
            Assert.IsTrue(testDataBad.TryParseInt64() == TypeExtension.DefaultInteger);
        }

        [TestMethod()]
        public void String_TryParseGuid()
        {
            var testDataGood = "A8CA69CE-F8C6-4FCC-9FED-6AF9F94879D9";
            var testDataBad = "A869CE-F8C6-4FCC-9FED-6AF994879D9";
            Assert.IsTrue(testDataGood.TryParseGuid() != TypeExtension.DefaultGuid);
            Assert.IsTrue(testDataBad.TryParseGuid() == TypeExtension.DefaultGuid);
        }

        [TestMethod()]
        public void String_TryParseEnum()
        {
            // 1
            string testData1 = EnumExtensionTests.EnumConsumer.MyEnumFlags.one.ToString();            
            var parsedData1 = EnumExtensionTests.EnumConsumer.MyEnumFlags.one;
            var test1 = testData1.TryParseEnum<EnumExtensionTests.EnumConsumer.MyEnumFlags>(EnumExtensionTests.EnumConsumer.MyEnumFlags.one);
            Assert.IsTrue(test1 == parsedData1);
            // 2
            string testData2 = EnumExtensionTests.EnumConsumer.MyEnumFlags.eight.ToString();
            var parsedData2 = EnumExtensionTests.EnumConsumer.MyEnumFlags.eight;
            var test2 = testData2.TryParseEnum<EnumExtensionTests.EnumConsumer.MyEnumFlags>(EnumExtensionTests.EnumConsumer.MyEnumFlags.eight);
            Assert.IsTrue(test2 == parsedData2);
            // 3
            string testType3 = EnumExtensionTests.EnumConsumer.MyEnumInts.one.ToString();
            var parsedType3 = EnumExtensionTests.EnumConsumer.MyEnumInts.one;
            var test3 = testType3.TryParseEnum<EnumExtensionTests.EnumConsumer.MyEnumInts>(EnumExtensionTests.EnumConsumer.MyEnumInts.one);
            Assert.IsTrue(test3 == parsedType3);
        }

        [TestMethod()]
        public void String_TryParseDecimal()
        {
            var testDataGood = "12.00";
            var testDataBad = "OneTwo12";
            Assert.IsTrue(testDataGood.TryParseDecimal() == 12.00M);
            Assert.IsTrue(testDataBad.TryParseDecimal() == TypeExtension.DefaultDecimal);
        }

        [TestMethod()]
        public void String_TryParseDouble()
        {
            var testDataGood = "12.00";
            var testDataBad = "OneTwo12";
            Assert.IsTrue(testDataGood.TryParseDouble() == 12.00);
            Assert.IsTrue(testDataBad.TryParseDouble() == TypeExtension.DefaultDouble);
        }

        [TestMethod()]
        public void String_TryParseDateTime()
        {
            var testDataGood = "08/24/2011";
            var testDataBad = "badDate";
            Assert.IsTrue(testDataGood.TryParseDateTime().Month == 8);
            Assert.IsTrue(testDataBad.TryParseDateTime() == TypeExtension.DefaultDate);
        }

        [TestMethod()]
        public void String_TryParseTime()
        {
            var testDataGood = "10:45 PM";
            var testDataBad = "badTime";
            Assert.IsTrue(testDataGood.TryParseTime().Minute == 45);
            Assert.IsTrue(testDataBad.TryParseTime().Minute == TypeExtension.DefaultDate.Minute );
        }
    }
}