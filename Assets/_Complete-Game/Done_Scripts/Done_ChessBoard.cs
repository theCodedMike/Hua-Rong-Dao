using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Done_huarongdao;

public class Done_ChessBoard : MonoBehaviour {


    public static int[,] state;                 //棋盘状态，有棋子的地方为1，没有棋子的地方为0

    public static void updateChessBoard(int x,int y,ChessType type,Direction dir)
    {
        if(type == ChessType.Rect11)
        {
            if(dir == Direction.Left)
            {
                state[x, y] = 1;
                state[x + 1, y] = 0;
            }
            if(dir == Direction.Right)
            {
                state[x, y] = 1;
                state[x - 1, y] = 0;
            }
            if(dir == Direction.Up)
            {
                state[x, y] = 1;
                state[x, y - 1] = 0;
            }
            if(dir == Direction.Down)
            {
                state[x, y] = 1;
                state[x, y + 1] = 0;
            }
            
        }
        

        if(type==ChessType.Rect12)
        {
            if(dir==Direction.Left)
            {
                state[x, y] = 1;
                state[x, y - 1] = 1;
                state[x + 1, y] = 0;
                state[x + 1, y - 1] = 0;
            }
            if(dir==Direction.Right)
            {
                state[x, y] = 1;
                state[x, y - 1] = 1;
                state[x - 1, y] = 0;
                state[x - 1, y - 1] = 0;
            }
            if(dir==Direction.Up)
            {
                state[x, y] = 1;
                state[x, y - 2] = 0;
            }
            if(dir==Direction.Down)
            {
                state[x, y-1] = 1;
                state[x, y + 1] = 0;
            }
        }

        if(type==ChessType.Rect21)
        {
            if(dir==Direction.Left)
            {
                state[x, y] = 1;
                state[x + 2, y] = 0;
            }
            if(dir==Direction.Right)
            {
                state[x - 1, y] = 0;
                state[x + 1, y] = 1;
            }
            if(dir==Direction.Down)
            {
                state[x, y] = 1;
                state[x + 1, y] = 1;
                state[x, y + 1] = 0;
                state[x + 1, y + 1] = 0;
            }
            if(dir==Direction.Up)
            {
                state[x, y] = 1;
                state[x + 1, y] = 1;
                state[x, y - 1] = 0;
                state[x + 1, y - 1] = 0;
            }
        }

        if(type == ChessType.Rect22)
        {

            if(dir == Direction.Left)
            {
                state[x, y] = 1;
                state[x, y - 1] = 1;
                state[x + 2, y] = 0;
                state[x + 2, y - 1] = 0;
            }

            if(dir==Direction.Right)
            {
                state[x - 1, y] = 0;
                state[x - 1, y - 1] = 0;
                state[x + 1, y] = 1;
                state[x + 1, y - 1] = 1;

            }

            if(dir == Direction.Up)
            {
                state[x, y - 2] = 0;
                state[x + 1, y - 2] = 0;
                state[x, y] = 1;
                state[x + 1, y] = 1;
            }

            if(dir == Direction.Down)
            {
                state[x, y-1] = 1;
                state[x + 1, y-1] = 1;
                state[x, y + 1] = 0;
                state[x + 1, y + 1] = 0;
            }
        }

    }


}
