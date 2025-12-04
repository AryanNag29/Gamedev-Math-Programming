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
    
    [Range(0,0.2f)]
    public float TickSizeSecMinHand = 0.2f;
    
    public float clockRadius = 1f;
    #endregion

    #region Constants

    private const float Tau = Mathf.PI * 2;
        

    #endregion
    

    #region Properties
    //MathUtilities
    static Vector2 AngToDis(float angle)=> new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

    #endregion

    #region Functions

    void DrawTick(Vector2 dir, float length, float Thickness)
    {
        Handles.DrawLine(dir, dir*(1f-length),Thickness);
    }

    Vector2 SecondOrMinuteToDirection(int secOrMin)
    {
        float t = (float)secOrMin / 60; // 0-1 value representing the percente / fraction along the 0-60 range
        
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
        Gizmos.DrawRay(default , SecondOrMinuteToDirection(angSecMinHand));
        
        //Tick(min/Sec)
        for (int i = 0; i < 60; i++)
        {
            Vector2 Dir = SecondOrMinuteToDirection(i);
            DrawTick(Dir,TickSizeSecMinHand,1);
        }
    }
    #endregion
    
}
