//-----------------------------------------------------------------------
// <copyright file="JsonSerializer.cs" company="Genesys Source">
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
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using Genesys.Extensions;
using Genesys.Extras.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Genesys.Extras.Serialization
{
    /// <summary>
    /// JSON serialization and deserialization
    /// </summary>
    /// <remarks></remarks>
    [CLSCompliant(true)]
    public class JsonSerializer<T> : Serializer<T>
    {
        /// <summary>
        /// Gets or sets a DateTimeFormat that defines the culturally appropriate format of displaying dates and times.
        /// Default is ISO 8601 DateTime Format. Does not default to microsoft Date()
        /// </summary>
        public DateTimeFormat DateTimeFormatString { get; set; } = new DateTimeFormat(DateTimeExtension.Formats.ISO8601F) { DateTimeStyles = System.Globalization.DateTimeStyles.RoundtripKind };

        /// <summary>
        /// Gets or sets the data contract JSON serializer settings to emit type information.
        /// </summary>
        public EmitTypeInformation EmitTypeInformation { get; set; } = EmitTypeInformation.Never;

        /// <summary>
        /// Constructor
        /// </summary>
        public JsonSerializer() : base() { }

        /// <summary>
        /// Constructor
        /// </summary>
        public JsonSerializer(IListSafe<Type> knownTypes) : base(knownTypes) { }

        /// <summary>
        /// Serializes and returns the JSON as a string
        /// </summary>
        /// <param name="objectToSerialize"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        [SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
        public override string Serialize(T objectToSerialize)
        {
            var returnValue = TypeExtension.DefaultString;
            DataContractJsonSerializer serializer;

            try
            {
                if (objectToSerialize == null && this.EmptyStringAndNullSupported == false) { throw new System.ArgumentNullException("Passed parameter is null. Unable to serialize null objects."); }
                serializer = new DataContractJsonSerializer(objectToSerialize.GetType(), new DataContractJsonSerializerSettings() { EmitTypeInformation = this.EmitTypeInformation, DateTimeFormat = DateTimeFormatString, KnownTypes = this.KnownTypes });
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.WriteObject(stream, objectToSerialize);
                    stream.Position = 0;
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        returnValue = reader.ReadToEnd();
                    }
                }
            }
            catch
            {
                if (ThrowException) throw;
            }

            return returnValue;
        }

        /// <summary>
        /// De-serializes the passed string to an object
        /// </summary>
        /// <param name="stringToDeserialize">Object to deserialize</param>
        /// <returns>Concrete class</returns>
        public override T Deserialize(string stringToDeserialize)
        {
            T returnValue = TypeExtension.InvokeConstructorOrDefault<T>();
            Byte[] bytes = null;
            DataContractJsonSerializer serializer;

            try
            {
                if (stringToDeserialize == TypeExtension.DefaultString && this.EmptyStringAndNullSupported == false) { throw new System.ArgumentNullException("Passed parameter is empty. Unable to deserialize empty strings."); }
                serializer = new DataContractJsonSerializer(typeof(T), new DataContractJsonSerializerSettings() { EmitTypeInformation = this.EmitTypeInformation, DateTimeFormat = DateTimeFormatString, KnownTypes = this.KnownTypes });
                bytes = Encoding.Unicode.GetBytes(stringToDeserialize);
                using (MemoryStream stream = new MemoryStream(bytes))
                {
                    returnValue = (T)serializer.ReadObject(stream);
                }
            }
            catch
            {
                if (ThrowException) throw;
            }

            return returnValue;
        }
    }
}
