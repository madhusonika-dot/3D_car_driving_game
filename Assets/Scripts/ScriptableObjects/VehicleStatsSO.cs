using UnityEngine;

namespace OpenWorldDriving.Vehicles
{
    /// <summary>
    /// Configurable vehicle stats for different classes.
    /// </summary>
    [CreateAssetMenu(menuName = "OpenWorldDriving/Vehicles/Vehicle Stats")]
    public class VehicleStatsSO : ScriptableObject
    {
        public string vehicleClassName = "Sports";
        public float maxTorque = 400f;
        public AnimationCurve torqueCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);
        public float maxRPM = 7000f;
        public float idleRPM = 900f;
        public float brakeTorque = 2000f;
        public float steeringAngle = 30f;
        public float tractionAssist = 0.2f;
        public float absAssist = 0.2f;
        public float driftFactor = 0.5f;
        public float fuelCapacity = 60f;
        public bool fuelUsageEnabled = false;
    }
}
