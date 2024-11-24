using NaughtyAttributes;
using UnityEngine;

namespace FishyBusiness
{
    [CreateAssetMenu(fileName = "GameMetrics", menuName = "FishyBusiness/GameMetrics")]
    public class GameMetrics : ScriptableObject
    {
        public static GameMetrics Global => GameController.Metrics;


        [field: SerializeField, BoxGroup("Levels")]
        public int StartQuota { get; private set; }

        [field: SerializeField, BoxGroup("Levels")]
        public float QuotaScaling { get; private set; }

        [field: SerializeField, BoxGroup("Levels")]
        public int PlayerLife { get; private set; }

        [field: SerializeField, BoxGroup("Levels")]
        public float LevelTime { get; private set; } = 45f;

        [field: SerializeField, BoxGroup("Levels")]
        public int VIPsCount { get; private set; } = 6;

        [field: SerializeField, BoxGroup("Levels"), Range(0, 50)]
        public int SellPrice { get; private set; }

        [field: SerializeField, BoxGroup("Levels/Probabilities"), Range(0, 1)]
        public float LyingFishProbability { get; private set; } = .3f;

        [field: SerializeField, BoxGroup("Levels/Probabilities"), Range(0, 1)]
        public float VIPFishProbability { get; private set; } = .3f;


        [field: SerializeField, Scene, BoxGroup("Scenes")]
        public int MainMenuScene { get; private set; }

        [field: SerializeField, Scene, BoxGroup("Scenes")]

        public int LevelScene { get; private set; }


        [field: SerializeField, BoxGroup("Fish Generation")]
        public int Year { get; private set; } = 2024;
        [field: SerializeField, BoxGroup("Fish Generation")]
        public int MaxFishAge { get; private set; } = 75;
        [field: SerializeField, BoxGroup("Fish Generation")]
        public Vector2Int ExpirationDateRange { get; private set; } = new Vector2Int(2015, 2030);

    }
}