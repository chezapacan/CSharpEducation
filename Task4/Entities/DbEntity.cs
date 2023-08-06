namespace CSharpEducation.Task4.Entities;

/// <summary>
/// Сущность для базы данных.
/// </summary>
public class DbEntity : IEntity
{
  /// <inheritdoc />
  public Guid Id { get; }

  /// <summary>
  /// Инициализация сущности.
  /// </summary>
  public DbEntity()
  {
    this.Id = Guid.NewGuid();
  }
}
