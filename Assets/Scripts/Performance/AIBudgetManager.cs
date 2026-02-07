using UnityEngine;

namespace OpenWorldDriving.Performance
{
    /// <summary>
    /// Enables AI sleep and budget scaling by distance.
    /// </summary>
    public class AIBudgetManager : MonoBehaviour
    {
        [SerializeField] private float sleepDistance = 200f;
        [SerializeField] private Transform player;

        public bool ShouldSleep(Transform ai)
        {
            if (ai == null || player == null)
            {
                return false;
            }

            return Vector3.Distance(player.position, ai.position) > sleepDistance;
        }
    }
}
