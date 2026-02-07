using UnityEngine;
using OpenWorldDriving.Shared;

namespace OpenWorldDriving.Audio
{
    /// <summary>
    /// Central audio bus for music, SFX, and ambience.
    /// </summary>
    public class AudioManager : ManagerBase
    {
        [SerializeField] private AudioSource musicSource;

        public void SetMusicVolume(float volume)
        {
            if (musicSource != null)
            {
                musicSource.volume = volume;
            }
        }
    }
}
