using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Sirenix.OdinInspector;
[CreateAssetMenu(fileName ="LibriaryEnemes", menuName = "Configs/LibriaryEnemes")]
public class Libriary : SerializedScriptableObject
{
    [DictionaryDrawerSettings(KeyLabel = "Типы", ValueLabel = "Препятствия", DisplayMode = DictionaryDisplayOptions.Foldout)]
    [SerializeField]
    private Dictionary<ZoneType, List<Enemy>> zones = new Dictionary<ZoneType, List<Enemy>>();

    public List<Enemy> Search(ZoneType type)
    { 
        return zones[type];
    }
}

public enum ZoneType
{
    Stone,
    StoneAndPipe,
    StoneAndArm,
    StoneAndPipeWithWather
}
