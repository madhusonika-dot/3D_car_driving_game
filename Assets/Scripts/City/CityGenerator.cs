using UnityEngine;

namespace OpenWorldDriving.City
{
    /// <summary>
    /// Entry point for procedural city generation.
    /// </summary>
    public class CityGenerator : MonoBehaviour
    {
        [SerializeField] private DistrictManager districtManager;
        [SerializeField] private RoadSplineBuilder roadBuilder;
        [SerializeField] private BuildingSpawner buildingSpawner;

        public void GenerateCity(int seed)
        {
            Random.InitState(seed);
            districtManager?.BuildDistricts();
            roadBuilder?.BuildRoadNetwork();
            buildingSpawner?.SpawnBuildings();
        }
    }
}
