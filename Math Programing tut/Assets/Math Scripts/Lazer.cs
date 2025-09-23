using System.Runtime.InteropServices;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    void OnDrawGizmos()
    {
        Vector2 origin = transform.position;
        Vector2 dir = transform.right;
        Ray ray = new Ray(origin, dir);

        //draw line on x axis
        Gizmos.DrawLine(origin, origin+dir);


        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Gizmos.DrawSphere(hit.point, 0.1f);
        }
        
    }
}
