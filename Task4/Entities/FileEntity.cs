namespace CSharpEducation.Task4.Entities;

/// <summary>
/// Сущность для работы с файлами.
/// </summary>
public class FileEntity : IEntity
{
  /// <inheritdoc />
  public Guid Id { get; }

  /// <summary>
  /// Информация о файле.
  /// </summary>
  public FileInfo FileInfo { get; }

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="fileInfo">Информация о файле.</param>
  public FileEntity(FileInfo fileInfo)
  {
    this.Id = Guid.NewGuid();
    this.FileInfo = fileInfo;
  }
}