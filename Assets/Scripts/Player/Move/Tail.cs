using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    public bool IsActive { get; set; } = false;

    public Transform Target { private get; set; }

    [SerializeField]
    private float speed = 1f;

    private void Update()
    {
        if (IsActive)
        {
            if (Target != null)
            {
                RotationAtTarget();
                Scale();                
            }
            Translate();
        }
        
    }

    private void RotationAtTarget()
    {
        var targetPosition = Target.position;
        var selfPosition = transform.position;

        var angle = Vector2.Angle(Vector2.right, targetPosition - selfPosition);//угол между вектором от объекта к мыше и осью х
        transform.eulerAngles = new Vector3(0f, 0f, selfPosition.y < targetPosition.y ? angle : -angle);//немного магии на последок
    }

    private void Scale()
    {
        var distance = Vector3.Distance(transform.position, Target.position);
        transform.localScale = new Vector3(distance, transform.localScale.y, 1f);
    }

    private void Translate()
    {
        var newPos = new Vector3(0f, -speed * Time.deltaTime, 0f);
        transform.position += newPos;
    }
}
