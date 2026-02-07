using System.Collections.Generic;
using UnityEngine;
using OpenWorldDriving.Shared;

namespace OpenWorldDriving.Missions
{
    /// <summary>
    /// Coordinates mission flow, branching, and retries.
    /// </summary>
    public class MissionManager : ManagerBase
    {
        [SerializeField] private List<MissionBase> activeMissions = new List<MissionBase>();

        public void StartMission(MissionBase mission)
        {
            if (mission == null)
            {
                return;
            }

            mission.StartMission();
            if (!activeMissions.Contains(mission))
            {
                activeMissions.Add(mission);
            }
        }

        public void FailMission(MissionBase mission)
        {
            if (mission == null)
            {
                return;
            }

            mission.FailMission();
            activeMissions.Remove(mission);
        }
    }
}
