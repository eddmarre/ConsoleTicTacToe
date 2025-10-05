using System.Text;

namespace ConsoleTicTacToe;

public class Board
{
    private StringBuilder _stringBuilder;
    private BoardDirectionalChecker _boardDirectionalChecker;
    private List<Tuple<int, int>> _listOfPlays;

    public Board(Action onGameWinAction)
    {
        _listOfPlays = new List<Tuple<int, int>>();
        _stringBuilder = new StringBuilder();
        _boardTileValues = new Tile.TileValue[BOARDSIZE, BOARDSIZE];
        _boardDirectionalChecker = new BoardDirectionalChecker();
        _boardDirectionalChecker.OnWinConditionsMet += onGameWinAction;
    }

    private Tile.TileValue[,] _boardTileValues;

    private const int BOARDSIZE = 3;

    public void UpdateBoardAtPosition(Tuple<int, int> coords, Tile.TileValue newTileValue)
    {
        _boardTileValues[coords.Item1, coords.Item2] = newTileValue;
    }

    public void DrawBoard()
    {
        _stringBuilder.Clear();

        int boardCount = 1;
        for (int x = 0; x < BOARDSIZE; x++)
        {
            for (int y = 0; y < BOARDSIZE; y++)
            {
                switch (_boardTileValues[x, y])
                {
                    case Tile.TileValue.Neutral:
                        _stringBuilder.Append($"{boardCount} ");
                        break;
                    case Tile.TileValue.X:
                        _stringBuilder.Append($"X ");
                        break;
                    case Tile.TileValue.O:
                        _stringBuilder.Append($"O ");
                        break;
                }

                boardCount++;
            }

            _stringBuilder.Append("\n");
        }

        Console.Write(_stringBuilder.ToString());
    }

    public bool CheckValidPlayerInput(string inputValue, Tile.TileValue currentTileValue)
    {
        switch (inputValue)
        {
            default:
                return false;
                break;
            case "1":
                return UpdateAndRedrawBoard(BoardPositions.TOPLEFT, currentTileValue);
                break;
            case "2":
                return UpdateAndRedrawBoard(BoardPositions.TOPCENTER, currentTileValue);
                break;
            case "3":
                return UpdateAndRedrawBoard(BoardPositions.TOPRIGHT, currentTileValue);
                break;
            case "4":
                return UpdateAndRedrawBoard(BoardPositions.CENTERLEFT, currentTileValue);
                break;
            case "5":
                return UpdateAndRedrawBoard(BoardPositions.CENTER, currentTileValue);
                break;
            case "6":
                return UpdateAndRedrawBoard(BoardPositions.CENTERRIGHT, currentTileValue);
                break;
            case "7":
                return UpdateAndRedrawBoard(BoardPositions.BOTTOMLEFT, currentTileValue);
                break;
            case "8":
                return UpdateAndRedrawBoard(BoardPositions.BOTTOMCENTER, currentTileValue);
                break;
            case "9":
                return UpdateAndRedrawBoard(BoardPositions.BOTTOMRIGHT, currentTileValue);
                break;
        }
    }

    private bool UpdateAndRedrawBoard(Tuple<int, int> position, Tile.TileValue currentTileValue)
    {
        Console.Clear();

        if (!_listOfPlays.Contains(position))
            _listOfPlays.Add(position);
        else
            return false;


        UpdateBoardAtPosition(position, currentTileValue);
        DrawBoard();
        _boardDirectionalChecker.CheckPositions(position, _boardTileValues);

        return true;
    }
}