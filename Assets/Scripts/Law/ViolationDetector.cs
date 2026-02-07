using UnityEngine;

namespace OpenWorldDriving.Law
{
    /// <summary>
    /// Detects traffic violations and reports to the WantedSystem.
    /// </summary>
    public class ViolationDetector : MonoBehaviour
    {
        [SerializeField] private WantedSystem wantedSystem;
        [SerializeField] private float speedLimit = 25f;

        private Rigidbody body;

        private void Awake()
        {
            body = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (body == null || wantedSystem == null)
            {
                return;
            }

            if (body.velocity.magnitude > speedLimit)
            {
                wantedSystem.AddInfraction(1);
            }
        }
    }
}
