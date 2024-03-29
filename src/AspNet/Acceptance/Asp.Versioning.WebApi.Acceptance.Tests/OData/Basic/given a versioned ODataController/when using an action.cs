﻿// Copyright (c) .NET Foundation and contributors. All rights reserved.

namespace given_a_versioned_ODataController;

using Asp.Versioning.OData.Basic;
using static System.Net.HttpStatusCode;

public class when_using_an_action : BasicAcceptanceTest
{
    [Theory]
    [InlineData( "api/customers/42?api-version=1.0" )]
    [InlineData( "api/customers/42?api-version=2.0" )]
    [InlineData( "api/customers/42?api-version=3.0" )]
    [InlineData( "api/customers?api-version=2.0" )]
    [InlineData( "api/customers?api-version=3.0" )]
    public async Task then_get_should_return_200( string requestUrl )
    {
        // arrange

        // act
        var response = await GetAsync( requestUrl );

        // assert
        response.StatusCode.Should().Be( OK );
    }

    [Theory]
    [InlineData( "api/customers?api-version=1.0" )]
    [InlineData( "api/customers?api-version=2.0" )]
    [InlineData( "api/customers?api-version=3.0" )]
    public async Task then_post_should_return_201( string requestUrl )
    {
        // arrange
        var customer = new { firstName = "John", lastName = "Doe" };

        // act
        var response = await PostAsync( requestUrl, customer );

        // assert
        response.StatusCode.Should().Be( Created );

        // BUG: https://github.com/OData/WebApi/issues/1137
        response.Headers.Location.Should().Be( new Uri( "http://localhost/api/Customers(42)" ) );
    }

    [Fact]
    public async Task then_put_should_return_204()
    {
        // arrange
        var requestUrl = "api/customers/42?api-version=3.0";
        var customer = new { id = 42, firstName = "John", lastName = "Doe", email = "john.doe@somewhere.com" };

        // act
        var response = await PutAsync( requestUrl, customer );

        // assert
        response.StatusCode.Should().Be( NoContent );
    }

    [Theory]
    [InlineData( "api/customers/42" )]
    [InlineData( "api/customers/42?api-version=1.0" )]
    [InlineData( "api/customers/42?api-version=2.0" )]
    [InlineData( "api/customers/42?api-version=3.0" )]
    public async Task then_delete_should_return_204( string requestUrl )
    {
        // arrange

        // act
        var response = await DeleteAsync( requestUrl );

        // assert
        response.StatusCode.Should().Be( NoContent );
    }

    public when_using_an_action( BasicFixture fixture ) : base( fixture ) { }
}