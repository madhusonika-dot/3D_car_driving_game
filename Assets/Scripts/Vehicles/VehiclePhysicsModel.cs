using UnityEngine;

namespace OpenWorldDriving.Vehicles
{
    /// <summary>
    /// Handles traction, ABS, drift, and suspension tuning.
    /// </summary>
    public class VehiclePhysicsModel : MonoBehaviour
    {
        [SerializeField] private VehicleStatsSO stats;
        [SerializeField] private float antiRollStrength = 5000f;
        [SerializeField] private bool tractionAssistEnabled = true;
        [SerializeField] private bool absAssistEnabled = true;

        public bool TractionAssistEnabled => tractionAssistEnabled;
        public bool AbsAssistEnabled => absAssistEnabled;

        public void ToggleTractionAssist(bool enabled)
        {
            tractionAssistEnabled = enabled;
        }

        public void ToggleAbsAssist(bool enabled)
        {
            absAssistEnabled = enabled;
        }

        public void ApplyAntiRoll(WheelCollider leftWheel, WheelCollider rightWheel)
        {
            if (leftWheel == null || rightWheel == null)
            {
                return;
            }

            leftWheel.GetGroundHit(out var leftHit);
            rightWheel.GetGroundHit(out var rightHit);

            var leftTravel = leftWheel.transform.InverseTransformPoint(leftHit.point).y;
            var rightTravel = rightWheel.transform.InverseTransformPoint(rightHit.point).y;
            var antiRollForce = (leftTravel - rightTravel) * antiRollStrength;

            if (leftWheel.isGrounded)
            {
                leftWheel.attachedRigidbody.AddForceAtPosition(leftWheel.transform.up * -antiRollForce, leftWheel.transform.position);
            }

            if (rightWheel.isGrounded)
            {
                rightWheel.attachedRigidbody.AddForceAtPosition(rightWheel.transform.up * antiRollForce, rightWheel.transform.position);
            }
        }

        public float ApplyTraction(float throttleInput, float slip)
        {
            if (!tractionAssistEnabled || stats == null)
            {
                return throttleInput;
            }

            var assist = Mathf.Clamp01(1f - Mathf.Abs(slip) * stats.tractionAssist);
            return throttleInput * assist;
        }

        public float ApplyAbs(float brakeInput, float slip)
        {
            if (!absAssistEnabled || stats == null)
            {
                return brakeInput;
            }

            var assist = Mathf.Clamp01(1f - Mathf.Abs(slip) * stats.absAssist);
            return brakeInput * assist;
        }

        public float ApplyDrift(float steeringInput, float velocityMagnitude)
        {
            if (stats == null)
            {
                return steeringInput;
            }

            var driftMultiplier = Mathf.Lerp(1f, stats.driftFactor, Mathf.Clamp01(velocityMagnitude / 30f));
            return steeringInput * driftMultiplier;
        }
    }
}
