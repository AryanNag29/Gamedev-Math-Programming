using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class TurretRotation : MonoBehaviour
{
    #region References
    public Transform target;
    public CheesyScript trigger;
    public Transform gunTf;
    public float smoothingFector = 1f; //t
    Quaternion TargetRotation;
    #endregion

    #region Variables

    #endregion

    #region Function

    #endregion

    #region Update
    void Update()
    {
        float angleDeg = 45f;
        float angleRad = angleDeg * Mathf.Deg2Rad; // 360/6.28
        float againangDeg = angleRad * Mathf.Rad2Deg; //6.28/360
        if (trigger.Contains(target.position))
        {
            //note: worldspace rotation
            Vector3 vecToTargetgun = target.position - gunTf.position;
            TargetRotation = Quaternion.LookRotation(vecToTargetgun, transform.up); 
        }     
            //smoothing rotation towards target using slerp  
            gunTf.rotation = Quaternion.Slerp(gunTf.rotation, TargetRotation,smoothingFector*Time.deltaTime);
    }
    #endregion

}
