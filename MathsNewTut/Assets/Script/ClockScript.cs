using Unity.VisualScripting;
using System;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class ClockScript : MonoBehaviour
{
    #region Variables 
    [Range(0,60)]
    public int angSecMinHand = 1;
    [Range(0,60f)]
    public float angHourHand = 1f;
    
    public float clockRadius = 1f;
    #endregion

    #region Constants

    private const float Tau = Mathf.PI * 2;
        

    #endregion
    

    #region Properties

    Vector2 AngToDis(float angle)=> new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

    #endregion

    #region Functions

    Vector2 SecondToDirection(int second)
    {
        float t = (float)second / 60;
        
        return FractionToDirection(t);
    }

    Vector2 FractionToDirection(float t)
    {
        float angleRad = -t * Tau + Tau/4;
        return AngToDis(angleRad);
    }

    #endregion

    #region Gizmos
    
    private void OnDrawGizmos()
    {
        Gizmos.matrix = Handles.matrix = transform.localToWorldMatrix;
        Handles.DrawWireDisc(default, Vector3.forward,clockRadius);
        Gizmos.DrawRay(default , SecondToDirection(angSecMinHand));
    }
    #endregion
    
}
