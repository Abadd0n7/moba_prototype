using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    float speed = 1000.0f;
    //int boundary = 1;
    //int width;
    //int height;
    //float speed2 = 10.0f;
    void Start()
    {
        //width = Screen.width;
        //height = Screen.height;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Input.GetAxis("Mouse X") < 0)
            {
                transform.position -= new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed,
                    0.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed);
            }

            else if (Input.GetAxis("Mouse X") > 0)
            {
                transform.position -= new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed,
                    0.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed);
            }
        }

        //if (Input.mousePosition.x < width - boundary)
        //{
        //    transform.position -= new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed2,
        //        0.0f, 0.0f);
        //}

        //if (Input.mousePosition.x > 0 + boundary)
        //{
        //    transform.position -= new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed2,
        //        0.0f, 0.0f);
        //}

        //if (Input.mousePosition.y < height - boundary)
        //{
        //    transform.position -= new Vector3(0.0f, 0.0f,
        //        Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed2);
        //}

        //if (Input.mousePosition.y > 0 + boundary)
        //{
        //    transform.position -= new Vector3(0.0f, 0.0f,
        //        Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed2);
        //}
    }
}
