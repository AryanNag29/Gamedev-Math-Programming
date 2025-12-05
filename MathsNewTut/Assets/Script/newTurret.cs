using System;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class newTurret : MonoBehaviour
{
    #region PublicReferences
    public Transform turret;
    #endregion

    #region Variables

    private float pitchDeg;
    private float yawDeg;
    public float smoothingFector = 0.2f;
    [Range(-90,90)]
    public float turretYawDegRotation;
    #endregion

    #region Functions

    public void UpdateMouse()
    {
        float xMouse = Input.GetAxis("Mouse X");//to get the mouse x input
        float yMouse = Input.GetAxis("Mouse Y");//to get the mouse y input
        pitchDeg += -yMouse*smoothingFector;
        pitchDeg = Mathf.Clamp(pitchDeg, -90,90);
        yawDeg += xMouse*smoothingFector;
        transform.rotation = Quaternion.Euler(pitchDeg, yawDeg, 0);// setting the mouse input into rotation of camera to locate the turret
        //when you press left mouse button the turret will be fixed
        if (Input.GetMouseButton(0))
        {
            pitchDeg = 0;
            yawDeg = 0;
        }

    }

    void MouseWheel()
    {
        float mouseWheel = Input.mouseScrollDelta.y;
        turretYawDegRotation += mouseWheel;
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
            Quaternion offset = Quaternion.Euler(0,turretYawDegRotation,0);
            turret.rotation = Quaternion.LookRotation(zAxis, yAxis)*offset;
            Debug.DrawLine(ray.origin, hit.point);
            turret.rotation = Quaternion.Euler(0,180f,0);
            // Gizmos.color = Color.white;
            // Gizmos.DrawLine(ray.origin, hit.point);
        }
    }

    #endregion

    #region Awake

    private void Awake()
    {
        Vector3 mouseLook = transform.eulerAngles;
        pitchDeg = mouseLook.y;
        yawDeg = mouseLook.x;
    }

    #endregion

    #region Update

    private void Update()
    {
        TurretPlacer();
        UpdateMouse();
        MouseWheel();
    }
    #endregion
}
