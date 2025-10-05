namespace ConsoleTicTacToe;

public class GameManager
{
    Board _board;

    private bool _isPlayer1;
    private bool _isGameActive;
    private string _userInput;
    private int _turnCount;

    public void StartGame()
    {
        _isPlayer1 = true;
        _isGameActive = true;
        _turnCount = 0;

        _board = new Board(OnGameWin);

        while (_isGameActive)
        {
            Console.Clear();
            _board.DrawBoard();
            char currentPlayer = _isPlayer1 ? '1' : '2';
            Console.WriteLine($"\nPlayer {currentPlayer} select a position, 1-9\n");
            _userInput = Console.ReadLine();
            Tile.TileValue currentTileValue = _isPlayer1 ? Tile.TileValue.X : Tile.TileValue.O;

            while (!_board.CheckValidPlayerInput(_userInput, currentTileValue))
            {
                Console.Clear();
                _board.DrawBoard();
                Console.WriteLine($"\nPlayer {currentPlayer} select a valid position, 1-9\n");
                _userInput = Console.ReadLine();
            }

            _isPlayer1 = !_isPlayer1;
            _turnCount++;

            if (_turnCount >= 9)
            {
               OnGameOver($"Draw nobody wins");
            }
        }
    }

    private void OnGameWin()
    {
        char isPlayer1 = _isPlayer1 ? '1' : '2';
        OnGameOver($"player {isPlayer1} has won the game!");
    }

    private void OnGameOver(string closingStatement)
    {
        Console.WriteLine(closingStatement);
        _isGameActive = false;
        Console.WriteLine($"\nWant to Play again (y/n)\n");
        string choice = Console.ReadLine();
        bool isValidChoice = false;
        while (!isValidChoice)
        {
            switch (choice)
            {
                default:
                    Console.Clear();
                    Console.WriteLine($"\nChoice Invalid.\nWant to Play again (y/n)\n");
                    choice = Console.ReadLine();
                    break;
                case "y":
                    isValidChoice = true;
                    Console.Clear();
                    StartGame();
                    break;
                case "Y":
                    isValidChoice = true;
                    Console.Clear();
                    StartGame();
                    break;
                case "n":
                    isValidChoice = true;
                    Console.Clear();
                    Console.WriteLine($"Game Over");
                    break;
                case "N":
                    isValidChoice = true;
                    Console.Clear();
                    Console.WriteLine($"Game Over");
                    break;
            }
        }
    }
}