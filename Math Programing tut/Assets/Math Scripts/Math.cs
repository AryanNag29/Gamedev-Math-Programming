using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class Math : MonoBehaviour
{
    //reference to game object a and b
    public Transform a;
    public Transform b;
    public float scalPro;
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

        //scaler projection 
        scalPro = Vector3.Dot(anorm, B);

        //vector projection
        Vector3 vecProj = anorm * scalPro;
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(vecProj, 0.05f);

        //draw line for scaler projection dot product
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(B, vecProj);

    }
    /* enum state machine logic
    public enum State
    {
        Idle,
        Walking,
        Attacking
    }

    private State state;

    public void Update()
    {
        switch (state)
        {
            case State.Idle:
                //idle logic
                break;
            case State.Walking:
                //walking logic
                break;
            case State.Attacking:
                //attacking logic
                break;
        }
    }*/
}
