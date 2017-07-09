//-----------------------------------------------------------------------
// <copyright file="JsonSerializer.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
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
                serializer = new DataContractJsonSerializer(objectToSerialize.GetType(), new DataContractJsonSerializerSettings() { EmitTypeInformation = this.EmitTypeInformation, DateTimeFormat = this.DateTimeFormatString, KnownTypes = this.KnownTypes });
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
                serializer = new DataContractJsonSerializer(typeof(T), new DataContractJsonSerializerSettings() { EmitTypeInformation = this.EmitTypeInformation, DateTimeFormat = this.DateTimeFormatString, KnownTypes = this.KnownTypes });
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
