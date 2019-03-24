using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveForTarget : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float speed;

    private void Update()
    {
        var newPos = new Vector3(transform.position.x, target.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPos, speed * Time.deltaTime);
    }
}
