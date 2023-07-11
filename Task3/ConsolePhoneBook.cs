namespace CSharpEducation.Task3;

/// <summary>
/// Работа с телефонной книгой в консоли.
/// </summary>
public static class ConsolePhoneBook
{

  /// <summary>
  /// Отрисовка телефонной книги в консоли.
  /// </summary>
  /// <param name="phoneBook">Телефонная книга.</param>
  public static void PrintPhoneBook(PhoneBook phoneBook)
  {
    List<Abonent> abonents = phoneBook.Abonents;

    Console.Clear();

    Console.WriteLine("0. Меню");
    for (int i = 0; i < abonents.Count; i++)
      Console.WriteLine($"{i + 1}. {abonents[i].Phone} - {abonents[i].Name}");

    int choosenOption = ChooseOption(abonents.Count);

    Console.Clear();

    Abonent choosenAbonent = null;
    if (choosenOption > 0)
    {
      choosenAbonent = abonents[choosenOption - 1];
      Console.WriteLine($"{choosenAbonent.Phone} - {choosenAbonent.Name}");
    }

    // В зависимости от выбора "Меню" (choosenOption = 0) или "Абонента" (choosenOption > 0) меняются допустимые опции.
    var options = choosenOption == 0
    ? new Dictionary<string, Action<PhoneBook>>()
    {
      {"Добавить нового абонента", AddAbonent},
      {"Поиск пользователя по телефону", GetAbonent},
      {"Поиск телефонных номеров по имени", GetPhoneNumber},
      {"Сохранение и выход", SaveAbonents},
    }
    : new Dictionary<string, Action<PhoneBook>>()
    {
      {"Удалить абонента из телефонной книги", RemoveAbonent(choosenAbonent.Phone)},
      {"Изменить имя абонента", ChangeAbonentName(choosenAbonent.Phone)},
      {"Изменить телефонный номер абонента", ChangeAbonentPhoneNumber(choosenAbonent.Phone)},
    };

    GetOptions(options, phoneBook);
  }

  /// <summary>
  /// Выбор опции.
  /// </summary>
  /// <param name="optionsCount">Количество опций.</param>
  /// <returns>Выбранная опция.</returns>
  private static int ChooseOption(int optionsCount)
  {
    int option = -1;
    bool isCorrectOption = false;

    static void clearLastLine()
    {
      Console.SetCursorPosition(0, Console.CursorTop - 1);
      Console.Write(new string(' ', Console.BufferWidth));
      Console.SetCursorPosition(0, Console.CursorTop - 1);
    }

    Console.WriteLine("-------------------------------");
    while (!isCorrectOption)
    {
      Console.Write("Введите номер для выбора опции: ");
      isCorrectOption = int.TryParse(Console.ReadLine(), out option) && option >= 0 && option <= optionsCount;

      clearLastLine();
    }

    return option;
  }

  /// <summary>
  /// Ввыводит список опций.
  /// </summary>
  /// <param name="options">Опции.</param>
  /// <param name="phoneBook">Телефонная книга.</param>
  private static void GetOptions(Dictionary<string, Action<PhoneBook>> options, PhoneBook phoneBook)
  {
    Console.WriteLine("0. Назад");
    int index = 1;
    foreach (var option in options)
    {
      Console.WriteLine($"{index}. {option.Key}");
      index++;
    }

    int chosenOption = ChooseOption(options.Count);

    if (chosenOption == 0)
      return;
    else
      options.ElementAt(chosenOption - 1).Value(phoneBook);
  }

  /// <summary>
  /// Добавление нового абонента в телефонную книгу.
  /// </summary>
  /// <param name="phoneBook">Телефонная книга.</param>
  private static void AddAbonent(PhoneBook phoneBook)
  {
    string phone;
    string name;
    bool isAdded = false;

    Console.Clear();

    while (!isAdded)
    {
      Console.Write("Введите телефон нового абонента: ");
      phone = Console.ReadLine();
      Console.Write("Введите имя нового абонента: ");
      name = Console.ReadLine();

      if (phone.Length != 0 && name.Length != 0)
        isAdded = phoneBook.Add(new Abonent() { Phone = phone, Name = name });

      if (!isAdded)
        Console.WriteLine("Введены некорректные данные или пользователь с таким номером уже существует.");
    }
  }

  /// <summary>
  /// Вывод абонента по введенному номеру.
  /// </summary>
  /// <param name="phoneBook">Телефонная книга.</param>
  private static void GetAbonent(PhoneBook phoneBook)
  {
    Console.Clear();
    Console.Write("Введите номер телефона: ");
    string phone = Console.ReadLine();
    Abonent abonent = phoneBook.GetAbonent(phone);

    if (abonent == null)
      Console.WriteLine("Пользователь не найден");
    else
      Console.WriteLine($"{abonent.Phone} - {abonent.Name}");

    Console.ReadKey();
  }

  /// <summary>
  /// Вывод всех телефонных номеров по имени.
  /// </summary>
  /// <param name="phoneBook">Телефонная книга.</param>
  private static void GetPhoneNumber(PhoneBook phoneBook)
  {
    Console.Clear();
    Console.Write("Введите имя пользователя: ");
    string name = Console.ReadLine();
    string[] phoneNumbers = phoneBook.GetPhoneNumbers(name);

    if (phoneNumbers.Length == 0)
    {
      Console.WriteLine("Номера не найдены");
    }
    else
    {
      Console.WriteLine($"Номера {name}:");
      foreach (string phoneNumber in phoneNumbers)
        Console.WriteLine(phoneNumber);
    }

    Console.ReadKey();
  }

  /// <summary>
  /// Сохранение всех абонентов в файл и выход из программы.
  /// </summary>
  /// <param name="phoneBook">Телефонная книга.</param>
  private static void SaveAbonents(PhoneBook phoneBook)
  {
    phoneBook.WriteInFile();
    Environment.Exit(0);
  }

  /// <summary>
  /// Удаление абонента из телефонной книги.
  /// </summary>
  /// <param name="phone">Телефонный номер.</param>
  /// <returns>Функция удаления абонента.</returns>
  private static Action<PhoneBook> RemoveAbonent(string phone)
  {
    return (phoneBook) => phoneBook.Remove(phone);
  }

  /// <summary>
  /// Изменение имени абонента.
  /// </summary>
  /// <param name="phone">Телефонный номер.</param>
  /// <returns>Функция ввода и изменении имени абонента.</returns>
  private static Action<PhoneBook> ChangeAbonentName(string phone)
  {
    return (phoneBook) =>
    {
      Console.Clear();
      Console.Write("Введите новое имя абонента: ");
      string newName = Console.ReadLine();
      phoneBook.UpdateName(phone, newName);
    };
  }

  /// <summary>
  /// Изменение телефонного номера абонента.
  /// </summary>
  /// <param name="phone">Телефонный номер.</param>
  /// <returns>Функция ввода и изменении телефонного номера абонента.</returns>
  private static Action<PhoneBook> ChangeAbonentPhoneNumber(string phone)
  {
    return (phoneBook) =>
    {
      bool isChanged = false;

      Console.Clear();

      while (!isChanged)
      {
        Console.Write("Введите новый уникальный номер абонента: ");
        string newPhone = Console.ReadLine();

        isChanged = phoneBook.UpdatePhone(phone, newPhone);
        if (!isChanged) Console.WriteLine("Номер не указан или уже занят");
      }
    };
  }
}
