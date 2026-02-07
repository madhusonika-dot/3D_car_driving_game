using System.Collections.Generic;
using UnityEngine;
using OpenWorldDriving.Vehicles;

namespace OpenWorldDriving.Garage
{
    /// <summary>
    /// Applies upgrades and calculates stat deltas.
    /// </summary>
    public class UpgradeSystem : MonoBehaviour
    {
        [SerializeField] private List<UpgradeDataSO> upgrades = new List<UpgradeDataSO>();
        [SerializeField] private VehicleStatsSO activeStats;

        public void ApplyUpgrade(UpgradeDataSO upgrade)
        {
            if (upgrade == null || activeStats == null)
            {
                return;
            }

            activeStats.maxTorque += upgrade.torqueBonus;
            activeStats.brakeTorque += upgrade.brakeBonus;
        }

        public IReadOnlyList<UpgradeDataSO> GetAvailableUpgrades()
        {
            return upgrades;
        }
    }
}
