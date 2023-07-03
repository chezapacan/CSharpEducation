namespace CSharpEducation.Task2;

/// <summary>
/// Игра "Крестики-нолики".
/// </summary>
public class TicTacToe
{
  /// <summary>
  /// Игровое поле.
  /// </summary>
  private string[,] field;

  /// <summary>
  /// Старт игры.
  /// </summary>
  public void StartGame()
  {
    int endGameFlag = 0;
    string cell;
    string mark;
    (int, int) cellIndex;
    bool isXTurn = true;

    Console.Clear();
    this.field = new string[3, 3] { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };
    DrawField();

    while (endGameFlag == 0)
    {
      mark = isXTurn ? "X" : "O";
      Console.Write($"Ход {mark}: ");
      cell = Console.ReadLine();
      cellIndex = FindIndex(cell);

      if (cellIndex.Item1 == -1)
      {
        Console.WriteLine("Некорректный ход");
        continue;
      }

      this.field[cellIndex.Item1, cellIndex.Item2] = mark;
      DrawField();
      isXTurn = !isXTurn;

      endGameFlag = CheckGameEnd(cellIndex);
      if (endGameFlag == 1)
        Console.WriteLine($"{mark} победили");
      if (endGameFlag == -1)
        Console.WriteLine("Ничья");
    }

    return;
  }

  /// <summary>
  /// Отрисовка игрового поля в консоли.
  /// </summary>
  private void DrawField()
  {
    for (int i = 0; i < 3; i++)
    {
      Console.WriteLine("-------------");
      Console.Write("|");

      for (int j = 0; j < 3; j++)
      {
        if (this.field[i, j] == "X")
          Console.ForegroundColor = ConsoleColor.Blue;
        if (this.field[i, j] == "O")
          Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($" {this.field[i, j]} ");

        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("|");
      }

      Console.WriteLine();
    }
    Console.WriteLine("-------------");
  }

  /// <summary>
  /// Поиск индекса значения в игровом поле.
  /// </summary>
  /// <param name="cell">Название клетки.</param>
  /// <returns>Пара индексов.</returns>
  private (int, int) FindIndex(string cell)
  {
    for (int x = 0; x < 3; x++)
    {
      for (int y = 0; y < 3; y++)
      {
        if (this.field[x, y] == cell)
          return (x, y);
      }
    }

    return (-1, -1);
  }

  /// <summary>
  /// Проверка на завершение игры.
  /// </summary>
  /// <param name="cellIndex">Пара индексов.</param>
  /// <returns>Числовой флаг состояния игры.</returns>
  private int CheckGameEnd((int, int) cellIndex)
  {
    int row = cellIndex.Item1;
    int column = cellIndex.Item2;

    if (this.field[row, 0] == this.field[row, 1] && this.field[row, 1] == this.field[row, 2])
      return 1;
    if (this.field[0, column] == this.field[1, column] && this.field[1, column] == this.field[2, column])
      return 1;
    if (this.field[0, 0] == this.field[1, 1] && this.field[1, 1] == this.field[2, 2])
      return 1;
    if (this.field[0, 2] == this.field[1, 1] && this.field[1, 1] == this.field[2, 0])
      return 1;

    for (int i = 0; i < 3; i++)
    {
      for (int j = 0; j < 3; j++)
      {
        if (this.field[i, j] != "X" && this.field[i, j] != "O")
        {
          return 0;
        }
      }
    }

    return -1;
  }
}
