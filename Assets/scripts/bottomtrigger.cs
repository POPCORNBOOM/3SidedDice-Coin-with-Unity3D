using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bottomtrigger : MonoBehaviour
{
    double setchecktime;
    public double timer;
    bool removemyself;
    public GameObject gameobj;
    GameObject parent;
    GameObject checktime;

    //GameObject c_standing = GameObject.Find("Canvas/_Standing/c_standing");
    // Start is called before the first frame update
    void Start()
    {
        checktime = GameObject.Find("Canvas/InputBoxes/in_checktime/Text");
        parent = gameobj.transform.parent.gameObject;
        setchecktime = checktime.GetComponent<Text>().text == "" ? 8F : Convert.ToDouble(checktime.GetComponent<Text>().text);
        timer = setchecktime;
        removemyself = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (removemyself && parent != null)
            Destroy(parent, 0);


    }




    public void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Ontrigger!!");
    }

    public void OnTriggerStay(Collider other)
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && removemyself == false)
        {
            GameObject.Find("Canvas/_Bottom/c_bottom").GetComponent<Text>().text = (Convert.ToInt32(GameObject.Find("Canvas/_Bottom/c_bottom").GetComponent<Text>().text) + 1).ToString();
            removemyself = true;
            Destroy(parent, 0);
            Debug.Log(gameObject.name +":"+ other.name + " is bot on");
        }
    }
    public void OnTriggerExit(Collider other)
    {
        timer = setchecktime;
    }

}
