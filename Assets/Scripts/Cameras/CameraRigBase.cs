using UnityEngine;

namespace OpenWorldDriving.Cameras
{
    /// <summary>
    /// Base class for camera rigs to support blending and mode switching.
    /// </summary>
    public abstract class CameraRigBase : MonoBehaviour
    {
        [SerializeField] protected Transform target;
        [SerializeField] protected float blendDuration = 0.5f;

        public virtual void SetTarget(Transform newTarget)
        {
            target = newTarget;
        }

        public abstract void Tick(float deltaTime);
    }
}
