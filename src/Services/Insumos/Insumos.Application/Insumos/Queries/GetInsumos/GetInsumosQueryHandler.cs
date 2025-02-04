using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Insumos.Application.Abstractions.Messaging;
using Dapper;
using Insumos.Domain.Exceptions;
using Insumos.Application.Insumos.Queries.GetInsumos;

namespace Insumos.Application.Insumos.Queries.GetInsumos;

internal sealed class GetInsumosQueryHandler : IQueryHandler<GetInsumosQuery, IEnumerable<InsumosResponse>>
{
    private readonly IDbConnection _dbConnection;

    public GetInsumosQueryHandler(IDbConnection dbConnection) => _dbConnection = dbConnection;

    public async Task<IEnumerable<InsumosResponse>> Handle(
        GetInsumosQuery request,
        CancellationToken cancellationToken)
    {
        const string sql = @"SELECT * FROM Insumo";

        var insumos = await _dbConnection.QueryAsync<InsumosResponse>(sql);

        return insumos;
    }
}