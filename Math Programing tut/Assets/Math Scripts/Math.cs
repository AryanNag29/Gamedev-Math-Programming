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

        Gizmos.color = Color.red;
        Gizmos.DrawLine(default, anorm);
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(default, B);


        


        // Gizmos.color = Color.yellow;
        // Gizmos.DrawSphere(transform.position, 1);
    }
}
