using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ventas.Application.Ventas.Queries.GetVentas;
using Ventas.Application.Ventas.Commands.CreateVenta;
using Ventas.Application.Ventas.Queries.GetVentaById;

namespace Ventas.Presentation.Controllers;

/// <summary>
/// Represents the webinars controller.
/// </summary>
public sealed class VentasController : ApiController
{
    /// <summary>
    /// Gets the Venta with the specified identifier, if it exists.
    /// </summary>
    /// <param name="ventaId">The Venta identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The Venta with the specified identifier, if it exists.</returns>
    [HttpGet("{ventaId:int}")]
    [ProducesResponseType(typeof(VentaResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetVenta(int ventaId, CancellationToken cancellationToken)
    {
        var query = new GetVentaByIdQuery(ventaId);

        var venta = await Sender.Send(query, cancellationToken);

        return Ok(venta);
    }

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
    public async Task<IActionResult> CreateVenta(
        [FromBody] CreateVentaRequest request,
        CancellationToken cancellationToken)
    {
        var command = request.Adapt<CreateVentaCommand>();

        var ventaId = await Sender.Send(command, cancellationToken);

        return CreatedAtAction(nameof(GetVenta), new { ventaId }, ventaId);
    }
}