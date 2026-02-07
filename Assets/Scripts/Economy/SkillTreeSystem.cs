using UnityEngine;

namespace OpenWorldDriving.Economy
{
    /// <summary>
    /// Simple skill tree toggle system.
    /// </summary>
    public class SkillTreeSystem : MonoBehaviour
    {
        [SerializeField] private int availablePoints;

        public bool SpendPoint()
        {
            if (availablePoints <= 0)
            {
                return false;
            }

            availablePoints--;
            return true;
        }
    }
}
