﻿// Copyright (c) .NET Foundation and contributors. All rights reserved.

namespace Asp.Versioning;

#if NETFRAMEWORK
using HttpRequest = System.Net.Http.HttpRequestMessage;
#else
using Microsoft.AspNetCore.Http;
#endif

/// <summary>
/// Represents the default <see cref="IApiVersionSelector">API version selector</see>.
/// </summary>
#if !NETFRAMEWORK
[CLSCompliant( false )]
#endif
public sealed class DefaultApiVersionSelector : IApiVersionSelector
{
    private readonly ApiVersioningOptions options;

    /// <summary>
    /// Initializes a new instance of the <see cref="DefaultApiVersionSelector"/> class.
    /// </summary>
    /// <param name="options">The <see cref="ApiVersioningOptions">API versioning options</see> associated with the selector.</param>
    public DefaultApiVersionSelector( ApiVersioningOptions options ) => this.options = options;

    /// <summary>
    /// Selects an API version given the specified HTTP request and API version information.
    /// </summary>
    /// <param name="request">The <see cref="HttpRequest">HTTP request</see> to select the version for.</param>
    /// <param name="model">The <see cref="ApiVersionModel">model</see> to select the version from.</param>
    /// <returns>The selected <see cref="ApiVersion">API version</see>.</returns>
    public ApiVersion SelectVersion( HttpRequest request, ApiVersionModel model ) => options.DefaultApiVersion;
}