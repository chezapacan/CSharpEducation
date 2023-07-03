using System.Formats.Asn1;

namespace CSharpEducation.Task2;
class Program
{
  static void Main()
  {
    var Game = new TicTacToe();

    while (NewGame())
    {
      Game.StartGame();
    }
  }

  static bool NewGame()
  {
    Console.Write("Если хотите начать новую игру нажмите Enter");
    var key = Console.ReadKey();

    return key.Key == ConsoleKey.Enter;
  }
}