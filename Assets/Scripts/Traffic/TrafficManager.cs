using System.Collections.Generic;
using UnityEngine;
using OpenWorldDriving.Shared;

namespace OpenWorldDriving.Traffic
{
    /// <summary>
    /// Spawns pooled traffic agents and enforces budget caps.
    /// </summary>
    public class TrafficManager : ManagerBase
    {
        [SerializeField] private GameObject trafficPrefab;
        [SerializeField] private int maxAgents = 50;
        [SerializeField] private List<TrafficAgentAI> activeAgents = new List<TrafficAgentAI>();

        public override void Initialize()
        {
            base.Initialize();
            SpawnInitialAgents();
        }

        public void SpawnInitialAgents()
        {
            if (trafficPrefab == null)
            {
                return;
            }

            for (var i = activeAgents.Count; i < maxAgents; i++)
            {
                var instance = Instantiate(trafficPrefab, Vector3.zero, Quaternion.identity);
                var agent = instance.GetComponent<TrafficAgentAI>();
                if (agent != null)
                {
                    activeAgents.Add(agent);
                }
            }
        }

        public void DespawnAll()
        {
            foreach (var agent in activeAgents)
            {
                if (agent != null)
                {
                    Destroy(agent.gameObject);
                }
            }

            activeAgents.Clear();
        }
    }
}
