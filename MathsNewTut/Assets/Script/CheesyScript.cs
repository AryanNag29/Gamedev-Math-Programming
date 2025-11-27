using System;
using JetBrains.Annotations;
using Unity.Mathematics;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

public class CheesyScript : MonoBehaviour
{
    #region Enum
    public enum Shape
    {
        WedgeSector,
        Spherical,
        SphericalSector
    }
    #endregion

    #region PublicReferences
    public Transform target;
    public laser TrigLaser;
    #endregion

    #region Variables 
    public Shape shape; //enum variable
    [FormerlySerializedAs("radius")] //unity will remember the variable as it formal name even you changed the name
    public float outterRadius = 1;
    public float innerRadius = 0.2f;
    public float height = 1;
    [Range(0, 180)] //quite usefull for the range base slider
    public float fovDeg = 45f; //an actual angle
    #endregion

    #region Properties
    float fovRed => fovDeg * Mathf.Deg2Rad;
    float angleThresh => Mathf.Cos(fovRed / 2);

    #endregion

    #region Gizmos

    void OnDrawGizmos()
    {
        //making gizmos relative to localtoworld metrix
        Gizmos.matrix = Handles.matrix = transform.localToWorldMatrix;
        //Condition for the trigger
        Gizmos.color = Handles.color = WedgeContains(target.position) ? Color.red : Color.white;

        switch (shape)
        {
            case Shape.WedgeSector:
                DrawWedgeGizmos();
                break;
            case Shape.Spherical:
                DrawSphereGismos();
                break;
        }

    }

    #endregion

    #region Function
    public bool Contains(Vector3 position) =>
        shape switch
        {
            Shape.WedgeSector => WedgeContains(position),
            Shape.Spherical => SphereContains(position),
            _ => throw new NotImplementedException()
        };

    //Sphere conditon and gismos
    public bool SphereContains(Vector3 position)
    {
        float dis = Vector3.Distance(transform.position, position);
        if (dis > outterRadius || dis < innerRadius) return false;
        return true;
    }

    public void DrawSphereGismos()
    {
        //Later
        // if (SphereContains(target.position))
        // {
        //     TrigLaser.inTrigger = true;
        // }
        // else
        // {
        //     TrigLaser.inTrigger = false;
        // }
        Gizmos.DrawWireSphere(default, innerRadius);
        Gizmos.DrawWireSphere(default, outterRadius);
    }
    
    //wedge conditon and gizmos
    public bool WedgeContains(Vector3 position)
    {

        Vector3 dirToTargetWorld = (position - transform.position);

        //InverseTransformVector is  world to local
        Vector3 vecToTarget = transform.InverseTransformVector(dirToTargetWorld);

        Vector3 flatDirToTarget = vecToTarget;
        float flatDirection = flatDirToTarget.magnitude;
        flatDirToTarget.y = 0;
        flatDirToTarget /= flatDirection;



        //cylindercal raidal check
        if (flatDirection > outterRadius || flatDirection < innerRadius) return false; //out of outterRadius range

        //height check
        if (vecToTarget.y < 0 || vecToTarget.y > height) return false; //out of height range


        //angular checks
        if (flatDirToTarget.z < angleThresh) return false; //out of angular range

        //if we pass all the test we are inside
        return true;
    }

    public void DrawWedgeGizmos()
    {
        //contains the bool of other clase and make it true when contains == true
        if (WedgeContains(target.position))
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

        Vector3 vLefDir = new Vector3(-x, 0, p);
        Vector3 vRightDir = new Vector3(x, 0, p);
        Vector3 vLeftOutter = vLefDir * outterRadius;
        Vector3 vRightOutter = vRightDir * outterRadius;
        Vector3 vLeftInner = vLefDir * innerRadius;
        Vector3 vRightInner = vRightDir * innerRadius;

        Vector3 top = new Vector3(0, height, 0);
        Handles.DrawWireArc(default, Vector3.up, vLeftInner, fovDeg, innerRadius);
        Handles.DrawWireArc(top, Vector3.up, vLeftInner, fovDeg, innerRadius);
        Handles.DrawWireArc(default, Vector3.up, vLeftOutter, fovDeg, outterRadius);
        Handles.DrawWireArc(top, Vector3.up, vLeftOutter, fovDeg, outterRadius);
        // Handles.DrawWireDisc(default, Vector3.up, outterRadius);
        // Handles.DrawWireDisc(top, Vector3.up, outterRadius);
        Gizmos.DrawLine(vLeftInner, vLeftOutter);
        Gizmos.DrawLine(vRightInner, vRightOutter);
        Gizmos.DrawLine(top + vLeftInner, top + vLeftOutter);
        Gizmos.DrawLine(top + vRightInner, top + vRightOutter);

        Gizmos.DrawLine(top + vLeftInner, vLeftInner);
        Gizmos.DrawLine(top + vRightInner, vRightInner);
        Gizmos.DrawLine(vLeftOutter, top + vLeftOutter);
        Gizmos.DrawLine(vRightOutter, top + vRightOutter);
    }

    public bool SphericalSectorContains(Vector3 position)
    {
        return true;
    }   
    public void DrawSphericalSectorGizmos()
    {
        
    }

    #endregion



}
