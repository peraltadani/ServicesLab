using System;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Insumos.Application.Conceptos.Queries.GetConceptos;
using Insumos.Application.Conceptos.Commands.CreateConcepto;
using Insumos.Domain.Entities;
using Insumos.Application.Conceptos.Queries.GetConceptoById;
using Insumos.Application.Insumos.Queries.GetInsumoById;
using Insumos.Application.Insumos.Queries.GetInsumos;
using Insumos.Application.Insumos.Commands.CreateInsumo;

namespace Insumos.Presentation.Controllers;

/// <summary>
/// Represents the webinars controller.
/// </summary>
public sealed class InsumosController : ApiController
{
    /// <summary>
    /// Gets the Insumo with the specified identifier, if it exists.
    /// </summary>
    /// <param name="insumoId">The Insumo identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The Concepto with the specified identifier, if it exists.</returns>
    [HttpGet("{insumoId:int}")]
    [ProducesResponseType(typeof(ConceptoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetInsumo(int insumoId, CancellationToken cancellationToken)
    {
        var query = new GetInsumoByIdQuery(insumoId);

        var insumo = await Sender.Send(query, cancellationToken);

        return Ok(insumo);
    }

    /// <summary>
    /// Gets the complete list of Insumos, if it exists.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The complete list of Insumos, if it exists.</returns>
    [HttpGet("")]
    [ProducesResponseType(typeof(ConceptoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetInsumos(CancellationToken cancellationToken)
    {
        var query = new GetInsumosQuery();

        var insumos = await Sender.Send(query, cancellationToken);

        return Ok(insumos);
    }

    /// <summary>
    /// Creates a new Insumo based on the specified request.
    /// </summary>
    /// <param name="request">The create Insumo request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The identifier of the newly created Insumo.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateConcepto(
        [FromBody] CreateConceptoRequest request,
        CancellationToken cancellationToken)
    {
        var command = request.Adapt<CreateInsumoCommand>();

        var insumoId = await Sender.Send(command, cancellationToken);

        return CreatedAtAction(nameof(GetInsumo), new { insumoId }, insumoId);
    }
}