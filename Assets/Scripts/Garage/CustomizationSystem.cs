using UnityEngine;

namespace OpenWorldDriving.Garage
{
    /// <summary>
    /// Applies paint, decals, and visual swaps to the active vehicle.
    /// </summary>
    public class CustomizationSystem : MonoBehaviour
    {
        [SerializeField] private Renderer[] paintRenderers;
        private GameObject activeVehicle;

        public void SetActiveVehicle(GameObject vehicle)
        {
            activeVehicle = vehicle;
        }

        public void ApplyPaint(Color color)
        {
            foreach (var renderer in paintRenderers)
            {
                if (renderer != null)
                {
                    renderer.material.color = color;
                }
            }
        }
    }
}
