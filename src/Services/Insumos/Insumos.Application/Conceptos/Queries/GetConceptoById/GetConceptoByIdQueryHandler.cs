using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Insumos.Application.Abstractions.Messaging;
using Dapper;
using Insumos.Domain.Exceptions;
using Insumos.Domain.Entities;

namespace Insumos.Application.Conceptos.Queries.GetConceptoById;

internal sealed class GetConceptoByIdQueryHandler : IQueryHandler<GetConcpetoByIdQuery, ConceptoResponse>
{
    private readonly IDbConnection _dbConnection;

    public GetConceptoByIdQueryHandler(IDbConnection dbConnection) => _dbConnection = dbConnection;

    public async Task<ConceptoResponse> Handle(
        GetConcpetoByIdQuery request,
        CancellationToken cancellationToken)
    {
        const string sql = @"SELECT * FROM Concepto WHERE ConceptoId = @ConceptoId";

        var concepto = await _dbConnection.QueryFirstOrDefaultAsync<ConceptoResponse>(
            sql,
            new { request.ConceptoId });

        if (concepto is null)
        {
            throw new ConceptoNotFoundException(request.ConceptoId);
        }

        return concepto;
    }
}