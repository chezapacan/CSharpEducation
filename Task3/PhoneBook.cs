namespace CSharpEducation.Task3;

/// <summary>
/// Телефонная книга.
/// </summary>
public class PhoneBook
{
  /// <summary>
  /// Список абонентов.
  /// </summary>
  private List<Abonent> abonents;

  /// <summary>
  /// Телефонная книга.
  /// </summary>
  private static PhoneBook instance = null;

  /// <summary>
  /// Получение списка абонентов.
  /// </summary>
  public List<Abonent> Abonents { get => abonents; }

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

  /// <summary>
  /// Инициализация телефонной книги.
  /// </summary>
  private PhoneBook()
  {
    var reader = new StreamReader("phonebook.txt");
    this.abonents = new List<Abonent>();
    string textLine;
    string[] splitedLine;

    while ((textLine = reader.ReadLine()) != null)
    {
      splitedLine = textLine.Split(':');
      this.abonents.Add(new Abonent() { Phone = splitedLine.First(), Name = splitedLine.Last() });
    }

    reader.Close();
  }

  /// <summary>
  /// Добавление нового абонента с уникальным номером.
  /// </summary>
  /// <param name="abonent">Абонент.</param>
  /// <returns>true, если новый абонент с уникальным номером добавлен, иначе false.</returns>
  public bool Add(Abonent abonent)
  {
    bool alreadyExists = this.abonents.Exists(elem => elem.Phone == abonent.Phone);

    if (!alreadyExists)
    {
      this.abonents.Add(abonent);
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
    Abonent abonent = this.abonents.Find(elem => elem.Phone == phone);

    if (abonent != null)
    {
      this.abonents.Remove(abonent);
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
    Abonent abonent = this.abonents.Find(elem => elem.Phone == phone);

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
    Abonent abonent = this.abonents.Find(elem => elem.Phone == phone);
    bool alreadyExists = this.abonents.Exists(elem => elem.Phone == newPhone);

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
    return this.abonents.Find(elem => elem.Phone == phone);
  }

  /// <summary>
  /// Получение телефонных номеров по имени абонента.
  /// </summary>
  /// <param name="name">Имя абонента.</param>
  /// <returns>Телефонные номера.</returns>
  public string[] GetPhoneNumbers(string name)
  {
    string[] phoneNumbers = this.abonents.FindAll(elem => elem.Name == name).Select(elem => elem.Phone).ToArray();

    return phoneNumbers;
  }

  /// <summary>
  /// Запись всех абонентов в файл.
  /// </summary>
  public void WriteInFile()
  {
    var writer = new StreamWriter("phonebook.txt");
    foreach (Abonent abonent in this.abonents)
    {
      writer.WriteLine($"{abonent.Phone}:{abonent.Name}");
    }
    writer.Close();
  }
}
