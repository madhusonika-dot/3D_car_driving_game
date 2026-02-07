using System.Collections.Generic;
using UnityEngine;

namespace OpenWorldDriving.Traffic
{
    /// <summary>
    /// Graph of lane nodes for AI navigation.
    /// </summary>
    public class LaneGraph : MonoBehaviour
    {
        [SerializeField] private List<Transform> nodes = new List<Transform>();

        public IReadOnlyList<Transform> Nodes => nodes;

        public Transform GetNextNode(int index)
        {
            if (nodes.Count == 0)
            {
                return null;
            }

            var nextIndex = (index + 1) % nodes.Count;
            return nodes[nextIndex];
        }
    }
}
