using System;
using FishyBusiness.DaySystem;
using UnityEngine;

namespace FishyBusiness.Fishes
{
    public class FishController : MonoBehaviour, ILogSource
    {
        public string Name => nameof(FishController);
        [SerializeField]
        private FishRenderer fishPrefab;

        [SerializeField]
        private Transform exit, entrance, idle;

        private FishRenderer currentFish;

        private void OnEnable()
        {
            LevelManager.Instance.OnDayBegun += SyncWithCurrentDay;
            LevelManager.Instance.OnDayEnded += UnSyncWithCurrentDay;
            LevelManager.Instance.OnSuccess += PlaySuccessAnim;
            LevelManager.Instance.OnFailure += PlayFailureAnim;
        }


        private void OnDisable()
        {
            LevelManager.Instance.OnDayBegun -= SyncWithCurrentDay;
            LevelManager.Instance.OnDayEnded -= UnSyncWithCurrentDay;
            LevelManager.Instance.OnSuccess -= PlaySuccessAnim;
            LevelManager.Instance.OnFailure -= PlayFailureAnim;
        }

        private void SyncWithCurrentDay(Day day)
        {
            day.OnNewFish += SpawnNewFish;
        }

        private void UnSyncWithCurrentDay(Day day)
        {
            day.OnNewFish -= SpawnNewFish;
        }
        private void SpawnNewFish(IDayFish idayFish)
        {
            GameController.Logger.Log(this, "Spawning new fish");
            if (idayFish is DayFish dayFish)
            {
                FishRenderer fish = Instantiate(fishPrefab, entrance.position, Quaternion.identity);

                fish.Bind(dayFish.fish);

                if(currentFish)
                    currentFish.MoveTo(exit);

                fish.MoveTo(idle);
                currentFish = fish;
            }
        }

        private void PlaySuccessAnim(IDayFish dayFish, Day day)
        {
            if (currentFish)
                currentFish.ReactPositively();
        }

        private void PlayFailureAnim(IDayFish dayFish, Day day)
        {
            if (currentFish)
                currentFish.ReactNegatively();
        }

    }
}