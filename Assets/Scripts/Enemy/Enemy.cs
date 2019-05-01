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

    protected void ChangeSide()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();

        float side = Mathf.Min(transform.position.x, 0);

        if (side == 0)
        {
            spriteRenderer.flipY = true;
        }
        else
        {
            spriteRenderer.flipY = false;
        }
    }

    protected abstract void DoSomething(GameObject player);

    public abstract void GetPosition(Vector2[] positions);
}
