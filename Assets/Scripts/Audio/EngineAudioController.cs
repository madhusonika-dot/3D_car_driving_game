using UnityEngine;

namespace OpenWorldDriving.Audio
{
    /// <summary>
    /// Drives layered engine audio based on RPM.
    /// </summary>
    public class EngineAudioController : MonoBehaviour
    {
        [SerializeField] private AudioSource engineSource;
        [SerializeField] private float maxPitch = 2f;

        public void UpdateRpm(float rpm, float maxRpm)
        {
            if (engineSource == null || maxRpm <= 0f)
            {
                return;
            }

            var normalized = Mathf.Clamp01(rpm / maxRpm);
            engineSource.pitch = Mathf.Lerp(1f, maxPitch, normalized);
        }
    }
}
