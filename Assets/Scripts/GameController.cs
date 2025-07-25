using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] chessPrefabs;

    public static Chess[] chess = new Chess[10];

    public static bool gameOver;

    private Chess _caoCao;
    
    // 7行6列，多一条边界
    public static int[,] state = {
        {1, 1, 1, 1, 1, 1},
        {1, 1, 0, 0, 1, 1},
        {1, 1, 1, 1, 1, 1},
        {1, 1, 1, 1, 1, 1},
        {1, 1, 1, 1, 1, 1},
        {1, 1, 1, 1, 1, 1},
        {1, 1, 1, 1, 1, 1}
    };
    
    private void Start()
    {
        InitGame();
    }

    private void InitGame()
    {
        // 以左下角为中心
        //   (马 {曹  操}(张
        //    超){曹  操} 飞)
        //   (黄 [关  羽](赵
        //    忠)[兵][兵] 云)
        //   [兵]       [兵]
        chess[0] = Chess.Build(chessPrefabs[0], ChessType.Rect11, 1, 1); // 兵
        chess[1] = Chess.Build(chessPrefabs[1], ChessType.Rect11, 4, 1); // 兵
        chess[2] = Chess.Build(chessPrefabs[2], ChessType.Rect11, 2, 2); // 兵
        chess[3] = Chess.Build(chessPrefabs[3], ChessType.Rect11, 3, 2); // 兵
        chess[4] = Chess.Build(chessPrefabs[4], ChessType.Rect12, 1, 3); // 黄忠
        chess[5] = Chess.Build(chessPrefabs[5], ChessType.Rect12, 1, 5); // 马超
        chess[6] = Chess.Build(chessPrefabs[6], ChessType.Rect12, 4, 5); // 张飞
        chess[7] = Chess.Build(chessPrefabs[7], ChessType.Rect12, 4, 3); // 赵云
        chess[8] = Chess.Build(chessPrefabs[8], ChessType.Rect21, 2, 3); // 关羽
        chess[9] = Chess.Build(chessPrefabs[9], ChessType.Rect22, 2, 5); // 曹操
        _caoCao = chess[9];
    }

    private void Update()
    {
        if (_caoCao.leftX == 2 && _caoCao.leftY == 2)
        {
            print("游戏结束...");
            gameOver = true;
        }
    }
}
