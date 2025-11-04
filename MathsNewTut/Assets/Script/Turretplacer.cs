using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Timeline;

public class Turretplacer : MonoBehaviour
{
    public Transform turret;
    void OnDrawGizmos()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (turret == null) return;
        
        if(Physics.Raycast(ray,out RaycastHit hit))
        {
            turret.transform.position = hit.point;
            turret.rotation = Quaternion.LookRotation(ray.direction);

            Gizmos.color = Color.blue;
            Gizmos.DrawRay(hit.point, hit.normal);
            Gizmos.DrawLine(ray.origin, hit.point);
        }
    }
}
