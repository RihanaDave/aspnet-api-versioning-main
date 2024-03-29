﻿// Copyright (c) .NET Foundation and contributors. All rights reserved.

namespace System;

using System.Reflection;
using static System.Reflection.BindingFlags;

internal static class TypeExtensions
{
    internal static Type[]? GetTypeArgumentsIfMatch( this Type closedType, Type matchingOpenType )
    {
        if ( !closedType.IsGenericType )
        {
            return null;
        }

        var openType = closedType.GetGenericTypeDefinition();

        return ( matchingOpenType == openType ) ? closedType.GetGenericArguments() : null;
    }

    internal static IEnumerable<PropertyInfo> GetBindableProperties( this Type type ) =>
        type.GetProperties( Instance | Public ).Where( p => p.GetGetMethod() != null && p.GetSetMethod() != null );

    internal static Type[]? GetGenericBinderTypeArgs( this Type supportedInterfaceType, Type modelType )
    {
        if ( !modelType.IsGenericType || modelType.IsGenericTypeDefinition )
        {
            return null;
        }

        var modelTypeArguments = modelType.GetGenericArguments();

        if ( modelTypeArguments.Length != supportedInterfaceType.GetGenericArguments().Length )
        {
            return null;
        }

        return modelTypeArguments;
    }
}