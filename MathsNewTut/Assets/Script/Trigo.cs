using System;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class Trigo : MonoBehaviour
{
    #region Variables
    [Range(0,360)]
    public float angDeg = 0f;
    #endregion

    #region Gizmos
    void OnDrawGizmos()
    {
        Handles.DrawWireDisc(Vector3.zero,Vector3.forward,1);
        float angRad = angDeg * Mathf.Deg2Rad;
        Vector2 v = new Vector2(Mathf.Cos(angRad),Mathf.Sin(angRad));
        Gizmos.DrawRay(default,v);
    }
    #endregion
}
