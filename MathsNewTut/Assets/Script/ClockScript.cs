using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ClockScript : MonoBehaviour
{
    #region variables
    public float clockRadius = 1f;
    public float angRed = 1f;
    private float secHand = .85f;
    private float minHand = .75f;
    private float hourHand = .50f;
    #endregion

    #region Properties

    Vector2 AngleToDis(float AngRed) => new Vector2(Mathf.Cos(AngRed), Mathf.Sin(AngRed));        

    #endregion
    
    #region gizmos
    void OnDrawGizmos()
    {
        Handles.DrawWireDisc(default, Vector3.forward,clockRadius);
        Vector2 Second = AngleToDis(angRed*20f)*secHand;
        Vector2 Minute = AngleToDis(angRed*45f)*minHand;
        Vector2 Hour = AngleToDis(angRed*90f)*hourHand;
        
        //DrawHands
        Gizmos.color = Color.red;
        Gizmos.DrawRay(default,Second);
        Gizmos.color = Color.green;
        Gizmos.DrawRay(default,Minute);
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(default,Hour);
        
    }
    #endregion

}
