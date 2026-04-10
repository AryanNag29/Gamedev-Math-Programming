using System;
using Unity.VisualScripting;
using UnityEngine;

public class DecoupledParent : MonoBehaviour
{
    public static event Action OnPlayerDeath ;

    public void TakeDamage(float damage)
    {
        Die();
    }
    
    void Die()
    {
        //logic
        
        //raise event 
        //"?" ensure it only fires if someone is actually listening 
        OnPlayerDeath?.Invoke();
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
