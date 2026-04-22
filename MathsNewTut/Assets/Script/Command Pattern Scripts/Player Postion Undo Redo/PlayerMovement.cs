using UnityEngine;

namespace UndoRedo
{
    public class PlayerMovement : MonoBehaviour
    {
        #region Variable

        [Range(0, 5f)] public float playerUpdatePostionY;

        [Range(0, 5f)] public float playerUpdatePostionZ;

        #endregion

        #region Functions

        void Movement()
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position = new Vector3(transform.position.x,
                    transform.position.y + playerUpdatePostionY * Time.deltaTime, transform.position.z);
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.position = new Vector3(transform.position.x,
                    transform.position.y - playerUpdatePostionY * Time.deltaTime, transform.position.z);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.position = new Vector3(transform.position.x,
                    transform.position.y, transform.position.z - playerUpdatePostionZ * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.position = new Vector3(transform.position.x,
                    transform.position.y,transform.position.z + playerUpdatePostionZ * Time.deltaTime);
            }
        }

        #endregion

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            Movement();
        }
    }
}