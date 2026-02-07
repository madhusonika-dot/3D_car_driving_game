using UnityEngine;

namespace OpenWorldDriving.Vehicles
{
    /// <summary>
    /// Main vehicle controller that wires input, physics, drivetrain, and wheels.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class CarController : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private VehicleStatsSO stats;
        [SerializeField] private VehiclePhysicsModel physicsModel;
        [SerializeField] private DrivetrainModule drivetrain;

        [Header("Wheels")]
        [SerializeField] private WheelModule[] wheelModules;
        [SerializeField] private WheelCollider frontLeft;
        [SerializeField] private WheelCollider frontRight;

        [Header("Runtime")]
        [SerializeField] private float currentRPM;
        [SerializeField] private float currentFuel;
        [SerializeField] private float damageAmount;

        private Rigidbody body;

        private void Awake()
        {
            body = GetComponent<Rigidbody>();
            if (stats != null)
            {
                currentFuel = stats.fuelCapacity;
            }
        }

        private void FixedUpdate()
        {
            var throttle = Input.GetAxis("Vertical");
            var steer = Input.GetAxis("Horizontal");
            var brake = Input.GetKey(KeyCode.Space) ? 1f : 0f;

            HandleMovement(throttle, steer, brake);
            UpdateWheels();
        }

        public void ResetVehicle(Vector3 position, Quaternion rotation)
        {
            transform.SetPositionAndRotation(position, rotation);
            body.velocity = Vector3.zero;
            body.angularVelocity = Vector3.zero;
        }

        private void HandleMovement(float throttleInput, float steeringInput, float brakeInput)
        {
            if (stats == null || physicsModel == null || drivetrain == null)
            {
                return;
            }

            var adjustedSteer = physicsModel.ApplyDrift(steeringInput, body.velocity.magnitude);
            var torque = stats.maxTorque * throttleInput * stats.torqueCurve.Evaluate(Mathf.Clamp01(currentRPM / stats.maxRPM));
            var slip = body.velocity.magnitude > 0.1f ? body.angularVelocity.magnitude : 0f;
            torque = physicsModel.ApplyTraction(torque, slip);

            var brakeTorque = physicsModel.ApplyAbs(stats.brakeTorque * brakeInput, slip);

            foreach (var wheel in wheelModules)
            {
                if (wheel == null)
                {
                    continue;
                }

                wheel.ApplySteer(adjustedSteer * stats.steeringAngle);
                wheel.ApplyMotor(torque / wheelModules.Length);
                wheel.ApplyBrake(brakeTorque);
            }

            currentRPM = Mathf.Lerp(currentRPM, drivetrain.CalculateRPM(body.velocity.magnitude * 60f), Time.fixedDeltaTime);

            if (stats.fuelUsageEnabled)
            {
                currentFuel = Mathf.Max(0f, currentFuel - Mathf.Abs(throttleInput) * Time.fixedDeltaTime);
            }

            physicsModel.ApplyAntiRoll(frontLeft, frontRight);
        }

        private void UpdateWheels()
        {
            foreach (var wheel in wheelModules)
            {
                wheel?.UpdateVisual();
            }
        }

        public void ApplyDamage(float amount)
        {
            damageAmount = Mathf.Max(0f, damageAmount + amount);
        }
    }
}
