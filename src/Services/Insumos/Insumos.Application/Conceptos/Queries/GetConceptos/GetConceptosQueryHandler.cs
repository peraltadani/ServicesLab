using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Insumos.Application.Abstractions.Messaging;
using Dapper;
using Insumos.Domain.Exceptions;

namespace Insumos.Application.Conceptos.Queries.GetConceptos;

internal sealed class GetConceptosQueryHandler : IQueryHandler<GetConcpetosQuery, IEnumerable<ConceptosResponse>>
{
    private readonly IDbConnection _dbConnection;

    public GetConceptosQueryHandler(IDbConnection dbConnection) => _dbConnection = dbConnection;

    public async Task<IEnumerable<ConceptosResponse>> Handle(
        GetConcpetosQuery request,
        CancellationToken cancellationToken)
    {
        const string sql = @"SELECT * FROM Concepto";

        var conceptos = await _dbConnection.QueryAsync<ConceptosResponse>(sql);

        return conceptos;
    }
}