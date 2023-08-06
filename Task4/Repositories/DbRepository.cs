using CSharpEducation.Task4.Entities;
using Microsoft.EntityFrameworkCore;

namespace CSharpEducation.Task4.Repositories;

/// <summary>
/// Репозиторий для работы с базой данных.
/// </summary>
/// <typeparam name="T">Сущность.</typeparam>
public class DbRepository<T> : IRepository<T> where T : DbEntity
{
  #region Поля и свойства

  /// <summary>
  /// Коллекция сущностей.
  /// </summary>
  private readonly DbSet<T> dbSet;

  #endregion

  #region Методы

  /// <inheritdoc />
  public T GetById(Guid id)
  {
    return dbSet.Single(entity => entity.Id == id);
  }

  /// <inheritdoc />
  public IEnumerable<T> GetAll()
  {
    return dbSet;
  }

  /// <inheritdoc />
  public void Insert(T entity)
  {
    dbSet.Add(entity);
  }

  /// <inheritdoc />
  public void Delete(T entity)
  {
    dbSet.Remove(entity);
  }

  /// <summary>
  /// Обновление сущности.
  /// </summary>
  /// <param name="entity">Сущность.</param>
  public void Update(T entity)
  {
    dbSet.Entry(entity).State = EntityState.Modified;
  }

  #endregion

  #region Конструктор

  /// <summary>
  /// Инициализация репозитория.
  /// </summary>
  /// <param name="entityList">Коллекция сущностей.</param>
  public DbRepository(DbSet<T> dbSet)
  {
    this.dbSet = dbSet;
  }

  #endregion
}
