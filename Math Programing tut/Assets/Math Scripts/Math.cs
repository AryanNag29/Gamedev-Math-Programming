using UnityEngine;


public class Math : MonoBehaviour
{
    public Transform a;
    public Transform b;

    //Draw in scene view
    void OnDrawGizmos()
    {
        Vector2 A = a.position;
        Vector2 B = b.position;

        Gizmos.color = Color.yellow;
        //Gizmos.DrawSphere(transform.position, 1);
    }
}
