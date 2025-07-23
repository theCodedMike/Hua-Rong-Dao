using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Done_huarongdao;

namespace Done_huarongdao
{
    public enum ChessType
    {
        Rect11, //兵，1×1的方块
        Rect12, //竖着的将军，1×2的方块
        Rect21, //横着的将军，2×1的方块
        Rect22  //曹操，2×2的方块
    }
    public enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }
}

public class Done_Chess : MonoBehaviour {

    public ChessType chesstype;

    public int left_x;             //棋子左上角坐标x
    public int left_y;             //棋子左上角坐标y
    public string chessName;       //棋子的名字
    public int width;              //棋子的宽度
    public int height;             //棋子的高度
    public GameObject _gameObject; //棋子的预制体

    
    //构造函数
    public Done_Chess(GameObject go,ChessType type,int x,int y)
    {
        chesstype = type;
        left_x = x;
        left_y = y;
        _gameObject = go;
        chessName = go.name;
        Instantiate(go, new Vector2(x, y), Quaternion.identity);
    }



    public int getWidth(ChessType type)
    {
        if(type==ChessType.Rect11||type == ChessType.Rect12)
        {
            width = 1;
        }
        if(type == ChessType.Rect21||type ==ChessType.Rect22)
        {
           width = 2;
        }
        return width;
    }

    public int getHeight(ChessType type)
    {
        if (type == ChessType.Rect11 || type == ChessType.Rect21)
        {
            height = 1;


        }
        if (type == ChessType.Rect12 || type == ChessType.Rect22)
        {
            height = 2;
        }
        return height;
    }

}
