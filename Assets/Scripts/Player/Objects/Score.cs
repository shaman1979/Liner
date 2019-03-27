using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class Score : MonoBehaviour
{

    [SerializeField]
    private int point = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy();
            DataBus.Instance.Notify(point);
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}

