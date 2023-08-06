using CSharpEducation.Task4.Entities;

namespace CSharpEducation.Task4.Repositories;

/// <summary>
/// Репозиторий для работы с файлами.
/// </summary>
public class FileRepository : IRepository<FileEntity>
{
  #region Поля и свойства

  /// <summary>
  /// Список файлов.
  /// </summary>
  private readonly List<FileEntity> fileList;

  #endregion

  #region Методы

  /// <summary>
  /// Получение файла по его уникальному идентификатору.
  /// </summary>
  /// <param name="name">Уникальный идентификатор.</param>
  /// <returns>Файл.</returns>
  public FileEntity GetById(Guid id)
  {
    return this.fileList.FirstOrDefault(file => file.Id == id);
  }

  /// <summary>
  /// Получение списка всех файлов.
  /// </summary>
  /// <returns>Список всех файлов.</returns>
  public IEnumerable<FileEntity> GetAll()
  {
    return this.fileList;
  }

  /// <summary>
  /// Создание нового файла.
  /// </summary>
  /// <param name="file">Файл.</param>
  public void Insert(FileEntity file)
  {
    if (!file.FileInfo.Exists)
    {
      using FileStream fs = file.FileInfo.Create();

      this.fileList.Add(file);
    }
  }

  /// <summary>
  /// Удаление сущности.
  /// </summary>
  /// <param name="file">Сущность.</param>
  public void Delete(FileEntity file)
  {
    if (file.FileInfo.Exists)
    {
      this.fileList.Remove(file);
      file.FileInfo.Delete();
    }
  }

  #endregion

  #region Конструктор

  /// <summary>
  /// Инициализация репозитория.
  /// </summary>
  /// <param name="path">Путь к директории.</param>
  public FileRepository(string path)
  {
    var directory = new DirectoryInfo(path);
    this.fileList = new List<FileEntity>();

    foreach (FileInfo file in directory.EnumerateFiles())
    {
      this.fileList.Add(new FileEntity(file));
    }
  }

  #endregion
}
