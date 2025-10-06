using System;
using Unity.Mathematics;
using UnityEngine;
public class LocalToWorld : MonoBehaviour
{

    #region Variables

    //variables
    public Vector2 localCoord;
    public Vector2 worldpos;

    #endregion

    #region Functions

    Vector2 LocaltoWorld(Vector2 local)
    {
        //also a more complicated way using matrix trs(translation , rotation , scale)
        Matrix4x4 mtx = Matrix4x4.TRS(new Vector3(2, 5, 6), quaternion.identity, Vector3.one);
        //shoutcut
        transform.localToWorldMatrix.MultiplyPoint3x4(local);

        //manual way
        //made the variable
        Vector2 position = transform.position;
        //store position + localcoord.x * transform.right
        position += local.x * (Vector2)transform.right;
        //store position localcoord.y * transform.up
        position += local.x * (Vector2)transform.up;
        return position;
    }

    #endregion

    #region Gizmos

    void OnDrawGizmos()
    {
        //this is also a method to transform from local to world space
        Vector2 WorldPos = transform.TransformPoint(localCoord); //M*(v.x,v.y,v.z,1)
        worldpos = LocaltoWorld(localCoord);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(worldpos, 0.1f);
        //local to world space line
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(default, worldpos);
    }
    #endregion
}
