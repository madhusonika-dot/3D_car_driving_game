using UnityEngine;

namespace OpenWorldDriving.Law
{
    /// <summary>
    /// Simple pursuit AI that follows a target using NavMesh-like steering.
    /// </summary>
    public class PoliceAI : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float speed = 20f;
        [SerializeField] private float stoppingDistance = 5f;

        private void Update()
        {
            if (target == null)
            {
                return;
            }

            var distance = Vector3.Distance(transform.position, target.position);
            if (distance <= stoppingDistance)
            {
                return;
            }

            var direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 3f);
        }
    }
}
