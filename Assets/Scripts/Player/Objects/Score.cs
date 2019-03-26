using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class Score : MonoBehaviour
{
    [Inject]
    public IPublisher Publisher { get; set; }
    [SerializeField]
    private float point = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy();
            Publisher.Notify(point);
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}

