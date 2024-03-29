﻿// Copyright (c) .NET Foundation and contributors. All rights reserved.

namespace Asp.Versioning.OData;

#if NETFRAMEWORK
using Microsoft.AspNet.OData;
#else
using Microsoft.AspNetCore.OData.Formatter;
#endif
using Microsoft.OData.Edm;

/// <summary>
/// Defines the behavior of a model type builder.
/// </summary>
public interface IModelTypeBuilder
{
    /// <summary>
    /// Creates and returns a new structured type given the specified structured type, CLR type, and API version.
    /// </summary>
    /// <param name="model">The <see cref="IEdmModel">EDM model</see> the structured type belongs to.</param>
    /// <param name="structuredType">The <see cref="IEdmStructuredType">structured type</see> to evaluate.</param>
    /// <param name="clrType">The CLR <see cref="Type">type</see> mapped to the <paramref name="structuredType">structured type</paramref>.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion">API version</see> associated with the type mapping.</param>
    /// <returns>The original <paramref name="clrType">CLR type</paramref> or a new, dynamically generated substitute <see cref="Type">type</see>
    /// that is a subset of the original <paramref name="clrType">CLR type</paramref>, but maps one-to-one with the
    /// <paramref name="structuredType">structured type</paramref>.</returns>
    /// <remarks>If a substitution is not required, the original <paramref name="clrType">CLR type</paramref> is returned. When a substitution
    /// <see cref="Type">type</see> is generated, it is performed only once per <paramref name="apiVersion">API version</paramref>.</remarks>
    Type NewStructuredType( IEdmModel model, IEdmStructuredType structuredType, Type clrType, ApiVersion apiVersion );

    /// <summary>
    /// Creates an returns a strongly-typed definition for OData action parameters.
    /// </summary>
    /// <param name="model">The <see cref="IEdmModel">EDM model</see> the action belongs to.</param>
    /// <param name="action">The defining <see cref="IEdmAction">action</see>.</param>
    /// <param name="controllerName">The name of the controller that defines the action. Necessary for generating unique parameter types.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion">API version</see> of the <paramref name="action"/> to create the parameter type for.</param>
    /// <returns>A strong <see cref="Type">type</see> definition for the OData <paramref name="action"/> parameters.</returns>
    /// <remarks><see cref="ODataActionParameters">OData action parameters</see> are modeled as a <see cref="Dictionary{TKey,TValue}">dictionary</see>,
    /// which is difficult to use effectively by documentation tools such as the API Explorer. The corresponding type is generated only once per
    /// <paramref name="apiVersion">API version</paramref>.</remarks>
    Type NewActionParameters( IEdmModel model, IEdmAction action, string controllerName, ApiVersion apiVersion );
}