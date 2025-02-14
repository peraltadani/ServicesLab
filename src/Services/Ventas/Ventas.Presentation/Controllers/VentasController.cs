using System;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ventas.Domain.Entities;
using Ventas.Application.Ventas.Queries.GetVentas;
using Ventas.Application.Ventas.Commands.CreateVenta;

namespace Ventas.Presentation.Controllers;

/// <summary>
/// Represents the webinars controller.
/// </summary>
public sealed class VentasController : ApiController
{


    /// <summary>
    /// Gets the complete list of Ventas, if it exists.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The complete list of Ventas, if it exists.</returns>
    [HttpGet("")]
    [ProducesResponseType(typeof(VentasResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetVentas(CancellationToken cancellationToken)
    {
        var query = new GetVentasQuery();

        var ventas = await Sender.Send(query, cancellationToken);

        return Ok(ventas);
    }

    /// <summary>
    /// Creates a new Venta based on the specified request.
    /// </summary>
    /// <param name="request">The create Venta request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The identifier of the newly created Venta.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateConcepto(
        [FromBody] CreateVentaRequest request,
        CancellationToken cancellationToken)
    {
        var command = request.Adapt<CreateVentaCommand>();

        var insumoId = await Sender.Send(command, cancellationToken);

        return CreatedAtAction(nameof(GetVentas), new { insumoId }, insumoId);
    }
}