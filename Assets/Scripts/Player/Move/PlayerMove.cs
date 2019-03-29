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
    private Direction direction = Direction.Left;

    private bool isTouch = true;
    private bool isStart = false;

    private float addSpeedInTime = 0.5f;
    private float interval = 1f;
    private float nouTime = 0f;//todo: Переименовать когда будет переводчик

    private float maxSpeed = 15f;

    public void StartGame()
    {
        isStart = true;
        speed = 5f;
    }
    private void Start()
    {
        nouTime = interval;
        Rotation(angel);
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
        nouTime -= Time.deltaTime;
        if (nouTime <= 0)
        {
            if (speed < maxSpeed)
            {
                speed += addSpeedInTime;
                nouTime = interval;
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
        var newPosition = new Vector3(0f, speed * Time.deltaTime, 0f);
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
