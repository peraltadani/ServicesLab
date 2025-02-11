using System.Threading;
using System.Threading.Tasks;

namespace Ventas.Domain.Abstractions;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}