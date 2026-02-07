using System.Collections.Generic;
using UnityEngine;
using OpenWorldDriving.Shared;

namespace OpenWorldDriving.InputSystem
{
    /// <summary>
    /// Handles keyboard input, rebinding, and camera toggle events.
    /// </summary>
    public class InputManager : ManagerBase
    {
        [Header("Bindings")]
        [SerializeField] private InputBindingsSO bindings;

        [Header("Camera Toggle Actions")]
        [SerializeField] private string[] cameraToggleActions =
        {
            "CameraThirdPerson",
            "CameraCockpit",
            "CameraHood",
            "CameraCinematic",
            "CameraReplay",
            "CameraPhoto"
        };

        private readonly Dictionary<string, KeyCode> runtimeBindings = new Dictionary<string, KeyCode>();

        public override void Initialize()
        {
            base.Initialize();
            CacheBindings();
        }

        private void Update()
        {
            foreach (var pair in runtimeBindings)
            {
                if (Input.GetKeyDown(pair.Value))
                {
                    GameEventBus.Publish(new InputActionEvent(pair.Key));
                }
            }
        }

        /// <summary>
        /// Rebinds a named action at runtime.
        /// </summary>
        public void RebindAction(string actionName, KeyCode newKey)
        {
            runtimeBindings[actionName] = newKey;
            if (bindings != null)
            {
                bindings.SetKey(actionName, newKey);
            }
        }

        /// <summary>
        /// Returns all camera toggle actions for UI setup.
        /// </summary>
        public IReadOnlyList<string> GetCameraToggleActions()
        {
            return cameraToggleActions;
        }

        private void CacheBindings()
        {
            runtimeBindings.Clear();
            if (bindings == null)
            {
                return;
            }

            foreach (var binding in bindings.bindings)
            {
                runtimeBindings[binding.actionName] = binding.key;
            }
        }
    }

    /// <summary>
    /// Event payload for input actions.
    /// </summary>
    public readonly struct InputActionEvent
    {
        public readonly string ActionName;

        public InputActionEvent(string actionName)
        {
            ActionName = actionName;
        }
    }
}
