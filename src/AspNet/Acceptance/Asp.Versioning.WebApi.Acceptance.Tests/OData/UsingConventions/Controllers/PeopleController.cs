﻿// Copyright (c) .NET Foundation and contributors. All rights reserved.

#pragma warning disable IDE0060 // Remove unused parameter

namespace Asp.Versioning.OData.UsingConventions.Controllers;

using Asp.Versioning.OData.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using System.Web.Http;

public class PeopleController : ODataController
{
    public IHttpActionResult Get( ODataQueryOptions<Person> options ) =>
        Ok( new[] { new Person() { Id = 1, FirstName = "Bill", LastName = "Mei", Email = "bill.mei@somewhere.com", Phone = "555-555-5555" } } );

    public IHttpActionResult Get( int key, ODataQueryOptions<Person> options ) =>
        Ok( new Person() { Id = key, FirstName = "Bill", LastName = "Mei", Email = "bill.mei@somewhere.com", Phone = "555-555-5555" } );

    [MapToApiVersion( "2.0" )]
    public IHttpActionResult Patch( int key, Delta<Person> delta, ODataQueryOptions<Person> options )
    {
        if ( !ModelState.IsValid )
        {
            return BadRequest( ModelState );
        }

        var person = new Person() { Id = key, FirstName = "Bill", LastName = "Mei", Email = "bill.mei@somewhere.com", Phone = "555-555-5555" };

        delta.Patch( person );

        return Updated( person );
    }
}