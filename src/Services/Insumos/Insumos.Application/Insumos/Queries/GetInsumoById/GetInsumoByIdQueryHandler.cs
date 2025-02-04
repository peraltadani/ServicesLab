using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Insumos.Application.Abstractions.Messaging;
using Dapper;
using Insumos.Domain.Exceptions;
using Insumos.Domain.Entities;

namespace Insumos.Application.Insumos.Queries.GetInsumoById;

internal sealed class GetInsumoByIdQueryHandler : IQueryHandler<GetInsumoByIdQuery, InsumoResponse>
{
    private readonly IDbConnection _dbConnection;

    public GetInsumoByIdQueryHandler(IDbConnection dbConnection) => _dbConnection = dbConnection;

    public async Task<InsumoResponse> Handle(
        GetInsumoByIdQuery request,
        CancellationToken cancellationToken)
    {
        const string sql = @"SELECT * FROM Insumo WHERE InsumoId = @InsumoId";

        var insumo = await _dbConnection.QueryFirstOrDefaultAsync<InsumoResponse>(
            sql,
            new { request.InsumoId });

        if (insumo is null)
        {
            throw new ConceptoNotFoundException(request.InsumoId);
        }

        return insumo;
    }
}