using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public enum Direction
    {
        Left = -1,
        Right = 1
    }

    private const int angel = 45;

    private float speed;
    private Direction direction;

    private bool isTouch = true;
    private bool isStart = false;

    

    private void Start()
    {
        Rotation(angel);    
    }

    private void Update()
    {
        Controller();
        AddSpeed();
    }

    private void AddSpeed()
    {
        
    }

    private void Controller()
    {
        if (isStart)
        {
            #region isEditor
            if (Application.isEditor)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    DirectionChange();
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    DirectionChange();
                }
            }
            #endregion
            else
            {
                if (Input.touchCount > 0 && isTouch)
                {
                    DirectionChange();
                    isTouch = false;
                }
                else if (Input.touchCount <= 0)
                {
                    isTouch = true;
                }
            }
            Move();
        }
        else
        {
            if (Input.touchCount > 0 || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                isStart = true;
                speed = 6f;
            }
        }
    }

    private void Move()
    {
        var newPosition = new Vector3(0f ,speed * Time.deltaTime, 0f);
        transform.Translate(newPosition);
    }

    private void DirectionChange()
    {
        switch (direction)
        {
            case Direction.Left:
                direction = Direction.Right;
                Rotation(-angel);
                break;
            case Direction.Right:
                direction = Direction.Left;
                Rotation(angel);
                break;
        }
    }

    private void Rotation(float angel)
    {
        transform.rotation = Quaternion.Euler(0f, 0f, angel);
    }
}
