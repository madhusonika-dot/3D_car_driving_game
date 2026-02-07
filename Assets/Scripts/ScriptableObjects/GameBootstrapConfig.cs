using System.Collections.Generic;
using UnityEngine;

namespace OpenWorldDriving.Core
{
    /// <summary>
    /// Controls bootstrap ordering and startup scene loading.
    /// </summary>
    [CreateAssetMenu(menuName = "OpenWorldDriving/Core/Bootstrap Config")]
    public class GameBootstrapConfig : ScriptableObject
    {
        [Tooltip("Scene name to load after boot completes.")]
        public string startupSceneName = "VehicleTest";

        [Tooltip("Ordered list of manager component types.")]
        public List<string> managerTypeNames = new List<string>();
    }
}
