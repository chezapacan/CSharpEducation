﻿namespace CSharpEducation.Task4.Entities;

/// <summary>
/// Сущность для работы в памяти.
/// </summary>
public class MemoryEntity : IEntity
{
  /// <inheritdoc />
  public Guid Id { get; }

  /// <summary>
  /// Конструктор.
  /// </summary>
  public MemoryEntity()
  {
    this.Id = Guid.NewGuid();
  }
}
