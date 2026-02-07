using System.Collections.Generic;
using UnityEngine;
using OpenWorldDriving.Shared;

namespace OpenWorldDriving.Performance
{
    /// <summary>
    /// Generic object pool manager.
    /// </summary>
    public class PoolManager : ManagerBase
    {
        private readonly Dictionary<GameObject, Queue<GameObject>> pools = new Dictionary<GameObject, Queue<GameObject>>();

        public GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            if (prefab == null)
            {
                return null;
            }

            if (!pools.TryGetValue(prefab, out var queue))
            {
                queue = new Queue<GameObject>();
                pools[prefab] = queue;
            }

            var instance = queue.Count > 0 ? queue.Dequeue() : Instantiate(prefab);
            instance.transform.SetPositionAndRotation(position, rotation);
            instance.SetActive(true);
            return instance;
        }

        public void Despawn(GameObject prefab, GameObject instance)
        {
            if (prefab == null || instance == null)
            {
                return;
            }

            if (!pools.TryGetValue(prefab, out var queue))
            {
                queue = new Queue<GameObject>();
                pools[prefab] = queue;
            }

            instance.SetActive(false);
            queue.Enqueue(instance);
        }
    }
}
