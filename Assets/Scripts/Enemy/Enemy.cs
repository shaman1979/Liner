using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Move))]
public abstract class Enemy : MonoBehaviour
{
    public ISpawnType SpawnType;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            DoSomething(collision.gameObject);
    }

    protected abstract void DoSomething(GameObject player);

    public abstract void GetPosition(Vector2[] positions);
}
