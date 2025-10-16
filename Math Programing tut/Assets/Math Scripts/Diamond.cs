using UnityEngine;

public class Diamond : MonoBehaviour
{
    public Transform b;
    public Transform c;
    public Transform d;

    void OnDrawGizmos()
    {
        transform.position = new Vector3(4, 1, 0);
        b.transform.position = new Vector3(2, 4, 0);
        c.transform.position = new Vector3(4, 7, 0);
        d.transform.position = new Vector3(6, 4, 0);

        Vector3 A = transform.position;
        Vector3 B = b.position;
        Vector3 C = c.position;
        Vector3 D = d.position;

        Gizmos.DrawLine(A, B);
        Gizmos.DrawLine(B, C);
        Gizmos.DrawLine(C, D);
        Gizmos.DrawLine(D, A);
    }
}
