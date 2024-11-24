using FishyBusiness;
using FishyBusiness.Data;
using FishyBusiness.Helpers;
using UnityEngine;

public class CharacterGenerator : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FishyBusiness.Data.Fish fish = FishGeneration.GenerateFish();
            GameController.Logger.Log(fish.ToString());
        }
    }
}