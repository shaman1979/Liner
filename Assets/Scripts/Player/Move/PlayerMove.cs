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

    [SerializeField]
    private float speed;
    [SerializeField]
    public Direction direction;


    private bool isTouch = true;

    private void Start()
    {
        Rotation(-45);    
    }

    private void Update()
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
            else if(Input.touchCount <= 0 )
            {
                isTouch = true;
            }
        }

        Move();
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
                Rotation(-45f);
                break;
            case Direction.Right:
                direction = Direction.Left;
                Rotation(45f);
                break;
        }
    }

    private void Rotation(float angel)
    {
        transform.rotation = Quaternion.Euler(0f, 0f, angel);
    }
}
