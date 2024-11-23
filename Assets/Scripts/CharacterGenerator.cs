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
            Debug.Log(fish.ID);
            Debug.Log(fish.Name);
            Debug.Log(fish.IDCard.ExpiryDate);
            Debug.Log(fish.IDCard.Age);
            Debug.Log(fish.IDCard.Country);
            Debug.Log(fish.IDCard.Mafia);
            Debug.Log(fish.IDCard.Rank);
        }
    }
}
