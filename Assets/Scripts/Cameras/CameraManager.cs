using System.Collections.Generic;
using UnityEngine;
using OpenWorldDriving.InputSystem;
using OpenWorldDriving.Shared;

namespace OpenWorldDriving.Cameras
{
    /// <summary>
    /// Manages camera rigs, blending, and input-driven mode switching.
    /// </summary>
    public class CameraManager : ManagerBase
    {
        [SerializeField] private CameraRigBase[] rigs;
        [SerializeField] private int defaultRigIndex = 0;
        [SerializeField] private Transform target;

        private CameraRigBase activeRig;
        private readonly Dictionary<string, int> actionToRigIndex = new Dictionary<string, int>();

        public override void Initialize()
        {
            base.Initialize();
            MapActions();
            SetActiveRig(defaultRigIndex);
            GameEventBus.Subscribe<InputActionEvent>(OnInputAction);
        }

        private void OnDestroy()
        {
            GameEventBus.Unsubscribe<InputActionEvent>(OnInputAction);
        }

        private void Update()
        {
            activeRig?.Tick(Time.deltaTime);
        }

        public void SetTarget(Transform newTarget)
        {
            target = newTarget;
            foreach (var rig in rigs)
            {
                rig?.SetTarget(newTarget);
            }
        }

        private void OnInputAction(InputActionEvent evt)
        {
            if (actionToRigIndex.TryGetValue(evt.ActionName, out var rigIndex))
            {
                SetActiveRig(rigIndex);
            }
        }

        private void SetActiveRig(int rigIndex)
        {
            if (rigs == null || rigs.Length == 0)
            {
                return;
            }

            rigIndex = Mathf.Clamp(rigIndex, 0, rigs.Length - 1);
            activeRig = rigs[rigIndex];
            activeRig?.SetTarget(target);
        }

        private void MapActions()
        {
            actionToRigIndex.Clear();
            actionToRigIndex["CameraThirdPerson"] = 0;
            actionToRigIndex["CameraCockpit"] = 1;
            actionToRigIndex["CameraHood"] = 2;
            actionToRigIndex["CameraCinematic"] = 3;
            actionToRigIndex["CameraReplay"] = 4;
            actionToRigIndex["CameraPhoto"] = 5;
        }
    }
}
