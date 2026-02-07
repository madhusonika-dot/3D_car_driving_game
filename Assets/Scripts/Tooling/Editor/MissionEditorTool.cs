#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using OpenWorldDriving.Missions;

namespace OpenWorldDriving.Tooling
{
    /// <summary>
    /// Editor tool for creating and editing mission graphs.
    /// </summary>
    public class MissionEditorTool : EditorWindow
    {
        private MissionGraph graph;

        [MenuItem("OpenWorldDriving/Mission Graph Editor")]
        public static void Open()
        {
            GetWindow<MissionEditorTool>("Mission Graph");
        }

        private void OnGUI()
        {
            graph = (MissionGraph)EditorGUILayout.ObjectField("Mission Graph", graph, typeof(MissionGraph), false);
            if (graph == null)
            {
                EditorGUILayout.HelpBox("Assign a MissionGraph asset to edit.", MessageType.Info);
            }
        }
    }
}
#endif
