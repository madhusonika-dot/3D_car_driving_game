using UnityEngine;
using OpenWorldDriving.Shared;

namespace OpenWorldDriving.Economy
{
    /// <summary>
    /// Tracks XP, driver rank, and progression.
    /// </summary>
    public class ProgressionManager : ManagerBase
    {
        [SerializeField] private int xp;
        [SerializeField] private int level = 1;
        [SerializeField] private int xpPerLevel = 100;

        public void AddXp(int amount)
        {
            xp += Mathf.Max(0, amount);
            while (xp >= xpPerLevel)
            {
                xp -= xpPerLevel;
                level++;
            }
        }
    }
}
