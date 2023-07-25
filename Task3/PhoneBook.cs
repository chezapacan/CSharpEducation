namespace CSharpEducation.Task3;

/// <summary>
/// Телефонная книга.
/// </summary>
public class PhoneBook
{
  #region Поля и свойства

  /// <summary>
  /// Телефонная книга.
  /// </summary>
  private static PhoneBook instance = null;

  /// <summary>
  /// Cписок абонентов.
  /// </summary>
  public List<Abonent> Abonents { get; private set; }

  /// <summary>
  /// Получение телефонной книги.
  /// </summary>
  public static PhoneBook Instance
  {
    get
    {
      instance ??= new PhoneBook();
      return instance;
    }
  }

  #endregion

  #region Методы

  /// <summary>
  /// Добавление нового абонента с уникальным номером.
  /// </summary>
  /// <param name="abonent">Абонент.</param>
  /// <returns>true, если новый абонент с уникальным номером добавлен, иначе false.</returns>
  public bool Add(Abonent abonent)
  {
    bool alreadyExists = this.Abonents.Exists(elem => elem.Phone == abonent.Phone);

    if (!alreadyExists)
    {
      this.Abonents.Add(abonent);
      return true;
    }

    return false;
  }

  /// <summary>
  /// Удаление абонента по номеру телефона.
  /// </summary>
  /// <param name="phone">Номер телефона.</param>
  /// <returns>true, если абонент с заданным номером удален, иначе false.</returns>
  public bool Remove(string phone)
  {
    Abonent abonent = this.Abonents.Find(elem => elem.Phone == phone);

    if (abonent != null)
    {
      this.Abonents.Remove(abonent);
      return true;
    }

    return false;
  }

  /// <summary>
  /// Изменение имени существующего абонента по номеру телефона.
  /// </summary>
  /// <param name="phone">Номер телефона.</param>
  /// <param name="newName">Новое имя абонента.</param>
  /// <returns>true, если имя существующего абонента изменено, иначе false.</returns>
  public bool UpdateName(string phone, string newName)
  {
    Abonent abonent = this.Abonents.Find(elem => elem.Phone == phone);

    if (abonent != null)
    {
      abonent.Name = newName;
      return true;
    }

    return false;
  }

  /// <summary>
  /// Изменение телефонного нормера существующего абонента.
  /// </summary>
  /// <param name="phone">Телефонный номер.</param>
  /// <param name="newPhone">Новый телефонный номер.</param>
  /// <returns>true, если телефонный номер существующего абонента изменен, иначе false.</returns>
  public bool UpdatePhone(string phone, string newPhone)
  {
    Abonent abonent = this.Abonents.Find(elem => elem.Phone == phone);
    bool alreadyExists = this.Abonents.Exists(elem => elem.Phone == newPhone);

    if (abonent != null && !alreadyExists && newPhone != string.Empty)
    {
      abonent.Phone = newPhone;
      return true;
    }

    return false;
  }

  /// <summary>
  /// Получение абонента по номеру телефона.
  /// </summary>
  /// <param name="phone">Телефонный номер.</param>
  /// <returns>Абонент.</returns>
  public Abonent GetAbonent(string phone)
  {
    return this.Abonents.Find(elem => elem.Phone == phone);
  }

  /// <summary>
  /// Получение телефонных номеров по имени абонента.
  /// </summary>
  /// <param name="name">Имя абонента.</param>
  /// <returns>Телефонные номера.</returns>
  public string[] GetPhoneNumbers(string name)
  {
    string[] phoneNumbers = this.Abonents.FindAll(elem => elem.Name == name).Select(elem => elem.Phone).ToArray();

    return phoneNumbers;
  }

  /// <summary>
  /// Запись всех абонентов в файл.
  /// </summary>
  public void WriteInFile()
  {
    var writer = new StreamWriter(FilePath.PhoneBookPath);
    foreach (Abonent abonent in this.Abonents)
    {
      writer.WriteLine($"{abonent.Phone}:{abonent.Name}");
    }
    writer.Close();
  }

  /// <summary>
  /// Запись всех абонентов из файла.
  /// </summary>
  private void ReadFromFile()
  {
    if (!File.Exists(FilePath.PhoneBookPath)) return;

    var reader = new StreamReader(FilePath.PhoneBookPath);
    string textLine;
    string[] splitedLine;

    while ((textLine = reader.ReadLine()) != null)
    {
      splitedLine = textLine.Split(':');
      this.Abonents.Add(new Abonent() { Phone = splitedLine.First(), Name = splitedLine.Last() });
    }

    reader.Close();
  }

  #endregion

  #region Конструктор

  /// <summary>
  /// Инициализация телефонной книги.
  /// </summary>
  private PhoneBook()
  {
    this.Abonents = new List<Abonent>();
    ReadFromFile();
  }

  #endregion
}

/// <summary>
/// Путь к файлу.
/// </summary>
public static class FilePath
{
  public const string PhoneBookPath = "phonebook.txt";
}