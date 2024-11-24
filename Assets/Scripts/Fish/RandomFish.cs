using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomFish : MonoBehaviour
{
    public static RandomFish instance;
    public List<Sprite> fishes;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        if(instance != this)
            Destroy(this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<SpriteRenderer>().sprite = fishes[Random.Range(0, fishes.Count)];
        }
    }

    public Sprite GetRandomFish()
    {
        //GetComponent<SpriteRenderer>().sprite = fishes[Random.Range(0, fishes.Count)];
        return fishes[Random.Range(0, fishes.Count)];
    }
}
