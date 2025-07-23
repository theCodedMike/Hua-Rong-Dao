using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Done_huarongdao;

public class Done_MouseEvent : MonoBehaviour {

    Vector2 first;                //鼠标点击的位置
    Vector2 second;               //鼠标抬起的位置
    Done_Chess targetChess;       //被选中的棋子
    Direction dir;                //移动方向

    Transform targetTransform;

  //  public Texture gameOver;
    public static bool over = false;

	// Use this for initialization
	void Start () {
        	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0))
        {
            first = Camera.main.ScreenToWorldPoint(Input.mousePosition);           
            for(int i = 0;i<10;i++)
            {
                 /**
                  * 判断鼠标点击的位置在哪一个方块上。
                  * 鼠标位置(Mx,My),棋子宽度w,棋子高度h,棋子左上角坐标为(Lx,Ly)
                  * (Mx>w) && (Mx<Lx+w) && (My<Ly) && (My>Ly-h)
                  * 若满足上述条件，则棋子被选中
                  */
                if(first.x>Done_Main.chess[i].left_x&&first.x<Done_Main.chess[i].left_x+Done_Main.chess[i].getWidth(Done_Main.chess[i].chesstype)
                    &&first.y<Done_Main.chess[i].left_y&&first.y>Done_Main.chess[i].left_y-Done_Main.chess[i].getHeight(Done_Main.chess[i].chesstype))
                {                  
                    //被选中的目标棋子
                    targetChess = Done_Main.chess[i];
                    //根据名字找到对应的棋子的初始位置
                    targetTransform = GameObject.Find(targetChess.chessName).transform.parent;                                                  
                    break;
                }
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            OnMyMouseUp();
        }
		
	}

    private void OnMyMouseUp()
    {
        //记录鼠标抬起是鼠标的位置
        second = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //计算方向
        if (first.x < second.x && Mathf.Abs(second.y - first.y) < 0.5)
        {
            dir = Direction.Right;

        }
        if (first.x > second.x && Mathf.Abs(second.y - first.y) < 0.5)
        {
            dir = Direction.Left;
        }
        if (first.y > second.y && Mathf.Abs(second.x - first.x) < 0.5)
        {
            dir = Direction.Down;
        }
        if (first.y < second.y && Mathf.Abs(second.x - first.x) < 0.5)
        {
            dir = Direction.Up;
        }
        Move();

    }


    void Move()
    {
        //向左
        if (dir == Direction.Left)
        {
            //小兵的移动
            if (targetChess.chesstype == ChessType.Rect11)
            {
                //判断小兵的的左边是否有棋子存在，即小兵左边的格子状态是否为0，为0，则没有棋子，小兵可以移动
                //if (Done_ChessBoard.state[(int)targetTransform.position.x - 1, (int)targetTransform.position.y] == 0)
                if (Done_ChessBoard.state[targetChess.left_x - 1, targetChess.left_y] == 0)
                {

                    targetTransform.position += new Vector3(-1, 0, 0);
                    //更新棋子的左上角坐标
                    targetChess.left_x -= 1;
                    //跟新棋盘的状态
                    // Done_ChessBoard.updateQiPan((int)targetTransform.position.x, (int)targetTransform.position.y, targetChess.chesstype, dir);
                    Done_ChessBoard.updateChessBoard(targetChess.left_x, targetChess.left_y, targetChess.chesstype, dir);
                }
            }

            //竖着的将军的移动
            if (targetChess.chesstype == ChessType.Rect12)
            {
                //if (Done_ChessBoard.state[(int)targetTransform.position.x - 1, (int)targetTransform.position.y] == 0 
                //    && Done_ChessBoard.state[(int)targetTransform.position.x - 1, (int)targetTransform.position.y - 1] == 0)
                if (Done_ChessBoard.state[targetChess.left_x - 1, targetChess.left_y] == 0
                    && Done_ChessBoard.state[targetChess.left_x-1, targetChess.left_y - 1] == 0)
                {
                    targetTransform.position += new Vector3(-1, 0, 0);
                    targetChess.left_x -= 1;
                    Done_ChessBoard.updateChessBoard((int)targetTransform.position.x, (int)targetTransform.position.y, targetChess.chesstype, dir);

                }
            }

            if (targetChess.chesstype == ChessType.Rect21)
            {
                //if (Done_ChessBoard.state[(int)targetTransform.position.x - 1, (int)targetTransform.position.y] == 0)
                if(Done_ChessBoard.state[targetChess.left_x-1,targetChess.left_y] == 0)
                {
                    targetTransform.position += new Vector3(-1, 0, 0);
                    targetChess.left_x -= 1;
                    //Done_ChessBoard.updateQiPan((int)targetTransform.position.x, (int)targetTransform.position.y, targetChess.chesstype, dir);
                    Done_ChessBoard.updateChessBoard(targetChess.left_x, targetChess.left_y, targetChess.chesstype, dir);
                }
            }

            if (targetChess.chesstype == ChessType.Rect22)
            {
                //if (Done_ChessBoard.state[(int)targetTransform.position.x - 1, (int)targetTransform.position.y] == 0
                //    && Done_ChessBoard.state[(int)targetTransform.position.x - 1, (int)targetTransform.position.y - 1] == 0)
                if(Done_ChessBoard.state[targetChess.left_x - 1,targetChess.left_y] == 0
                    &&Done_ChessBoard.state[targetChess.left_x-1,targetChess.left_y -1] == 0)
                {
                    targetTransform.position += new Vector3(-1, 0, 0);
                    targetChess.left_x -= 1;
                    isFinish(targetTransform.position);
                    // Done_ChessBoard.updateQiPan((int)targetTransform.position.x, (int)targetTransform.position.y, targetChess.chesstype, dir);
                    Done_ChessBoard.updateChessBoard(targetChess.left_x, targetChess.left_y, targetChess.chesstype, dir);
                }
            }
           


        }
        if (dir == Direction.Right)
        {

            if (targetChess.chesstype == ChessType.Rect11)
            {
                //if (Done_ChessBoard.state[(int)targetTransform.position.x + 1, (int)targetTransform.position.y] == 0)
                if(Done_ChessBoard.state[targetChess.left_x+1,targetChess.left_y] == 0)
                {
                    targetTransform.position += new Vector3(1, 0, 0);
                    targetChess.left_x += 1;
                    //Done_ChessBoard.updateQiPan((int)targetTransform.position.x, (int)targetTransform.position.y, targetChess.chesstype, dir);
                    Done_ChessBoard.updateChessBoard(targetChess.left_x, targetChess.left_y, targetChess.chesstype, dir);
                }
            }

            if (targetChess.chesstype == ChessType.Rect12)
            {
                //if (Done_ChessBoard.state[(int)targetTransform.position.x + 1, (int)targetTransform.position.y] == 0
                //    && Done_ChessBoard.state[(int)targetTransform.position.x + 1, (int)targetTransform.position.y - 1] == 0)
                if(Done_ChessBoard.state[targetChess.left_x+1,targetChess.left_y]==0
                    &&Done_ChessBoard.state[targetChess.left_x+1,targetChess.left_y-1]==0)
                {
                    targetTransform.position += new Vector3(1, 0, 0);
                    targetChess.left_x += 1;
                    //Done_ChessBoard.updateQiPan((int)targetTransform.position.x, (int)targetTransform.position.y, targetChess.chesstype, dir);
                    Done_ChessBoard.updateChessBoard(targetChess.left_x, targetChess.left_y, targetChess.chesstype, dir);
                }
            }

            if (targetChess.chesstype == ChessType.Rect21)
            {
                //if (Done_ChessBoard.state[(int)targetTransform.position.x + 2, (int)targetTransform.position.y] == 0)
                if(Done_ChessBoard.state[targetChess.left_x+2,targetChess.left_y]==0)
                {
                    targetTransform.position += new Vector3(1, 0, 0);
                    targetChess.left_x += 1;
                    //Done_ChessBoard.updateQiPan((int)targetTransform.position.x, (int)targetTransform.position.y, targetChess.chesstype, dir);
                    Done_ChessBoard.updateChessBoard(targetChess.left_x, targetChess.left_y, targetChess.chesstype, dir);
                }
            }

            if (targetChess.chesstype == ChessType.Rect22)
            {
                //if (Done_ChessBoard.state[(int)targetTransform.position.x + 2, (int)targetTransform.position.y] == 0
                //    && Done_ChessBoard.state[(int)targetTransform.position.x + 2, (int)targetTransform.position.y - 1] == 0)
                if(Done_ChessBoard.state[targetChess.left_x+2,targetChess.left_y]==0
                    &&Done_ChessBoard.state[targetChess.left_x+2,targetChess.left_y-1] == 0)
                {
                    targetTransform.position += new Vector3(1, 0, 0);
                    targetChess.left_x += 1;
                    isFinish(targetTransform.position);
                    //Done_ChessBoard.updateQiPan((int)targetTransform.position.x, (int)targetTransform.position.y, targetChess.chesstype, dir);
                    Done_ChessBoard.updateChessBoard(targetChess.left_x, targetChess.left_y, targetChess.chesstype, dir);
                }
            }
            
            // targetTransform.position += new Vector3(1, 0, 0);
        }
        if (dir == Direction.Up)
        {

            if (targetChess.chesstype == ChessType.Rect11)
            {
                //if (Done_ChessBoard.state[(int)targetTransform.position.x, (int)targetTransform.position.y + 1] == 0)
                if(Done_ChessBoard.state[targetChess.left_x,targetChess.left_y+1]==0)
                {
                    targetTransform.position += new Vector3(0, 1, 0);
                    targetChess.left_y += 1;
                    //Done_ChessBoard.updateQiPan((int)targetTransform.position.x, (int)targetTransform.position.y, targetChess.chesstype, dir);
                    Done_ChessBoard.updateChessBoard(targetChess.left_x, targetChess.left_y, targetChess.chesstype, dir);
                }
            }

            if (targetChess.chesstype == ChessType.Rect12)
            {
                //if (Done_ChessBoard.state[(int)targetTransform.position.x, (int)targetTransform.position.y + 1] == 0)
                if(Done_ChessBoard.state[targetChess.left_x,targetChess.left_y+1]==0)
                {
                    targetTransform.position += new Vector3(0, 1, 0);
                    targetChess.left_y += 1;
                    //Done_ChessBoard.updateQiPan((int)targetTransform.position.x, (int)targetTransform.position.y, targetChess.chesstype, dir);
                    Done_ChessBoard.updateChessBoard(targetChess.left_x, targetChess.left_y, targetChess.chesstype, dir);
                }
            }


            if (targetChess.chesstype == ChessType.Rect21)
            {
                //if (Done_ChessBoard.state[(int)targetTransform.position.x, (int)targetTransform.position.y + 1] == 0
                //    && Done_ChessBoard.state[(int)targetTransform.position.x + 1, (int)targetTransform.position.y + 1] == 0)
                if(Done_ChessBoard.state[targetChess.left_x,targetChess.left_y+1]==0
                    &&Done_ChessBoard.state[targetChess.left_x+1,targetChess.left_y+1]==0)
                {
                    targetTransform.position += new Vector3(0, 1, 0);
                    targetChess.left_y += 1;
                    //Done_ChessBoard.updateQiPan((int)targetTransform.position.x, (int)targetTransform.position.y, targetChess.chesstype, dir);
                    Done_ChessBoard.updateChessBoard(targetChess.left_x, targetChess.left_y, targetChess.chesstype, dir);
                }
            }

            if (targetChess.chesstype == ChessType.Rect22)
            {

                //if (Done_ChessBoard.state[(int)targetTransform.position.x, (int)targetTransform.position.y + 1] == 0
                //    && Done_ChessBoard.state[(int)targetTransform.position.x + 1, (int)targetTransform.position.y + 1] == 0)
                if(Done_ChessBoard.state[targetChess.left_x,targetChess.left_y + 1] == 0
                    &&Done_ChessBoard.state[targetChess.left_x+1,targetChess.left_y+1] == 0)
                {
                    Debug.Log("jinru");
                    targetTransform.position += new Vector3(0, 1, 0);
                    targetChess.left_y += 1;
                    isFinish(targetTransform.position);
                    //Done_ChessBoard.updateQiPan((int)targetTransform.position.x, (int)targetTransform.position.y, targetChess.chesstype, dir);
                    Done_ChessBoard.updateChessBoard(targetChess.left_x, targetChess.left_y, targetChess.chesstype, dir);
                }
            }
            

        }

        //向下移动棋子
        if (dir == Direction.Down)
        {
            //兵
            if (targetChess.chesstype == ChessType.Rect11)
            {

                //if (Done_ChessBoard.state[(int)targetTransform.position.x, (int)targetTransform.position.y - 1] == 0)
                if(Done_ChessBoard.state[targetChess.left_x,targetChess.left_y-1] == 0)
                {
                    targetTransform.position += new Vector3(0, -1, 0);
                    targetChess.left_y -= 1;
                    //Done_ChessBoard.updateQiPan((int)targetTransform.position.x, (int)targetTransform.position.y, targetChess.chesstype, dir);
                    Done_ChessBoard.updateChessBoard(targetChess.left_x, targetChess.left_y, targetChess.chesstype, dir);
                }
            }

            //竖着的将军
            if (targetChess.chesstype == ChessType.Rect12)
            {

                //if (Done_ChessBoard.state[(int)targetTransform.position.x, (int)targetTransform.position.y - 2] == 0)
                if(Done_ChessBoard.state[targetChess.left_x,targetChess.left_y-2] == 0)
                {
                    targetTransform.position += new Vector3(0, -1, 0);
                    targetChess.left_y -= 1;
                    //Done_ChessBoard.updateQiPan((int)targetTransform.position.x, (int)targetTransform.position.y, targetChess.chesstype, dir);
                    Done_ChessBoard.updateChessBoard(targetChess.left_x, targetChess.left_y, targetChess.chesstype, dir);

                }

            }
            //横着的将军
            if (targetChess.chesstype == ChessType.Rect21)
            {
                //if (Done_ChessBoard.state[(int)targetTransform.position.x, (int)targetTransform.position.y - 1] == 0 
                //    && Done_ChessBoard.state[(int)targetTransform.position.x + 1, (int)targetTransform.position.y - 1] == 0)
                if(Done_ChessBoard.state[targetChess.left_x,targetChess.left_y-1]==0
                    &&Done_ChessBoard.state[targetChess.left_x+1,targetChess.left_y-1] == 0)
                {
                    targetTransform.position += new Vector3(0, -1, 0);
                    targetChess.left_y -= 1;
                    //Done_ChessBoard.updateQiPan((int)targetTransform.position.x, (int)targetTransform.position.y, targetChess.chesstype, dir);
                    Done_ChessBoard.updateChessBoard(targetChess.left_x, targetChess.left_y, targetChess.chesstype, dir);
                }

            }

            //曹操
            if (targetChess.chesstype == ChessType.Rect22)
            {
                //if (Done_ChessBoard.state[(int)targetTransform.position.x, (int)targetTransform.position.y - 2] == 0
                //    && Done_ChessBoard.state[(int)targetTransform.position.x + 1, (int)targetTransform.position.y - 2] == 0)
                if(Done_ChessBoard.state[targetChess.left_x,targetChess.left_y-2] == 0
                    &&Done_ChessBoard.state[targetChess.left_x+1,targetChess.left_y-2] == 0)
                {
                    targetTransform.position += new Vector3(0, -1, 0);
                    targetChess.left_y -= 1;
                    isFinish(targetTransform.position);
                    //Done_ChessBoard.updateQiPan((int)targetTransform.position.x, (int)targetTransform.position.y, targetChess.chesstype, dir);
                    Done_ChessBoard.updateChessBoard(targetChess.left_x, targetChess.left_y, targetChess.chesstype, dir);
                }

            }
            
        }
    }
    void isFinish(Vector2 v)
    {
        if (v.x == 2 && v.y == 2)
        {
            Debug.Log("游戏结束");
            over = true;
            //enabled = false;
            //Instantiate(gameOver, new Vector3(3, 2.5f, 0), Quaternion.identity);
            // GUI.DrawTexture(new Rect(0, 50, 300, 100), gameOver, ScaleMode.ScaleToFit, true, 10.0F);

        }
    }

    //private void OnGUI()
    //{
    //    //if (over)
    //    //{
    //      Debug.Log("游戏结束");
    //        //Instantiate(gameOver, new Vector3(3, 2.5f, 0), Quaternion.identity);
          
          

    //    //}
    //}
}
