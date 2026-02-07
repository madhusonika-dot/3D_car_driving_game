using UnityEngine;

namespace OpenWorldDriving.Multiplayer
{
    /// <summary>
    /// Handles lobby flow, matchmaking, and room codes.
    /// </summary>
    public class LobbyManager : MonoBehaviour
    {
        [SerializeField] private string roomCode;

        public void CreateLobby(string code)
        {
            roomCode = code;
        }

        public string GetRoomCode()
        {
            return roomCode;
        }
    }
}
