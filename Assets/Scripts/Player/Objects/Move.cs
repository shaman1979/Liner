using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Move : MonoBehaviour
{
    #region Configs
    [SerializeField]
    private float speed;
    [SerializeField]
    private float deleteZone = -5f;
    #endregion

    private void Update()
    {
        Movening();
        Destroy();
    }

    private void Destroy()
    {
        if (transform.position.y <= deleteZone)
        {
            Destroy(gameObject);
        }
    }

    private void Movening()
    {
        transform.position += new Vector3(0f, -speed * Time.deltaTime, 0f);
    }
}
