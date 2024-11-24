using FishyBusiness;
using FishyBusiness.Data;
using FishyBusiness.Helpers;
using UnityEngine;

public class CharacterGenerator : MonoBehaviour
{
    FishGenerator fishGenerator;

    void Start()
    {
        fishGenerator = new FishGenerator();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fish fish = fishGenerator.GenerateFish();
            GameController.Logger.Log(fish.ToString());
        }
    }
}