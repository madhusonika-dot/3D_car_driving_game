using UnityEngine;

namespace OpenWorldDriving.Missions
{
    /// <summary>
    /// Handles mission accept/decline interactions with NPCs.
    /// </summary>
    public class NPCInteraction : MonoBehaviour
    {
        [SerializeField] private MissionBase mission;
        [SerializeField] private DialogueSystem dialogueSystem;

        public void Interact(bool accept)
        {
            if (!accept)
            {
                return;
            }

            if (mission != null)
            {
                mission.StartMission();
            }
        }

        public string GetDialogueLine()
        {
            return dialogueSystem != null ? dialogueSystem.GetCurrentLine() : string.Empty;
        }
    }
}
