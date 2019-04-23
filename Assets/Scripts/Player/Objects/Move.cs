using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Move : MonoBehaviour
{
    #region Configs
    [SerializeField]
    private float speed = 1f;
    #endregion

    private void Update()
    {
        Movening();
    }

    private void Movening()
    {
        transform.position += new Vector3(0f, -speed * Time.deltaTime, 0f);
    }
}
