using UnityEditor;
using UnityEngine;

public class laser : MonoBehaviour
{
    #region References 
    public Transform target;
    public bool inTrigger = false;
    #endregion
    
    #region Gizmos

    void OnDrawGizmos()
    {
        if (inTrigger)
        {
            Gizmos.DrawLine(transform.position,target.position);
        }
    }
    
    #endregion

}
