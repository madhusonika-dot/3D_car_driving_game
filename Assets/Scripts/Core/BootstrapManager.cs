using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using OpenWorldDriving.Shared;

namespace OpenWorldDriving.Core
{
    /// <summary>
    /// Creates a persistent root and initializes all managers in order.
    /// </summary>
    public class BootstrapManager : MonoBehaviour
    {
        [Header("Bootstrap Config")]
        [SerializeField] private GameBootstrapConfig bootstrapConfig;
        [SerializeField] private Transform managerRoot;

        private readonly List<ManagerBase> managers = new List<ManagerBase>();

        private void Awake()
        {
            if (managerRoot == null)
            {
                var root = new GameObject("PersistentManagers");
                managerRoot = root.transform;
                DontDestroyOnLoad(root);
            }
            else
            {
                DontDestroyOnLoad(managerRoot.gameObject);
            }

            InitializeManagers();
        }

        private void Start()
        {
            foreach (var manager in managers)
            {
                manager.PostInitialize();
            }

            if (bootstrapConfig != null && !string.IsNullOrWhiteSpace(bootstrapConfig.startupSceneName))
            {
                SceneManager.LoadSceneAsync(bootstrapConfig.startupSceneName, LoadSceneMode.Single);
            }
        }

        private void InitializeManagers()
        {
            if (bootstrapConfig == null)
            {
                Debug.LogWarning("BootstrapConfig missing. Managers will not be auto-created.");
                return;
            }

            foreach (var typeName in bootstrapConfig.managerTypeNames)
            {
                var type = Type.GetType(typeName);
                if (type == null)
                {
                    Debug.LogWarning($"Manager type not found: {typeName}");
                    continue;
                }

                var component = managerRoot.gameObject.AddComponent(type) as ManagerBase;
                if (component == null)
                {
                    Debug.LogWarning($"Type {typeName} is not a ManagerBase.");
                    continue;
                }

                managers.Add(component);
                component.Initialize();
            }
        }
    }
}
