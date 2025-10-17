using Unity.Mathematics;
using UnityEngine;

public class TurretPlacer : MonoBehaviour
{
    public Transform turret;
    public Transform turl;
    
    void OnDrawGizmos()
    {
        if (turret == null) return;

        Ray ray = new Ray(transform.position,transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            turret.position = hit.point;
            turret.rotation = quaternion.LookRotation(ray.direction,transform.forward);
        }
    }
}
