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
        var newPosition = new Vector3(speed * (int)direction * Time.deltaTime, 0f, 0f);
        transform.Translate(newPosition);
    }

    private void DirectionChange()
    {
        switch (direction)
        {
            case Direction.Left:
                direction = Direction.Right;
                break;
            case Direction.Right:
                direction = Direction.Left;
                break;
        }
        Rotation();
    }

    private void Rotation()
    {
        float rotationZ = (int)direction * 90f;
        transform.Rotate(0f, 0f, rotationZ);
    }
}
