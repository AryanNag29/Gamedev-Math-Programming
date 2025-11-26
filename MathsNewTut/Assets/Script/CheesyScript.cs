using System;
using JetBrains.Annotations;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class CheesyScript : MonoBehaviour
{
    #region PublicReferences
    public Transform target;
    public laser TrigLaser;
    #endregion

    #region Variables 
    [FormerlySerializedAs("radius")] //unity will remember the variable as it formal name even you changed the name
    public float outterRadius = 1;
    public float innerRadius = 0.2f;
    public float height = 1;
    [Range(0, 180)] //quite usefull for the range base slider
    public float fovDeg = 45f; //an actual angle
    #endregion

    #region Properties
    float fovRed=>fovDeg*Mathf.Deg2Rad;
    float angleThresh => Mathf.Cos(fovRed/2);

    #endregion

    #region Gizmos

    void OnDrawGizmos()
    {
        //making gizmos relative to localtoworld metrix
        Gizmos.matrix = Handles.matrix = transform.localToWorldMatrix;
        //Condition for the trigger
        Gizmos.color = Handles.color = Contains(target.position) ? Color.red : Color.white;

        //contains the bool of other clase and make it true when contains == true
        if (Contains(target.position))
        {
            TrigLaser.inTrigger = true;
        }
        else
        {
            TrigLaser.inTrigger = false;
        }
        //Drawing the angle(pythagoras theorem)
        float p = angleThresh;
        float x = Mathf.Sqrt(1 - p * p);
        
        Vector3 vLeft = new Vector3(-x, 0, p) * outterRadius;
        Vector3 vRight = new Vector3(x, 0, p) * outterRadius;

        //this is basically mean this 1y = 90degree
        Quaternion up90 = Quaternion.AngleAxis(90,Vector3.up);
        //euler angles 
        //transform.eulerAngles
        Quaternion VecA = Quaternion.Euler(30,45,90);
        Quaternion VecB = Quaternion.AngleAxis(60,Vector3.up);
        Quaternion rotCombination = VecA * VecB; //combined rotation
        Quaternion.Slerp(VecA,VecB,5f);
        Quaternion rotInverse = Quaternion.Inverse(rotCombination);
        Vector3 rotateVec = rotInverse*vLeft;

        Vector3 top = new Vector3(0, height, 0);
        Handles.DrawWireArc(default,Vector3.up,vLeft,fovDeg,outterRadius-innerRadius);
        Handles.DrawWireArc(top,Vector3.up,vLeft,fovDeg,outterRadius-innerRadius);
        Handles.DrawWireArc(default,Vector3.up,vLeft,fovDeg,outterRadius);
        Handles.DrawWireArc(top,Vector3.up,vLeft,fovDeg,outterRadius);
        // Handles.DrawWireDisc(default, Vector3.up, outterRadius);
        // Handles.DrawWireDisc(top, Vector3.up, outterRadius);

        

        ;
        Gizmos.DrawRay(default, vLeft);
        Gizmos.DrawRay(top, vLeft);

        
        Gizmos.DrawRay(default, vRight);
        Gizmos.DrawRay(top, vRight);

        Gizmos.DrawLine(default, top);
        Gizmos.DrawLine(vLeft, top + vLeft);
        Gizmos.DrawLine(vRight, top + vRight);

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

        if (flatDirection > outterRadius && flatDirection>innerRadius) return false; //out of outterRadius range
        
        //height check
        if (vecToTarget.y < 0 || vecToTarget.y > height) return false; //out of height range


        //angular checks
        if (flatDirToTarget.z < angleThresh) return false; //out of angular range

        //if we pass all the test we are inside
        return true;
    }

    #endregion


    //long method to assign using localtoworld method


        // void OnDrawGizmos()
    // {
    //     //making gizmos relative to localtoworld metrix
    //     Gizmos.matrix = transform.localToWorldMatrix;
    //     Gizmos.color = Handles.color = Contains(target.position) ? Color.red : Color.white;

    //     Vector3 origin = transform.position;
    //     Vector3 up = transform.up;
    //     Vector3 right = transform.right;
    //     Vector3 forward = transform.forward;
    //     Vector3 top = origin + up * height;
    //     Handles.DrawWireDisc(origin, up, outterRadius);
    //     Handles.DrawWireDisc(top, up, outterRadius);

    //     //Drawing the angle
    //     float p = angThresh;
    //     float x = Mathf.Sqrt(1 - p * p);

    //     Vector3 vLeft = (forward * p + right * (-x)) * outterRadius;
    //     Gizmos.DrawRay(origin, vLeft);
    //     Gizmos.DrawRay(top, vLeft);

    //     Vector3 vRight = (forward * p + right * x) * outterRadius;
    //     Gizmos.DrawRay(origin, vRight);
    //     Gizmos.DrawRay(top, vRight);

    //     Gizmos.DrawLine(origin, top);
    //     Gizmos.DrawLine(origin + vLeft, top + vLeft);
    //     Gizmos.DrawLine(origin + vRight, top + vRight);
    //     Gizmos.DrawLine(origin, target.position);
    // }
}
