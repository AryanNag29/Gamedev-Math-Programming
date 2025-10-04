using UnityEngine;

public class LocalToWorld : MonoBehaviour
{

    #region Variables

    //variables
    public Vector2 localCoord;
    public Vector2 worldpos;

    #endregion

    #region Functions

    Vector2 LocalToWorld(Vector2 local) {
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
        worldpos = LocalToWorld(localCoord);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(worldpos, 0.1f);
        //local to world space line
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(default, worldpos);
    }
    #endregion
}
