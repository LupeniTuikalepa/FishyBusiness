using NaughtyAttributes;
using UnityEngine;

namespace FishyBusiness
{
    [CreateAssetMenu(fileName = "GameMetrics", menuName = "FishyBusiness/GameMetrics")]
    public class GameMetrics : ScriptableObject
    {
        public static GameMetrics Global => GameController.Metrics;

        [field: SerializeField]
        public int Version { get; private set; }

        [field: SerializeField] 
        public int StartQuota { get; private set; } 

        [field: SerializeField]
        public float QuotaScaling { get; private set; }
        
        [field: SerializeField]
        public int PlayerLife { get; private set; }

        [field: SerializeField, Scene]
        
        public int MainMenuScene { get; private set; }
        
        [field: SerializeField, Scene]
        
        public int LevelScene { get; private set; }


        [field: SerializeField]
        public int Year { get; private set; } = 2024;
    }
}