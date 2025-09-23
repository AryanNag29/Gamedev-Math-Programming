using JetBrains.Annotations;
using Unity.InferenceEngine;
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

        float plen = playerVec.magnitude;
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

        if (isequal)
        {
            Gizmos.color = Color.blue;
        }
        else
        {
            Gizmos.color = Color.white;
        }

        if (infront)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.white;
        }

        if (isbehind)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.white;
        }
        

        //draw circle at scal pro
        Gizmos.DrawSphere(vecpro, 0.2f);

        //draw line from enemy car to vec pro
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(vecpro, enemyVec);


    }
}
