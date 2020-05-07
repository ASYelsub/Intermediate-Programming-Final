using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternBehavior : MonoBehaviour
{
    [SerializeField] 
    private Transform lanternTransform;
    [SerializeField] 
    private GameObject lightSource;

    private Vector3 putAwayPos;
    private Vector3 outPos;
    private float percentage;
    
    private bool isPutAway = false; //if false, the lantern is out
    private bool stateChange = false; //if false, the lantern's position is stagnant
    //-1.073 to -1.49
    // Update is called once per frame
    private void Start()
    {
        percentage = 0;
        putAwayPos = new Vector3(-1.49f,lanternTransform.localPosition.y,lanternTransform.localPosition.z);
        outPos = new Vector3(-1.073f,lanternTransform.localPosition.y,lanternTransform.localPosition.z);
        
    }

    void Update()
    {
        if (stateChange)
        {
            if (isPutAway)
            {
                percentage += 1 * Time.deltaTime;
                if (percentage >= 1)
                {
                    stateChange = false;
                    lightSource.SetActive(false);
                }
            }
            else
            {
                percentage -= 1 * Time.deltaTime;
                if (percentage <= 0)
                {
                    stateChange = false;
                    lightSource.SetActive(true);
                }
            }
            lanternTransform.localPosition = Vector3.Lerp(outPos,putAwayPos,percentage);
            print(percentage);
        }

    }

    public void SwitchLightState()
    {
        
        if (!stateChange)
        {
            stateChange = true;
            isPutAway = !isPutAway;
        }
        

    }
}
