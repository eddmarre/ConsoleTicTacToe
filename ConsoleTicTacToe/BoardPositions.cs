using System.Numerics;

namespace ConsoleTicTacToe;

public class BoardPositions
{
    public static Tuple<int, int> BOTTOMLEFT = new(2, 0);
    public static Tuple<int, int> BOTTOMCENTER = new(2, 1);
    public static Tuple<int, int> BOTTOMRIGHT = new(2, 2);
    public static Tuple<int, int> CENTERLEFT = new(1, 0);
    public static Tuple<int, int> CENTER = new(1, 1);
    public static Tuple<int, int> CENTERRIGHT = new(1, 2);
    public static Tuple<int, int> TOPLEFT = new(0, 0);
    public static Tuple<int, int> TOPCENTER = new(0, 1);
    public static Tuple<int, int> TOPRIGHT = new(0, 2);
}