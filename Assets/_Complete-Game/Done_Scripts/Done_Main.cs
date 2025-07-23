using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Done_huarongdao;

public class Done_Main : MonoBehaviour {

    int[,] state1 =
         {
                {1,1,1,1,1,1,1 },
                {1,1,1,1,1,1,1 },
                {1,0,1,1,1,1,1 },
                {1,0,1,1,1,1,1 },
                {1,1,1,1,1,1,1 },
                {1,1,1,1,1,1,1 }
            };

    int[,] state2 =
           {
                {1,1,1,1,1,1,1 },
                {1,0,1,1,1,1,1 },
                {1,0,1,1,1,1,1 },
                {1,1,1,1,1,1,1 },
                {1,1,1,1,1,1,1 },
                {1,1,1,1,1,1,1 }
            };

    public static Done_Chess[] chess = new Done_Chess[10];
    public GameObject[] chessPrefab;

    public int[] Map = new int[2];
    public static int MapNum;
    public GameObject[] ZhenFa;

	// Use this for initialization
	void Start () {
        //两种布局，随机产生
        MapNum = (int)Random.Range(1, 3);
        Ini_Game(MapNum);
        if(MapNum == 1)
        {
            Done_ChessBoard.state = state1;
        }
        if(MapNum==2)
        {
            Done_ChessBoard.state = state2;
        }
       
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    //初始化布局
    void Ini_Game(int i)
    {
        if (i == 1)
        {
            chess[0] = new Done_Chess(chessPrefab[0], ChessType.Rect11, 1, 1);
            chess[1] = new Done_Chess(chessPrefab[1], ChessType.Rect11, 4, 1);
            chess[2] = new Done_Chess(chessPrefab[2], ChessType.Rect11, 2, 2);
            chess[3] = new Done_Chess(chessPrefab[3], ChessType.Rect11, 3, 2);
            chess[4] = new Done_Chess(chessPrefab[4], ChessType.Rect12, 1, 3);
            chess[5] = new Done_Chess(chessPrefab[5], ChessType.Rect12, 1, 5);
            chess[6] = new Done_Chess(chessPrefab[6], ChessType.Rect12, 4, 5);
            chess[7] = new Done_Chess(chessPrefab[7], ChessType.Rect12, 4, 3);
            chess[8] = new Done_Chess(chessPrefab[8], ChessType.Rect21, 2, 3);
            chess[9] = new Done_Chess(chessPrefab[9], ChessType.Rect22, 2, 5);

        }




        /**
         * 近在咫尺
         * */
        if (i == 2)
        {
            chess[0] = new Done_Chess(chessPrefab[0], ChessType.Rect11, 1, 5);
            chess[1] = new Done_Chess(chessPrefab[1], ChessType.Rect11, 1, 4);
            chess[2] = new Done_Chess(chessPrefab[2], ChessType.Rect11, 3, 3);
            chess[3] = new Done_Chess(chessPrefab[3], ChessType.Rect11, 4, 3);
            chess[4] = new Done_Chess(chessPrefab[10], ChessType.Rect21, 1, 3);
            chess[5] = new Done_Chess(chessPrefab[5], ChessType.Rect12, 4, 5);
            chess[6] = new Done_Chess(chessPrefab[6], ChessType.Rect12, 2, 5);
            chess[7] = new Done_Chess(chessPrefab[7], ChessType.Rect12, 3, 5);
            chess[8] = new Done_Chess(chessPrefab[8], ChessType.Rect21, 1, 2);
            chess[9] = new Done_Chess(chessPrefab[9], ChessType.Rect22, 3, 2);

        }
    }


}









