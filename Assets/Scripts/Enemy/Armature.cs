﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armature : Enemy
{
    private void Awake()
    {
        SpawnType = new AnchorSpawn();
    }

    public override void GetPosition(Vector2[] position)
    {
        transform.position = (SpawnType as ISpawnType<Vector2>).SetPosition(position[0]);
        ChangeSide();
    }

    protected override void DoSomething(GameObject player)
    {
        Destroy(player);
    }
}
