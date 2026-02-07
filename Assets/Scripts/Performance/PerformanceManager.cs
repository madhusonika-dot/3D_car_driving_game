using UnityEngine;
using OpenWorldDriving.Shared;

namespace OpenWorldDriving.Performance
{
    /// <summary>
    /// Central performance tuning for quality and physics timesteps.
    /// </summary>
    public class PerformanceManager : ManagerBase
    {
        [SerializeField] private int targetFrameRate = 60;
        [SerializeField] private float physicsStep = 0.02f;

        public override void Initialize()
        {
            base.Initialize();
            Application.targetFrameRate = targetFrameRate;
            Time.fixedDeltaTime = physicsStep;
        }
    }
}
