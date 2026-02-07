using System.Collections.Generic;
using UnityEngine;

namespace OpenWorldDriving.City
{
    /// <summary>
    /// Streams city chunks based on distance to the player.
    /// </summary>
    public class WorldStreamer : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private float loadDistance = 500f;
        [SerializeField] private List<GameObject> chunks = new List<GameObject>();

        private void Update()
        {
            if (player == null)
            {
                return;
            }

            foreach (var chunk in chunks)
            {
                if (chunk == null)
                {
                    continue;
                }

                var distance = Vector3.Distance(player.position, chunk.transform.position);
                var shouldBeActive = distance <= loadDistance;
                if (chunk.activeSelf != shouldBeActive)
                {
                    chunk.SetActive(shouldBeActive);
                }
            }
        }
    }
}
