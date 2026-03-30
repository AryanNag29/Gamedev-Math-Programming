using Unity.Mathematics;
using UnityEngine;

public class DiscRotation : MonoBehaviour
{
    #region Variables

    private float rotationSpeed = 10f;

    #endregion

    #region Functions

    public void DiscRotationSpeed()
    {
        quaternion currentRotation = transform.rotation;
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0f);
    }

    #endregion
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DiscRotationSpeed();
    }
}
