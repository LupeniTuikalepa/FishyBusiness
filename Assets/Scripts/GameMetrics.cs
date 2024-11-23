using UnityEngine;

namespace FishyBusiness
{
    [CreateAssetMenu(fileName = "GameMetrics", menuName = "FishyBusiness/GameMetrics")]
    public class GameMetrics : ScriptableObject
    {
        public static GameMetrics Global => GameController.Metrics;

        [field: SerializeField]
        public int Version { get; private set; }
    }
}