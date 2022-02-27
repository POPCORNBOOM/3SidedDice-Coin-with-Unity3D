using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCtrl : MonoBehaviour
{

    public void exitapp()
    {
        UnityEngine.Application.Quit();
    }

    public void choosefolder()
    {
        GameObject.Find("Canvas/t_dir").GetComponent<Text>().text = FolderBrowserHelper.GetPathFromWindowsExplorer();
        
    }

    public void resettimescale()
    {
        GameObject.Find("Canvas/Slider").GetComponent<Slider>().value = 1.0F;
    }
}

