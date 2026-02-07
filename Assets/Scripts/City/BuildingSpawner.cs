using System.Collections.Generic;
using UnityEngine;

namespace OpenWorldDriving.City
{
    /// <summary>
    /// Spawns buildings and landmark prefabs.
    /// </summary>
    public class BuildingSpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> buildingPrefabs = new List<GameObject>();
        [SerializeField] private Transform parentRoot;

        public void SpawnBuildings()
        {
            foreach (var prefab in buildingPrefabs)
            {
                if (prefab == null)
                {
                    continue;
                }

                var instance = Instantiate(prefab, Vector3.zero, Quaternion.identity, parentRoot);
                instance.name = prefab.name;
            }
        }
    }
}
