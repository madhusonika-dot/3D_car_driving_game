using UnityEngine;

namespace OpenWorldDriving.UI
{
    /// <summary>
    /// Controls minimap camera and icons.
    /// </summary>
    public class MinimapSystem : MonoBehaviour
    {
        [SerializeField] private Camera minimapCamera;
        [SerializeField] private Transform target;
        [SerializeField] private float height = 50f;

        private void LateUpdate()
        {
            if (minimapCamera == null || target == null)
            {
                return;
            }

            var position = target.position;
            minimapCamera.transform.position = new Vector3(position.x, position.y + height, position.z);
            minimapCamera.transform.rotation = Quaternion.Euler(90f, target.eulerAngles.y, 0f);
        }
    }
}
