using UnityEngine;

// 棋子类型
public enum ChessType
{
    Rect11, // 1 x 1 的小正方形棋子，即"兵"
    Rect12, // 1 x 2 的竖长方形棋子，即"张飞"、"赵云"、"马超"、"黄忠"
    Rect21, // 2 x 1 的横长方形棋子，即"关羽"
    Rect22, // 2 x 2 的大正方形棋子，即"曹操"
}

// 棋子的移动方向
public enum Direction
{
    Right,
    Left,
    Up,
    Down
}

public class Chess
{
    public ChessType chessType;
    public int leftX; // 棋子左上角坐标x
    public int leftY; // 棋子左上角坐标y
    public string chessName; // 棋子名称
    public GameObject chessPrefab; // 预制体

    public Chess(GameObject go, ChessType chessType, int x, int y)
    {
        this.chessType = chessType;
        leftX = x;
        leftY = y;
        chessName = go.name;
        chessPrefab = go;
        Object.Instantiate(chessPrefab, new Vector2(x, y), Quaternion.identity);
    }
}
