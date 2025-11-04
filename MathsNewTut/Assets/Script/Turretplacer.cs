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


            Vector3 yAxis = hit.normal;
            //cross product for the turret
            //Grahm-Schmidt orthonormalization
            Vector3 xAxis = Vector3.Cross(yAxis, ray.direction).normalized;
            Vector3 zAxis = Vector3.Cross(xAxis, yAxis);
            turret.rotation = Quaternion.LookRotation(xAxis,yAxis);
            Gizmos.color = Color.green;
            Gizmos.DrawRay(hit.point, yAxis);
            Gizmos.color = Color.red;
            Gizmos.DrawRay(hit.point, xAxis);
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(hit.point, zAxis);
            Gizmos.color = Color.white;
            Gizmos.DrawLine(ray.origin, hit.point);
        }
    }
}
