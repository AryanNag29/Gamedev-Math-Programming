using UnityEngine;

public class NotesCode : MonoBehaviour
{
    Vector3 vLeftOutter;
    // Update is called once per frame
    void Update()
    {
                //this is basically mean this 1y = 90degree
        Quaternion up90 = Quaternion.AngleAxis(90,Vector3.up);
        //euler angles 
        //transform.eulerAngles
        Quaternion VecA = Quaternion.Euler(30,45,90);
        Quaternion VecB = Quaternion.AngleAxis(60,Vector3.up);
        Quaternion rotCombination = VecA * VecB; //combined rotation
        Quaternion.Slerp(VecA,VecB,5f);
        Quaternion rotInverse = Quaternion.Inverse(rotCombination);
        Vector3 rotateVec = rotInverse*vLeftOutter;



          //long method to assign using localtoworld method


        // void OnDrawGizmos()
    // {
    //     //making gizmos relative to localtoworld metrix
    //     Gizmos.matrix = transform.localToWorldMatrix;
    //     Gizmos.color = Handles.color = Contains(target.position) ? Color.red : Color.white;

    //     Vector3 origin = transform.position;
    //     Vector3 up = transform.up;
    //     Vector3 right = transform.right;
    //     Vector3 forward = transform.forward;
    //     Vector3 top = origin + up * height;
    //     Handles.DrawWireDisc(origin, up, outterRadius);
    //     Handles.DrawWireDisc(top, up, outterRadius);

    //     //Drawing the angle
    //     float p = angThresh;
    //     float x = Mathf.Sqrt(1 - p * p);

    //     Vector3 vLeftOutter = (forward * p + right * (-x)) * outterRadius;
    //     Gizmos.DrawRay(origin, vLeftOutter);
    //     Gizmos.DrawRay(top, vLeftOutter);

    //     Vector3 vRightOutter = (forward * p + right * x) * outterRadius;
    //     Gizmos.DrawRay(origin, vRightOutter);
    //     Gizmos.DrawRay(top, vRightOutter);

    //     Gizmos.DrawLine(origin, top);
    //     Gizmos.DrawLine(origin + vLeftOutter, top + vLeftOutter);
    //     Gizmos.DrawLine(origin + vRightOutterOutter, top + vRightOutterOutter);
    //     Gizmos.DrawLine(origin, target.position);
    // }
    }
}
