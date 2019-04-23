using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DeleteZone : MonoBehaviour
{
    [Inject]
    public EndGameValue endGameValue { get; set; }

    [Inject]
    public Publisher Publisher { get; set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            EndGame();

        Destroy(collision.gameObject);
    }

    private void EndGame()
    {
        Publisher.Notify<EndGameValue>(endGameValue);
    }
}
