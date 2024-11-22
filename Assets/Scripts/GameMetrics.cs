using FishyBusiness.Core;
using UnityEngine;

namespace FishyBusiness.Core
{
    [CreateAssetMenu(fileName = "GameMetrics", menuName = "FishyBusiness/GameMetrics")]
    public class GameMetrics : ScriptableObject
    {
        public static GameMetrics Global => GameController.Metrics;

        [field: SerializeField]
        public int Version { get; private set; }
    }
}