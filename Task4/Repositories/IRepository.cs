using CSharpEducation.Task4.Entities;

namespace CSharpEducation.Task4.Repositories;

/// <summary>
/// Репозиторий.
/// </summary>
/// <typeparam name="T">Сущность.</typeparam>
public interface IRepository<T> where T : IEntity
{
  /// <summary>
  /// Получение сущности по уникальному идентификатору.
  /// </summary>
  /// <param name="id">Уникальный идентификатор.</param>
  /// <returns>Сущность.</returns>
  T GetById(Guid id);

  /// <summary>
  /// Получение всех сущностей.
  /// </summary>
  /// <returns></returns>
  IEnumerable<T> GetAll();

  /// <summary>
  /// Вставка новой сущности.
  /// </summary>
  /// <param name="entity">Сущность.</param>
  void Insert(T entity);

  /// <summary>
  /// Удаление сущности.
  /// </summary>
  /// <param name="entity">Сущность.</param>
  void Delete(T entity);
}
