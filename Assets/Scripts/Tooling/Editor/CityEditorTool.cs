#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using OpenWorldDriving.City;

namespace OpenWorldDriving.Tooling
{
    /// <summary>
    /// Editor tool for previewing city generation.
    /// </summary>
    public class CityEditorTool : EditorWindow
    {
        private CityGenerator generator;
        private int seed;

        [MenuItem("OpenWorldDriving/City Preview")]
        public static void Open()
        {
            GetWindow<CityEditorTool>("City Preview");
        }

        private void OnGUI()
        {
            generator = (CityGenerator)EditorGUILayout.ObjectField("Generator", generator, typeof(CityGenerator), true);
            seed = EditorGUILayout.IntField("Seed", seed);

            if (GUILayout.Button("Generate City") && generator != null)
            {
                generator.GenerateCity(seed);
            }
        }
    }
}
#endif
