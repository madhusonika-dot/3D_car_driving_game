using UnityEngine;

namespace OpenWorldDriving.Vehicles
{
    /// <summary>
    /// Wraps WheelCollider and visual wheel reference.
    /// </summary>
    public class WheelModule : MonoBehaviour
    {
        [SerializeField] private WheelCollider wheelCollider;
        [SerializeField] private Transform wheelVisual;
        [SerializeField] private bool isSteerWheel;
        [SerializeField] private bool isDriveWheel;
        [SerializeField] private bool isBrakeWheel;

        public WheelCollider Collider => wheelCollider;
        public bool IsDriveWheel => isDriveWheel;
        public bool IsBrakeWheel => isBrakeWheel;
        public bool IsSteerWheel => isSteerWheel;

        public void ApplySteer(float angle)
        {
            if (isSteerWheel && wheelCollider != null)
            {
                wheelCollider.steerAngle = angle;
            }
        }

        public void ApplyMotor(float torque)
        {
            if (isDriveWheel && wheelCollider != null)
            {
                wheelCollider.motorTorque = torque;
            }
        }

        public void ApplyBrake(float torque)
        {
            if (isBrakeWheel && wheelCollider != null)
            {
                wheelCollider.brakeTorque = torque;
            }
        }

        public void UpdateVisual()
        {
            if (wheelCollider == null || wheelVisual == null)
            {
                return;
            }

            wheelCollider.GetWorldPose(out var position, out var rotation);
            wheelVisual.position = position;
            wheelVisual.rotation = rotation;
        }
    }
}
