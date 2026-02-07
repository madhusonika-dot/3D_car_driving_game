using System.Collections.Generic;
using UnityEngine;
using OpenWorldDriving.Shared;

namespace OpenWorldDriving.Law
{
    /// <summary>
    /// Spawns and manages police units for pursuit.
    /// </summary>
    public class PoliceManager : ManagerBase
    {
        [SerializeField] private GameObject policePrefab;
        [SerializeField] private List<PoliceAI> activeUnits = new List<PoliceAI>();

        public override void Initialize()
        {
            base.Initialize();
            GameEventBus.Subscribe<WantedLevelChangedEvent>(OnWantedLevelChanged);
        }

        private void OnDestroy()
        {
            GameEventBus.Unsubscribe<WantedLevelChangedEvent>(OnWantedLevelChanged);
        }

        private void OnWantedLevelChanged(WantedLevelChangedEvent evt)
        {
            if (evt.WantedLevel > 0)
            {
                DispatchUnit();
            }
        }

        private void DispatchUnit()
        {
            if (policePrefab == null)
            {
                return;
            }

            var instance = Instantiate(policePrefab, Vector3.zero, Quaternion.identity);
            var unit = instance.GetComponent<PoliceAI>();
            if (unit != null)
            {
                activeUnits.Add(unit);
            }
        }
    }
}
