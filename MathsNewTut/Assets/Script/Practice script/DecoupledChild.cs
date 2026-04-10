using System;
using UnityEngine;

public class DecoupledChild : MonoBehaviour
{
    void DisplayGameOver()
    {
        Debug.Log("Displaying Game Over UI via Event!");
    }

    private void OnEnable()
    {
        DecoupledParent.OnPlayerDeath += DisplayGameOver;
    }

    private void OnDisable()
    {
        DecoupledParent.OnPlayerDeath -= DisplayGameOver;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}