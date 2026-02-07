using UnityEngine;
using OpenWorldDriving.Shared;

namespace OpenWorldDriving.Weather
{
    /// <summary>
    /// Controls day-night cycle and applies lighting profiles.
    /// </summary>
    public class DayNightSystem : ManagerBase
    {
        [SerializeField] private LightingProfileSO lightingProfile;
        [SerializeField] private Light directionalLight;
        [SerializeField] private float dayLengthMinutes = 30f;
        [SerializeField] private float timeOfDay;

        private void Update()
        {
            if (lightingProfile == null || directionalLight == null)
            {
                return;
            }

            timeOfDay += Time.deltaTime / (dayLengthMinutes * 60f);
            timeOfDay %= 1f;

            var color = lightingProfile.directionalColor.Evaluate(timeOfDay);
            directionalLight.color = color;
            directionalLight.intensity = lightingProfile.intensityCurve.Evaluate(timeOfDay);
            RenderSettings.ambientLight = lightingProfile.ambientColor.Evaluate(timeOfDay);
        }
    }
}
