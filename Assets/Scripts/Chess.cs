using System;
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

public class Chess : MonoBehaviour
{
    public ChessType chessType;
    public string chessName;
    public int leftX; // 棋子左上角坐标x
    public int leftY; // 棋子左上角坐标y
    public int width;  // 棋子宽度
    public int height; // 棋子高度
    
    
    public static Chess Build(GameObject chessPrefab, ChessType chessType, int x, int y)
    {
        GameObject chessObj = Instantiate(chessPrefab, new Vector2(x, y), Quaternion.identity);
        chessObj.AddComponent<Chess>();
        Chess chess = chessObj.GetComponent<Chess>();
        chess.chessType = chessType;
        chess.chessName = chessPrefab.name;
        chess.leftX = x;
        chess.leftY = y;
        (chess.width, chess.height) = chess.GetWidthAndHeight(chessType);
        return chess;
    }

    private (int, int) GetWidthAndHeight(ChessType type)
    {
        return type switch
        {
            ChessType.Rect11 => (1, 1),
            ChessType.Rect12 => (1, 2),
            ChessType.Rect21 => (2, 1),
            ChessType.Rect22 => (2, 2),
            _ => throw new ArgumentException($"chessType unknown: {type}")
        };
    }
}
