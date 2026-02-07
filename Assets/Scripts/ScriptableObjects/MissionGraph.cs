using System.Collections.Generic;
using UnityEngine;

namespace OpenWorldDriving.Missions
{
    /// <summary>
    /// Scriptable mission graph with objectives and branching paths.
    /// </summary>
    [CreateAssetMenu(menuName = "OpenWorldDriving/Missions/Mission Graph")]
    public class MissionGraph : ScriptableObject
    {
        public string missionName;
        public List<ObjectiveNode> objectives = new List<ObjectiveNode>();
    }
}
