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

    #region function
    static Vector2 AngToDis(float angRad) => new Vector2(Mathf.Cos(angRad),Mathf.Sin(angRad));
    #endregion

    #region Gizmos
    void OnDrawGizmos()
    {
        Handles.DrawWireDisc(Vector3.zero,Vector3.forward,1);
        float angRad = angDeg * Mathf.Deg2Rad;
        Gizmos.DrawRay(default,AngToDis(angRad));
    }
    #endregion
}
