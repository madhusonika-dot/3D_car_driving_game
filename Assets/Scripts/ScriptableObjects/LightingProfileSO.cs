using UnityEngine;

namespace OpenWorldDriving.Weather
{
    /// <summary>
    /// Lighting profile for time-of-day settings.
    /// </summary>
    [CreateAssetMenu(menuName = "OpenWorldDriving/Weather/Lighting Profile")]
    public class LightingProfileSO : ScriptableObject
    {
        public Gradient ambientColor;
        public Gradient directionalColor;
        public AnimationCurve intensityCurve = AnimationCurve.Linear(0f, 0.2f, 1f, 1f);
    }
}
