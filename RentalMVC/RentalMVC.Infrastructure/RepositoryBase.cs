using Microsoft.EntityFrameworkCore;
using RentalMVC.Domain.Interfaces;
using System.Linq.Expressions;

namespace RentalMVC.Infrastructure;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    private readonly Context _context;
    public RepositoryBase(Context context)
    {
        _context = context;
    }

    public IQueryable<T> FindAll() => _context.Set<T>().AsNoTracking();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
        _context.Set<T>().Where(expression).AsNoTracking();

    public void Create(T entity) => _context.Set<T>().Add(entity);

    public void Update(T entity) => _context.Set<T>().Update(entity);

    public void Remove(T entity) => _context.Set<T>().Remove(entity);
}