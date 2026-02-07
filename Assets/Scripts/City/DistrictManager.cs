using System.Collections.Generic;
using UnityEngine;

namespace OpenWorldDriving.City
{
    /// <summary>
    /// Manages district metadata and density configurations.
    /// </summary>
    public class DistrictManager : MonoBehaviour
    {
        [SerializeField] private List<CityDistrict> districts = new List<CityDistrict>();

        public void BuildDistricts()
        {
            foreach (var district in districts)
            {
                district.Initialize();
            }
        }

        public IReadOnlyList<CityDistrict> GetDistricts()
        {
            return districts;
        }
    }

    [System.Serializable]
    public class CityDistrict
    {
        public string name;
        public Vector3 center;
        public float radius = 500f;
        public float trafficDensity = 0.6f;

        public void Initialize()
        {
            // Placeholder for district-specific setup.
        }
    }
}
