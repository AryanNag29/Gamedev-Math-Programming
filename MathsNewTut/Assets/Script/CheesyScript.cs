using System;
using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;
using Mono.Cecil;
using NUnit.Framework.Constraints;
using Unity.Mathematics;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;
using Debug = UnityEngine.Debug;

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

    #region Stack

    Stack<Matrix4x4> mtx = new Stack<Matrix4x4>();
    void Pushmtx() => mtx.Push(Gizmos.matrix); //pushing the matrix into stack

    void Popmtx() =>
        SetGizmosMatrix(mtx.Pop()); //popping the matrix from the stack and restoring the matrix into it's original form

    #endregion

    #region Variables

    public Shape shape; //enum variable

    [FormerlySerializedAs("radius")] //unity will remember the variable as it formal name even you changed the name
    public float outterRadius = 1;

    public float innerRadius = 0.2f;
    public float height = 1;

    [Range(0, 360)] //quite usefull for the range base slider
    public float fovDeg = 45f; //an actual angle

    #endregion

    #region Properties

    public float fovRed => fovDeg * Mathf.Deg2Rad;
    public float angleThresh => Mathf.Cos(fovRed / 2);
    public void SetGizmosMatrix(Matrix4x4 m) => Gizmos.matrix = Handles.matrix = m;

    #endregion

    #region Gizmos

    void OnDrawGizmos()
    {
        //making gizmos relative to localtoworld metrix
        SetGizmosMatrix(transform.localToWorldMatrix);
        //Condition for the trigger
        Gizmos.color = Handles.color = Contains(target.position) ? Color.red : Color.white;

        if (Contains(target.position))
        {
            TrigLaser.inTrigger = true;
        }
        else
        {
            TrigLaser.inTrigger = false;
        }

        switch (shape)
        {
            case Shape.WedgeSector:
                DrawWedgeGizmos();
                break;
            case Shape.Spherical:
                DrawSphereGismos();
                break;
            case Shape.SphericalSector:
                DrawSphericalSectorGizmos();
                break;
        }
    }

    #endregion


    #region Function

    public void DrawSphericalSectorGizmos()
    {
        float p = angleThresh;
        float x = Mathf.Sqrt(1 - p * p);
        Vector3 vLefDir = new Vector3(-x, 0, p);
        Vector3 vRightDir = new Vector3(x, 0, p);
        Vector3 vLeftOutter = vLefDir * outterRadius;
        Vector3 vRightOutter = vRightDir * outterRadius;
        Vector3 vLeftInner = vLefDir * innerRadius;
        Vector3 vRightInner = vRightDir * innerRadius;


        //arcs
        void DrawFlatWedge()
        {
            //gizmos and handles 
            Handles.DrawWireArc(default, Vector3.up, vLeftInner, fovDeg, innerRadius);
            Handles.DrawWireArc(default, Vector3.up, vLeftOutter, fovDeg, outterRadius);
            Gizmos.DrawLine(vLeftInner, vLeftOutter);
            Gizmos.DrawLine(vRightInner, vRightOutter);
        }

        DrawFlatWedge();
        Pushmtx(); // saves the current matrix to the stack
        SetGizmosMatrix(Gizmos.matrix * Matrix4x4.TRS(default, Quaternion.Euler(0, 0, 90), Vector3.one));
        DrawFlatWedge();
        Popmtx();

        //radius
        void Drawring(float coneRadius)
        {
            float a = fovRed / 2;
            //Making circle on the ark
            float dist = coneRadius * Mathf.Cos(a);
            float radius = coneRadius * Mathf.Sin(a);
            Vector3 center = new Vector3(0, 0, dist);
            Handles.DrawWireDisc(center, Vector3.forward, radius);
        }

        Drawring(innerRadius);
        Drawring(outterRadius);
    }

    public void DrawSphereGismos()
    {
        Gizmos.DrawWireSphere(default, innerRadius);
        Gizmos.DrawWireSphere(default, outterRadius);
    }

    public void DrawWedgeGizmos()
    {
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

    public bool Contains(Vector3 position) =>
        shape switch
        {
            Shape.WedgeSector => WedgeContains(position),
            Shape.Spherical => SphereContains(position),
            Shape.SphericalSector => SphericalSectorContains(position),
            _ => throw new IndexOutOfRangeException()
        };

    static float AngleBetweenNormalizedVectors(Vector3 a, Vector3 b)
    {
        return Mathf.Acos(Mathf.Clamp(Vector3.Dot(a, b), -1, 1));
    }

    public bool SphericalSectorContains(Vector3 position)
    {
        if (SphereContains(position) == false)
            return false; //out of radial range
        Vector3 dirToTarget = (position - transform.position).normalized;
        float angleRad = AngleBetweenNormalizedVectors(transform.forward, dirToTarget);
        if (angleRad > fovRed / 2) return false; //out of angular range 
        //both conditon is true
        return true;
    }

    //Sphere conditon and gismos
    public bool SphereContains(Vector3 position)
    {
        Vector3 dirToTargetWorld = (position - transform.position);
        Vector3 dirToTargetLocal = transform.InverseTransformVector(dirToTargetWorld);
        float distance = dirToTargetLocal.magnitude;
        return distance >= innerRadius && distance <= outterRadius;
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

    #endregion
}