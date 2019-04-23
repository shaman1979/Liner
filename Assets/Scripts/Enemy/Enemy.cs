using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Move))]
public abstract class Enemy : MonoBehaviour
{ 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            DoSomething(collision.gameObject);
    }

    protected abstract void DoSomething(GameObject player);
}
