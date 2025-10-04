using UnityEngine;

public class WorldToLocal : MonoBehaviour
{
    #region variables

    public Vector2 worldCoord;
    public Vector2 localPos;

    #endregion

    #region Function

    Vector2 worldtolocal(Vector2 world)
    {
        Vector2 rel = world - (Vector2)transform.position;
        float x = Vector2.Dot(rel, transform.right);
        float y = Vector2.Dot(rel, transform.up);
        return new(x, y);
    }

    #endregion

    #region Gizmos

    void OnDrawGizmos()
    {
        //matrix transformation from local to world
        Matrix4x4 localtoworldmtx = transform.localToWorldMatrix;
        localtoworldmtx.MultiplyPoint3x4(worldCoord); // ignore the last row of 4x4 matrix also faster
        //Transforming from one space to another(local , world)
        //transform.TransformPoint() // M*(v.x, v.y , v.z , 1); // local to world
        // transform.InverseTransformPoint(); // M^-1* (v.x , v.y , v.z ,1 ) // world to local 
        // transform.TransformVector(); //M*(v.x, v.y , v.z , 0) //it does not include position
        // transform.InverseTransformVector(); // m^-1 * (v.x , v.y , v.z, 0) // inverse



        //update in the inspector:
        Vector2 LocalPos = transform.InverseTransformPoint((Vector3)worldCoord); // M^-1 * (v.x,v.y,v.z,1)
        localPos = worldtolocal(worldCoord);
        Gizmos.DrawSphere(worldCoord, 0.1f);

        Gizmos.DrawLine(worldCoord, localPos);
    }

    #endregion

}
