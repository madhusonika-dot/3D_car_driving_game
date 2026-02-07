using UnityEngine;
using OpenWorldDriving.Shared;

namespace OpenWorldDriving.Multiplayer
{
    /// <summary>
    /// Entry point for Netcode-driven multiplayer sessions.
    /// </summary>
    public class MultiplayerManager : ManagerBase
    {
        [SerializeField] private bool autoStartHost;

        public override void Initialize()
        {
            base.Initialize();
#if UNITY_NETCODE
            // Netcode initialization would go here.
#endif
        }

        public void StartHostSession()
        {
#if UNITY_NETCODE
            // Start host session.
#endif
        }
    }
}
