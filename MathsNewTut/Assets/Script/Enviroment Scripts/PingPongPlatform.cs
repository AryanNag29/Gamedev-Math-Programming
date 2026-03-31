using System;
using UnityEngine;

public class PingPongPlatform : MonoBehaviour
{
    #region Variables

    public Vector3 movementOffset = new Vector3(0, 0, 0);
    private Vector3 startPos;
    private Vector3 endPos;
    
    [Range(0.1f,2f)]
    public float speed = 0f;

    #endregion


    #region Functions

     private void ChangePosPlatform()
     {
         float platformSpeed = Mathf.PingPong(Time.time * speed, 1f);
         transform.position = Vector3.Lerp(startPos, endPos, platformSpeed);
     }

    #endregion

    #region Start

    private void Start()
    {
        startPos = transform.position;
        endPos = startPos + movementOffset;
    }

    #endregion

    #region Update

    private void Update()
    {
        ChangePosPlatform();
    }

    #endregion
}
