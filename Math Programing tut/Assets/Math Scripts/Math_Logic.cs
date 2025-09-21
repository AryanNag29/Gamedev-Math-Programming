using Unity.InferenceEngine;
using UnityEditor;
using UnityEngine;

public class Math_Logic : MonoBehaviour
{
    public Transform P1;

    public float radius = 1f;

    public float dist;

    public bool isTrigger = false;

    void OnDrawGizmos()
    {
        Vector3 center = transform.position;
        //Handles.DrawWireArc(); Handles has more functions then gizmos 

        if (P1 == null)
        {
            return;
        }

        Vector3 playerpos = P1.position;

        dist = Vector3.Distance(center, playerpos);
        Vector3 playerDist = P1.transform.position;
        Gizmos.DrawLine(center, playerDist);
        //istrigger Condition
        if (dist <= radius)
        {
            isTrigger = true;
        }
        else
        {
            isTrigger = false;
        }
        
        Gizmos.color = isTrigger ? Color.red : Color.white;
        Gizmos.DrawWireSphere(center, radius);


    }
}
