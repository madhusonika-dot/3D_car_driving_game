using UnityEngine;
using OpenWorldDriving.Shared;

namespace OpenWorldDriving.Economy
{
    /// <summary>
    /// Handles player currency wallet and purchases.
    /// </summary>
    public class EconomyManager : ManagerBase
    {
        [SerializeField] private int currency;

        public bool Spend(int amount)
        {
            if (amount <= 0 || currency < amount)
            {
                return false;
            }

            currency -= amount;
            return true;
        }

        public void Add(int amount)
        {
            currency += Mathf.Max(0, amount);
        }
    }
}
