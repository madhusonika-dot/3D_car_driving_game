using UnityEngine;
using OpenWorldDriving.Shared;

namespace OpenWorldDriving.Weather
{
    /// <summary>
    /// Toggles weather states and notifies dependent systems.
    /// </summary>
    public class WeatherManager : ManagerBase
    {
        public enum WeatherState { Clear, Rain, Fog }

        [SerializeField] private WeatherState currentState = WeatherState.Clear;

        public void SetWeather(WeatherState newState)
        {
            currentState = newState;
            GameEventBus.Publish(new WeatherChangedEvent(newState));
        }
    }

    public readonly struct WeatherChangedEvent
    {
        public readonly WeatherManager.WeatherState State;

        public WeatherChangedEvent(WeatherManager.WeatherState state)
        {
            State = state;
        }
    }
}
