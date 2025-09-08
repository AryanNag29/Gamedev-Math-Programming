using UnityEngine;


public class Math : MonoBehaviour
{
    //Draw in scene view
    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 5);
    }
}
