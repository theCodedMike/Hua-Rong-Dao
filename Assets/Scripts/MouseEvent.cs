using System;
using UnityEngine;

public class MouseEvent : MonoBehaviour
{
    private Vector2 _firstPos; // 鼠标第一次点击的位置
    private Vector2 _secondPos; // 鼠标松开时的位置
    private Chess _targetChess; // 被选中的棋子
    //private Transform _targetTrans; // 被选中棋子的Transform
    private Camera _mainCamera;
    private float _threshold = 0.5f; // 移动阈值
    private Direction _dir; // 鼠标移动大致方向
    

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _firstPos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            
            // 设鼠标位置为(Mx, My)，棋子宽度为w，高度为h，棋子左上角的坐标为(Lx, Ly)
            // Lx < Mx < Lx + w && Ly - h < My < Ly
            foreach (Chess chess in GameController.chess)
            {
                if (chess.leftX < _firstPos.x && _firstPos.x < chess.leftX + chess.width &&
                    chess.leftY - chess.height < _firstPos.y && _firstPos.y < chess.leftY)
                {
                    _targetChess = chess;
                    //_targetTrans = chess.transform;
                    break;
                }
            }
        }

        if (Input.GetMouseButtonUp(0) && _targetChess != null)
        {
            _secondPos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            if (_firstPos == _secondPos)
                return;
            
            // 计算方向
            ComputeDirection();
            // 棋子移动
            Move();

            _targetChess = null;
        }
    }

    // 计算鼠标移动的大致方向
    private void ComputeDirection()
    {
        // 上
        if (_firstPos.y < _secondPos.y && Mathf.Abs(_secondPos.x - _firstPos.x) < _threshold)
            _dir = Direction.Up;
        // 下
        else if (_secondPos.y < _firstPos.y && Mathf.Abs(_secondPos.x - _firstPos.x) < _threshold)
            _dir = Direction.Down;
        // 左
        else if (_secondPos.x < _firstPos.x && Mathf.Abs(_secondPos.y - _firstPos.y) < _threshold)
            _dir = Direction.Left;
        // 右
        else if (_firstPos.x < _secondPos.x && Mathf.Abs(_secondPos.y - _firstPos.y) < _threshold)
            _dir = Direction.Right;
    }

    private void Move()
    {
        (bool canMove, Vector3 moveDir, Action updateState) = CanMove();
        if (canMove)
        {
            updateState();
            _targetChess.transform.position += moveDir;
            Vector3 position = _targetChess.transform.position;
            _targetChess.leftX = (int)position.x;
            _targetChess.leftY = (int)position.y;
        }
    }

    private (bool, Vector3, Action) CanMove()
    {
        print($"CanMove: {_targetChess.chessType} {_targetChess.chessName} {_dir} {_targetChess.leftX} {_targetChess.leftY}");
        switch (_targetChess.chessType)
        {
            case ChessType.Rect11:
                if (_dir == Direction.Up && GameController.state[_targetChess.leftY + 1, _targetChess.leftX] == 0)
                    return (true, Vector3.up, () =>
                    {
                        GameController.state[_targetChess.leftY, _targetChess.leftX] = 0;
                        GameController.state[_targetChess.leftY + 1, _targetChess.leftX] = 1;
                    });
                if (_dir == Direction.Down && GameController.state[_targetChess.leftY - 1, _targetChess.leftX] == 0)
                    return (true, Vector3.down, () =>
                    {
                        GameController.state[_targetChess.leftY, _targetChess.leftX] = 0;
                        GameController.state[_targetChess.leftY - 1, _targetChess.leftX] = 1;
                    });
                if (_dir == Direction.Left && GameController.state[_targetChess.leftY, _targetChess.leftX - 1] == 0)
                    return (true, Vector3.left, () =>
                    {
                        GameController.state[_targetChess.leftY, _targetChess.leftX] = 0;
                        GameController.state[_targetChess.leftY, _targetChess.leftX - 1] = 1;
                    });
                if (_dir == Direction.Right && GameController.state[_targetChess.leftY, _targetChess.leftX + 1] == 0)
                    return (true, Vector3.right, () =>
                    {
                        GameController.state[_targetChess.leftY, _targetChess.leftX] = 0;
                        GameController.state[_targetChess.leftY, _targetChess.leftX + 1] = 1;
                    });
                break;
            case ChessType.Rect12:
                if (_dir == Direction.Up && GameController.state[_targetChess.leftY + 1, _targetChess.leftX] == 0)
                    return (true, Vector3.up, () =>
                    {
                        GameController.state[_targetChess.leftY - 1, _targetChess.leftX] = 0;
                        GameController.state[_targetChess.leftY + 1, _targetChess.leftX] = 1;
                    });
                if (_dir == Direction.Down && GameController.state[_targetChess.leftY - 2, _targetChess.leftX] == 0)
                    return (true, Vector3.down, () =>
                    {
                        GameController.state[_targetChess.leftY, _targetChess.leftX] = 0;
                        GameController.state[_targetChess.leftY - 2, _targetChess.leftX] = 1;
                    });
                if (_dir == Direction.Left && GameController.state[_targetChess.leftY, _targetChess.leftX - 1] == 0
                                           && GameController.state[_targetChess.leftY - 1, _targetChess.leftX - 1] == 0)
                    return (true, Vector3.left, () =>
                    {
                        GameController.state[_targetChess.leftY, _targetChess.leftX] = 0;
                        GameController.state[_targetChess.leftY - 1, _targetChess.leftX] = 0;
                        GameController.state[_targetChess.leftY, _targetChess.leftX - 1] = 1;
                        GameController.state[_targetChess.leftY - 1, _targetChess.leftX - 1] = 1;
                    });
                if(_dir == Direction.Right && GameController.state[_targetChess.leftY, _targetChess.leftX + 1] == 0
                                           && GameController.state[_targetChess.leftY - 1, _targetChess.leftX + 1] == 0)
                    return (true, Vector3.right, () =>
                    {
                        GameController.state[_targetChess.leftY, _targetChess.leftX] = 0;
                        GameController.state[_targetChess.leftY - 1, _targetChess.leftX] = 0;
                        GameController.state[_targetChess.leftY, _targetChess.leftX + 1] = 1;
                        GameController.state[_targetChess.leftY - 1, _targetChess.leftX + 1] = 1;
                    });
                break;
            case ChessType.Rect21:
                if (_dir == Direction.Up && GameController.state[_targetChess.leftY + 1, _targetChess.leftX] == 0 
                                         && GameController.state[_targetChess.leftY + 1, _targetChess.leftX + 1] == 0)
                    return (true, Vector3.up, () =>
                    {
                        GameController.state[_targetChess.leftY, _targetChess.leftX] = 0;
                        GameController.state[_targetChess.leftY, _targetChess.leftX + 1] = 0;
                        GameController.state[_targetChess.leftY + 1, _targetChess.leftX] = 1;
                        GameController.state[_targetChess.leftY + 1, _targetChess.leftX + 1] = 1;
                    });
                if (_dir == Direction.Down && GameController.state[_targetChess.leftY - 1, _targetChess.leftX] == 0 
                                           && GameController.state[_targetChess.leftY - 1, _targetChess.leftX + 1] == 0)
                    return (true, Vector3.down, () =>
                    {
                        GameController.state[_targetChess.leftY, _targetChess.leftX] = 0;
                        GameController.state[_targetChess.leftY, _targetChess.leftX + 1] = 0;
                        GameController.state[_targetChess.leftY - 1, _targetChess.leftX] = 1;
                        GameController.state[_targetChess.leftY - 1, _targetChess.leftX + 1] = 1;
                    });
                if (_dir == Direction.Left && GameController.state[_targetChess.leftY, _targetChess.leftX - 1] == 0)
                    return (true, Vector3.left, () =>
                    {
                        GameController.state[_targetChess.leftY, _targetChess.leftX + 1] = 0;
                        GameController.state[_targetChess.leftY, _targetChess.leftX - 1] = 1;
                    });
                if (_dir == Direction.Right && GameController.state[_targetChess.leftY, _targetChess.leftX + 2] == 0)
                    return (true, Vector3.right, () =>
                    {
                        GameController.state[_targetChess.leftY, _targetChess.leftX] = 0;
                        GameController.state[_targetChess.leftY, _targetChess.leftX + 2] = 1;
                    });
                break;
            case ChessType.Rect22: 
                if (_dir == Direction.Up && GameController.state[_targetChess.leftY + 1, _targetChess.leftX] == 0
                                         && GameController.state[_targetChess.leftY + 1, _targetChess.leftX + 1] == 0)
                    return (true, Vector3.up, () =>
                    {
                        GameController.state[_targetChess.leftY - 1, _targetChess.leftX] = 0;
                        GameController.state[_targetChess.leftY - 1, _targetChess.leftX + 1] = 0;
                        GameController.state[_targetChess.leftY + 1, _targetChess.leftX] = 1;
                        GameController.state[_targetChess.leftY + 1, _targetChess.leftX + 1] = 1;
                    });
                if (_dir == Direction.Down && GameController.state[_targetChess.leftY - 2, _targetChess.leftX] == 0
                                         && GameController.state[_targetChess.leftY - 2, _targetChess.leftX + 1] == 0)
                    return (true, Vector3.down, () =>
                    {
                        GameController.state[_targetChess.leftY, _targetChess.leftX] = 0;
                        GameController.state[_targetChess.leftY, _targetChess.leftX + 1] = 0;
                        GameController.state[_targetChess.leftY - 2, _targetChess.leftX] = 1;
                        GameController.state[_targetChess.leftY - 2, _targetChess.leftX + 1] = 1;
                    });
                if (_dir == Direction.Left && GameController.state[_targetChess.leftY, _targetChess.leftX - 1] == 0
                                         && GameController.state[_targetChess.leftY - 1, _targetChess.leftX - 1] == 0)
                    return (true, Vector3.left, () =>
                    {
                        GameController.state[_targetChess.leftY, _targetChess.leftX + 1] = 0;
                        GameController.state[_targetChess.leftY - 1, _targetChess.leftX + 1] = 0;
                        GameController.state[_targetChess.leftY, _targetChess.leftX - 1] = 1;
                        GameController.state[_targetChess.leftY - 1, _targetChess.leftX - 1] = 1;
                    });
                if (_dir == Direction.Right && GameController.state[_targetChess.leftY, _targetChess.leftX + 2] == 0
                                            && GameController.state[_targetChess.leftY - 1, _targetChess.leftX + 2] == 0)
                    return (true, Vector3.right, () =>
                    {
                        GameController.state[_targetChess.leftY, _targetChess.leftX] = 0;
                        GameController.state[_targetChess.leftY - 1, _targetChess.leftX] = 0;
                        GameController.state[_targetChess.leftY, _targetChess.leftX + 2] = 1;
                        GameController.state[_targetChess.leftY - 1, _targetChess.leftX + 2] = 1;
                    });
                break;
        }
        
        return (false, Vector3.zero, () => {});
    }
}
