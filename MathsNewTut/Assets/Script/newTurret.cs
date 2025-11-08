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
            Vector3 xAxis = Vector3.Cross(yAxis, ray.direction).normalized;
            Vector3 zAxis = Vector3.Cross(yAxis, xAxis);

            Turret.rotation = quaternion.LookRotation(zAxis, yAxis);
        }
    }
}
