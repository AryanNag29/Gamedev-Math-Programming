using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class CheesyScript : MonoBehaviour
{
    #region PublicReferences
    public Transform target;
    #endregion

    #region Variables 
    public float radius = 1;
    public float height = 1;
    [Range(0, 1)] //quite usefull for the range base slider
    public float angThresh = 0.5f; //not an actual
    #endregion

    #region Gizmos
    void OnDrawGizmos()
    {
        Vector3 origin = transform.position;
        Vector3 up = transform.up;
        Vector3 right = transform.right;
        Vector3 forward = transform.forward;
        Vector3 top = origin + up * height;
        Handles.DrawWireDisc(origin, up, radius);
        Handles.DrawWireDisc(top, up, radius);

        //Drawing the angle
        float p = angThresh;
        float x = Mathf.Sqrt(1 - p * p);

        Vector3 vLeft = (forward * p + right * (-x))*radius;
        Gizmos.DrawRay(origin, vLeft);
        Gizmos.DrawRay(top, vLeft);
        
        Vector3 vRight = (forward * p + right * x)*radius;
        Gizmos.DrawRay(origin, vRight);
        Gizmos.DrawRay(top, vRight);

        Gizmos.DrawLine(origin, top);
        Gizmos.DrawLine(origin + vLeft, top + vLeft);
        Gizmos.DrawLine(origin + vRight , top + vRight);

        

    }
    #endregion

    #region Function

    #endregion
}
