using UnityEngine;

namespace OpenWorldDriving.Garage
{
    /// <summary>
    /// Upgrade configuration for garage customization.
    /// </summary>
    [CreateAssetMenu(menuName = "OpenWorldDriving/Garage/Upgrade Data")]
    public class UpgradeDataSO : ScriptableObject
    {
        public string upgradeName;
        public float torqueBonus;
        public float brakeBonus;
        public float suspensionBonus;
        public int price;
    }
}
