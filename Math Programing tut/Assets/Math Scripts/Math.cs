using UnityEditor;
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

        //manual version and short form (but using manual version increase performance)
        float alen = Mathf.Sqrt(A.x * A.x + A.y * A.y + A.z * A.z);
        float blen = B.magnitude;
        Vector3 anorm = A / alen;
        Vector3 bnorm = B.normalized;


        //draw line to objects
        Gizmos.color = Color.red;
        Gizmos.DrawLine(default, A);
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(default, B);

        //drawspehere
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(anorm, 0.1f);

        //draw line for scaler projection dot product
        //Gizmos.color = Color.blue;
        //Gizmos.DrawLine(B, anorm);


        


        // Gizmos.color = Color.yellow;
        // Gizmos.DrawSphere(transform.position, 1);
    }
}
