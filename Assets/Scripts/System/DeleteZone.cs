using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            EndGame();

        Destroy(collision.gameObject);
    }

    private void EndGame()
    {
        DataBus.Instance.Notify<EndGameValue>(new EndGameValue());
    }
}
