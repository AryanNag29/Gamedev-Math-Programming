using UnityEditor;
using UnityEngine;

public class CheesyScript : MonoBehaviour
{
    #region PublicReferences
    public Transform target;
    #endregion

    #region Variables 
    public float radius = 1;
    public float height = 1;
    [Range(0, 1)] //quite usefull for the range base slider
    public float angThresh = 0.5f; //not an actual
    #endregion

    #region Gizmos
    void OnDrawGizmos()
    {
        Vector3 origin = transform.position;
        Vector3 up = transform.up;
        Vector3 top = origin + up * height;
        Handles.DrawWireDisc(origin, up, radius);
        Handles.DrawWireDisc(top, up, radius);
    }
    #endregion
}
