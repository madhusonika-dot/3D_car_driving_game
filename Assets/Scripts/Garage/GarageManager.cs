using UnityEngine;
using OpenWorldDriving.Shared;

namespace OpenWorldDriving.Garage
{
    /// <summary>
    /// Manages the garage flow and vehicle library.
    /// </summary>
    public class GarageManager : ManagerBase
    {
        [SerializeField] private CustomizationSystem customizationSystem;

        public void EnterGarage(GameObject vehicle)
        {
            customizationSystem?.SetActiveVehicle(vehicle);
        }
    }
}
