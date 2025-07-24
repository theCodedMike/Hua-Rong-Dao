using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] chessPrefabs;

    private Chess[] _chess = new Chess[10];
    
    
    private void Start()
    {
        InitGame();
    }

    private void InitGame()
    {
        _chess[0] = new Chess(chessPrefabs[0], ChessType.Rect11, 1, 1); // 兵
        _chess[1] = new Chess(chessPrefabs[1], ChessType.Rect11, 4, 1); // 兵
        _chess[2] = new Chess(chessPrefabs[2], ChessType.Rect11, 2, 2); // 兵
        _chess[3] = new Chess(chessPrefabs[3], ChessType.Rect11, 3, 2); // 兵
        _chess[4] = new Chess(chessPrefabs[4], ChessType.Rect12, 1, 3); // 黄忠
        _chess[5] = new Chess(chessPrefabs[5], ChessType.Rect12, 1, 5); // 马超
        _chess[6] = new Chess(chessPrefabs[6], ChessType.Rect12, 4, 5); // 张飞
        _chess[7] = new Chess(chessPrefabs[7], ChessType.Rect12, 4, 3); // 赵云
        _chess[8] = new Chess(chessPrefabs[8], ChessType.Rect21, 2, 3); // 关羽
        _chess[9] = new Chess(chessPrefabs[9], ChessType.Rect22, 2, 5); // 曹操
    }
}
