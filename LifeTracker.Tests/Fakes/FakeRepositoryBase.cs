namespace LifeTracker.Tests.Fakes;

public class FakeRepositoryBase<T> //: IRepositoryBase<T> where T : class
{
    // private List<T> _items;
    // private readonly Func<T, int> _identitySelector;
    //
    // public FakeRepositoryBase(Func<T, int> identitySelector)
    // {
    //     _items = new List<T>();
    //     _identitySelector = identitySelector;
    // }
    //
    // public void SetItems(IEnumerable<T> data)
    // {
    //     _items = data.ToList();
    // }
    //
    // public Task<T> GetByIdAsync(int id)
    // {
    //     return Task.FromResult(_items.FirstOrDefault(item => _identitySelector(item) == id));
    // }
    //
    // public Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filterPredicate = null, params Expression<Func<T, object>>[] includePredicates)
    // {
    //     IEnumerable<T> result = _items.AsQueryable();
    //     if (filterPredicate != null)
    //     {
    //         result = result.Where(filterPredicate.Compile());
    //     }
    //     return Task.FromResult(result);
    // }
    //
    // public Task AddAsync(T entity)
    // {
    //     _items.Add(entity);
    //     return Task.CompletedTask;
    // }
    //
    // public Task UpdateAsync(T entity)
    // {
    //     var existing = _items.FirstOrDefault(x => _identitySelector(x) == _identitySelector(entity));
    //     if (existing != null)
    //     {
    //         var index = _items.IndexOf(existing);
    //         _items[index] = entity;
    //     }
    //     return Task.CompletedTask;
    // }
    //
    // public Task DeleteAsync(T entity)
    // {
    //     _items.Remove(entity);
    //     return Task.CompletedTask;
    // }
}