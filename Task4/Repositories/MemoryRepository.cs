using CSharpEducation.Task4.Entities;

namespace CSharpEducation.Task4.Repositories;

/// <summary>
/// Репозиторий для работы в памяти.
/// </summary>
/// <typeparam name="T">Сущность.</typeparam>
public class MemoryRepository<T> : IRepository<T> where T : MemoryEntity
{
  #region Поля и свойства

  /// <summary>
  /// Коллекция сущностей.
  /// </summary>
  private readonly ICollection<T> entities;

  #endregion

  #region Методы

  /// <inheritdoc />
  public T GetById(Guid id)
  {
    return this.entities.FirstOrDefault(entity => entity.Id == id);
  }

  /// <inheritdoc />
  public IEnumerable<T> GetAll()
  {
    return this.entities;
  }

  /// <inheritdoc />
  public void Insert(T entity)
  {
    this.entities.Add(entity);
  }

  /// <inheritdoc />
  public void Delete(T entity)
  {
    this.entities.Remove(entity);
  }

  #endregion

  #region Контструктор

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="entityList">Коллекция сущностей.</param>
  public MemoryRepository(ICollection<T> entityList)
  {
    this.entities = entityList;
  }

  #endregion
}