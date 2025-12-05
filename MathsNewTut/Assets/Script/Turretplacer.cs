using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Timeline;

public class Turretplacer : MonoBehaviour
{
    #region PublicReferences
    public Transform turret;
    #endregion

    #region Functions

    public void UpdateMouse()
    {
        float xMouse = Input.GetAxis("Mouse X");//to get the mouse x input
        float yMouse = Input.GetAxis("Mouse Y");//to get the mouse y input
        Debug.Log($"x: {xMouse}, y: {yMouse}");
    }

    public void TurretPlacer()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            turret.position = hit.point;

            Vector3 yAxis = hit.normal;
            //cross product for the turret
            //Gram-Schmidt orthonormalization
            Vector3 xAxis = Vector3.Cross(yAxis, ray.direction).normalized; //bitangent 
            Vector3 zAxis = Vector3.Cross(xAxis, yAxis); //tangents
            turret.rotation = Quaternion.LookRotation(zAxis, yAxis);
            Debug.DrawLine(ray.origin, hit.point);
            // Gizmos.color = Color.white;
            // Gizmos.DrawLine(ray.origin, hit.point);
        }
    }

    #endregion

    #region Gizmos

    private void Update()
    {
        TurretPlacer();
        UpdateMouse();
    }
    #endregion
}
