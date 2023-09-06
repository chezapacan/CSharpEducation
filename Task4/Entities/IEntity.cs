namespace CSharpEducation.Task4.Entities;

/// <summary>
/// Сущность.
/// </summary>
public interface IEntity
{
  /// <summary>
  /// Уникальный идентификатор.
  /// </summary>
  Guid Id { get; }
}