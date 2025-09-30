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
        localPos = worldtolocal(worldCoord);
        Gizmos.DrawSphere(worldCoord, 0.1f);

        Gizmos.DrawLine(worldCoord, localPos);
    }

    #endregion

}
