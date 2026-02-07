using UnityEngine;

namespace OpenWorldDriving.Cameras
{
    /// <summary>
    /// Cockpit camera rig anchored to an interior transform.
    /// </summary>
    public class CockpitRig : CameraRigBase
    {
        [SerializeField] private Transform cockpitAnchor;
        [SerializeField] private float snapSpeed = 8f;

        public override void SetTarget(Transform newTarget)
        {
            base.SetTarget(newTarget);
            cockpitAnchor = newTarget;
        }

        public override void Tick(float deltaTime)
        {
            if (cockpitAnchor == null)
            {
                return;
            }

            transform.position = Vector3.Lerp(transform.position, cockpitAnchor.position, snapSpeed * deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, cockpitAnchor.rotation, snapSpeed * deltaTime);
        }
    }
}
