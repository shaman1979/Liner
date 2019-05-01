using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/GameConfigs")]
public class GameConfig : SerializedScriptableObject
{
    [BoxGroup(CenterLabel = true,GroupName = "Границы сцены", ShowLabel = true)]
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
