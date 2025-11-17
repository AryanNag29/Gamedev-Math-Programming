using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class TurretRotation : MonoBehaviour
{
    #region References
    public Transform target;
    public CheesyScript trigger;
    public Transform gunTf;
    public float smoothingFector = 1f;
    #endregion

    #region Variables

    #endregion

    #region Function

    #endregion

    #region Gizmos
    void Update()
    {
        if (trigger.Contains(target.position))
        {
            //note: worldspace rotation
            Vector3 vecToTargetgun = target.position - gunTf.position;
            Quaternion TargetRotation = Quaternion.LookRotation(vecToTargetgun, transform.up); 
            gunTf.rotation = Quaternion.Slerp(gunTf.rotation, TargetRotation,smoothingFector*Time.deltaTime);
        }       
    }
    #endregion

}
