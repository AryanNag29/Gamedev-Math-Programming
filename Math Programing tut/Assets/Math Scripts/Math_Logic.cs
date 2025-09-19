using UnityEditor;
using UnityEngine;

public class Math_Logic : MonoBehaviour
{
    public Transform P1;

    public float radius = 1f;

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(default, radius);
        //Handles.DrawWireArc(); Handles has more functions then gizmos 
    }
}
