//-----------------------------------------------------------------------
// <copyright file="EndpointInfoTests.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Genesys.Extras.Net;
using Genesys.Extras.Text;
using Genesys.Extras.Configuration;

namespace Genesys.Extras.Test
{
    [TestClass()]
    public class EndpointInfoTests
    {
        [TestMethod()]
        public void Net_Http_EndpointInfo()
        {
            var controller = "HomeApi";
            var configuration = ConfigurationManagerSafeTests.ConfigurationManagerSafeConstruct();
            StringMutable testData = "Hello world";
            EndpointInfo<StringMutable> endpoint = new EndpointInfo<StringMutable>(configuration.AppSettingValue("MyWebService"), controller, -1, testData, testData);
            Assert.IsTrue(endpoint.GetEndpoint.Url.ToString().Contains("http"));
            Assert.IsTrue(endpoint.GetEndpoint.Url.ToString().Contains(controller));
        }
    }
}