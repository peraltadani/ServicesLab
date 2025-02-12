using Dapper;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Ventas.Application.Abstractions.Messaging;
using Ventas.Application.Ventas.Queries.GetConceptos;

namespace Ventas.Application.Ventas.Queries.GetConceptos;

internal sealed class GetVentasQueryHandler : IQueryHandler<GetVentasQuery, IEnumerable<VentasResponse>>
{
    private readonly IDbConnection _dbConnection;

    public GetVentasQueryHandler(IDbConnection dbConnection) => _dbConnection = dbConnection;

    public async Task<IEnumerable<VentasResponse>> Handle(
        GetVentasQuery request,
        CancellationToken cancellationToken)
    {
        const string sql = @"SELECT * FROM Venta";

        var ventas = await _dbConnection.QueryAsync<VentasResponse>(sql);

        return ventas;
    }
}