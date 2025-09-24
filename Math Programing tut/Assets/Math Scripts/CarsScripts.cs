using JetBrains.Annotations;
using Unity.InferenceEngine;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class CarsScripts : MonoBehaviour
{
    public Transform enemy;
    public Transform player;
    public float scalpro;
    bool infront = false;
    bool isbehind = false;
    bool isequal = false;
    void OnDrawGizmos()
    {
        Vector3 enemyVec = enemy.position;
        Vector3 playerVec = player.position;

        if (player == null) return;

        float plen = Mathf.Sqrt(playerVec.x*playerVec.x + playerVec.y*playerVec.y + playerVec.z* playerVec.z);
        Vector3 pnrom = playerVec / plen;
        scalpro = Vector3.Dot(pnrom, enemyVec);
        Vector3 vecpro = pnrom * scalpro;

        //condition
        if (scalpro == 0)
        {
            isequal = true;
        }
        else {
            isequal = false;
        }

        if (scalpro > 0)
        {
            infront = true;
        }
        else
        {
            infront = false;
        }

        if (scalpro < 0)
        {
            isbehind = true;
        }
        else
        {
            isbehind = false;
        }


        Gizmos.color = isequal? Color.blue : Color.white;
        Gizmos.color = infront? Color.red : Color.white;
        Gizmos.color = isbehind ? Color.green : Color.white;
        
        //draw circle at scal pro
        Gizmos.DrawSphere(vecpro, 0.2f);

        //draw line from enemy car to vec pro
        Gizmos.DrawLine(vecpro, enemyVec);


    }
}
