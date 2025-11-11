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
        //making gizmos relative to localtoworld metrix
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.color = Handles.color = Contains(target.position) ? Color.red : Color.white;

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

        Vector3 vLeft = (forward * p + right * (-x)) * radius;
        Gizmos.DrawRay(origin, vLeft);
        Gizmos.DrawRay(top, vLeft);

        Vector3 vRight = (forward * p + right * x) * radius;
        Gizmos.DrawRay(origin, vRight);
        Gizmos.DrawRay(top, vRight);

        Gizmos.DrawLine(origin, top);
        Gizmos.DrawLine(origin + vLeft, top + vLeft);
        Gizmos.DrawLine(origin + vRight, top + vRight);
        Gizmos.DrawLine(origin, target.position);
    }
    #endregion

    #region Function
    public bool Contains(Vector3 position)
    {

        Vector3 dirToTargetWorld = (position - transform.position);

        //InverseTransformVector is  world to local
        Vector3 vecToTarget = transform.InverseTransformVector(dirToTargetWorld);

        Vector3 flatDirToTarget = vecToTarget;
        float flatDirection = flatDirToTarget.magnitude;
        flatDirToTarget.y = 0;
        flatDirToTarget /= flatDirection;



        //cylindercal raidal check
        
        //height check
        if (vecToTarget.y < 0 || vecToTarget.y > height) return false; //out of height range


        //angular checks
        if (flatDirToTarget.z < angThresh) return false; //out of angular range


        return true;
    }
    #endregion
    

    //quick method to assign using localtoworld method

    // void OnDrawGizmos()
    // {
    //     //making gizmos relative to localtoworld metrix
    //     Gizmos.matrix = transform.localToWorldMatrix;

    //     Vector3 top = new Vector3(0,height,0);
    //     Handles.DrawWireDisc(default, Vector3.up, radius);
    //     Handles.DrawWireDisc(top, Vector3.up, radius);

    //     //Drawing the angle
    //     float p = angThresh;
    //     float x = Mathf.Sqrt(1 - p * p);

    //     Vector3 vLeft = new Vector3(-x, 0, p) * radius;
    //     Gizmos.DrawRay(default, vLeft);
    //     Gizmos.DrawRay(top, vLeft);

    //     Vector3 vRight = new Vector3(x, 0, p) * radius;
    //     Gizmos.DrawRay(default, vRight);
    //     Gizmos.DrawRay(top, vRight);

    //     Gizmos.DrawLine(default, top);
    //     Gizmos.DrawLine(vLeft, top + vLeft);
    //     Gizmos.DrawLine(vRight , top + vRight);
    // }
}
