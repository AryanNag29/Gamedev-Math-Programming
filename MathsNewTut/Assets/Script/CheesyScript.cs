using UnityEditor;
using UnityEngine;

public class CheesyScript : MonoBehaviour
{
    public float radius = 1;
    public float height = 1;
    [Range(0, 1)]
    public float angThresh = 0.5f;
    void OnDrawGizmos()
    {
        Handles.DrawWireDisc(transform.position, transform.up, radius);
    }
}
