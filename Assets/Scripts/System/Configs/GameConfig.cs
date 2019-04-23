using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/GameConfigs")]
public class GameConfig : ScriptableObject
{
    public SpawnZone SpawnZone;
    public float playerSpeed;
}

[System.Serializable]
public class SpawnZone
{
    public float LeftX;
    public float RightX;
    public float UpY;
    public float DownY;
}
