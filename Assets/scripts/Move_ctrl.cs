using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move_ctrl : MonoBehaviour
{
    public GameObject cam;
    public GameObject facing;
    public float speed;
    bool islock = false;
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
            speed = 60;
        else
            speed = 30;

        if (Input.GetKey(KeyCode.W))
            this.transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.A))
            this.transform.Translate(Vector3.left * Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.S))
            this.transform.Translate(Vector3.back * Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.D))
            this.transform.Translate(Vector3.right * Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.Q))
            this.transform.Translate(Vector3.down * Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.E))
            this.transform.Translate(Vector3.up * Time.deltaTime * speed);
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (islock)
            {
                Cursor.lockState = CursorLockMode.None;
                islock=false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                islock = true;
            }

        }
        facing.GetComponent<Text>().text = "충날실똑:" + transform.rotation.eulerAngles.y.ToString();
    }

    public void resetpos()
    {

        transform.position = new Vector3(0, 10, 0);

    }
}
