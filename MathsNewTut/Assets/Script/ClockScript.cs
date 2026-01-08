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
    public float angSecMinHand = 1;
    [Range(0,24)]
    public float angHourHand = 1;
    
    [Range(0,0.2f)]
    public float TickSizeSecMinHand = 0.05f;
    [Range(0,0.2f)]
    public float TickSizeHourHand = 0.3f;
    
    public float clockRadius = 1f;
    public bool SmoothMotion;
    public bool IS24Hours;
    #endregion

    #region Constants

    private const float Tau = Mathf.PI * 2;
    
    #endregion
    

    #region Properties
    //MathUtilities
    //angle to vector
    static Vector2 AngToDis(float angle)=> new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    //Atan2 is use to convert from vector2 to angle in radian
    static float DirToAngle(Vector2 v) => Mathf.Atan2(v.y, v.x);
    
    int hours24 => IS24Hours? 24:12;
    #endregion

    #region Functions

    void DrawTick(Vector2 dir, float length, float Thickness)
    {
        Handles.DrawLine(dir, dir*(1f-length),Thickness);
    }
    void DrawClockHands(Vector2 dir, float length, float Thickness,Color color)
    {
        using (new Handles.DrawingScope(color))
        Handles.DrawLine(default, dir*length,Thickness);
    }
    
    Vector2 SecondOrMinuteToDirection(float secOrMin)=>ValueToDir(secOrMin,60);
    Vector2 HoursToDirection(float Hours) => ValueToDir(Hours,hours24);
    Vector2 ValueToDir(float value , float maxValue)
    {
        float t = (float)value / maxValue; // 0-1 value representing the percente / fraction along the 0-60 range
        return FractionToDirection(t);
    }

    Vector2 FractionToDirection(float t)
    {
        float angleRad = -t * Tau + Tau/4;
        float a = DirToAngle(AngToDis(angleRad)) * Mathf.Rad2Deg;
        Debug.Log(a);
        return AngToDis(angleRad);
    }

    #endregion

    #region Gizmos
    
    private void OnDrawGizmos()
    {
        Gizmos.matrix = Handles.matrix = transform.localToWorldMatrix;
        Handles.DrawWireDisc(default, Vector3.forward,clockRadius);
        
        //Tick(min/Sec)
        for (float i = 0; i < 60; i++)
        {
            Vector2 Dir = SecondOrMinuteToDirection(i);
            DrawTick(Dir,TickSizeSecMinHand,1);
        }
        
        //hours
        for (float i = 0; i < hours24; i++)
        {
            Vector2 Dir = HoursToDirection(i);
            DrawTick(Dir,TickSizeHourHand,3);
        }
        //DrawClockHands
        DateTime Time = DateTime.Now;
        float Seconds = Time.Second;
        if (SmoothMotion)
            Seconds += Time.Millisecond / 1000f;
        DrawClockHands(SecondOrMinuteToDirection(Seconds),0.8f,1,Color.red);
        DrawClockHands(SecondOrMinuteToDirection(Time.Minute),0.7f,4,Color.green);
        DrawClockHands(HoursToDirection(Time.Hour),0.5f,8,Color.blue);
        
    }
    #endregion
    
}
