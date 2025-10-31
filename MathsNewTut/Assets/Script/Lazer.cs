using UnityEngine;

public class Lazer : MonoBehaviour
{
 #region Gizmos

    void OnDrawGizmos()
    {
        Vector2 origin = transform.position;
        Vector2 dir = transform.right;
        Ray ray = new Ray(origin, dir);
        int maxBounces = 40;

        for (int i = 0; i < maxBounces; i++)
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Gizmos.DrawSphere(hit.point, 0.05f);
                //draw line on x axis
                Gizmos.color = Color.red;
                Gizmos.DrawLine(ray.origin, hit.point);
                Vector2 Reflected = Reflect(ray.direction, hit.normal);
                //draw line 
                Gizmos.color = Color.green;
                Gizmos.DrawLine(hit.point, (Vector2)hit.point + Reflected);
                ray.direction = Reflected;
                ray.origin = hit.point;
            }
            else break;
        }
    }
    #endregion

    #region functions

    Vector2 Reflect(Vector2 inDir, Vector2 normal)
    {
        float proj = Vector2.Dot(inDir, normal);
        return inDir - 2 * proj * normal;
    }
    
    #endregion
}
