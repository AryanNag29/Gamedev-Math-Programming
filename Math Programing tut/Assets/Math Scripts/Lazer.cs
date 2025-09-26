using System.Runtime.InteropServices;
using UnityEditor.Analytics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Lazer : MonoBehaviour
{
    void OnDrawGizmos()
    {
        Vector2 origin = transform.position;
        Vector2 dir = transform.right;
        Ray ray = new Ray(origin, dir);


        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Gizmos.DrawSphere(hit.point, 0.1f);
            //draw line on x axis
            Gizmos.color = Color.red;
            Gizmos.DrawLine(origin, hit.point);

            Vector2 Reflected = Reflect(ray.direction, hit.normal);
            //draw line 
            Gizmos.color = Color.green;
            Gizmos.DrawLine(hit.point, (Vector2)hit.point + Reflected);
        }
    }

    Vector2 Reflect(Vector2 inDir, Vector2 normal)
    {
        float proj = Vector2.Dot(inDir, normal);
        return inDir - 2 *proj* normal;
    }
}
