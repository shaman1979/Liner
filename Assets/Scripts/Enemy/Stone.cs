using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : Enemy
{
    private void Awake()
    {
        SpawnType = new RandomSpawn();
    }

   
    public override void GetPosition(Vector2[] position)
    {
        transform.position = (SpawnType as ISpawnType<Vector2[]>).SetPosition(position);
        ChangeSide();
    }

    protected override void DoSomething(GameObject player)
    {
        Destroy(player);
    }
}
