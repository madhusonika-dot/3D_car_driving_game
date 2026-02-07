using UnityEngine;
using OpenWorldDriving.Shared;

namespace OpenWorldDriving.UI
{
    /// <summary>
    /// Coordinates HUD widgets and navigation UI.
    /// </summary>
    public class UIManager : ManagerBase
    {
        [SerializeField] private HUDSystem hudSystem;

        public void SetHudVisible(bool visible)
        {
            if (hudSystem != null)
            {
                hudSystem.gameObject.SetActive(visible);
            }
        }
    }
}
