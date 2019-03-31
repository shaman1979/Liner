using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISubscriber
{
}

public interface ISubscriber<TMassage>: ISubscriber
{
    void UpdateData(TMassage massage);
}
