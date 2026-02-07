using UnityEngine;

namespace OpenWorldDriving.Traffic
{
    /// <summary>
    /// AI agent that follows lane nodes and reacts to signals.
    /// </summary>
    public class TrafficAgentAI : MonoBehaviour
    {
        [SerializeField] private LaneGraph laneGraph;
        [SerializeField] private float speed = 10f;
        [SerializeField] private int currentNodeIndex;

        private void Update()
        {
            if (laneGraph == null || laneGraph.Nodes.Count == 0)
            {
                return;
            }

            var targetNode = laneGraph.Nodes[currentNodeIndex];
            var direction = (targetNode.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 2f);

            if (Vector3.Distance(transform.position, targetNode.position) < 2f)
            {
                currentNodeIndex = (currentNodeIndex + 1) % laneGraph.Nodes.Count;
            }
        }
    }
}
