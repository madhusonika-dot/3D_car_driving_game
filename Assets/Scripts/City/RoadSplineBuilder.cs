using System.Collections.Generic;
using UnityEngine;

namespace OpenWorldDriving.City
{
    /// <summary>
    /// Builds a spline-based road network for procedural roads and highways.
    /// </summary>
    public class RoadSplineBuilder : MonoBehaviour
    {
        [SerializeField] private List<Transform> controlPoints = new List<Transform>();

        public void BuildRoadNetwork()
        {
            // Placeholder for spline generation and intersection creation.
        }

        public IReadOnlyList<Transform> GetControlPoints()
        {
            return controlPoints;
        }
    }
}
