using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBus : Publisher
{
    private DataBus() { }

    private static DataBus _instance;

    public static DataBus Instance => _instance ?? (_instance = new DataBus());

}
