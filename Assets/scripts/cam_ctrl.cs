using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cam_ctrl : MonoBehaviour
{
    public Transform player;
    private float mouseX, mouseY;
    public float mouseSens;
    public float xRotation;
    bool islock = false;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            if (islock)
            {
                islock = false;
            }
            else
                islock = true;
        }
        if (islock)
        {
            
            mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            player.Rotate(Vector3.up * mouseX);
            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        }
    }


}
