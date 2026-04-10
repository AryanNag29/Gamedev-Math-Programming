using UnityEngine;

public class CoupledParent : MonoBehaviour
{
    public CoupledChild coupledChild;
    public void takeDamage(float damage)
    {
        //logic 
        die();
    }

    void die()
    {
        //logic 
        
        coupledChild.childManager();
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coupledChild = GetComponent<CoupledChild>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
