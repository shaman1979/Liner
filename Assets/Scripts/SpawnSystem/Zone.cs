using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Liner
{
    [CreateAssetMenu(fileName = "Zone", menuName = "SO/Create Zone")]
    public class Zone : ScriptableObject
    {
        [SerializeField]
        private SceneObject[] spawnObjects;
        [SerializeField]
        private ZoneType zoneType;

        public SceneObject[] GetSceneObjects()
        {
            return spawnObjects;
        }

    }

    [System.Serializable]
    public class SceneObject
    {
        public SpawnObject obj;

        public SpawnType spawnType;

        public Vector2 position;

        public DirectionSpawn directionSpawn;
    }

    public enum SpawnType
    {
        anchor,
        random
    }

    public enum DirectionSpawn
    {
        left,
        right
    }

    public enum ZoneType
    {
        isEmpty,
        onlyEnergy,
        onlyGarBadge,
        EnergyAndGarBadge
    }
}
