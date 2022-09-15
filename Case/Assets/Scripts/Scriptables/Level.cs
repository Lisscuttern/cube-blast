using UnityEngine;

namespace PEAK
{
    [CreateAssetMenu(menuName = "Level", fileName = "Level", order = 1)]
    public class Level : ScriptableObject
    {
        [Header("General")]
        public int Id;
        public string Name;
        public LevelComponent Prefab;
        public int GoalNumber;
        public int MoveValue;
    }
}