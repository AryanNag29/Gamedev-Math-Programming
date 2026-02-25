using UnityEngine;

public class RotationTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.rotation = Quaternion.Euler(90f, 90f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
