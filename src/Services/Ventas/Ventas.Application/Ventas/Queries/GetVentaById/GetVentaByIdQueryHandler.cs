using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Ventas.Application.Abstractions.Messaging;
using Ventas.Domain.Exceptions;

namespace Ventas.Application.Ventas.Queries.GetVentaById;

internal sealed class GetVentaByIdQueryHandler : IQueryHandler<GetVentaByIdQuery, VentaResponse>
{
    private readonly IDbConnection _dbConnection;

    public GetVentaByIdQueryHandler(IDbConnection dbConnection) => _dbConnection = dbConnection;

    public async Task<VentaResponse> Handle(
        GetVentaByIdQuery request,
        CancellationToken cancellationToken)
    {
        const string sql = @"SELECT * FROM Venta WHERE InsumoId = @InsumoId";

        var venta = await _dbConnection.QueryFirstOrDefaultAsync<VentaResponse>(
            sql,
            new { request.VentaId });

        if (venta is null)
        {
            throw new VentaNotFoundException(request.VentaId);
        }

        return venta;
    }
}