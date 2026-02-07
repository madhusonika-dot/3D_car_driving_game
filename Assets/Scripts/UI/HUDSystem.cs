using UnityEngine;

namespace OpenWorldDriving.UI
{
    /// <summary>
    /// Aggregates speedometer, RPM, and wanted widgets.
    /// </summary>
    public class HUDSystem : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float rpm;

        public void UpdateSpeed(float newSpeed)
        {
            speed = newSpeed;
        }

        public void UpdateRpm(float newRpm)
        {
            rpm = newRpm;
        }
    }
}
