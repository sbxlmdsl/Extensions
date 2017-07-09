//-----------------------------------------------------------------------
// <copyright file="AgeCalculator.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using Genesys.Extensions;

namespace Genesys.Extras.Mathematics
{
    /// <summary>
    /// Calculates age in days and years
    /// </summary>
    /// <remarks></remarks>
    [CLSCompliant(true)]
    public class Age
    {
        private DateTime birthDayField = TypeExtension.DefaultDate;
        private DateTime todayField = TypeExtension.DefaultDate;
        private int yearsField = TypeExtension.DefaultInteger;
        private int daysField = TypeExtension.DefaultInteger;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dateToAge">Date that will be used to calculate age</param>
        public Age(DateTime dateToAge)
            : base()
        {
            yearsField = 0;
            daysField = 0;
            birthDayField = dateToAge;
            todayField = DateTime.UtcNow;
        }

        /// <summary>
        /// Age in years
        /// </summary>
        public int Years
        {
            get
            {
                if (birthDayField != TypeExtension.DefaultDate)
                {
                    yearsField = DateTime.Today.Year - birthDayField.Year;
                    if (birthDayField.AddYears(yearsField) > DateTime.Today)
                    {
                        yearsField = yearsField - 1;
                    }
                }
                return yearsField;
            }
        }

        /// <summary>
        /// Age in days
        /// </summary>
        public int Days
        {
            get
            {
                if (birthDayField != TypeExtension.DefaultDate)
                {
                    daysField = todayField.Subtract(birthDayField).Days;
                }
                return daysField;
            }
        }
    }
}
