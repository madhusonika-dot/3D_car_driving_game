using UnityEngine;

namespace OpenWorldDriving.UI
{
    /// <summary>
    /// Provides GPS-style navigation cues.
    /// </summary>
    public class GPSNavigator : MonoBehaviour
    {
        [SerializeField] private Transform destination;

        public Vector3 GetDirection(Transform origin)
        {
            if (destination == null || origin == null)
            {
                return Vector3.zero;
            }

            return (destination.position - origin.position).normalized;
        }
    }
}
