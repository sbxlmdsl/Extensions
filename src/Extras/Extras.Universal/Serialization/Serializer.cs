//-----------------------------------------------------------------------
// <copyright file="Serializer.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using Genesys.Extras.Collections;
using Genesys.Extensions;

namespace Genesys.Extras.Serialization
{
    /// <summary>
    /// Generically typed Serialization and Deserialization
    /// </summary>
    /// <typeparam name="T">Type to serialize</typeparam>
    public abstract class Serializer<T> : ISerializer<T>
    {
        /// <summary>
        /// List of types that allow serializer to use a type not explicitly defined. 
        ///   Primarily used to define ISerialier Of IMyType, but pass in object of MyType 
        ///   (serializer blows up on now knowing that MyType exists, only knows about IMyType)
        /// </summary>
        public IListSafe<Type> KnownTypes { get; set; } = new ListSafe<Type>();

        /// <summary>
        /// Setting to throw exception
        /// </summary>
        public bool ThrowException { get; set; } = TypeExtension.DefaultBoolean;

        /// <summary>
        /// Setting to throw exception
        /// </summary>
        public bool EmptyStringAndNullSupported { get; set; } = TypeExtension.DefaultBoolean;

        /// <summary>
        /// Constructor
        /// </summary>
        public Serializer() : base()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Serializer(IListSafe<Type> knownTypes) : base()
        {
            {
                KnownTypes.AddRange(knownTypes);
            }
        }

        /// <summary>
        /// Serializes and returns the object as a string
        /// </summary>
        /// <param name="objectToSerialize"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public abstract string Serialize(T objectToSerialize);

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="stringToDeserialize"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public abstract T Deserialize(string stringToDeserialize);
    }
}
