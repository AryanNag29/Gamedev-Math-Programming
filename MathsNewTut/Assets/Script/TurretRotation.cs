using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class TurretRotation : MonoBehaviour
{
    #region References
    public Transform target;
    public CheesyScript trigger;
    public Transform gunTf;
    public float smoothingFector = 1f; //t of lerp function
    Quaternion TargetRotation;
    #endregion

    #region Variables

    #endregion

    #region Function

    #endregion

    #region Update
    void Update()
    {
        //snell's law using unity plane type
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        Ray ray = default;
        if (plane.Raycast(ray, out float dist))
        {
            Vector3 lightIntersection = ray.GetPoint(dist);
        }


        float angleDeg = 45f;
        float angleRad = angleDeg * Mathf.Deg2Rad; // 360/6.28
        float againangDeg = angleRad * Mathf.Rad2Deg; //6.28/360
        if (trigger.Contains(target.position))
        {
            //note: worldspace rotation
            Vector3 vecToTargetgun = target.position - gunTf.position;
            TargetRotation = Quaternion.LookRotation(vecToTargetgun, transform.up);
        }else{}
        //smoothing rotation towards target using slerp  (make this outsize of condition)
        gunTf.rotation = Quaternion.Slerp(gunTf.rotation, TargetRotation, smoothingFector * Time.deltaTime);
    }
    #endregion

}
