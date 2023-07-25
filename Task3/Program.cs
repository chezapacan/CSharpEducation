namespace CSharpEducation.Task3;

class Program
{
  /// <summary>
  /// Точка входа программы.
  /// </summary>
  static void Main()
  {
    var phoneBook = PhoneBook.Instance;
    while (true)
    {
      ConsolePhoneBook.PrintPhoneBook(phoneBook);
    }
  }
}