﻿// Copyright (c) .NET Foundation and contributors. All rights reserved.

namespace given_a_versioned_Controller;

using Asp.Versioning;
using Asp.Versioning.Mvc.UsingAttributes;
using static System.Net.HttpStatusCode;

[Collection( nameof( BasicTestCollection ) )]
public class when_a_version_is_mapped_only : AcceptanceTest
{
    [Fact]
    public async Task then_get_should_return_404()
    {
        // arrange
        var requestUrl = "api/v42/helloworld/unreachable";

        // act
        var response = await GetAsync( requestUrl );

        // assert
        response.StatusCode.Should().Be( NotFound );
    }

    public when_a_version_is_mapped_only( BasicFixture fixture, ITestOutputHelper console )
        : base( fixture ) => console.WriteLine( fixture.DirectedGraphVisualizationUrl );
}