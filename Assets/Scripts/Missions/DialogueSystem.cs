using System.Collections.Generic;
using UnityEngine;

namespace OpenWorldDriving.Missions
{
    /// <summary>
    /// Simple dialogue tree system for mission givers.
    /// </summary>
    public class DialogueSystem : MonoBehaviour
    {
        [SerializeField] private List<string> lines = new List<string>();
        private int currentIndex;

        public string GetCurrentLine()
        {
            if (lines.Count == 0)
            {
                return string.Empty;
            }

            return lines[Mathf.Clamp(currentIndex, 0, lines.Count - 1)];
        }

        public void NextLine()
        {
            currentIndex = Mathf.Clamp(currentIndex + 1, 0, lines.Count - 1);
        }
    }
}
