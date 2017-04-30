//-----------------------------------------------------------------------
// <copyright file="CustomerSearchModel.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Extensions;
using System;
using System.Collections.Generic;

namespace Genesys.Extras.Test
{
    /// <summary>
    /// Simulates a customer business object search class, for passing over Http and binding to screens
    /// </summary>
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
}
