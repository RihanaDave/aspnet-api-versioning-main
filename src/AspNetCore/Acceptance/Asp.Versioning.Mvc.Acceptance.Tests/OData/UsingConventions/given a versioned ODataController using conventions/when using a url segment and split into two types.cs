﻿// Copyright (c) .NET Foundation and contributors. All rights reserved.

namespace given_a_versioned_ODataController_using_conventions;

using Asp.Versioning;
using Asp.Versioning.OData.UsingConventions;
using static System.Net.HttpStatusCode;

public class when_using_a_url_segment_and_split_into_two_types : ConventionsAcceptanceTest
{
    [Theory]
    [InlineData( "v1/people" )]
    [InlineData( "v1/people/42" )]
    [InlineData( "v2/people" )]
    [InlineData( "v2/people/42" )]
    [InlineData( "v3/people" )]
    [InlineData( "v3/people/42" )]
    public async Task then_get_should_return_200( string requestUrl )
    {
        // arrange


        // act
        var response = ( await GetAsync( requestUrl ) ).EnsureSuccessStatusCode();

        // assert
        response.Headers.GetValues( "api-supported-versions" ).Single().Should().Be( "1.0, 2.0, 3.0" );
    }

    [Fact]
    public async Task then_patch_should_return_204()
    {
        // arrange
        var person = new { id = 42, firstName = "John", lastName = "Doe", email = "john.doe@somewhere.com" };

        // act
        var response = await PatchAsync( "v2/people/42", person );

        // assert
        response.StatusCode.Should().Be( NoContent );
    }

    [Theory]
    [InlineData( "v1/people/42" )]
    [InlineData( "v3/people/42" )]
    public async Task then_patch_should_return_400_if_supported_in_any_version( string requestUrl )
    {
        // arrange
        var person = new { id = 42, firstName = "John", lastName = "Doe", email = "john.doe@somewhere.com" };

        // act
        var response = await PatchAsync( requestUrl, person );
        var problem = await response.Content.ReadAsProblemDetailsAsync();

        // assert
        response.StatusCode.Should().Be( BadRequest );
        problem.Type.Should().Be( ProblemDetailsDefaults.Unsupported.Type );
    }

    [Fact]
    public async Task then_delete_should_return_405_for_unmatched_action()
    {
        // arrange


        // act
        var response = await DeleteAsync( "v1/people/42" );

        // assert
        response.StatusCode.Should().Be( MethodNotAllowed );
    }

    [Fact]
    public async Task then_patch_should_return_404_for_an_unsupported_version()
    {
        // arrange
        var person = new { id = 42, firstName = "John", lastName = "Doe", email = "john.doe@somewhere.com" };

        // act
        var response = await PatchAsync( "v4/people/42", person );

        // assert
        response.StatusCode.Should().Be( NotFound );
    }

    public when_using_a_url_segment_and_split_into_two_types( ConventionsFixture fixture ) : base( fixture ) { }
}