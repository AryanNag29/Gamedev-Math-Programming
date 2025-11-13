using UnityEngine;
using UnityEngine.UIElements;

public class TurretRotation : MonoBehaviour
{
    #region References
    public Transform target;
    public CheesyScript trigger;
    public Transform gunTf;
    #endregion

    #region Variables

    #endregion

    #region Function

    #endregion

    #region Gizmos
    void OnDrawGizmos()
    {
        if (trigger.Contains(target.position))
        {
            //note: worldspace rotation
            
            Vector3 vecToTargetgun = target.position - gunTf.position;
            gunTf.rotation = Quaternion.LookRotation(vecToTargetgun, transform.up);

        }
       
    }
    #endregion

}
