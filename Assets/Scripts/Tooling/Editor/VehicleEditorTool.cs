#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using OpenWorldDriving.Vehicles;

namespace OpenWorldDriving.Tooling
{
    /// <summary>
    /// Editor tool for previewing vehicle stat configurations.
    /// </summary>
    public class VehicleEditorTool : EditorWindow
    {
        private VehicleStatsSO stats;

        [MenuItem("OpenWorldDriving/Vehicle Stat Editor")]
        public static void Open()
        {
            GetWindow<VehicleEditorTool>("Vehicle Stats");
        }

        private void OnGUI()
        {
            stats = (VehicleStatsSO)EditorGUILayout.ObjectField("Vehicle Stats", stats, typeof(VehicleStatsSO), false);
            if (stats == null)
            {
                EditorGUILayout.HelpBox("Assign a VehicleStatsSO asset to edit.", MessageType.Info);
            }
        }
    }
}
#endif
