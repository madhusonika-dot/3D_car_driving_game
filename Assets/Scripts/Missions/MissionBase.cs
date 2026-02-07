using UnityEngine;

namespace OpenWorldDriving.Missions
{
    /// <summary>
    /// Base class for mission implementations.
    /// </summary>
    public abstract class MissionBase : MonoBehaviour
    {
        [SerializeField] protected MissionGraph missionGraph;
        [SerializeField] protected int currentObjectiveIndex;

        public virtual void StartMission()
        {
            currentObjectiveIndex = 0;
        }

        public virtual void CompleteObjective()
        {
            currentObjectiveIndex++;
            if (missionGraph != null && currentObjectiveIndex >= missionGraph.objectives.Count)
            {
                CompleteMission();
            }
        }

        public virtual void CompleteMission()
        {
            // Hook for mission completion.
        }

        public virtual void FailMission()
        {
            // Hook for mission failure.
        }
    }
}
