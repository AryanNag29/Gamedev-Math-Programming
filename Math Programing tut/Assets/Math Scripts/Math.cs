using UnityEngine;


public class Math : MonoBehaviour
{
    public Transform a;
    public Transform b;

    //Draw in scene view
    void OnDrawGizmos()
    {
        Vector3 A = a.position;
        Vector3 B = b.position;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.zero, A);
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(Vector3.zero, B);
        


        // Gizmos.color = Color.yellow;
        // Gizmos.DrawSphere(transform.position, 1);
    }
}
