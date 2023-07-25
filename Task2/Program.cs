namespace CSharpEducation.Task2;

class Program
{
  /// <summary>
  /// Точка входа программы.
  /// </summary>
  static void Main()
  {
    var Game = new TicTacToe();

    while (NewGameStarted())
    {
      Game.StartGame();
    }
  }

  /// <summary>
  /// Начало новой игры.
  /// </summary>
  /// <returns>true, если нажата кнопка "Enter", иначе false.</returns>
  static bool NewGameStarted()
  {
    Console.Write("Если хотите начать новую игру нажмите Enter");
    var key = Console.ReadKey();

    return key.Key == ConsoleKey.Enter;
  }
}