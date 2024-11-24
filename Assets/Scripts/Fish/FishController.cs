using System;
using UnityEngine;

public class FishController : MonoBehaviour
{
    [SerializeField]private GameObject fishPrefab;
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        GetComponent<RandomFish>().GetRandomFish();
        _animator.Play("Enter");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Instantiate(fishPrefab, transform.position, Quaternion.identity);
            _animator.Play("Exit");
        }
    }

    public void DestroyFish()
    {
        Destroy(gameObject);
    }
}
