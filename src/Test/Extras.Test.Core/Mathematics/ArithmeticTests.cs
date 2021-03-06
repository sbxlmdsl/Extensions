﻿//-----------------------------------------------------------------------
// <copyright file="ArithmeticTests.cs" company="Genesys Source">
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
using Genesys.Extras.Mathematics;
using System.Collections.Generic;

namespace Genesys.Extras.Test
{
    /// <summary>
    /// Arithmetic Tests
    /// </summary>
    [TestClass()]
    public class ArithmeticTests
    {
        [TestMethod()]
        public void Mathematics_Arithmetic_Addition()
        {
            Assert.IsTrue(Arithmetic.Addition(5, 6) == 11);
        }

        [TestMethod()]
        public void Mathematics_Arithmetic_Subtraction()
        {
            Assert.IsTrue(Arithmetic.Subtraction(6, 6) == 0);
        }

        [TestMethod()]
        public void Mathematics_Arithmetic_Multiply()
        {
            Assert.IsTrue(Arithmetic.Multiply(5, 6) == 30);
        }

        [TestMethod()]
        public void Mathematics_Arithmetic_Divide()
        {
            Assert.IsTrue(Arithmetic.Divide(5, 5) == 1);
        }
        
        [TestMethod()]
        public void Mathematics_Arithmetic_AverageDecimal()
        {
            List<decimal> data = new List<decimal>() { 1, 1, 3, 3 };
            Assert.IsTrue(Arithmetic.AverageDecimal(data) == 2);
        }

        [TestMethod()]
        public void Mathematics_Arithmetic_ROI()
        {
            // ToDo: Assert.Fail();
        }

        /// <summary>
        /// Ensures Arithmentic.Random method behaves per spec
        /// </summary>
        [TestMethod()]
        public void Mathematics_Arithmetic_Random()
        {
            // Should be semi unique
            var randoms = new List<int>();
            for(var count = 0; count < 30;  count++)
            {
                var random = Arithmetic.Random();
                randoms.Add(random);
            }
            var doubleCheck = Arithmetic.Random();
            Assert.IsTrue(randoms.Contains(doubleCheck) == false);

            // Should be able to be defined by length, for pin codes, etc.
            for (var count = 1; count < 11; count++)
            {
                var randomResult = (long)Arithmetic.Random(count);
                var length = randomResult.ToString().Length;
                Assert.IsTrue(length == count, "Did not work.");
            }            
        }        
    }
}