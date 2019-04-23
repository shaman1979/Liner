using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeWithLiquid : Enemy
{
    protected override void DoSomething(GameObject player)
    {
        Destroy(player);
    }
}
