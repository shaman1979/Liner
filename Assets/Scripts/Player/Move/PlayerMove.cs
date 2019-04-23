using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerMove : MonoBehaviour
{
    public enum Direction
    {
        Left = -1,
        Right = 1
    }

    public TapEvent Tap;

    private const int angel = 55;

    private float speed;
    private Direction direction = Direction.Right;

    private bool isTouch = true;
    private bool isStart = false;

    private float addSpeedInTime = 0.5f;
    private float interval = 1f;
    private float nowTime = 0f;

    private float maxSpeed = 15f;

    public void StartGame()
    {
        isStart = true;
        speed = 3f;
    }
    private void Start()
    {
        nowTime = interval;
        Rotation(-angel);
    }

    private void Update()
    {
        if (isStart)
        {
            Controller();
            AddSpeed();
        }
    }

    private void AddSpeed()
    {
        nowTime -= Time.deltaTime;
        if (nowTime <= 0)
        {
            if (speed < maxSpeed)
            {
                speed += addSpeedInTime;
                nowTime = interval;
            }
        }
    }

    private void Controller()
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

    private void Move()
    {
        var newPosition = new Vector3(speed * Time.deltaTime * (int)direction,0f, 0f);
        transform.position += newPosition;
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

        Tap.Invoke(direction);
    }

    private void Rotation(float angel)
    {
        transform.rotation = Quaternion.Euler(0f, 0f, angel);
    }
}

[Serializable]
public class TapEvent : UnityEvent<PlayerMove.Direction>
{

}
