using UnityEngine;

namespace OpenWorldDriving.Multiplayer
{
    /// <summary>
    /// Network-ready vehicle wrapper with client prediction hooks.
    /// </summary>
    public class NetworkVehicle : MonoBehaviour
    {
#if UNITY_NETCODE
        // Inherit NetworkBehaviour when Netcode is installed.
#endif
        [SerializeField] private bool isServerAuthoritative = true;

        public void ApplyNetworkState(Vector3 position, Quaternion rotation)
        {
            transform.SetPositionAndRotation(position, rotation);
        }
    }
}
