using System.Threading;
using System.Threading.Tasks;

namespace TargetZero.Domain.Abstractions
{
    /// <summary>
    /// Контекст данных
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Сохранение данных в репозиторий
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Сохранение данных в репозиторий
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
    }
}
