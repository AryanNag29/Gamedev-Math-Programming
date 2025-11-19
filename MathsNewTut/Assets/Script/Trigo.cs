using System;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class Trigo : MonoBehaviour
{
    #region Variables
    [Range(0,360)]
    [SerializeField]private float angDeg = 0f;
    #endregion

    #region function
    static Vector2 AngToDis(float angRad) => new Vector2(Mathf.Cos(angRad),Mathf.Sin(angRad));
    #endregion

    #region Gizmos
    void OnDrawGizmos()
    {
        Handles.DrawWireDisc(Vector3.zero,Vector3.forward,1f);
        float angRad = angDeg * Mathf.Deg2Rad;
        //float angTurns = (float)EditorApplication.timeSinceStartup; //this function use to run the time of edior without using update function make sure to tick the always refresh in the editor
        Vector2 v = AngToDis(angRad);
        Gizmos.DrawRay(default,v);
    }
    #endregion
}
