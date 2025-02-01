using System;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Productos.Application.Conceptos.Queries.GetConceptos;
using Productos.Application.Conceptos.Commands.CreateConcepto;
using Productos.Domain.Entities;
using Productos.Application.Conceptos.Queries.GetConceptoById;

namespace Presentation.Controllers;

/// <summary>
/// Represents the webinars controller.
/// </summary>
public sealed class ConceptosController : ApiController
{
    /// <summary>
    /// Gets the webinar with the specified identifier, if it exists.
    /// </summary>
    /// <param name="conceptoId">The Concepto identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The Concepto with the specified identifier, if it exists.</returns>
    [HttpGet("{conceptoId:int}")]
    [ProducesResponseType(typeof(ConceptoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetConcepto(int conceptoId, CancellationToken cancellationToken)
    {
        var query = new GetConcpetoByIdQuery(conceptoId);

        var concepto = await Sender.Send(query, cancellationToken);

        return Ok(concepto);
    }

    /// <summary>
    /// Gets the complete list of Conceptos, if it exists.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The complete list of Conceptos, if it exists.</returns>
    [HttpGet("")]
    [ProducesResponseType(typeof(ConceptoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetConceptos(CancellationToken cancellationToken)
    {
        var query = new GetConcpetosQuery();

        var conceptos = await Sender.Send(query, cancellationToken);

        return Ok(conceptos);
    }

    /// <summary>
    /// Creates a new Concepto based on the specified request.
    /// </summary>
    /// <param name="request">The create Concepto request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The identifier of the newly created Concepto.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateConcepto(
        [FromBody] CreateConceptoRequest request,
        CancellationToken cancellationToken)
    {
        var command = request.Adapt<CreateConceptoCommand>();

        var conceptoId = await Sender.Send(command, cancellationToken);

        return CreatedAtAction(nameof(GetConcepto), new { conceptoId }, conceptoId);
    }
}