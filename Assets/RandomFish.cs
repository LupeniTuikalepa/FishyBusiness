using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomFish : MonoBehaviour
{
    public List<Sprite> fishes;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<SpriteRenderer>().sprite = fishes[Random.Range(0, fishes.Count)];
        }
    }
}
