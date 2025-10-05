namespace ConsoleTicTacToe;

public class BoardDirectionalChecker
{
    private const int BOARDSIZE = 3;

    private Tile.TileValue[] _horizontalWin;
    private Tile.TileValue[] _verticalWin;
    private Tile.TileValue[] _rightDiagnolWin;
    private Tile.TileValue[] _leftDiagnolWin;

    public event Action OnWinConditionsMet;
    
    private void InitializeWinArrays()
    {
        _horizontalWin = new Tile.TileValue[BOARDSIZE];
        _verticalWin = new Tile.TileValue[BOARDSIZE];
        _rightDiagnolWin = new Tile.TileValue[BOARDSIZE];
        _leftDiagnolWin = new Tile.TileValue[BOARDSIZE];
    }


    public void CheckPositions(Tuple<int, int> coords, Tile.TileValue[,] _boardTiles)
    {
        InitializeWinArrays();

        int x = coords.Item1;
        int y = coords.Item2;

        bool isCenterTile = BoardPositions.CENTER == coords;
        bool isRightDiagnolCorner = BoardPositions.TOPLEFT == coords || BoardPositions.BOTTOMRIGHT == coords;
        bool isLeftDiagnolCorner = BoardPositions.BOTTOMLEFT == coords || BoardPositions.TOPRIGHT == coords;

        if (isCenterTile)
        {
            CheckDiagnolLeft(_boardTiles);
            CheckDiagnolRight(_boardTiles);
        }

        if (isRightDiagnolCorner)
        {
            CheckDiagnolRight(_boardTiles);
        }

        if (isLeftDiagnolCorner)
        {
            CheckDiagnolLeft(_boardTiles);
        }

        CheckVertical(x, _boardTiles);
        CheckHorizontal(y, _boardTiles);

        if (HasWinningPattern())
            OnWinConditionsMet?.Invoke();
    }

    private bool HasWinningPattern()
    {
        bool hasWonVertical = WinningConditions(_verticalWin);
        bool hasWonHorizontal = WinningConditions(_horizontalWin);
        bool hasWonRightDiagnol = WinningConditions(_rightDiagnolWin);
        bool hasWonLeftDiagnol = WinningConditions(_leftDiagnolWin);

        return hasWonVertical || hasWonHorizontal || hasWonRightDiagnol || hasWonLeftDiagnol;
    }

    private bool WinningConditions(Tile.TileValue[] winDirection)
    {
        int firstIndex = 0;
        int secondIndex = 1;
        int thirdIndex = 2;

        bool hasAllMatchingSymbols = winDirection[firstIndex] == winDirection[secondIndex] &&
                                     winDirection[secondIndex] == winDirection[thirdIndex] &&
                                     winDirection[firstIndex] == winDirection[thirdIndex];
        bool hasNoNeutralSymbols = winDirection[firstIndex] != Tile.TileValue.Neutral ||
                                   winDirection[secondIndex] != Tile.TileValue.Neutral ||
                                   winDirection[thirdIndex] != Tile.TileValue.Neutral;

        return hasNoNeutralSymbols && hasAllMatchingSymbols;
    }

    private void CheckVertical(int position, Tile.TileValue[,] _boardTiles)
    {
        for (int i = 0; i < _boardTiles.GetLength(0); i++)
        {
            if (_boardTiles[position, i] == Tile.TileValue.X)
            {
                _verticalWin[i] = Tile.TileValue.X;
            }

            if (_boardTiles[position, i] == Tile.TileValue.O)
            {
                _verticalWin[i] = Tile.TileValue.O;
            }
        }
    }

    private void CheckHorizontal(int position, Tile.TileValue[,] _boardTiles)
    {
        for (int i = 0; i < _boardTiles.GetLength(0); i++)
        {
            if (_boardTiles[i, position] == Tile.TileValue.X)
            {
                _horizontalWin[i] = Tile.TileValue.X;
            }

            if (_boardTiles[i, position] == Tile.TileValue.O)
            {
                _horizontalWin[i] = Tile.TileValue.O;
            }
        }
    }

    private void CheckDiagnolRight(Tile.TileValue[,] _boardTiles)
    {
        for (int i = 0; i < _boardTiles.GetLength(0); i++)
        {
            if (_boardTiles[i, i] == Tile.TileValue.X)
            {
                _rightDiagnolWin[i] = Tile.TileValue.X;
            }

            if (_boardTiles[i, i] == Tile.TileValue.O)
            {
                _rightDiagnolWin[i] = Tile.TileValue.O;
            }
        }
    }

    private void CheckDiagnolLeft(Tile.TileValue[,] _boardTiles)
    {
        int leftSide = _boardTiles.GetLength(0) - 1;
        for (int i = 0; i < _boardTiles.GetLength(0); i++)
        {
            if (_boardTiles[i, leftSide] == Tile.TileValue.X)
            {
                _leftDiagnolWin[i] = Tile.TileValue.X;
            }

            if (_boardTiles[i, leftSide] == Tile.TileValue.O)
            {
                _leftDiagnolWin[i] = Tile.TileValue.O;
            }

            leftSide--;
        }
    }
}