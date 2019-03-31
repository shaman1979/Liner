using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBus : Publisher
{
    public DataBus() { }

    private static DataBus _instance;

    public static DataBus Instance { get { return _instance; } set { _instance = value; } }

}
