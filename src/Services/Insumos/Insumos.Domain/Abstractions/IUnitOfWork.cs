using System.Threading;
using System.Threading.Tasks;

namespace Insumos.Domain.Abstractions;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}