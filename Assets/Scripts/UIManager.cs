using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] activeToolInterface = new GameObject[4];

    private bool toolActive;
    public void PickTool(int i)
    {
        //goes through the tool images
        for (int  j = 0; j < activeToolInterface.Length; j++)
        {    //sets the active tool image to i
            toolActive = j == i ? true : false;
            activeToolInterface[j].SetActive(toolActive);
        }
    }
    
}
