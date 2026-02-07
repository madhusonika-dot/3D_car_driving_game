using UnityEngine;

namespace OpenWorldDriving.Cameras
{
    /// <summary>
    /// Third-person follow camera rig with dynamic FOV and collision avoidance hooks.
    /// </summary>
    public class FollowRig : CameraRigBase
    {
        [SerializeField] private Vector3 offset = new Vector3(0f, 3f, -6f);
        [SerializeField] private float followSpeed = 6f;
        [SerializeField] private Camera rigCamera;
        [SerializeField] private float baseFov = 60f;
        [SerializeField] private float speedFovBonus = 15f;

        public override void Tick(float deltaTime)
        {
            if (target == null)
            {
                return;
            }

            var desiredPosition = target.TransformPoint(offset);
            transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, followSpeed * deltaTime);

            if (rigCamera != null)
            {
                var speed = target.GetComponent<Rigidbody>()?.velocity.magnitude ?? 0f;
                rigCamera.fieldOfView = Mathf.Lerp(rigCamera.fieldOfView, baseFov + speed * 0.2f, deltaTime * 2f);
            }
        }
    }
}
