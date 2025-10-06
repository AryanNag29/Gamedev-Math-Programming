using UnityEngine;

public class WorldToLocal : MonoBehaviour
{
    #region variables

    public Vector2 worldCoord;
    public Vector2 localPos;

    #endregion

    #region Function

    Vector3 worldtolocal(Vector3 world)
    {
        //shortcut

        Matrix4x4 worldtolocalmtx = transform.worldToLocalMatrix;
        worldtolocalmtx.MultiplyPoint3x4(world);

        //manual

        Vector3 rel = world - transform.position;
        float x = Vector3.Dot(rel, transform.right);
        float y = Vector3.Dot(rel, transform.up);
        float z = Vector3.Dot(rel, transform.forward);
        return new(x, y,z);
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
