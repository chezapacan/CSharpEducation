namespace CSharpEducation.Practice;
class Program
{
  static void Main()
  {
    Console.ReadKey();
  }

  static void Task1()
  {
    short age;
    string name;
    string companyName;
    bool toggle;
    float weight;
  }

  static void Task2()
  {
    short age = 23;
    string name = "Дмитрий";
    short temperature = 23;
    bool isWomen = false;
  }

  static void Task3()
  {
    for (int i = 0; i < 10; i++)
    {
      Console.Write(i);
    }

    Console.WriteLine();
    int j = 0;
    while (j < 10)
    {
      Console.Write(j);
      j++;
    }

    Console.WriteLine();
    int k = 0;
    do
    {
      Console.Write(k);
      k++;
    }
    while (k < 10);

    Console.WriteLine();
    string resultFor = String.Empty;
    for (int i = 0; i < 3; i++)
    {
      Console.Write($"Введите {i + 1} слово: ");
      resultFor += Console.ReadLine() + " ";
    }
    Console.WriteLine(resultFor);

    string resultWhile = String.Empty;
    string word = " ";
    while (word != String.Empty)
    {
      Console.Write("Введите слово или нажмите Enter: ");
      word = Console.ReadLine();
      resultWhile += word + " ";
    }
    Console.WriteLine(resultWhile);

    word = " ";
    resultWhile = String.Empty;
    do
    {
      Console.Write("Введите слово или нажмите Enter: ");
      word = Console.ReadLine();
      resultWhile += word + " ";
    }
    while (word != String.Empty);
    Console.WriteLine(resultWhile);
  }

  static void Task4()
  {

  }
}