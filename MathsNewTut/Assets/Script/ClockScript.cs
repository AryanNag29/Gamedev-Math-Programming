using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ClockScript : MonoBehaviour
{
    #region variables
    public float clockRadius = 1f;
    public float angRed = 0f;
    #endregion

    #region Properties

    Vector2 AngleToDis(float AngRed) => new Vector2(Mathf.Cos(AngRed), Mathf.Sin(AngRed));        

    #endregion
    
    #region gizmos
    void OnDrawGizmos()
    {
        Handles.DrawWireDisc(default, Vector3.forward,clockRadius);
        Vector2 Second = AngleToDis(angRed);
        
        Gizmos.DrawRay(default,Second);
        
    }
    #endregion

}
