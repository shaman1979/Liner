﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armature : Enemy
{
    protected override void DoSomething(GameObject player)
    {
        Destroy(player);
    }
}
