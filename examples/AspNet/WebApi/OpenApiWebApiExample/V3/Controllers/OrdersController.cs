﻿namespace ApiVersioning.Examples.V3.Controllers;

using ApiVersioning.Examples.V3.Models;
using Asp.Versioning;
using System.Web.Http;
using System.Web.Http.Description;
using static System.Net.HttpStatusCode;

/// <summary>
/// Represents a RESTful service of orders.
/// </summary>
[ApiVersion( 3.0 )]
[RoutePrefix( "api/orders" )]
public class OrdersController : ApiController
{
    private const string ByIdRouteName = "GetOrderById-" + nameof( V3 );

    /// <summary>
    /// Retrieves all orders.
    /// </summary>
    /// <returns>All available orders.</returns>
    /// <response code="200">Orders successfully retrieved.</response>
    /// <response code="400">The order is invalid.</response>
    [HttpGet]
    [Route]
    [ResponseType( typeof( IEnumerable<Order> ) )]
    public IHttpActionResult Get()
    {
        var orders = new Order[]
        {
            new(){ Id = 1, Customer = "John Doe" },
            new(){ Id = 2, Customer = "John Doe" },
            new(){ Id = 3, Customer = "Jane Doe", EffectiveDate = DateTimeOffset.UtcNow.AddDays( 7d ) },
        };

        return Ok( orders );
    }

    /// <summary>
    /// Gets a single order.
    /// </summary>
    /// <param name="id">The requested order identifier.</param>
    /// <returns>The requested order.</returns>
    /// <response code="200">The order was successfully retrieved.</response>
    /// <response code="404">The order does not exist.</response>
    [HttpGet]
    [Route( "{id:int}", Name = ByIdRouteName )]
    [ResponseType( typeof( Order ) )]
    public IHttpActionResult Get( int id ) => Ok( new Order() { Id = id, Customer = "John Doe" } );

    /// <summary>
    /// Places a new order.
    /// </summary>
    /// <param name="order">The order to place.</param>
    /// <returns>The created order.</returns>
    /// <response code="201">The order was successfully placed.</response>
    /// <response code="400">The order is invalid.</response>
    [HttpPost]
    [Route]
    [ResponseType( typeof( Order ) )]
    public IHttpActionResult Post( [FromBody] Order order )
    {
        if ( !ModelState.IsValid )
        {
            return BadRequest( ModelState );
        }

        order.Id = 42;

        return CreatedAtRoute( ByIdRouteName, new { id = order.Id }, order );
    }

    /// <summary>
    /// Cancels an order.
    /// </summary>
    /// <param name="id">The order to cancel.</param>
    /// <returns>None</returns>
    [HttpDelete]
    [Route( "{id:int}" )]
    public IHttpActionResult Delete( int id ) => StatusCode( NoContent );
}