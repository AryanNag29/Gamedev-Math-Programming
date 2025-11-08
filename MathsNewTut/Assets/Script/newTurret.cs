using Unity.Mathematics;
using UnityEngine;

public class newTurret : MonoBehaviour
{
    public Transform Turret;

    void OnDrawGizmos()
    {
        if (Turret == null) return;

        Ray ray = new Ray(transform.position, transform.forward);

        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            Turret.position = hit.point;
            Vector3 yAxis = hit.normal;
            Gizmos.color = Color.green;
            Gizmos.DrawRay(hit.point, yAxis);
            Vector3 xAxis = Vector3.Cross(yAxis, ray.direction).normalized;
            Gizmos.color = Color.red;
            Gizmos.DrawRay(hit.point, xAxis);
            Vector3 zAxis = Vector3.Cross(yAxis, xAxis);
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(hit.point, zAxis);
            Turret.rotation = quaternion.LookRotation(zAxis, yAxis);
            Gizmos.color = Color.white;
            Gizmos.DrawLine(ray.origin, hit.point);
        }
    }
}
