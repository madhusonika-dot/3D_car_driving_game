using UnityEngine;

namespace OpenWorldDriving.Audio
{
    /// <summary>
    /// Triggers ambient audio zones across the city.
    /// </summary>
    public class AmbientZoneSystem : MonoBehaviour
    {
        [SerializeField] private AudioSource ambientSource;
        [SerializeField] private AudioClip[] zoneClips;

        public void PlayZoneClip(int index)
        {
            if (ambientSource == null || zoneClips == null || zoneClips.Length == 0)
            {
                return;
            }

            var clipIndex = Mathf.Clamp(index, 0, zoneClips.Length - 1);
            ambientSource.clip = zoneClips[clipIndex];
            ambientSource.Play();
        }
    }
}
