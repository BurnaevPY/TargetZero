namespace TargetZero.Domain.Abstractions
{
    /// <summary>
    /// Репозиторий
    /// </summary>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Контекст данных/транзакции
        /// </summary>
        IUnitOfWork UnitOfWork { get; }

    }
}
