using UnityEngine;

namespace OpenWorldDriving.Vehicles
{
    /// <summary>
    /// Calculates gear ratios, RPM, and drivetrain mode.
    /// </summary>
    public class DrivetrainModule : MonoBehaviour
    {
        public enum DriveMode
        {
            FrontWheelDrive,
            RearWheelDrive,
            AllWheelDrive
        }

        [SerializeField] private DriveMode driveMode = DriveMode.RearWheelDrive;
        [SerializeField] private float[] gearRatios = { 2.8f, 1.9f, 1.4f, 1.1f, 0.9f };
        [SerializeField] private float finalDriveRatio = 3.2f;
        [SerializeField] private int currentGear = 1;

        public DriveMode CurrentDriveMode => driveMode;
        public int CurrentGear => currentGear;

        public void ShiftUp()
        {
            currentGear = Mathf.Clamp(currentGear + 1, 1, gearRatios.Length);
        }

        public void ShiftDown()
        {
            currentGear = Mathf.Clamp(currentGear - 1, 1, gearRatios.Length);
        }

        public float GetCurrentRatio()
        {
            var gearIndex = Mathf.Clamp(currentGear - 1, 0, gearRatios.Length - 1);
            return gearRatios[gearIndex] * finalDriveRatio;
        }

        public float CalculateRPM(float wheelRPM)
        {
            return Mathf.Abs(wheelRPM) * GetCurrentRatio();
        }
    }
}
