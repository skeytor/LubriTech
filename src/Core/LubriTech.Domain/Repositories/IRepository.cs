using SharedKernel.Common;

namespace LubriTech.Domain.Repositories;

public interface IRepository<TEntity, in TId>
    where TEntity : IAggregateRoot
    where TId : IEquatable<TId>
{
    Task<TEntity> InsertAsync(TEntity entity, CancellationToken ct = default);
    ValueTask<TEntity?> FindByIdAsync(TId id, CancellationToken ct = default);
    Task<IReadOnlyList<TEntity>> GetPagedAsync(int page, int size, CancellationToken ct = default);
    Task<int> CountAsync(CancellationToken ct = default);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}