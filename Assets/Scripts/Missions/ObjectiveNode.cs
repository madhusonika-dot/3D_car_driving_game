using UnityEngine;

namespace OpenWorldDriving.Missions
{
    /// <summary>
    /// Defines a mission objective node.
    /// </summary>
    [System.Serializable]
    public class ObjectiveNode
    {
        public string description;
        public bool isOptional;
        public float timeLimit;
    }
}
