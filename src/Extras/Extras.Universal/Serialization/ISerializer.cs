//-----------------------------------------------------------------------
// <copyright file="ISerializer.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Extras.Collections;
using System;

namespace Genesys.Extras.Serialization
{
    /// <summary>
    /// Strongly typed serializer
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [CLSCompliant(true)]
    public interface ISerializer<T>
    {
        /// <summary>
        /// List of types that allow serializer to use a type not explicitly defined. 
        ///   Primarily used to define ISerialier Of IMyType, but pass in object of MyType 
        ///   (serializer blows up on now knowing that MyType exists, only knows about IMyType)
        /// </summary>
        IListSafe<Type> KnownTypes { get; set; }

        /// <summary>
        /// Setting to throw exception
        /// </summary>
        bool ThrowException { get; set; }

        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="objectToSerialize"></param>
        /// <returns></returns>
        string Serialize(T objectToSerialize);

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="stringToDeserialize"></param>
        /// <returns></returns>
        T Deserialize(string stringToDeserialize);
    }
}
