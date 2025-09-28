using UnityEngine;

public class TransformVectors : MonoBehaviour
{

    #region Variables

    //variables
    public Vector2 localCoord;

    #endregion

    #region Functions

    Vector2 LocalToWorld(Vector2 local) {
        Vector2 position = transform.position;
        position += local.x * (Vector2)transform.right;
        position += local.x * (Vector2)transform.up;
        return position;
    }

    #endregion

    #region Gizmos

    void OnDrawGizmos()
    {
        Vector2 worldpos = LocalToWorld(localCoord);
        Gizmos.DrawSphere(worldpos, 0.1f);
    }
    #endregion
}
