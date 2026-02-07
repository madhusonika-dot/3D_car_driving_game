using UnityEngine;

namespace OpenWorldDriving.Shared
{
    /// <summary>
    /// Base class for managers that need a consistent lifecycle.
    /// </summary>
    public abstract class ManagerBase : MonoBehaviour
    {
        /// <summary>
        /// Called by BootstrapManager in initialization order.
        /// </summary>
        public virtual void Initialize() { }

        /// <summary>
        /// Called by BootstrapManager after all managers initialize.
        /// </summary>
        public virtual void PostInitialize() { }
    }
}
