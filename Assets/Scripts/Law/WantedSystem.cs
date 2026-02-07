using UnityEngine;
using OpenWorldDriving.Shared;

namespace OpenWorldDriving.Law
{
    /// <summary>
    /// Tracks wanted level and dispatch triggers.
    /// </summary>
    public class WantedSystem : ManagerBase
    {
        [SerializeField] private int wantedLevel;
        [SerializeField] private int maxWantedLevel = 5;

        public void AddInfraction(int amount)
        {
            wantedLevel = Mathf.Clamp(wantedLevel + amount, 0, maxWantedLevel);
            GameEventBus.Publish(new WantedLevelChangedEvent(wantedLevel));
        }

        public void ClearWanted()
        {
            wantedLevel = 0;
            GameEventBus.Publish(new WantedLevelChangedEvent(wantedLevel));
        }
    }

    public readonly struct WantedLevelChangedEvent
    {
        public readonly int WantedLevel;

        public WantedLevelChangedEvent(int level)
        {
            WantedLevel = level;
        }
    }
}
