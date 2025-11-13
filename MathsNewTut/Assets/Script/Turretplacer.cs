using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Timeline;

public class Turretplacer : MonoBehaviour
{
    #region PublicReferences
    public Transform turret;
    #endregion

    #region Gizmos
    void OnDrawGizmos()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (turret == null) return;

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            turret.position = hit.point;

            Vector3 yAxis = hit.normal;
            //cross product for the turret
            //Gram-Schmidt orthonormalization
            Vector3 xAxis = Vector3.Cross(yAxis, ray.direction).normalized; //bitangent 
            Vector3 zAxis = Vector3.Cross(xAxis, yAxis); //tangents
            turret.rotation = Quaternion.LookRotation(zAxis, yAxis);
            Gizmos.color = Color.white;
            Gizmos.DrawLine(ray.origin, hit.point);
        }
    }
    #endregion
}
