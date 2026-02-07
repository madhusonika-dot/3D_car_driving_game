using System.Collections.Generic;
using UnityEngine;

namespace OpenWorldDriving.Cameras
{
    /// <summary>
    /// Stores transform snapshots for replay camera playback.
    /// </summary>
    public class ReplayRecorder : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float recordInterval = 0.1f;
        [SerializeField] private int maxFrames = 600;

        private readonly Queue<Snapshot> snapshots = new Queue<Snapshot>();
        private float timer;

        private void Update()
        {
            if (target == null)
            {
                return;
            }

            timer += Time.deltaTime;
            if (timer >= recordInterval)
            {
                timer = 0f;
                RecordSnapshot();
            }
        }

        public Snapshot[] GetSnapshots()
        {
            return snapshots.ToArray();
        }

        private void RecordSnapshot()
        {
            snapshots.Enqueue(new Snapshot(target.position, target.rotation));
            while (snapshots.Count > maxFrames)
            {
                snapshots.Dequeue();
            }
        }

        public readonly struct Snapshot
        {
            public readonly Vector3 Position;
            public readonly Quaternion Rotation;

            public Snapshot(Vector3 position, Quaternion rotation)
            {
                Position = position;
                Rotation = rotation;
            }
        }
    }
}
