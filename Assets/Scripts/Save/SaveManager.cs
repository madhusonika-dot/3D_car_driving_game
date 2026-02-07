using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using OpenWorldDriving.Shared;

namespace OpenWorldDriving.SaveSystem
{
    /// <summary>
    /// Handles profile-based JSON save data with versioning and safe fallbacks.
    /// </summary>
    public class SaveManager : ManagerBase
    {
        private const int CurrentVersion = 1;
        private const string SaveFolderName = "Saves";

        public override void Initialize()
        {
            base.Initialize();
            EnsureSaveFolder();
        }

        public void SaveProfile(SaveProfileData data)
        {
            data.version = CurrentVersion;
            var json = JsonUtility.ToJson(data, true);
            File.WriteAllText(GetProfilePath(data.profileSlot), json);
        }

        public SaveProfileData LoadProfile(int profileSlot)
        {
            var path = GetProfilePath(profileSlot);
            if (!File.Exists(path))
            {
                return CreateDefaultProfile(profileSlot);
            }

            try
            {
                var json = File.ReadAllText(path);
                var data = JsonUtility.FromJson<SaveProfileData>(json);
                if (data == null || data.version != CurrentVersion)
                {
                    return CreateDefaultProfile(profileSlot);
                }

                if (data.settings == null)
                {
                    data.settings = new List<SettingsEntry>();
                }

                return data;
            }
            catch (Exception)
            {
                return CreateDefaultProfile(profileSlot);
            }
        }

        private void EnsureSaveFolder()
        {
            var path = Path.Combine(Application.persistentDataPath, SaveFolderName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private string GetProfilePath(int profileSlot)
        {
            var filename = $"profile_{profileSlot}.json";
            return Path.Combine(Application.persistentDataPath, SaveFolderName, filename);
        }

        private SaveProfileData CreateDefaultProfile(int slot)
        {
            return new SaveProfileData
            {
                profileSlot = slot,
                version = CurrentVersion,
                lastPlayed = DateTime.UtcNow.ToString("o"),
                settings = new List<SettingsEntry>()
            };
        }
    }

    /// <summary>
    /// Serializable save data container.
    /// </summary>
    [Serializable]
    public class SaveProfileData
    {
        public int profileSlot;
        public int version;
        public string lastPlayed;
        public List<SettingsEntry> settings = new List<SettingsEntry>();

        public Dictionary<string, float> GetSettingsDictionary()
        {
            var result = new Dictionary<string, float>();
            if (settings == null)
            {
                return result;
            }

            foreach (var entry in settings)
            {
                if (entry == null || string.IsNullOrEmpty(entry.key))
                {
                    continue;
                }

                result[entry.key] = entry.value;
            }

            return result;
        }

        public void SetSettingsDictionary(Dictionary<string, float> source)
        {
            settings = new List<SettingsEntry>();
            if (source == null)
            {
                return;
            }

            foreach (var pair in source)
            {
                settings.Add(new SettingsEntry
                {
                    key = pair.Key,
                    value = pair.Value
                });
            }
        }
    }

    [Serializable]
    public class SettingsEntry
    {
        public string key;
        public float value;
    }
}
