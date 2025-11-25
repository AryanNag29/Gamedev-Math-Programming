using System.Runtime.InteropServices.WindowsRuntime;
using JetBrains.Annotations;
using NUnit.Framework;
using Unity.InferenceEngine;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class CarsScripts : MonoBehaviour
{
    #region GameObject reference

    public Transform enemy;
    public Transform player;

    #endregion

    #region Variables

    public float scalpro;
    bool infront = false;
    bool isbehind = false;
    bool isequal = false;

    #endregion

    #region Gizmos

    void OnDrawGizmos()
    {
        Vector3 enemyVec = enemy.position;
        Vector3 playerVec = player.position;
        

        if (player == null) return;

        float plen = Mathf.Sqrt(playerVec.x * playerVec.x + playerVec.y * playerVec.y + playerVec.z * playerVec.z);
        Vector3 pnrom = playerVec / plen;
        scalpro = Vector3.Dot(pnrom, enemyVec);
        Vector3 vecpro = pnrom * scalpro;

        //condition
        isequal = scalpro == 0 ? true : false;
        infront = scalpro > 0 ? true : false;
        isbehind = scalpro < 0 ? true : false;

        Gizmos.color = isequal ? Color.blue : Color.white;
        Gizmos.color = infront ? Color.red : Color.white;
        Gizmos.color = isbehind ? Color.green : Color.white;

        //draw circle at scal pro
        Gizmos.DrawSphere(vecpro, 0.2f);

        //draw line from enemy car to vec pro
        Gizmos.DrawLine(vecpro, enemyVec);


    }

    #endregion
}
