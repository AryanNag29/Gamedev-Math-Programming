using UnityEngine;

public class TurretPlacer : MonoBehaviour
{
    void OnDrawGizmos()
    {
        Ray ray = new Ray(transform.position,transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            
        }
    }
}
