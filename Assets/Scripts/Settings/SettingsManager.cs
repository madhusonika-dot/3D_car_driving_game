using System.Collections.Generic;
using UnityEngine;
using OpenWorldDriving.Shared;
using OpenWorldDriving.SaveSystem;

namespace OpenWorldDriving.Settings
{
    /// <summary>
    /// Central storage for runtime settings with save integration.
    /// </summary>
    public class SettingsManager : ManagerBase
    {
        [SerializeField] private SaveManager saveManager;
        [SerializeField] private int activeProfileSlot = 0;

        private readonly Dictionary<string, float> settings = new Dictionary<string, float>();

        public override void Initialize()
        {
            base.Initialize();
            LoadSettings();
        }

        public void SetFloat(string key, float value)
        {
            settings[key] = value;
        }

        public float GetFloat(string key, float defaultValue = 0f)
        {
            return settings.TryGetValue(key, out var value) ? value : defaultValue;
        }

        public void SaveSettings()
        {
            if (saveManager == null)
            {
                Debug.LogWarning("SaveManager not assigned.");
                return;
            }

            var data = saveManager.LoadProfile(activeProfileSlot);
            data.SetSettingsDictionary(new Dictionary<string, float>(settings));
            saveManager.SaveProfile(data);
        }

        private void LoadSettings()
        {
            if (saveManager == null)
            {
                Debug.LogWarning("SaveManager not assigned.");
                return;
            }

            var data = saveManager.LoadProfile(activeProfileSlot);
            settings.Clear();
            foreach (var pair in data.GetSettingsDictionary())
            {
                settings[pair.Key] = pair.Value;
            }
        }
    }
}
